using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientWinFormsExamples.ch08.E01
{
    public partial class E0801UdpChat : Form
    {
        private UdpClient? receiveUdpClient;  //接收
        private UdpClient? sendUdpClient;     //发送
        private const int port = 18001;  //和本机绑定的端口号
        private readonly IPAddress ip;   //本机IP
        private readonly IPAddress remoteIp;  //远程主机IP

        public E0801UdpChat()
        {
            InitializeComponent();

            this.Load += E0801UdpChat_Load;
            this.buttonSend.Click += ButtonSend_Click;

            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName()); //获取本机可用IP地址
            ip = ips[^1];     //获取ips的最后一个元素
            remoteIp = ip;    //为了在同一台机器调试，此IP也作为默认远程IP
            textBoxRemoteIP.Text = remoteIp.ToString();
            textBoxSend.Text = "早上好！";
        }

        private void E0801UdpChat_Load(object? sender, EventArgs e)
        {
            //创建一个线程接收远程主机发来的信息
            Thread myThread = new(ReceiveData)
            {
                IsBackground = true
            };
            myThread.Start();
            textBoxSend.Focus();
        }
        private void ReceiveData()
        {
            IPEndPoint local = new(ip, port);
            receiveUdpClient = new UdpClient(local);
            IPEndPoint remote = new(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    //关闭udpClient时此句会产生异常
                    byte[] receiveBytes = receiveUdpClient.Receive(ref remote);
                    string receiveMessage = Encoding.Unicode.GetString(
                        receiveBytes, 0, receiveBytes.Length);
                    AddItem(listBoxReceive, $"来自{remote}：{receiveMessage}");
                }
                catch { break; }
            }
        }

        private void ButtonSend_Click(object? sender, EventArgs e)
        {
            Thread t = new(SendMessage)
            {
                IsBackground = true
            };
            t.Start(textBoxSend.Text);
        }

        /// <summary>发送数据到远程主机</summary>
        private void SendMessage(object? obj)
        {
            string? message = (string?)obj;
            sendUdpClient = new UdpClient(0);
            message ??= "";    //如果message为null,则将其赋值为""
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(message);
            IPEndPoint iep = new(remoteIp, port);
            try
            {
                sendUdpClient.Send(bytes, bytes.Length, iep);
                AddItem(listBoxStatus, $"向{iep}发送：{message}");
            }
            catch (Exception ex)
            {
                AddItem(listBoxStatus, $"发送出错：{ex.Message}");
            }
        }
        private void AddItem(ListBox listbox, string text)
        {
            if (listbox.InvokeRequired)
            {
                listbox.Invoke(AddItem, listbox, text);
            }
            else
            {
                listbox.Items.Add(text);
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.ClearSelected();
            }
        }
    }
}
