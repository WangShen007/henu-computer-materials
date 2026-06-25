using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace _2210050000_name_lab06_TCP
{    public partial class ClientChatWindow : Form
    {
        private TcpClient? _client;
        private NetworkStream? _stream;
        private StreamReader? _reader;
        private StreamWriter? _writer;
        private string? _username;
        private const string ServerAddress = "127.0.0.1";
        private const int ServerPort = 8989;
        private CancellationTokenSource? _cancellationTokenSource;


        public ClientChatWindow()
        {
            InitializeComponent();
            this.Text = "群聊客户端";
            UpdateLoginState(false);
        }

        private void UpdateLoginState(bool loggedIn)
        {
            txtUsername.Enabled = !loggedIn;
            btnLogin.Enabled = !loggedIn;

            lstOnlineUsers.Enabled = loggedIn;
            rtbChatMessages.Enabled = loggedIn;
            txtMessageInput.Enabled = loggedIn;
            btnSend.Enabled = loggedIn;

            if (loggedIn)
            {
                this.Text = $"群聊客户端 - {_username}";
            }
            else
            {
                this.Text = "群聊客户端";
                lstOnlineUsers.Items.Clear();
                rtbChatMessages.Clear();
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            _username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(_username))
            {
                MessageBox.Show("用户名不能为空。", "登录错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(ServerAddress, ServerPort);
                _stream = _client.GetStream();
                _reader = new StreamReader(_stream, Encoding.UTF8);
                _writer = new StreamWriter(_stream, Encoding.UTF8) { AutoFlush = true };

                await _writer.WriteLineAsync($"LOGIN|{_username}");                _cancellationTokenSource = new CancellationTokenSource();
                _ = Task.Run(() => ReceiveMessages(_cancellationTokenSource.Token), _cancellationTokenSource.Token);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接服务器失败: {ex.Message}", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateLoginState(false);
                CleanupNetworkResources();
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string message = txtMessageInput.Text.Trim();
            if (!string.IsNullOrEmpty(message) && _writer != null)
            {
                try
                {
                    await _writer.WriteLineAsync($"MSG|{message}");
                    txtMessageInput.Clear();
                }
                catch (Exception ex)
                {
                    AddMessageToChat($"发送消息失败: {ex.Message}");
                }
            }
        }        private async Task ReceiveMessages(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested && _client?.Connected == true)
                {
                    string? message = await _reader!.ReadLineAsync();
                    if (message == null)
                    {
                        AddMessageToChat("与服务器的连接已断开。");
                        this.Invoke((MethodInvoker)delegate
                        {
                            UpdateLoginState(false);
                            CleanupNetworkResources();
                        });
                        break;
                    }

                    ProcessServerMessage(message);
                }
            }
            catch (IOException)
            {
                if (!token.IsCancellationRequested)
                {
                    AddMessageToChat("与服务器的连接中断。");
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateLoginState(false);
                        CleanupNetworkResources();
                    });
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                {
                    AddMessageToChat($"接收消息时出错: {ex.Message}");
                    this.Invoke((MethodInvoker)delegate
                    {
                        UpdateLoginState(false);
                        CleanupNetworkResources();
                    });
                }
            }
        }

        private void ProcessServerMessage(string message)
        {
            this.Invoke((MethodInvoker)delegate
            {
                string[] parts = message.Split(new[] { '|' }, 2);
                string command = parts[0];
                string payload = parts.Length > 1 ? parts[1] : string.Empty;

                switch (command)
                {
                    case "LOGIN_OK":
                        UpdateLoginState(true);
                        AddMessageToChat("成功登录到服务器！");
                        break;
                    case "LOGIN_FAIL":
                        MessageBox.Show($"登录失败: {payload}", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateLoginState(false);
                        CleanupNetworkResources();
                        break;
                    case "USER_LIST":
                        lstOnlineUsers.Items.Clear();
                        if (!string.IsNullOrEmpty(payload))
                        {
                            var users = payload.Split(',');
                            foreach (var user in users)
                            {
                                lstOnlineUsers.Items.Add(user);
                            }
                        }
                        break;
                    case "NEW_MSG":
                        AddMessageToChat(payload);
                        break;
                    case "USER_JOINED":
                        if (!lstOnlineUsers.Items.Contains(payload))
                        {
                            lstOnlineUsers.Items.Add(payload);
                        }
                        AddMessageToChat($"系统消息: 用户 {payload} 加入了聊天室。");
                        break;
                    case "USER_LEFT":
                        if (lstOnlineUsers.Items.Contains(payload))
                        {
                            lstOnlineUsers.Items.Remove(payload);
                        }
                        AddMessageToChat($"系统消息: 用户 {payload} 离开了聊天室。");
                        break;
                    case "SERVER_MSG":
                        AddMessageToChat($"服务器消息: {payload}");
                        break;
                    default:
                        AddMessageToChat($"未知服务器消息: {message}");
                        break;
                }
            });
        }


        private void AddMessageToChat(string message)
        {
            if (rtbChatMessages.InvokeRequired)
            {
                rtbChatMessages.Invoke((MethodInvoker)delegate
                {
                    rtbChatMessages.AppendText(message + Environment.NewLine);
                    rtbChatMessages.ScrollToCaret();
                });
            }
            else
            {
                rtbChatMessages.AppendText(message + Environment.NewLine);
                rtbChatMessages.ScrollToCaret();
            }
        }

        private void CleanupNetworkResources()
        {
            _cancellationTokenSource?.Cancel();
            _reader?.Dispose();
            _writer?.Dispose();
            _stream?.Dispose();
            _client?.Close();
            _client = null;
            _reader = null;
            _writer = null;
            _stream = null;
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
        }


        private async void ClientChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_client != null && _client.Connected && _writer != null)
            {
                try
                {
                    await _writer.WriteLineAsync("LOGOUT|");
                    await Task.Delay(50);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"发送LOGOUT时出错: {ex.Message}");
                }
            }
            CleanupNetworkResources();
        }
    }
}