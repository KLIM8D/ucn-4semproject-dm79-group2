using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using BusinessLogic.Resources;
using Utils.Serialization;

namespace EndpointService.SocketServer
{
    class Listener
    {
        public static ManualResetEvent AllDone = new ManualResetEvent(false);

        public static void StartListening()
        {
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[2]; // change the value to the corresponding nic (usually 2)
            var localEndPoint = new IPEndPoint(ipAddress, 1500);

            var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                Console.WriteLine("Waiting for a connection...");

                while (true)
                {
                    AllDone.Reset();
                    listener.BeginAccept(AcceptCallback, listener);
                    AllDone.WaitOne();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            AllDone.Set();

            var listener = (Socket)ar.AsyncState;
            var handler = listener.EndAccept(ar);

            var state = new StateObject { WorkSocket = handler };

            handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, ReadCallback, state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            var state = (StateObject)ar.AsyncState;
            var handler = state.WorkSocket;

            var bytesRead = handler.EndReceive(ar);

            if (bytesRead <= 0) return;

            using (var stream = new MemoryStream(state.Buffer))
            {
                stream.Position = 0;

                var jsonString = new StreamReader(stream).ReadToEnd();
                var dateTime = ConvertJsonStringToDateTime(jsonString);

                var obj = JsonHelper.DeserializeJson<DataStream>(jsonString, true);
                obj.TimeStamp = dateTime;

                try
                {
                    var userLogic = new UserLogic();
                    var balance = userLogic.GetBalanceByUserId(userLogic.GetUserIdByCardNo(obj.CardId));

                    if (balance >= 20)
                    {
                        new RegisterLogic().InsertTravel(obj);
                        SendStatus(handler, "OK");
                    }
                    else
                    {
                        SendStatus(handler, "FAIL");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Uh oh, spaghettios: " + ex);
                }
            }
        }

        private static void SendStatus(Socket handler, String data)
        {
            var byteData = Encoding.ASCII.GetBytes(data);

            handler.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                var handler = (Socket)ar.AsyncState;

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Uh oh, spaghettios: " + ex);
            }
        }

        public static DateTime ConvertJsonStringToDateTime(string jsonTime)
        {
            if (string.IsNullOrEmpty(jsonTime) || jsonTime.IndexOf("Date", StringComparison.Ordinal) <= -1) 
                return DateTime.Now;

            var milis = jsonTime.Substring(jsonTime.IndexOf("(", StringComparison.Ordinal) + 1);
            milis = milis.Substring(0, milis.IndexOf(")", StringComparison.Ordinal));
            var ret = new DateTime(1970, 1, 1);
            var fuzzyhat = ret.AddSeconds(Convert.ToInt64(milis));

            var zone = TimeZone.CurrentTimeZone;

            return zone.ToLocalTime(fuzzyhat);
        }
    }
}