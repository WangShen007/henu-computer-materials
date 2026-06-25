using System.Net.Sockets;
using System.Net;
using ServerConsoleExamples.ch07.Common;

namespace ServerConsoleExamples.ch07.E02
{
    internal class E0702Main
    {
        private readonly List<User> userList = new();
        private readonly IPAddress? localAddress;
        private const int port = 51888;
        private readonly TcpListener? myListener;

        public E0702Main()
        {
            localAddress=Service.GetIpV4Address();
            if(localAddress != null)
            {
                myListener = new TcpListener(localAddress, port);
                myListener.Start();
                Console.WriteLine("开始在{0}:{1}监听客户端连接", localAddress, port);
                _ = ListenClientConnect();
            }
            //阻止窗口闪退。执行异步操作后，由于主程序中无其他执行代码，控制台窗口会立即退出
            Console.ReadKey();
        }

        private async Task ListenClientConnect()
        {
            while (true)
            {
                if(myListener == null) { return; }
                try
                {
                    TcpClient newClient = await myListener.AcceptTcpClientAsync();
                    if (newClient != null)
                    {
                        User user = new(newClient);
                        //每接受一个客户端连接,就创建一个对应的Task任务循环接收该客户端发来的信息
                        _= Task.Run(() =>ReceiveDataAsync(user));
                        userList.Add(user);
                        if (newClient.Client != null)
                        {
                            Console.WriteLine($"[{newClient.Client.RemoteEndPoint}]进入");
                        }
                        Console.WriteLine("当前连接用户数：{0}", userList.Count);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
        }

        private async Task ReceiveDataAsync(object userState)
        {
            User user = (User)userState;
            while (true)
            {
                string? receiveString;
                receiveString = await ReceiveMessageAsync(user);

                if (receiveString == null)
                {
                    RemoveUser(user);
                    break;
                }
                Console.WriteLine("来自[{0}]：{1}", user.Client?.Client.RemoteEndPoint, receiveString);
                string[] splitString = receiveString.Split(',');
                switch (splitString[0])
                {
                    case "Login":
                        user.UserName = splitString[1];
                        var s1 = "";
                        foreach (var v in userList)
                        {
                            s1 += v.UserName+",";
                        }
                        await SendToAllAsync($"Online,{s1.TrimEnd(',')}");
                        break;
                    case "Logout":
                        RemoveUser(user);
                        var s2 = "";
                        foreach (var v in userList)
                        {
                            s2 += v.UserName + ",";
                        }
                        await SendToAllAsync($"Online,{s2.TrimEnd(',')}");
                        break;
                    case "Talk":
                        string talkStr = receiveString.Remove(0, splitString[0].Length + splitString[1].Length + 2);
                        await SendToAllAsync($"Talk,{user.UserName},{talkStr}");
                        break;
                    default:
                        Console.WriteLine("什么意思啊：" + receiveString);
                        break;
                }
            }
        }
        private static async Task<string?> ReceiveMessageAsync(User user)
        {
            string? receiveMessage = null;
            try
            {
                receiveMessage = await Task.Run(() => user.SReader?.ReadLineAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                receiveMessage = null;
            }
            return receiveMessage;
        }
        private async Task SendToAllAsync(string message)
        {
            Console.WriteLine($"-----userList.Count:{userList.Count}");

            foreach (var v in userList)
            {
                await Task.Run(() =>
                {
                    v.SWriter?.WriteLineAsync(message);
                    v.SWriter?.Flush();
                });
            }
        }
        /// <summary>移除用户</summary>
        private void RemoveUser(User user)
        {
            userList.Remove(user);
            user.Client?.Close();
            Console.WriteLine(string.Format("当前连接用户数：{0}", userList.Count));
        }
    }
}
