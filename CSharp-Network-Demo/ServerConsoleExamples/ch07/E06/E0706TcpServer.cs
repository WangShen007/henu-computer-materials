using System.Net.Sockets;
using System.Net;
using System.Drawing;

namespace ServerConsoleExamples.ch07.E06
{
    public class E0706TcpServer
    {
        public IPAddress LocalAddress { get; set; } //本机IP地址
        public int Port { get; } = 51888;//监听端口
        public TcpListener MyListener { get; private set; }

        public bool ExitServerThread { get; set; } = false;

        public List<E0706User> Users { get; } = new List<E0706User>();

        public E0706TcpServer()
        {
            //便于客户端继续上次绘图
            CC.DeserializeObject(CC.BackupFileName);

            IPAddress[] addrIP = Dns.GetHostAddresses(Dns.GetHostName());
            LocalAddress = addrIP[^1];
            MyListener = new TcpListener(LocalAddress, Port);
            MyListener.Start();
            //创建一个线程监听客户端连接请求
            Thread myThread = new(ListenClientConnect);
            myThread.Start();
        }

        private readonly object lockedObj = new();
        private int GetID()
        {
            lock (lockedObj)
            {
                CC.ID++;
            }
            return CC.ID;
        }

        /// <summary>接收客户端连接</summary>
        private void ListenClientConnect()
        {
            while (true)
            {
                TcpClient? newClient = null;
                try
                {
                    newClient = MyListener.AcceptTcpClient();
                }
                catch
                {
                    for (int i = 0; i < Users.Count; i++)
                    {
                        Users[i].NormalExit = true;
                    }
                    break;
                }
                E0706User user = new(newClient);
                Users.Add(user);
                Thread threadReceive = new(ReceiveData);
                threadReceive.Start(user);
            }
            //关闭用户对象，释放其占用的所有资源
            foreach (E0706User myuser in Users)
            {
                myuser.CloseUser();
            }
        }

        /// <summary>接收、处理客户端信息的线程</summary>
        private void ReceiveData(object? obj)
        {
            if (obj == null) return;
            E0706User user = (E0706User)obj;
            while (user.NormalExit == false)
            {
                string? receiveStr;
                try
                {
                    receiveStr = user.Sr.ReadLine();
                }
                catch(Exception err)
                {
                    Console.WriteLine($"与{user.UserName}失去联系，已终止接收该用户信息：{err.Message}");
                    break;
                }
                if (receiveStr == null)
                {
                    break;
                }
                Console.WriteLine($"服务器收到：{receiveStr}");
                string[] splitString = receiveStr.Split(',');
                switch (splitString[0])
                {
                    case "Login": //该用户刚刚登录。格式：Login 用户名
                        {
                            user.UserName = splitString[1];
                            try
                            {
                                byte[] bytes = CC.Serialize(CC.MyGraphicsList)!;
                                SendToOne(user, "WelcomeLogin," + bytes.Length);
                                SendToOne(user, bytes);


                                SendToAllUser("UserCount," + Users.Count);
                            }
                            catch (Exception err)
                            {
                                Console.WriteLine("Login序列化失败，原因：" + err);
                            }
                        }
                        break;
                    case "GetID":
                        SendToOne(user, "ID," + GetID());
                        break;
                    case "Logout"://用户退出
                        Console.WriteLine($"{user.UserName}退出");
                        Users.Remove(user);
                        SendToAllUser("Logout," + Users.Count);
                        user.NormalExit = true;
                        break;
                    case "DrawMyImage"://格式：DrawMyImage，序列化后的字节数
                        {
                            int count = int.Parse(splitString[1]);
                            byte[]? bytes = ReceiveBytesFromUser(user, count);
                            if (bytes != null)
                            {
                                DrawImage(bytes);
                                SendToAllUser(receiveStr);
                                SendToAllUser(bytes);
                            }
                        }
                        break;
                    case "ContinueLastDraw"://格式：ContinueLastDraw，序列化后的字节数
                        {
                            int count = int.Parse(splitString[1]);
                            byte[]? bytes = ReceiveBytesFromUser(user, count);
                            if (bytes != null)
                            {
                                SendToAllUser(receiveStr);
                                SendToAllUser(bytes);
                            }
                        }
                        break;
                    default:
                        DataProcessing(receiveStr);
                        SendToAllUser(receiveStr);
                        break;
                }
            }
            user.CloseUser();
        }

