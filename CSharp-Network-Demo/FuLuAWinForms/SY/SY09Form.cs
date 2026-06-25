using System.Net.Sockets;
using System.Net;
using System.Text;

namespace FuLuAWinForms
{
    public partial class SY09Form : Form
    {
        //接收端口号
        private readonly int port = 8001;
        private UdpClient? udpClient;
        private IPAddress? myIP;

        public SY09Form()
        {
            InitializeComponent();

            this.Load += SY09Form_Load;
            buttonSend.Click += ButtonSend_Click;
        }

        private void ButtonSend_Click(object? sender, EventArgs e)
        {
            UdpClient myUdpClient = new();
            if (IPAddress.TryParse(textBoxRemoteIP.Text, out IPAddress? remoteIP) == false)
            {
                MessageBox.Show("远程IP格式不正确");
                return;
            }
            IPEndPoint iep = new(remoteIP, port);
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(textBoxSendMessage.Text);
            try
            {
                myUdpClient.Send(bytes, bytes.Length, iep);
                textBoxSendMessage.Clear();
                myUdpClient.Close();
                textBoxSendMessage.Focus();
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

        private void SY09Form_Load(object? sender, EventArgs e)
        {
            //获取本机第一个可用IP地址
            foreach (var p in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (p.AddressFamily == AddressFamily.InterNetwork)
                {
                    myIP = p;
                    break;
                }
            }
            if(myIP == null)
            {
                MessageBox.Show("未找到本机可用的IPv4地址！", "警告");
                return;
            }
            //为了在同一台机器调试，此IP也作为默认远程IP
            textBoxRemoteIP.Text = myIP.ToString();
            //创建一个线程接收远程主机发来的信息
            Thread myThread = new Thread(ReceiveData);
            myThread.Start();
            textBoxSendMessage.Focus();
        }

        /// <summary>
        /// 接收线程
        /// </summary>
        private void ReceiveData()
        {
            //在本机指定的端口接收
            udpClient = new UdpClient(port);
            IPEndPoint? remote = null;
            //接收从远程主机发送过来的信息；
            while (true)
            {
                try
                {
                    //关闭udpClient时此句会产生异常
                    byte[] bytes = udpClient.Receive(ref remote);
                    string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    MessageBox.Show(str, $"接收到来自[{remote}]的呼叫");
                }
                catch
                {
                    //退出循环，结束线程
                    break;
                }
            }
        }
    }
}
