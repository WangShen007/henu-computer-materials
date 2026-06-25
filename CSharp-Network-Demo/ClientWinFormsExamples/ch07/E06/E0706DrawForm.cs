using System.Diagnostics;
using System.Net;
using System.Net.Sockets;

namespace ClientWinFormsExamples.ch07.E06
{
    public partial class E0706DrawForm : Form
    {
        public PanelUC UC1 { get; private set; }

        /// <summary>用于判断焦点的形状（是否为句柄）</summary>
        public bool IsToolPoint { get; set; }

        public string UserName { get; private set; }

        private readonly string backupFileName;

        public MyTcpClient? MyClient { get; private set; }

        public TextInfo TextInfo { get; private set; }

        /// <summary>临时保存选择的图像</summary>
        public byte[]? Imagesbytes { get; set; }

        public E0706DrawForm(string userName)
        {
            InitializeComponent();

            UserName = userName;
            labelUserName.Text = userName;

            backupFileName = $"{Application.StartupPath}\\{userName}backup.gcs";

            UC1 = uc1;
            //初始化绘图工具数组
            uc1.Tools = new ToolObject[Enum.GetNames(typeof(ToolType)).Length];
            uc1.Tools[(int)ToolType.Pointer] = new ToolPointer(this);
            uc1.Tools[(int)ToolType.Rectangle] = new ToolRectangle(this);
            uc1.Tools[(int)ToolType.Ellipse] = new ToolEllipse(this);
            uc1.Tools[(int)ToolType.Text] = new ToolText(this);
            uc1.Tools[(int)ToolType.Curve] = new ToolCurve(this);
            uc1.Tools[(int)ToolType.ArrowCurve] = new ToolArrowCurve(this);
            uc1.Tools[(int)ToolType.Image] = new ToolImage(this);
            uc1.ActiveTool = ToolType.Pointer;
            uc1.MyClient = MyClient;
            uc1.MouseDown += Uc1_MouseDown;

            textBoxServer.Text = Dns.GetHostAddresses(Dns.GetHostName())[^1].ToString();
            panelDraw.Visible = false;

            TextInfo = new TextInfo();

            //绘制类型
            foreach (var r in groupBox1.Controls)
            {
                RadioButton r1 = (RadioButton)r;
                r1.Click += RadioButtonDrawType_Click;
            }

            buttonOK.Click += ButtonOK_Click;
            buttonSave.Click += ButtonSave_Click;
            FormClosing += E0706DrawForm_FormClosing;
        }

        /// <summary>确定按钮处理 </summary>
        private void ButtonOK_Click(object? sender, EventArgs e)
        {
            labelStatus.Text = "正在连接服务器，请稍等……";
            IPEndPoint ipe = new(IPAddress.Parse(textBoxServer.Text), 51888);
            TcpClient tcpclient = new();
            try
            {
                tcpclient.Connect(ipe);
            }
            catch
            {
                labelStatus.Text = "与服务器连接失败，请查看“" + textBoxServer.Text + "”是否运行服务端！";
                return;
            }
            MyClient = new MyTcpClient(tcpclient, this)
            {
                LabelStatus = this.labelStatus,
            };
            panelServerIP.Enabled = false;
            panelDraw.Visible = true;

            //格式：Login,用户名
            MyClient.SendToServer($"Login,{UserName}");
            buttonOK.Enabled = false;
            labelStatus.Text = "提示：按住鼠标左键拖动鼠标绘制，鼠标右击停止绘制进入框选状态。框选状态下可修改、移动、删除对象。";
        }

        //导出图片
        private void ButtonSave_Click(object? sender, EventArgs e)
        {
            Bitmap myBitmap = DrawImage();
            string fileName = Application.StartupPath + "\\myDraw.jpg";
            myBitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show($"导出位置：{fileName}", "导出成功");
        }
        private Bitmap DrawImage()
        {
            Bitmap myBitmap = new(UC1.Width, UC1.Height);
            if (UC1.Graphics == null)
            {
                return myBitmap;
            }
            Graphics g = Graphics.FromImage(myBitmap);
            g.Clear(Color.White);
            UC1.Graphics.Draw(g);
            Pen p = new(Color.Black, 1f);
            Rectangle myRectangle = new(1, 1, UC1.Width - 2, UC1.Height - 2);
            g.DrawRectangle(p, myRectangle);
            p.Dispose();
            return myBitmap;
        }