        private static void DataProcessing(string receiveString)
        {
            string[] splitStr = receiveString.Split(',');
            string command = splitStr[0];
            string s = receiveString.Remove(0, command.Length+1);
            string[] paramArr = s.Split(',');

            int x, y, w, h, id, index, lineWidth;
            string text, idStr, xStr, yStr;
            Color color;
            switch (command)
            {
                //刪除对象ID集合
                case "DeleteObjects":
                    //string[] ids = splitStr[1].Split('@');
                    string[] ids = paramArr[0].Split('@');
                    for (int i = 0; i < ids.Length; i++)
                    {
                        CC.MyGraphicsList.Remove(int.Parse(ids[i]));
                    }
                    break;
                case "MoveObject":
                    //x,y,移动的对象ID集合,ipEndpoint
                    index = 0;
                    x = int.Parse(paramArr[index++]);
                    y = int.Parse(paramArr[index++]);
                    idStr = paramArr[index++];

                    MoveObject(x, y, idStr);
                    break;
                case "MoveObjectHandle":
                    //左上角x坐标，左上角y坐标,一到多个对象的ID字符串,ipEndPoint
                    index = 0;
                    x = int.Parse(paramArr[index++]);
                    y = int.Parse(paramArr[index++]);
                    idStr = paramArr[index++];

                    MoveObjectHandle(x, y, idStr);
                    break;
                case "DrawMyText":
                    //x1，y1,x2,y2,旋转角度,文字内容,颜色,文字高,ID
                    index = 0;
                    x = int.Parse(paramArr[index++]);
                    y = int.Parse(paramArr[index++]);
                    Point p1 = new(x, y);
                    x = int.Parse(paramArr[index++]);
                    y = int.Parse(paramArr[index++]);
                    Point p2 = new(x, y);
                    float angle = float.Parse(paramArr[index++]);
                    text = paramArr[index++];
                    color = Color.FromArgb(int.Parse(paramArr[index++]));
                    int fontHeight = int.Parse(paramArr[index++]);
                    id = int.Parse(paramArr[index++]);
                    DrawMyText(p1, p2, angle, text, color, fontHeight, id);
                    break;
                case "DrawMyRectangle":
                    //左上角x坐标，左上角y坐标,宽,高,颜色,ID
                    index = 0;
                    x = int.Parse(paramArr[index++]);
                    y = int.Parse(paramArr[index++]);
                    w = int.Parse(paramArr[index++]);
                    h = int.Parse(paramArr[index++]);
                    color = Color.FromArgb(int.Parse(paramArr[index++]));
                    id = int.Parse(paramArr[index++]);
                    DrawMyRectangle(x, y, w, h, color, id);
                    break;
                case "DrawMyEllipse":
                    //外接矩形左上角x坐标，左上角y坐标,宽,高,颜色,ID
                    index = 0;
                    x = int.Parse(paramArr[index++]);
                    y = int.Parse(paramArr[index++]);
                    w = int.Parse(paramArr[index++]);
                    h = int.Parse(paramArr[index++]);
                    color = Color.FromArgb(int.Parse(paramArr[index++]));
                    id = int.Parse(paramArr[index++]);
                    DrawMyEllipse(x, y, w, h, color, id);
                    break;
                case "DrawMyCurve":
                    //x点数,y点数,线条宽度,线条颜色,ID
                    index = 0;
                    xStr = paramArr[index++];
                    yStr = paramArr[index++];
                    lineWidth = int.Parse(paramArr[index++]);
                    color = Color.FromArgb(int.Parse(paramArr[index++]));
                    id = int.Parse(paramArr[index++]);
                    DrawMyCurve(xStr, yStr, lineWidth, color, id);
                    break;
                case "DrawMyArrowCurve":
                    //x点数,y点数,线条宽度,线条颜色,ID
                    index = 0;
                    xStr = paramArr[index++];
                    yStr = paramArr[index++];
                    lineWidth = int.Parse(paramArr[index++]);
                    color = Color.FromArgb(int.Parse(paramArr[index++]));
                    id = int.Parse(paramArr[index++]);
                    DrawMyArrowCurve(xStr, yStr, lineWidth, color, id);
                    break;
                default:
                    Console.WriteLine("什么意思啊：" + receiveString);
                    break;
            }
        }

        private static void DrawImage(byte[] bytes)
        {
            try
            {
                GraphicsList myGraphicsList = CC.Deserialize<GraphicsList>(bytes)!;
                DrawImage w = (DrawImage)myGraphicsList[0]!;
                CC.MyGraphicsList.Add(w);
            }
            catch (Exception err)
            {
                Console.WriteLine($"反序列化图片失败，原因：{err.Message}");
            }
        }


        /// <summary>无箭头曲线，参数：x点数,y点数,线条宽度,线条颜色,ID</summary>
        private static void DrawMyCurve(string xString, string yString, int width, Color color, int id)
        {
            List<Point> list = GetPointList(xString, yString);
            DrawCurve w = new(list, color, width, id);
            CC.MyGraphicsList.Add(w);
        }

        /// <summary>箭头曲线，参数：x点数,y点数,线条宽度,线条颜色,ID</summary>
        private static void DrawMyArrowCurve(string xString, string yString, int width, Color color, int id)
        {
            List<Point> list = GetPointList(xString, yString);
            DrawArrowCurve w = new(list, color, width, id);
            CC.MyGraphicsList.Add(w);
        }

        /// <summary>曲线命令点集获取/summary>
        private static List<Point> GetPointList(string xString, string yString)
        {
            string[] xArray = xString.Split('@');
            string[] yArray = yString.Split('@');
            List<Point> list = new();
            for (int i = 0; i < xArray.Length; i++)
            {
                list.Add(new Point(int.Parse(xArray[i]), int.Parse(yArray[i])));
            }
            return list;
        }


