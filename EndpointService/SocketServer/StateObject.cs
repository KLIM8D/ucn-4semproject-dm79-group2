using System.Net.Sockets;
using System.Text;

namespace EndpointService.SocketServer
{
    class StateObject
    {
        public Socket WorkSocket = null;
        public const int BufferSize = 1024;
        public byte[] Buffer = new byte[BufferSize];
        public StringBuilder Sb = new StringBuilder();
    }
}