        /// <summary>鼠标按下处理事件</summary>
        private void Uc1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rbPointer.Checked = true;
            }
        }
        /// <summary>关闭窗体保存制作信息</summary>
        private void E0706DrawForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            //保存本次制作信息
            SerializeObject(UC1.Graphics!, backupFileName);

            if (MyClient != null)
            {
                MyClient.SendToServer("Logout");
                MyClient.normalExit = true;
                Debug.Print("客户端退出制作!");
            }
        }

        /// <summary>选择绘制工具</summary>
        private void RadioButtonDrawType_Click(object? sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender!;
            switch (r.Text)
            {
                case "框选": UC1.ActiveTool = ToolType.Pointer; break;
                case "矩形": UC1.ActiveTool = ToolType.Rectangle; break;
                case "椭圆": UC1.ActiveTool = ToolType.Ellipse; break;
                case "文字":
                    ch07.E06.TextDialog td = new();
                    if (td.ShowDialog() == DialogResult.OK)
                    {
                        TextInfo.Text = td.MyText!;
                        TextInfo.Color = td.MyColor;
                        UC1.ActiveTool = ToolType.Text;
                    }
                    break;
                case "曲线": UC1.ActiveTool = ToolType.Curve; break;
                case "箭头曲线": UC1.ActiveTool = ToolType.ArrowCurve; break;
                case "图像":
                    OpenFileDialog f = new()
                    {
                        Multiselect = false,
                        CheckPathExists = true,
                        Title = "添加图像",
                        Filter = "JPEG (*.jpg)|*.jpg|Bitmap (*.bmp)|*.bmp|PNG (*.png)|*.png|GIF (*.gif)|*.gif|All files|*.*"
                    };
                    if (f.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap bitmap = (Bitmap)Bitmap.FromFile(f.FileName, true);
                        Imagesbytes = CC.BitmapToGrayByte(bitmap);
                        UC1.ActiveTool = ToolType.Image;
                    }
                    break;
            }
        }

        /// <summary>将Graphics序列化到fileName中</summary>
        public void SerializeObject(GraphicsList serializedGraphics, string fileName)
        {
            try
            {
                using Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                byte[]? buffer = CC.Serialize(serializedGraphics);
                if (buffer != null)
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception err)
            {

                labelStatus.Text = "保存文件失败!";
                Debug.Print(err.Message);
            }
        }

        /// <summary>将fileName反序列化到Graphics中</summary>
        public void DeserializeObject(string fileName)
        {
            if (File.Exists(fileName) == false)
            {
                return;
            }
            try
            {
                //using FileStream fs = new(fileName, FileMode.Open, FileAccess.Read);
                //int count = (int)fs.Length;
                //byte[] buffer = new byte[count];
                //int realreadlength = fs.Read(buffer, 0, count);

                byte[] buffer = File.ReadAllBytes(fileName);

                var data = CC.Deserialize<GraphicsList>(buffer);
                if (data != null)
                {
                    uc1.Graphics = data;
                }
                //刚打开文件时，初始化ID
                InitID();
            }
            catch (Exception ex)
            {
                labelStatus.Text = $"打开文件失败，文件名：{fileName}。";
                Debug.Print(ex.Message);
            }
        }
        private void InitID()
        {
            int id = 0;
            var a = uc1.Graphics;
            if (a != null)
            {
                for (int i = 0; i < a.Count; i++)
                {
                    var v = a[i];
                    if (v != null)
                    {
                        if (v.ID > id)
                        {
                            id = v.ID;
                        }
                    }
                }
            }
            id++;
            uc1.ID = id;
        }
    }
}
