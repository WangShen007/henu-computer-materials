using System.Net.Sockets;
using System.Net;

namespace FuLuAWinForms
{
    public partial class SY08Form : Form
    {
        TcpListener? myListener;
        IPAddress? localAddress;

        public SY08Form()
        {
            InitializeComponent();
            buttonStop.Click += ButtonStop_Click;
            buttonStart.Click += ButtonStart_Click;
        }

        private void ButtonStart_Click(object? sender, EventArgs e)
        {
            //判断端口是否合法
            if (int.TryParse(textBoxPort.Text, out int port) == false)
            {
                textBox1.Text += "请输入正整数。\r\n";
                return;
            }
            if (1 > port || port > 65535)
            {
                textBox1.Text += "输入的数值不在合理范围内，请重新输入。\r\n";
                return;
            }
            localAddress = GetIpV4Address();//获取IP地址
            if (localAddress != null)
            {
                try
                {
                    myListener = new TcpListener(localAddress, port);
                    myListener.Start();
                    textBox1.Text += $"开始在{localAddress}:{port}监听客户端连接\r\n";
                    buttonStart.Enabled = false;
                    buttonStop.Enabled = true;
                }
                catch (Exception ex)
                {
                    textBox1.Text += $"{ex.Message}\r\n";
                }
            }
            else
            {
                textBox1.Text += "获取IPv4失败，无法通过IPv4监听客户端连接\r\n";
            }
        }

        private void ButtonStop_Click(object? sender, EventArgs e)
        {
            if (myListener != null)
            {
                myListener.Stop();
                textBox1.Text += "成功停止监听服务。" + "\r\n ";
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
            }
        }

        /// <summary>
        /// 获取本机IPv4地址
        /// </summary>
        /// <returns></returns>
        public static IPAddress? GetIpV4Address()
        {
            IPAddress[] addrIP = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress? localIPv4Address = null;
            foreach (var ip in addrIP)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIPv4Address = ip;
                    break;
                }
            }
            return localIPv4Address;
        }
    }
}
