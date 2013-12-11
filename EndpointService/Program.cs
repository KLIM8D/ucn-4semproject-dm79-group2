using System;
using EndpointService.SocketServer;

namespace EndpointService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Endpoint for check-in/out backend service" +
                              "\n-----------------------------------------");

            try
            {
                Listener.StartListening();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }
    }
}