        /// <summary>矩形,参数：左上角x坐标，左上角y坐标,宽,高,颜色,ID</summary>
        private static void DrawMyRectangle(int x, int y, int width, int height, Color color, int id)
        {
            DrawRectangle w = new(x, y, width, height, color, id);
            CC.MyGraphicsList.Add(w);
        }

        /// <summary>椭圆,参数：左上角x坐标，左上角y坐标,宽,高,颜色,ID</summary>
        private static void DrawMyEllipse(int x, int y, int width, int height, Color color, int id)
        {
            DrawEllipse w = new(x, y, width, height, color, id);
            CC.MyGraphicsList.Add(w);
        }

        /// <summary>文字,参数：左上角顶点，右上角顶点,角度,文字内容,颜色,文字大小,id</summary>
        private static void DrawMyText(Point p1, Point p2, float angle, string text, Color color, int fontHeight, int id)
        {
            DrawText w = new(p1, p2, angle, text, color, fontHeight, id);
            CC.MyGraphicsList.Add(w);
        }

        /// <summary>移动图形对象到指定位置,参数：x方向移动分量、y方向移动分量，待移动对象的ID</summary>
        public static void MoveObject(int dx, int dy, string idStr)
        {
            string[] ids = idStr.Split('@');
            for (int i = 0; i < ids.Length; i++)
            {
                int index = FindObjectIndex(int.Parse(ids[i]));
                if (index != -1)
                {
                    DrawObject w = CC.MyGraphicsList[index]!;
                    w.Move(dx, dy);
                }
            }
        }

        /// <summary>移动对象手柄到指定位置,参数：左上角x坐标,左上角y坐标,对象的ID和句柄号</summary>
        public static void MoveObjectHandle(int x, int y, string idString)
        {
            string[] s = idString.Split('@');
            int id = int.Parse(s[0]);
            int handleNumber = int.Parse(s[1]);
            int index = FindObjectIndex(id);
            if (index != -1)
            {
                DrawObject w = CC.MyGraphicsList[index]!;
                w.MoveHandleTo(new Point(x, y), handleNumber);
            }
        }

        /// <summary>找对应对象的id,如果找不到，返回-1，否则返回该对象的序号</summary>
        public static int FindObjectIndex(int ID)
        {
            int index = -1;
            for (int i = 0; i < CC.MyGraphicsList.Count; i++)
            {
                if (CC.MyGraphicsList[i]!.ID == ID)//【!】表示不对其进行null检查
                {
                    index = i;
                    break;
                }
            }
            return index;

        }

        /// <summary>向所有客户端发送字符串</summary>
        public static void SendToAllUser(string str)
        {
            foreach (E0706User user in CC.Server!.Users)
            {
                SendToOne(user, str);
            }
        }

        /// <summary>向所有客户端发送字节数组</summary>
        public void SendToAllUser(byte[] bytes)
        {
            foreach (E0706User user in Users)
            {
                SendToOne(user, bytes);
            }
        }

        /// <summary>向指定客户端发送字节数组</summary>
        public static void SendToOne(E0706User user, byte[] bytes)
        {
            try
            {
                int size = user.Client.SendBufferSize;
                int dataleft = bytes.Length;
                int start = 0;
                while (dataleft > 0)
                {
                    if (dataleft < size)
                    {
                        size = dataleft;
                    }
                    user.NetworkStream.Write(bytes, start, size);
                    start += size;
                    dataleft -= size;
                }
                Console.WriteLine($"服务器向{user.UserName}发送{bytes.Length}个字节的数据");
            }
            catch (Exception err)
            {
                Console.WriteLine("服务器发送信息失败，原因：{0}", err.Message);
            }
        }

        /// <summary>向指定客户端发送字符串</summary>
        public static void SendToOne(E0706User user, string str)
        {
            try
            {
                user.Sw.WriteLine(str);
                user.Sw.Flush();
                Console.WriteLine($"服务器向{user.UserName}发送{str}");
            }
            catch (Exception err)
            {
                Console.WriteLine($"服务器向{user.UserName}发送信息失败，原因：{err.Message}");
            }
        }

        /// <summary>接收count个字节的数据，返回字节数组</summary>
        private static byte[]? ReceiveBytesFromUser(E0706User user, int count)
        {
            byte[] bytes = new byte[count];
            int dataleft = bytes.Length;
            int start = 0;
            int size = user.Client.ReceiveBufferSize;
            try
            {
                while (dataleft > 0)
                {
                    if (dataleft < size)
                    {
                        size = dataleft;
                    }
                    int recv = user.NetworkStream.Read(bytes, start, size);
                    start += recv;
                    dataleft -= recv;
                }
                Console.WriteLine($"服务器成功接收{user.UserName}发来的{bytes.Length}个字节数据。");
                return bytes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"接收来自{user.UserName}的字节数据失败，原因：{ex.Message}");
                return null;
            }
        }
    }
}
