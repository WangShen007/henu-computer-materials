using System.Net.Sockets;
using System.Text;

namespace ServerConsoleExamples.ch07.E06
{
    public class E0706User
    {
        public string UserName { get; set; } = "";

        /// <summary>
        /// 指示是否正常退出接收线程
        /// </summary>
        public bool NormalExit { get; set; } = false;

        /// <summary>
        /// 与该用户通信的TCPClient对象
        /// </summary>
        public TcpClient Client { get; set; }

        /// <summary>
        /// 与该用户通信用的StreamReader对象
        /// </summary>
        public StreamReader Sr { get; set; }

        /// <summary>
        /// 与该用户通信用的StreamWriter对象
        /// </summary>
        public StreamWriter Sw { get; set; }

        /// <summary>
        /// 与该用户通信用的NetworkStream对象
        /// </summary>
        public NetworkStream NetworkStream { get; set; }

        public E0706User(TcpClient client)
        {
            this.Client = client;
            NetworkStream = client.GetStream();
            Sr = new StreamReader(NetworkStream, Encoding.UTF8);
            Sw = new StreamWriter(NetworkStream, Encoding.UTF8)
            {
                AutoFlush = true
            };
        }

        public void CloseUser()
        {
            Sr.Close();
            Sw.Close();
            NetworkStream.Close();
            Client.Close();
        }
    }
}
