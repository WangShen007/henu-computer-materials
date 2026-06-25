using System.Net.Sockets;
using System.Text;

namespace ServerConsoleExamples.ch07.Common
{
    public class User
    {
        public TcpClient? Client { get; private set; }

        public StreamReader? SReader { get; private set; }
        public StreamWriter? SWriter { get; private set; }
        public string UserName { get; set; } = string.Empty;

        public User(TcpClient? client)
        {
            Client = client;
            if (client != null)
            {
                NetworkStream netStream = client.GetStream();
                SReader = new StreamReader(netStream, Encoding.UTF8);
                SWriter = new StreamWriter(netStream, Encoding.UTF8);
            }
        }
    }
}
