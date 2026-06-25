using System.Text;
using System.Net.Sockets;
using System.Diagnostics;

namespace ClientWinFormsExamples.ch07.E06
{
    //封装信息
    public class MyTcpClient
    {
        public Label? LabelStatus { get; set; }

        public TcpClient Client { get; set; }
        public StreamWriter? Sw { get; set; }
        public StreamReader? Sr { get; set; }
        public NetworkStream NetworkStream { get; set; }

        /// <summary>是否正常退出接收线程</summary>
        public bool normalExit = false;

        private readonly E0706DrawForm fm;

        public MyTcpClient(TcpClient client, E0706DrawForm fm)
        {
            this.Client = client;
            this.fm = fm;
            NetworkStream = client.GetStream();
            Sr = new StreamReader(NetworkStream, Encoding.UTF8);
            Sw = new StreamWriter(NetworkStream, Encoding.UTF8)
            {
                AutoFlush = true
            };
            Thread threadReceive = new(ReceiveData)
            {
                IsBackground = true
            };
            threadReceive.Start();
        }

        private bool finishGetNewID = false;
        public bool FinishGetNewID
        {
            get { return finishGetNewID; }
        }

        private void ReceiveData()
        {
            while (normalExit == false)
            {
                string? receiveString = null;
                try
                {
                    if (Sr != null)
                    {
                        receiveString = Sr.ReadLine();
                    }
                }
                catch
                {
                    Debug.Print("MyTcpClient:接收receiveString数据失败");
                    break;
                }
                if (receiveString == null)
                {
                    if (normalExit == false)
                    {
                        AddInfo("与服务器失去联系，窗体关闭时数据自动存储本机！");
                    }
                    break;
                }
                Debug.Print("收到：{0}", receiveString);
                string[] splitString = receiveString.Split(',');
                switch (splitString[0])
                {
                    case "ID":
                        fm.UC1.ID = int.Parse(splitString[1]);
                        finishGetNewID = true;
                        break;
                    case "ServerExit":
                        normalExit = true;
                        AddInfo("服务器退出，窗体关闭时数据自动存储本机！");
                        break;
                    case "UserCount":
                        AddInfo("用户数：" + splitString[1]);
                        break;
                    case "WelcomeLogin":
                        {
                            //格式：WelcomeLogin，字节数
                            byte[]? bytes = ReceiveBytesFromServer(int.Parse(splitString[1]));
                            try
                            {
                                GraphicsList? v = CC.Deserialize<GraphicsList>(bytes);
                                if (v != null)
                                {
                                    fm.UC1.Graphics = v;
                                    RefreshUC1();
                                    Debug.Print($"WelcomeLogin反序列化成功。");
                                }
                                else
                                {
                                    Debug.Print($"WelcomeLogin反序列化结果为null。");
                                }
                            }
                            catch (Exception err)
                            {
                                Debug.Print($"WelcomeLogin反序列化失败，原因： {err.Message}");
                                break;
                            }
                        }
                        break;
                    case "Logout":
                        {
                            AddInfo("用户数：" + splitString[1]);
                            Debug.Print(receiveString);
                        }
                        break;
                    case "DrawMyImage":
                        {
                            //格式：DrawMyImage，序列化后的字节数
                            int count = int.Parse(splitString[1]);
                            byte[] bytes = ReceiveBytesFromServer(count);
                            try
                            {
                                GraphicsList? myGraphicsList = CC.Deserialize<GraphicsList>(bytes);
                                if (myGraphicsList != null)
                                {
                                    DrawImage w = (DrawImage)myGraphicsList[0]!;
                                    w.Selected = false;
                                    fm.UC1.Graphics?.Add(w);
                                    myGraphicsList.Clear();
                                }
                                RefreshUC1();
                            }
                            catch (Exception err)
                            {
                                Debug.Print("反序列化图片失败，原因： {0}", err.Message);
                            }
                        }
                        break;
                    case "DeleteObjects":
                        {
                            string[] str = splitString[1].Split('@');
                            for (int i = 0; i < str.Length; i++)
                            {
                                fm.UC1.Graphics?.Remove(int.Parse(str[i]));
                            }
                            RefreshUC1();
                        }
                        break;
                    default:
                        DataProcessing(receiveString);
                        break;
                }
            }
        }
        private void DataProcessing(string receiveString)
        {
            string[] splitStr = receiveString.Split(',');
            int x, y, index, lineWidth, h, w, id;
            string text, idStr, xStr, yStr;
            Color lineColor;
            string IPEndPointString;
            switch (splitStr[0])
            {
                case "MoveObject":
                    //x,y,移动的对象ID集合,IPEndPoint
                    index = 1;
                    x = int.Parse(splitStr[index++]);
                    y = int.Parse(splitStr[index++]);
                    idStr = splitStr[index++];
                    IPEndPointString = splitStr[index++];
                    if (fm.MyClient != null)
                    {
                        if (IPEndPointString != fm.MyClient.Client.Client.LocalEndPoint?.ToString())
                        {
                            MoveObject(x, y, idStr);
                        }
                    }
                    break;
                case "MoveObjectHandle":
                    //左上角x坐标，左上角y坐标,一到多个对象的ID字符串,IPEndPoint
                    index = 1;
                    x = int.Parse(splitStr[index++]);
                    y = int.Parse(splitStr[index++]);
                    idStr = splitStr[index++];
                    IPEndPointString = splitStr[index++];
                    if (fm.MyClient != null)
                    {
                        if (IPEndPointString != fm.MyClient.Client.Client.LocalEndPoint?.ToString())
                        {
                            MoveObjectHandle(x, y, idStr);
                        }
                    }
                    break;
                case "DrawMyText":
                    //x1，y1,x2,y2,旋转角度,文字内容,颜色,文字高,ID
                    index = 1;
                    x = int.Parse(splitStr[index++]);
                    y = int.Parse(splitStr[index++]);
                    Point p1 = new(x, y);
                    x = int.Parse(splitStr[index++]);
                    y = int.Parse(splitStr[index++]);
                    Point p2 = new(x, y);
                    float angle = float.Parse(splitStr[index++]);
                    text = splitStr[index++];
                    lineColor = Color.FromArgb(int.Parse(splitStr[index++]));
                    int fontHeight = int.Parse(splitStr[index++]);
                    id = int.Parse(splitStr[index++]);
                    DrawMyText(p1, p2, angle, text, lineColor, fontHeight, id);
                    break;
                case "DrawMyRectangle":
                    //左上角x坐标，左上角y坐标,宽,高,颜色,ID
                    index = 1;
                    x = int.Parse(splitStr[index++]);
                    y = int.Parse(splitStr[index++]);
                    w = int.Parse(splitStr[index++]);
                    h = int.Parse(splitStr[index++]);
                    lineColor = Color.FromArgb(int.Parse(splitStr[index++]));
                    id = int.Parse(splitStr[index++]);
                    DrawMyRectangle(x, y, w, h, lineColor, id);
                    break;
                case "DrawMyEllipse":
                    //左上角x坐标，左上角y坐标,宽,高,颜色,ID
                    index = 1;
                    x = int.Parse(splitStr[index++]);
                    y = int.Parse(splitStr[index++]);
                    w = int.Parse(splitStr[index++]);
                    h = int.Parse(splitStr[index++]);
                    lineColor = Color.FromArgb(int.Parse(splitStr[index++]));
                    id = int.Parse(splitStr[index++]);
                    DrawMyEllipse(x, y, w, h, lineColor, id);
                    break;
                case "DrawMyCurve":
                    //x点数,y点数,线条宽度,线条颜色,ID
                    index = 1;
                    xStr = splitStr[index++];
                    yStr = splitStr[index++];
                    lineWidth = int.Parse(splitStr[index++]);
                    lineColor = Color.FromArgb(int.Parse(splitStr[index++]));
                    id = int.Parse(splitStr[index++]);
                    DrawMyCurve(xStr, yStr, lineWidth, lineColor, id);
                    break;
                case "DrawMyArrowCurve":
                    //x点数,y点数,线条宽度,线条颜色,ID
                    index = 1;
                    xStr = splitStr[index++];
                    yStr = splitStr[index++];
                    lineWidth = int.Parse(splitStr[index++]);
                    lineColor = Color.FromArgb(int.Parse(splitStr[index++]));
                    id = int.Parse(splitStr[index++]);
                    DrawMyArrowCurve(xStr, yStr, lineWidth, lineColor, id);
                    break;
                default:
                    Debug.Print("什么意思啊：" + receiveString);
                    break;
            }
        }

