using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

namespace FuLuAWinForms
{
    public partial class LX18Form : Form
    {
        TcpClient? client;
        IPAddress? ipAddress;
        public LX18Form()
        {
            InitializeComponent();
            buttonStop.Click += ButtonStop_Click;
            buttonStart.Click += ButtonStart_Click;
        }

        private void ButtonStart_Click(object? sender, EventArgs e)
        {
            if (IsIP(textBoxIP.Text) == false)
            {
                textBox1.Text += "非法IP地址，请重新输入。\r\n";
                return;
            }
            //判断端口是否合法
            if (int.TryParse(textBoxPort.Text, out int port) == false)
            {
                textBox1.Text += "端口号非法，请输入正整数。\r\n";
                return;
            }
            if (1 > port || port > 65535)
            {
                textBox1.Text += "输入的数值不在合理范围内，请重新输入端口号。\r\n";
                return;
            }
            client = new TcpClient();
            try
            {
                this.Cursor = Cursors.WaitCursor;
                buttonStart.Enabled = false;
                ipAddress = IPAddress.Parse(textBoxIP.Text);
                client.Connect(ipAddress, port);//连接远程服务器
                textBox1.Text += $"与{ipAddress}:{port}连接成功\r\n";
                buttonStop.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                textBox1.Text += $"与{ipAddress}:{port}连接失败。\r\n{ex.Message}\r\n";
                buttonStart.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void ButtonStop_Click(object? sender, EventArgs e)
        {
            if (client != null)
            {
                client.Close();
                textBox1.Text += "成功关闭连接" + "\r\n ";
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
            }
        }

        /// <summary>
        /// 利用正则表达式判断IP是否合法
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return IpRegex().IsMatch(ip);
        }

        //（由于教材篇幅限制，本书未介绍正则表达式，有兴趣的读者可参考正则表达式的相关资料）
        [GeneratedRegex("^((2[0-4]\\d|25[0-5]|[01]?\\d\\d?)\\.){3}(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)$")]
        private static partial Regex IpRegex();
    }
}
