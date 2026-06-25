using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatServer
{
    class Server
    {
        private TcpListener? _listener;
        private readonly ConcurrentDictionary<string, ClientHandler> _clients = new ConcurrentDictionary<string, ClientHandler>();
        private const int Port = 8989;
        private bool _isRunning = false;

        public void Start()
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start();
            _isRunning = true;
            Console.WriteLine($"服务器已启动，监听端口 {Port}...");

            while (_isRunning)
            {
                try
                {
                    TcpClient tcpClient = _listener.AcceptTcpClient();
                    ClientHandler clientHandler = new ClientHandler(tcpClient, this);
                    Task.Run(() => clientHandler.Process());
                }
                catch (Exception ex)
                {
                    if (_isRunning)
                    {
                        Console.WriteLine($"接受客户端连接时出错: {ex.Message}");
                    }
                }
            }
        }        public bool TryAddClient(string username, ClientHandler clientHandler)
        {
            if (_clients.TryAdd(username, clientHandler))
            {
                Console.WriteLine($"用户 {username} 已连接。当前在线用户数: {_clients.Count}");
                BroadcastUserList();
                BroadcastMessage($"SERVER_MSG|用户 {username} 加入了聊天室。", clientHandler);
                return true;
            }
            return false;
        }

        public void RemoveClient(string username)
        {
            if (_clients.TryRemove(username, out ClientHandler? clientHandler))
            {
                Console.WriteLine($"用户 {username} 已断开连接。当前在线用户数: {_clients.Count}");
                BroadcastMessage($"SERVER_MSG|用户 {username} 离开了聊天室。", clientHandler);
                BroadcastUserList();
                clientHandler?.Close();
            }
        }        public void BroadcastMessage(string message, ClientHandler? sender)
        {
            Console.WriteLine($"广播消息: {message}");
            var clientsToRemove = new List<string>();

            foreach (var client in _clients.Values)
            {
                bool shouldSend = true;

                if (sender != null && (message.StartsWith("SERVER_MSG|") || message.StartsWith("USER_LIST|")))
                {
                    shouldSend = client != sender;
                }

                if (shouldSend)
                {
                    try
                    {
                        client.SendMessage(message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"向 {client.Username} 发送消息失败: {ex.Message}");
                        if (!string.IsNullOrEmpty(client.Username))
                        {
                            clientsToRemove.Add(client.Username);
                        }
                    }
                }
            }

            foreach (var username in clientsToRemove)
            {
                RemoveClient(username);
            }
        }public void BroadcastUserList()
        {
            string userListPayload = string.Join(",", _clients.Keys.ToArray());
            BroadcastMessage($"USER_LIST|{userListPayload}", null);
        }

        public string GetUserListPayload()
        {
            return string.Join(",", _clients.Keys.ToArray());
        }

        public ConcurrentDictionary<string, ClientHandler> GetClients()
        {
            return _clients;
        }

        public void Stop()
        {
            _isRunning = false;
            try
            {
                _listener?.Stop();
                Console.WriteLine("服务器已停止。");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"停止服务器时出错: {ex.Message}");
            }
        }

        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }

    class ClientHandler
    {
        private readonly TcpClient _tcpClient;
        private readonly Server _server;
        private NetworkStream? _stream;
        private StreamReader? _reader;
        private StreamWriter? _writer;
        public string? Username { get; private set; }
        private bool _isRunning = true;

        public ClientHandler(TcpClient tcpClient, Server server)
        {
            _tcpClient = tcpClient;
            _server = server;
        }

        public async Task Process()
        {
            _stream = _tcpClient.GetStream();
            _reader = new StreamReader(_stream, Encoding.UTF8);
            _writer = new StreamWriter(_stream, Encoding.UTF8) { AutoFlush = true };            try
            {
                while (_isRunning && _tcpClient.Connected)
                {
                    string? message = await _reader.ReadLineAsync();
                    if (message == null)
                    {
                        _isRunning = false;
                        break;
                    }

                    Console.WriteLine($"收到来自 {(Username ?? "未知用户")} 的消息: {message}");
                    string[] parts = message.Split(new[] { '|' }, 2);
                    string command = parts[0];
                    string payload = parts.Length > 1 ? parts[1] : string.Empty;

                    switch (command)
                    {
                        case "LOGIN":
                            HandleLogin(payload);
                            break;
                        case "MSG":
                            if (Username != null)
                            {
                                _server.BroadcastMessage($"NEW_MSG|[{Username}]说: {payload}", this);
                            }
                            break;
                        case "LOGOUT":
                            _isRunning = false;
                            break;
                        default:
                            SendMessage("SERVER_MSG|未知命令");
                            break;
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"与 {(Username ?? "客户端")} 通信IO异常: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"处理 {(Username ?? "客户端")} 消息时出错: {ex.Message}");
            }
            finally
            {
                if (Username != null)
                {
                    _server.RemoveClient(Username);
                }
                Close();
            }
        }        private void HandleLogin(string username)
        {
            if (string.IsNullOrWhiteSpace(username) || _server.GetClients().ContainsKey(username))
            {
                SendMessage("LOGIN_FAIL|用户名无效或已被占用。");
                _isRunning = false;
                return;
            }

            Username = username;
            if (_server.TryAddClient(Username, this))
            {
                SendMessage("LOGIN_OK|");
                SendMessage($"USER_LIST|{_server.GetUserListPayload()}");
            }
            else
            {
                SendMessage("LOGIN_FAIL|无法登录，请重试。");
                _isRunning = false;
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                if (_tcpClient?.Connected == true && _writer != null)
                {
                    _writer.WriteLine(message);
                }
                else
                {
                    throw new InvalidOperationException("客户端连接已断开");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"向 {Username ?? "未知用户"} 发送消息时发生IO错误: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"向 {Username ?? "未知用户"} 发送消息时发生错误: {ex.Message}");
                throw;
            }
        }        public void Close()
        {
            _isRunning = false;
            try
            {
                _reader?.Close();
                _writer?.Close();
                _stream?.Close();
                _tcpClient?.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"关闭客户端连接时出错: {ex.Message}");
            }
            Console.WriteLine($"客户端 {(Username ?? "")} 连接已关闭。");
        }
    }
}