        #region 绘制
        /// <summary>画无箭头曲线，参数：x点数,y点数,线条宽度,线条颜色,ID</summary>
        private void DrawMyCurve(string xString, string yString, int width, Color color, int id)
        {
            List<Point> list = GetPointList(xString, yString);
            DrawCurve w = new(fm, list, width, color, id);
            fm.UC1.Graphics!.Add(w);
            w.Selected = false;
            RefreshUC1();
        }

        /// <summary>画箭头曲线，参数：x点数,y点数,线条宽度,线条颜色,ID</summary>
        private void DrawMyArrowCurve(string xString, string yString, int width, Color color, int id)
        {
            List<Point> list = GetPointList(xString, yString);
            DrawArrowCurve w = new(fm, list, width, color, id);
            fm.UC1.Graphics!.Add(w);
            w.Selected = false;
            RefreshUC1();
        }

        /// <summary>曲线，参数：x点数,y点数</summary>
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

        /// <summary>画矩形,参数：左上角x坐标，左上角y坐标,宽,高,颜色,ID</summary>
        private void DrawMyRectangle(int x, int y, int width, int height, Color color, int id)
        {
            DrawRectangle w = new(fm, x, y, width, height, color, id);
            fm.UC1.Graphics!.Add(w);
            w.Selected = false;
            RefreshUC1();
        }

        /// <summary>画椭圆,参数：左上角x坐标，左上角y坐标,宽,高,颜色,ID</summary>
        private void DrawMyEllipse(int x, int y, int width, int height, Color color, int id)
        {
            DrawEllipse w = new(fm, x, y, width, height, color, id);
            fm.UC1.Graphics!.Add(w);
            w.Selected = false;
            RefreshUC1();
        }

