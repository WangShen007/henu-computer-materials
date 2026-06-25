using System.Net;
using System.Net.Sockets;
using ClientWinFormsExamples.ch07.Common;

namespace ClientWinFormsExamples.ch07.E02
{
    public partial class ChatForm : Form
    {
        private bool isExit = false;
        private TcpClient? client;
        private StreamReader? sr;
        private StreamWriter? sw;
        public ChatForm(string userName)
        {
            InitializeComponent();
            textBoxUserName.Text = userName;
            listBoxOnline.HorizontalScrollbar = true;
            buttonConnect.Click += ButtonConnect_Click;
            buttonSend.Click += ButtonSend_Click;
        }

        private void ButtonConnect_Click(object? sender, EventArgs e)
        {
            buttonConnect.Enabled = false;
            ConnectToServer();
        }

        private void ButtonSend_Click(object? sender, EventArgs e)
        {
            SendTalk($"Talk,{textBoxUserName.Text},{textBoxSend.Text}");
            textBoxSend.Clear();
        }

        private async void ConnectToServer()
        {
            client = new TcpClient();
            await Task.Run(() =>
            {
                try
                {
                    client.Connect(E07Service.GetIpV4AddressString(), 51888);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "与服务器连接失败");
                    return;
                }
            });
            NetworkStream networkStream = client.GetStream();
            sr = new StreamReader(networkStream);
            sw = new StreamWriter(networkStream);

            SendTalk("Login," + textBoxUserName.Text);

            await Task.Run(() => ReceiveConnecAsync());
        }

        private async Task ReceiveConnecAsync()
        {
            string? receiveString = null;
            while (isExit == false)
            {
                await Task.Run(() =>
                {
                    try
                    {
                        receiveString = sr?.ReadLine();
                    }
                    catch
                    {
                        isExit = true;
                    }
                });
                if(isExit == true)
                {
                    break;
                }
                else if (receiveString == null)
                {
                    MessageBox.Show("与服务器失去联系。");
                    break;
                }
                //AddMessage(listBoxStatus,$"收到：{receiveString}");
                string[] splitString = receiveString.Split(',');
                string command = splitString[0].ToLower();
                switch (command)
                {
                    case "online":  //格式：login,用户名
                        ClearlistBoxOnline();
                        for (int i = 1; i < splitString.Length; i++)
                        {
                            AddMessage(listBoxOnline, splitString[i]);
                        }
                        break;
                    case "talk":  //格式：talk,用户名,对话信息
                        var msg = receiveString.Remove(0, splitString[0].Length + splitString[1].Length + 2);
                        AddMessage(listBoxStatus, $"{splitString[1]}：{msg}");
                        break;
                }
            }
        }

        private void SendTalk(string message)
        {
            try
            {
                sw?.WriteLine(message);
                sw?.Flush();
            }
            catch (Exception ex)
            {
                AddMessage(listBoxStatus, $"发送失败：{ex.Message}");
            }
        }

        private void AddMessage(ListBox listbox, string message)
        {
            if (listbox.InvokeRequired)
            {
                if (listbox.Disposing == false)
                    listbox.Invoke(AddMessage, listbox, message);
            }
            else
            {
                listbox.Items.Add(message);
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.ClearSelected();
            }
        }
        private void ClearlistBoxOnline()
        {
            if (listBoxOnline.InvokeRequired)
            {
                listBoxOnline.Invoke(ClearlistBoxOnline);
            }
            else
            {
                listBoxOnline.Items.Clear();
            }
        }

        private void FormClient_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (client != null)
            {
                if (client.Client.Connected)
                {
                    SendTalk("Logout," + textBoxUserName.Text);
                }
                isExit = true;
                sr?.Close();
                sw?.Close();
                client?.Close();
            }
        }
    }
}
