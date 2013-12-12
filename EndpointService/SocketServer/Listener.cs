using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace EndpointService.SocketServer
{
    class Listener
    {
        public static ManualResetEvent AllDone = new ManualResetEvent(false);

        public static void StartListening()
        {
            var ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[2]; // change the value to the corresponding nic (usually 1)
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
                    Console.WriteLine("Something happend!");
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
                var sr = new StreamReader(stream);
                var myStr = sr.ReadToEnd();
                Console.WriteLine(myStr);
            }
        }
    }
}