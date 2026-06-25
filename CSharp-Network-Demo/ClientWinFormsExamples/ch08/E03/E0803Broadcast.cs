using System.Net;
using System.Net.Sockets;
using System.Text;
namespace ClientWinFormsExamples.ch08.E03
{
    public partial class E0803Broadcast : Form
    {
        private readonly int port = 8001;//使用的接收端口号
        private UdpClient? udpClient;

        public E0803Broadcast()
        {
            InitializeComponent();
            this.Load += E0803Broadcast_Load;
            buttonSend.Click += ButtonSend_Click;
            this.FormClosing += E0803Broadcast_FormClosing;
        }

        private void E0803Broadcast_Load(object? sender, EventArgs e)
        {
            Thread myThread = new(ReceiveData)
            {
                IsBackground = true
            };
            myThread.Start();
        }

        /// <summary> 在后台运行的接收线程 </summary>
        private void ReceiveData()
        {
            udpClient = new UdpClient(port);
            IPEndPoint? remote = null;
            while (true)
            {
                try
                {
                    //关闭udpClient时此句会产生异常
                    byte[] bytes = udpClient.Receive(ref remote);
                    string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    AddMessage(string.Format("来自{0}：{1}", remote, str));
                }
                catch
                { break; }
            }
        }

        private void ButtonSend_Click(object? sender, EventArgs e)
        {
            UdpClient myUdpClient = new();
            try
            {
                //让其自动提供子网中的IP广播地址
                IPEndPoint iep = new(IPAddress.Broadcast, 8001);
                byte[] bytes = Encoding.UTF8.GetBytes(textBox1.Text);
                myUdpClient.Send(bytes, bytes.Length, iep);
                textBox1.Clear();
                textBox1.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "发送失败");
            }
            finally
            {
                myUdpClient.Close();
            }
        }
        private void AddMessage(string text)
        {
            if (listBox1.InvokeRequired == true)
            {
                listBox1.Invoke(AddMessage, text);
            }
            else
            {
                listBox1.Items.Add(text);
            }
        }
        private void E0803Broadcast_FormClosing(object? sender, FormClosingEventArgs e)
        {
            udpClient?.Close();
        }
    }
}
