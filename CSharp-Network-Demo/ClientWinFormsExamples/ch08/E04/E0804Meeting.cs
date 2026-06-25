using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientWinFormsExamples.ch08.E04
{
    public partial class E0804Meeting : Form
    {
        //使用的IP地址
        private readonly IPAddress broderCastIp = IPAddress.Parse("224.100.0.1");
        //使用的接收端口号
        private readonly int port = 8001;
        private UdpClient? udpClient;

        public E0804Meeting()
        {
            InitializeComponent();
            this.Load += E0804Meeting_Load;
            this.FormClosing += E0804Meeting_FormClosing;
            foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    labelUserName.Text = ip.ToString();
                    break;
                }
            }
        }
        private void E0804Meeting_Load(object? sender, EventArgs e)
        {
            buttonLogin.Click += ButtonLogin_Click;
            buttonLogout.Click += ButtonLogout_Click;
            buttonSend.Click += ButtonSend_Click;
            textBoxMessage.KeyPress += TextBoxMessage_KeyPress;
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            buttonSend.Enabled = false;
        }
        private void ButtonLogin_Click(object? sender, EventArgs e)
        {
            //进入会议室
            Cursor.Current = Cursors.WaitCursor;
            Thread myThread = new(ReceiveMessage);
            myThread.Start();
            Thread.Sleep(1000);//等待接收线程准备完毕
            SendMessage(broderCastIp, "Login");
            buttonLogin.Enabled = false;
            buttonLogout.Enabled = true;
            buttonSend.Enabled = true;
            Cursor.Current = Cursors.Default;
        }
        /// <summary> 接收消息 </summary>
        private void ReceiveMessage()
        {
            udpClient = new UdpClient(port);
            udpClient.JoinMulticastGroup(broderCastIp); //必须使用组播地址范围内的地址
            udpClient.Ttl = 50;
            IPEndPoint? remote = null;
            while (true)
            {
                try
                {
                    //关闭udpClient时此句会产生异常
                    byte[] bytes = udpClient.Receive(ref remote);
                    string str = Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    string[] splitString = str.Split(',');
                    int s = splitString[0].Length;
                    switch (splitString[0])
                    {
                        case "Login":  //进入会议室 
                            SetListBoxItem(listBoxMessage, $"[{remote.Address}]进入。", ListBoxOperation.AddItem);
                            SetListBoxItem(listBoxAddress, remote.Address.ToString(), ListBoxOperation.AddItem);
                            string userListString = $"List,{remote.Address}";
                            for (int i = 0; i < listBoxAddress.Items.Count; i++)
                            {
                                userListString += "," + listBoxAddress.Items[i].ToString();
                            }
                            SendMessage(remote.Address, userListString);
                            break;
                        case "List": //参加会议人员名单
                            for (int i = 1; i < splitString.Length; i++)
                            {
                                SetListBoxItem(listBoxAddress,
                                    splitString[i], ListBoxOperation.AddItem);
                            }
                            break;
                        case "Message":  //发言内容
                            SetListBoxItem(listBoxMessage,
                                string.Format("[{0}]说：{1}", remote.Address.ToString(), str.Substring(8)),
                                ListBoxOperation.AddItem);
                            break;
                        case "Logout": //退出会议室
                            SetListBoxItem(listBoxMessage,
                                string.Format("[{0}]退出。", remote.Address.ToString()),
                                ListBoxOperation.AddItem);
                            SetListBoxItem(listBoxAddress,
                                remote.Address.ToString(), ListBoxOperation.RemoveItem);
                            break;
                    }
                }
                catch
                {
                    //退出循环，结束线程
                    break;
                }
            }
        }
        /// <summary> 发送消息 </summary>
        private void SendMessage(IPAddress ip, string sendString)
        {
            UdpClient myUdpClient = new();
            //允许发送和接收广播数据报
            // myUdpClient.EnableBroadcast = true;
            //必须使用组播地址范围内的地址
            IPEndPoint iep = new(ip, port);
            //将发送内容转换为字节数组
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(sendString);
            try
            {
                //向子网发送信息
                myUdpClient.Send(bytes, bytes.Length, iep);
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
        private void TextBoxMessage_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (textBoxMessage.Text.Trim().Length > 0)
                {
                    SendMessage(broderCastIp, "Message," + textBoxMessage.Text);
                    textBoxMessage.Text = "";
                }
            }
        }
        private void ButtonSend_Click(object? sender, EventArgs e)
        {
            if (textBoxMessage.Text.Trim().Length > 0)
            {
                SendMessage(broderCastIp, "Message," + textBoxMessage.Text);
                textBoxMessage.Text = "";
            }
        }
        private void ButtonLogout_Click(object? sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SendMessage(broderCastIp, "Logout");
            udpClient?.DropMulticastGroup(this.broderCastIp);
            Thread.Sleep(1000); //等待接收线程处理完毕
            udpClient?.Close();
            buttonLogin.Enabled = true;
            buttonLogout.Enabled = false;
            buttonSend.Enabled = false;
            Cursor.Current = Cursors.Default;
        }
        private void E0804Meeting_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (buttonLogout.Enabled == true)
            {
                MessageBox.Show("请先离开会议室，然后再退出！", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }
        private enum ListBoxOperation { AddItem, RemoveItem };
        private void SetListBoxItem(ListBox listbox, string text, ListBoxOperation operation)
        {
            if (listbox.InvokeRequired == true)
            {
                listbox.Invoke(SetListBoxItem, listbox, text, operation);
            }
            else
            {
                if (operation == ListBoxOperation.AddItem)
                {
                    if (listbox == listBoxAddress)
                    {
                        if (listbox.Items.Contains(text) == false)
                        {
                            listbox.Items.Add(text);
                        }
                    }
                    else
                    {
                        listbox.Items.Add(text);
                    }
                    listbox.SelectedIndex = listbox.Items.Count - 1;
                    listbox.ClearSelected();
                }
                else if (operation == ListBoxOperation.RemoveItem)
                {
                    listbox.Items.Remove(text);
                }
            }
        }
    }
}
