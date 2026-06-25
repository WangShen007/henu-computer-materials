using System.Net.Sockets;
using System.Net;

namespace ServerConsoleExamples.ch07.Common
{
    internal abstract class Room
    {
        public abstract GameTable[] PlayingTable { get; set; }  //游戏桌

        public readonly int maxUsers = 50;   //游戏室允许进入的最多人数
        public readonly int maxTables = 20;   //游戏室开出的桌数
        public readonly List<User> userList = new();  //连接的用户
        public readonly IPAddress? localAddress;   //使用的本机IP地址
        public readonly int port = 51888;  //监听端口
        public readonly TcpListener? myListener;

        public Room()
        {
            localAddress = Service.GetIpV4Address();
            if (localAddress != null)
            {
                myListener = new TcpListener(localAddress, port);
                myListener.Start();
                Console.WriteLine($"开始在{localAddress}:{port}监听客户端连接");
                //创建一个线程监听客户端连接请求
                ThreadStart ts = new(ListenClientConnect);
                Thread myThread = new(ts);
                myThread.Start();
            }
            else
            {
                Console.WriteLine("获取IPv4失败，无法通过IPv4监听客户端连接");
            }
        }

        //监听客户端连接
        private void ListenClientConnect()
        {
            while (true)
            {
                if (myListener == null) return;
                TcpClient newClient = new();
                try
                {
                    newClient = myListener.AcceptTcpClient();  //等待用户进入
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"等待用户进入出错：{ex.Message}");
                    Console.WriteLine("已终止接收客户端连接");
                    break;
                }
                User user = new(newClient);
                userList.Add(user);
                Console.WriteLine($"【{newClient.Client.RemoteEndPoint}】进入游戏室");
                Console.WriteLine($"当前连接用户数：{userList.Count}");

                //每接受一个客户端连接，就创建一个对应的线程循环接收该客户端发来的信息
                ParameterizedThreadStart pts = new(ReceiveData);
                Thread threadReceive = new(pts);
                threadReceive.Start(user);
            }
        }

        /// <summary>接收、处理客户端信息，每客户1个线程，参数用于区分是哪个客户</summary>
        public abstract void ReceiveData(object? obj);

        /// <summary>
        /// 循环检测该用户是否坐到某游戏桌上，如果是，将其从游戏桌上移除，并终止该桌游戏
        /// </summary>
        public void RemoveUser(User user)
        {
            for (int i = 0; i < PlayingTable.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (PlayingTable[i].Player[j].PlayingUser != null)
                    {
                        //判断是否同一个对象
                        if (PlayingTable[i].Player[j].PlayingUser == user)
                        {
                            StopPlayer(i, j);
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>停止第i桌游戏（i：桌号，j：座位号）</summary>
        public void StopPlayer(int i, int j)
        {
            PlayingTable[i].Timer1.Stop();
            PlayingTable[i].Player[j].Sitdown = false;
            PlayingTable[i].Player[j].Started = false;
            int otherSide = (j + 1) % 2;
            if (PlayingTable[i].Player[otherSide].Sitdown == true)
            {
                PlayingTable[i].Player[otherSide].Started = false;
                var user1 = PlayingTable[i].Player[otherSide].PlayingUser;
                if (user1 != null && user1.Client != null)
                {
                    if (user1.Client.Connected == true)
                    {
                        //发送格式：Lost，座位号，用户名
                        Service.SendToOne(user1, $"Lost,{j},{user1}");
                    }
                }
            }
        }

        /// <summary>获取每桌是否有人的字符串，0无人，1有人</summary>
        public string GetOnlineString()
        {
            string str = "";
            for (int i = 0; i < PlayingTable.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    str += PlayingTable[i].Player[j].Sitdown == true ? "1" : "0";
                }
            }
            return str;
        }
    }
}
