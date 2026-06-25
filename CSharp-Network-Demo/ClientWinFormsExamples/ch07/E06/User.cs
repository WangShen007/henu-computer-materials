using System.Text;
using System.Net.Sockets;

namespace ClientWinFormsExamples.ch07.E06
{
    public class User
    {
        /// <summary>
        /// 指示是否正常退出接收线程
        /// </summary>
        //public bool normalExit { get; set; } = false;

        /// <summary>
        /// 与该用户通信的TCPClient对象
        /// </summary>
        public TcpClient MyClient { get; set; }
        /// <summary>
        /// 与该用户通信用的StreamReader对象
        /// </summary>
        public StreamReader MyReader { get; set; }
        /// <summary>
        /// 与该用户通信用的StreamWriter对象
        /// </summary>
        public StreamWriter MyWriter { get; set; }
        /// <summary>
        /// 与该用户通信用的NetworkStream对象
        /// </summary>
        public NetworkStream MyNetworkStream { get; set; }

        public User(TcpClient client)
        {
            this.MyClient = client;
            MyNetworkStream = client.GetStream();
            MyReader = new StreamReader(MyNetworkStream, Encoding.UTF8);
            MyWriter = new StreamWriter(MyNetworkStream, Encoding.UTF8);
            MyWriter.AutoFlush = true;
        }

        public void CloseUser()
        {
            MyReader.Close();
            MyWriter.Close();
            MyNetworkStream.Close();
            MyClient.Close();
        }
    }
}