        /// <summary>画文字,参数：左上角顶点，右上角顶点,角度,文字内容,颜色,文字大小,ID</summary>
        private void DrawMyText(Point p1, Point p2, float angle, string text, Color color, int fontHeight, int id)
        {
            DrawText w = new(fm, p1, p2, angle, text, color, fontHeight, id);
            fm.UC1.Graphics!.Add(w);
            w.Selected = false;
            RefreshUC1();
        }

        /// <summary>移动图形对象到指定位置,参数：层号,左上角x坐标,左上角y坐标,对象的ID</summary>
        public void MoveObject(int dx, int dy, string idString)
        {
            string[] ids = idString.Split('@');
            for (int i = 0; i < ids.Length; i++)
            {
                int index = fm.UC1.FindObjectIndex(int.Parse(ids[i]));
                if (index != -1)
                {
                    DrawObject w = fm.UC1.Graphics![index]!;
                    w.Move(dx, dy);
                    w.Selected = false;
                    RefreshUC1();
                }
            }
        }
        /// <summary>移动对象手柄到指定位置,参数：左上角x坐标,左上角y坐标,对象的ID和句柄号</summary>
        public void MoveObjectHandle(int x, int y, string idString)
        {
            string[] s = idString.Split('@');
            int id = int.Parse(s[0]);
            int handleNumber = int.Parse(s[1]);
            int index = fm.UC1.FindObjectIndex(id);
            if (index != -1)
            {
                DrawObject w = fm.UC1.Graphics![index]!;
                w.MoveHandleTo(new Point(x, y), handleNumber);
                w.Selected = false;
                RefreshUC1();
            }
        }

        public void RefreshUC1()
        {
            if (fm.UC1.InvokeRequired == true)
            {
                fm.UC1.Invoke(RefreshUC1);
            }
            else
            {
                fm.UC1.Capture = false;
                fm.UC1.Refresh();
            }
        }

        /// <summary>获取新ID，注意此方法不能放在静态实例中</summary>
        public void SetNewID()
        {
            if (fm == null) return;
            if (fm.MyClient == null) return;

            Cursor cursor = fm.UC1.Cursor;
            ShowWaitCursor(Cursors.WaitCursor);
            SendToServer("GetID");
            int n = Environment.TickCount;
            while (true)
            {
                if (FinishGetNewID == false)
                {
                    if (Environment.TickCount - n < 1000)  //最多等待1秒
                    {
                        Thread.Sleep(20);
                    }
                    else
                    {
                        AddInfo("向服务器申请ID超时，请检查网络连接。");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            ShowWaitCursor(cursor);
        }

        private void ShowWaitCursor(Cursor cursor)
        {
            if (fm.UC1.InvokeRequired)
            {
                fm.UC1.Invoke(ShowWaitCursor, cursor);
            }
            else
            {
                fm.UC1.Cursor = cursor;
            }
        }

        public void AddInfo(string strMsg)
        {
            if (LabelStatus?.InvokeRequired == true)
            {
                LabelStatus.Invoke(AddInfo, strMsg);
            }
            else
            {
                LabelStatus!.Text = strMsg;
            }
        }

        #endregion

        /// <summary>发送字符串</summary>
        public void SendToServer(string str)
        {
            if (str == "GetID")
            {
                finishGetNewID = false;
            }
            try
            {
                if (Sw != null)
                {
                    Sw.WriteLine(str);
                    Sw.Flush();
                }
            }
            catch (Exception err)
            {
                Debug.Print("向服务器发送数据失败：{0}", err);
            }
        }

        /// <summary>发送字节数据</summary>
        public void SendToServer(byte[] bytes)
        {
            try
            {
                int size = Client.SendBufferSize;
                int dataleft = bytes.Length;
                int start = 0;
                while (dataleft > 0)
                {
                    if (dataleft < size)
                    {
                        size = dataleft;
                    }
                    NetworkStream.Write(bytes, start, size);
                    start += size;
                    dataleft -= size;
                }
                Debug.Print("发送字节{0}成功", bytes.Length);
            }
            catch (Exception err)
            {
                Debug.Print("向服务器发送数据失败：{0}", err);
            }
        }

        /// <summary>接收字节数组并处理接收的内容。count：字节个数</summary>
        public byte[] ReceiveBytesFromServer(int count)
        {
            byte[] bytes = new byte[count];
            int size = Client.ReceiveBufferSize;
            int dataleft = bytes.Length;
            int start = 0;
            try
            {
                while (dataleft > 0)
                {
                    if (dataleft < size)
                    {
                        size = dataleft;
                    }
                    int recv = NetworkStream.Read(bytes, start, size);
                    start += recv;
                    dataleft -= recv;
                }
            }
            catch (Exception err)
            {
                Debug.Print("从服务器读取数据失败：{0}", err);

            }
            Debug.Print("客户端收到{0}字节的数据", bytes.Length);
            return bytes;
        }
    }
}
