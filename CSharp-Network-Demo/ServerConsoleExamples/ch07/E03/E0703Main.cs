using System.Net.Sockets;
using ServerConsoleExamples.ch07.Common;

namespace ServerConsoleExamples.ch07.E03
{
    internal class E0703Main : Room
    {
        public override GameTable[] PlayingTable { get; set; }  //游戏桌

        public E0703Main()
        {
            PlayingTable = new E0703PlayingTable[maxTables];
            for (int i = 0; i < maxTables; i++)
            {
                PlayingTable[i] = new E0703PlayingTable();
            }
        }

        /// <summary>接收、处理客户端信息，每客户1个线程，参数用于区分是哪个客户</summary>
        public override void ReceiveData(object? obj)
        {
            if (obj == null)
            {
                Console.WriteLine("user为null，已退出ReceiveData线程");
                return;
            }
            User user = (User)obj;
            TcpClient? client = user.Client;
            bool normalExit = false;  //是否正常退出接收线程
            bool exitWhile = false;   //用于控制是否退出循环
            while (exitWhile == false)
            {
                string? receiveStr = null;
                try
                {
                    receiveStr = user.SReader?.ReadLine();
                }
                catch (Exception ex)
                {
                    //该客户底层套接字不存在时会出现异常
                    Console.WriteLine($"接收数据失败：{ex.Message}");

                    //如果该用户正坐在游戏桌上，则退出游戏桌
                    //RemoveCLientFromPlayer(user);
                    RemoveUser(user);
                }

                //关闭TcpClient对象并不能让底层套接字关闭，也不产生异常，但读取的结果为null
                if (receiveStr == null)
                {
                    if (normalExit == false && client != null)
                    {
                        //如果停止了监听，Connected为false
                        if (client.Connected == true)
                        {
                            if (client.Connected == true) //true表示未停止监听
                            {
                                Console.WriteLine($"与{client.Client.RemoteEndPoint}失去联系，已终止接收该用户信息");
                            }
                        }
                        //如果该用户正坐在游戏桌上，则退出游戏桌
                        //RemoveCLientFromPlayer(user);
                        RemoveUser(user);

                        //重新将游戏室各桌情况发送给所有在线用户
                        Service.SendToAll(userList, "Tables," + GetOnlineString());

                    }
                    break;
                }

                //------此句仅用于观察接收的信息，需要观察时可以去掉注释---------------//
                Console.WriteLine($"-----来自{user.UserName}：{receiveStr}");
                //---------------------------------------------------------------------//

                string[] splitString = receiveStr.Split(',');
                int tableIndex = -1;    //桌号
                int side = -1;          //座位号
                int anotherSide = -1;   //对方座位号
                string sendString = "";
                string command = splitString[0].ToLower();
                switch (command)
                {
                    case "login":
                        //该用户刚刚登录(格式：Login,用户名)
                        if (userList.Count > maxUsers)
                        {
                            sendString = "Sorry";
                            Service.SendToOne(user, sendString);
                            Console.WriteLine("人数已满，拒绝" + splitString[1] + "进入游戏室");
                            exitWhile = true;
                        }
                        else
                        {
                            //将用户昵称保存到用户列表中
                            user.UserName = splitString[1];
                            Console.WriteLine( $"{client?.Client.RemoteEndPoint}以【{user.UserName}】为用户名进入游戏室");

                            //将服务器游戏桌数以及已经进入游戏室的总人数发送给该用户
                            //格式：RoomNumbers,房间数
                            Service.SendToOne(user, $"RoomNumbers,{maxTables},{userList.Count}");

                            //将各房间人员情况发送给所有用户
                            sendString = "Tables," + GetOnlineString();
                            Service.SendToAll(userList, sendString);
                            //告诉所有用户有人登录进入游戏室
                            Service.SendToAll(userList, $"Login,{user.UserName}");
                        }
                        break;
                    case "logout":
                        Console.WriteLine($"{user.UserName}退出游戏室");

                        RemoveUser(user);

                        //重新将游戏室各桌情况发送给所有在线用户
                        Service.SendToAll(userList, "Tables," + GetOnlineString());

                        normalExit = true;  //客户端正常退出
                        exitWhile = true;   //停止接收该客户端消息
                        break;
                    case "sitdown":  //该用户坐到某座位上(格式：SitDown，桌号，座位号)
                        tableIndex = int.Parse(splitString[1]);
                        side = int.Parse(splitString[2]);
                        PlayingTable[tableIndex].Player[side].PlayingUser = user;
                        PlayingTable[tableIndex].Player[side].Sitdown = true;
                        if (side == 0)
                        {
                            Console.WriteLine($"{user.UserName}在第{tableIndex + 1}桌黑方入座");
                        }
                        else
                        {
                            Console.WriteLine($"{user.UserName}在第{tableIndex + 1}桌白方入座");

                        }

                        anotherSide = (side + 1) % 2;  //得到对家座位号
                        //判断对方是否有人坐下
                        if (PlayingTable[tableIndex].Player[anotherSide].Sitdown == true)
                        {
                            //先告诉该用户对家已经入座（格式：SitDown，桌号，座位号，用户名）
                            sendString = $"SitDown,{tableIndex},{anotherSide}," +
                                $"{PlayingTable[tableIndex].Player[anotherSide].PlayingUser?.UserName}";
                            Service.SendToOne(user, sendString);
                        }
                        //同时告诉两个用户该用户入座（也可能对方无人）
                        sendString = $"SitDown,{tableIndex},{side},{user.UserName}";
                        Service.SendToBoth(PlayingTable[tableIndex], sendString);
                        //重新将游戏室各桌情况发送给所有用户
                        Service.SendToAll(userList, "Tables," + GetOnlineString());
                        break;
                    case "getup":   //用户离开座位回到游戏室（格式：GetUp，桌号，座位号）
                        tableIndex = int.Parse(splitString[1]);
                        side = int.Parse(splitString[2]);
                        Console.WriteLine($"{user.UserName}离座");
                        //将离座信息同时发送给两个用户，以便客户端作离座处理
                        //发送格式：GetUp，桌号，座位号，用户名
                        Service.SendToBoth(PlayingTable[tableIndex], $"GetUp,{tableIndex},{side},{user.UserName}");
                        //服务器进行离座处理
                        PlayingTable[tableIndex].Player[side].Sitdown = false;
                        PlayingTable[tableIndex].Player[side].Started = false;
                        anotherSide = (side + 1) % 2;
                        if (PlayingTable[tableIndex].Player[anotherSide].Sitdown == true)
                        {
                            PlayingTable[tableIndex].Player[anotherSide].Started = false;
                        }
                        //重新将游戏室各桌情况发送给所有用户
                        Service.SendToAll(userList, "Tables," + GetOnlineString());
                        break;
                    case "talk":
                        //格式：Talk,桌号,对话内容
                        tableIndex = int.Parse(splitString[1]);
                        sendString = string.Format("Talk,{0},{1}", user.UserName,
                            receiveStr.Remove(0,splitString[0].Length + splitString[1].Length));
                        Service.SendToBoth(PlayingTable[tableIndex], sendString);
                        break;
                    case "start":
                        //该用户单击了开始按钮(格式：Start,桌号,座位号)
                        tableIndex = int.Parse(splitString[1]);
                        side = int.Parse(splitString[2]);
                        PlayingTable[tableIndex].Player[side].Started = true;
                        if (side == 0)
                        {
                            anotherSide = 1;
                            sendString = "Message,黑方已开始。";
                        }
                        else
                        {
                            anotherSide = 0;
                            sendString = "Message,白方已开始。";
                        }
                        Service.SendToBoth(PlayingTable[tableIndex], sendString);
                        if (PlayingTable[tableIndex].Player[anotherSide].Started == true)
                        {
                            PlayingTable[tableIndex].ResetGrid();
                            Service.SendToBoth(PlayingTable[tableIndex], "Start," + PlayingTable[tableIndex].NextDotColor);
                        }
                        break;
                    case "setchess":
                        //客户请求放置棋子(格式：SetChess,桌号,座位号,行,列)
                        tableIndex = int.Parse(splitString[1]);
                        side = int.Parse(splitString[2]);
                        int xi = int.Parse(splitString[3]);
                        int xj = int.Parse(splitString[4]);
                        int color = side;
                        PlayingTable[tableIndex].SetDot(xi, xj, color);
                        break;
                    default:
                        Service.SendToAll(userList, "什么意思啊：" + receiveStr);
                        break;
                }
            }
            userList.Remove(user);
            client?.Close();
            Console.WriteLine($"{user.UserName}退出游戏室，剩余连接用户数：{userList.Count}");
        }
    }
}
