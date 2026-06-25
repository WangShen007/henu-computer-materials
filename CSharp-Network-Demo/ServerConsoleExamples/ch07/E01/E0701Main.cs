using ServerConsoleExamples.ch07.Common;

namespace ServerConsoleExamples.ch07.E01
{
    internal class E0701Main : Room
    {
        public override GameTable[] PlayingTable { get; set; }  //游戏桌

        public E0701Main()
        {
            PlayingTable = new E0701PlayingTable[maxTables];
            for (int i = 0; i < maxTables; i++)
            {
                PlayingTable[i] = new E0701PlayingTable();
            }
        }

        /// <summary>接收、处理客户端信息，每客户1个线程，参数用于区分是哪个客户</summary>
        public override void ReceiveData(object? obj)
        {
            if (obj == null)
            {
                return;
            }
            User user = (User)obj;
            bool exitWhile = false;   //用于控制是否退出循环
            while (exitWhile == false)
            {
                string? receiveString = null;
                try
                {
                    receiveString = user.SReader?.ReadLine();
                }
                catch (Exception ex)
                {
                    //该客户底层套接字不存在时会出现异常
                    Console.WriteLine($"接收数据失败：{ex.Message}");
                    //移除该用户
                    RemoveUser(user);
                }
                if (receiveString == null)
                {
                    if (user.Client != null)
                    {
                        if (user.Client.Connected == true) //true表示未停止监听
                        {
                            Console.WriteLine($"与{user.Client.Client.RemoteEndPoint}失去联系，已终止接收该用户信息");

                            //发送格式：Lost，座位号，用户名
                            //Service.SendToOne(user1, $"Lost,{j},{user1}");

                        }
                    }
                    userList.Remove(user);
                    //如果该用户正在某游戏桌，则退出游戏桌
                    RemoveUser(user);
                    //重新将游戏室各桌情况发送给所有在线用户
                    Service.SendToAll(userList, "Tables," + GetOnlineString());
                    break;  //退出循环
                }
                Console.WriteLine($"-----来自{user.UserName}：{receiveString}");
                string[] splitString = receiveString.Split(',');
                string command = splitString[0].ToLower();
                switch (command)
                {
                    case "login":  //该用户刚刚登录(格式：Login,用户名)
                        if (userList.Count > maxUsers)
                        {
                            Service.SendToOne(user, "Sorry");
                            Console.WriteLine($"人数已满，拒绝{splitString[1]}进入游戏室");
                            exitWhile = true;
                        }
                        else
                        {
                            //将用户名保存到用户列表中
                            user.UserName = splitString[1];
                            //将各桌是否有人情况发送给该用户
                            Service.SendToOne(user, $"Tables,{GetOnlineString()}");
                        }
                        break;
                    case "logout":  //用户退出游戏室(格式：Logout)
                        Console.WriteLine($"{user.UserName}退出游戏室");
                        //重新将游戏室各桌情况发送给所有在线用户
                        Service.SendToAll(userList, "Tables," + GetOnlineString());
                        exitWhile = true;   //停止接收该客户端消息
                        break;
                    case "sitdown":  //该用户坐到某座位上(格式：SitDown，桌号，座位号)
                        {
                            var tableIndex = int.Parse(splitString[1]);
                            var side = int.Parse(splitString[2]);
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
                            string sendString;
                            var anotherSide = side == 0 ? 1 : 0;  //得到对家座位号
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
                        }
                        break;
                    case "getup":   //用户离开座位回到游戏室（格式：GetUp，桌号，座位号）
                        {
                            var tableIndex = int.Parse(splitString[1]);
                            var side = int.Parse(splitString[2]);
                            Console.WriteLine($"{user.UserName}离座");
                            PlayingTable[tableIndex].Timer1.Stop();
                            //将离座信息同时发送给两个用户，以便客户端作离座处理
                            //发送格式：GetUp，桌号，座位号，用户名
                            Service.SendToBoth(PlayingTable[tableIndex], $"GetUp,{tableIndex},{side},{user.UserName}");
                            //服务器进行离座处理
                            PlayingTable[tableIndex].Player[side].Sitdown = false;
                            PlayingTable[tableIndex].Player[side].Started = false;
                            var anotherSide = (side + 1) % 2;
                            if (PlayingTable[tableIndex].Player[anotherSide].Sitdown == true)
                            {
                                PlayingTable[tableIndex].Player[anotherSide].Started = false;
                            }
                            //重新将游戏室各桌情况发送给所有用户
                            Service.SendToAll(userList, "Tables," + GetOnlineString());
                        }
                        break;
                    case "level":  //设置难度级别（格式：Level，桌号，难度级别）
                        {
                            var tableIndex = int.Parse(splitString[1]);
                            PlayingTable[tableIndex].Timer1.Interval = (6 - int.Parse(splitString[2])) * 400;
                            Service.SendToBoth(PlayingTable[tableIndex], receiveString);
                        }
                        break;
                    case "talk":  //聊天（格式：Talk，桌号，发言内容）
                        {
                            var tableIndex = int.Parse(splitString[1]);
                            //由于说话内容可能包含逗号，所以需要特殊处理
                            var sendString = string.Format("Talk,{0},{1}", user.UserName,
                                receiveString.Remove(0, splitString[0].Length + splitString[1].Length + 2));
                            Service.SendToBoth(PlayingTable[tableIndex], sendString);
                        }
                        break;
                    case "start":  //该用户单击了开始按钮（格式：Start，桌号，座位号）
                        {
                            var tableIndex = int.Parse(splitString[1]);
                            var side = int.Parse(splitString[2]);
                            PlayingTable[tableIndex].Player[side].Started = true;
                            if (side == 0)
                            {
                                Service.SendToBoth(PlayingTable[tableIndex], "Message,黑方已开始。");
                            }
                            else
                            {
                                Service.SendToBoth(PlayingTable[tableIndex], "Message,白方已开始。");
                            }
                            int anotherSide = side == 0 ? 1 : 0;
                            if (PlayingTable[tableIndex].Player[anotherSide].Started == true)
                            {
                                PlayingTable[tableIndex].ResetGrid();
                                PlayingTable[tableIndex].Timer1.Start();
                            }
                        }
                        break;
                    case "unsetdot":  //消去客户单击的棋子
                        {
                            //格式：UnsetDot，桌号，座位号，行，列
                            int tableIndex = int.Parse(splitString[1]);
                            int xi = int.Parse(splitString[3]);
                            int xj = int.Parse(splitString[4]);
                            PlayingTable[tableIndex].UnsetDot(xi, xj);
                        }
                        break;
                    default:
                        Service.SendToAll(userList, "什么意思啊：" + receiveString);
                        break;
                }
            }
            user.Client?.Close();
            userList.Remove(user);
            Console.WriteLine($"有一个用户退出，剩余连接用户数：{userList.Count}");
        }
    }
}