using System.Net.Sockets;
using System.Net;
using System.Text;
namespace ClientWinFormsExamples.ch08.E02
{
    public partial class E0802AsyncUdpChat : Form
    {
        private readonly int port = 8001;//和本机绑定的接收端口号
        private UdpClient? receiveClient;//接收信息用的UdpClient实例
        private IPEndPoint? iep;   //远程端点
        private string sendMessage = "";
        public E0802AsyncUdpChat()
        {
            InitializeComponent();
            this.Load += E0802AsyncUdpChat_Load;
            this.FormClosing += E0802AsyncUdpChat_FormClosing;
            this.textBoxSend.KeyPress += TextBoxSend_KeyPress;
            this.buttonSend.Click += ButtonSend_Click;
        }

        private void E0802AsyncUdpChat_Load(object? sender, EventArgs e)
        {
            //获取本机可用IP地址(为了在同一台机器调试，此IP也作为默认远程IP)
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            textBoxRemoteIP.Text = ips[^1].ToString();  //获取ips的最后一个元素
            receiveClient = new UdpClient(port);
            Task.Run(() => ReceiveDataAsync());
        }
        private async Task ReceiveDataAsync()
        {
            var result = await Task.Run<UdpReceiveResult>(() =>
            {
                return receiveClient?.ReceiveAsync();
            });
            Byte[] receiveBytes = result.Buffer;
            string str = Encoding.UTF8.GetString(receiveBytes, 0, receiveBytes.Length);
            AddItem(listBoxReceive, $"来自{result.RemoteEndPoint}：{str}");
        }
        /// <summary> 发送数据到远程主机 </summary>
        private async void SendData()
        {
            UdpClient sendUdpClient = new();
            //IPAddress remoteIP;
            if (IPAddress.TryParse(textBoxRemoteIP.Text, out IPAddress? remoteIP) == false)
            {
                MessageBox.Show("远程IP格式不正确");
                return;
            }
            iep = new IPEndPoint(remoteIP, port);
            sendMessage = textBoxSend.Text;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sendMessage);
            await Task.Run(() =>
            {
                try
                {
                    sendUdpClient.SendAsync(bytes, bytes.Length, iep);
                    ClearTextBoxSend();
                    AddItem(listBoxStatus, $"向{iep}发送：{sendMessage}");
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "发送失败");
                }
            });
            sendUdpClient.Close();
        }
        private void ButtonSend_Click(object? sender, EventArgs e)
        {
            SendData();
        }
        private void TextBoxSend_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                SendData();
        }
        private void E0802AsyncUdpChat_FormClosing(object? sender, FormClosingEventArgs e)
        {
            receiveClient?.Close();
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
        private void ClearTextBoxSend()
        {
            if (textBoxSend.InvokeRequired)
            {
                textBoxSend.Invoke(ClearTextBoxSend, null);
            }
            else
            {
                textBoxSend.Clear();
            }
        }
    }
}
