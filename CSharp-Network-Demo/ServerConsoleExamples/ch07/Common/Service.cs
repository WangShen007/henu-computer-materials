using System.Net.Sockets;
using System.Net;

namespace ServerConsoleExamples.ch07.Common
{
    internal static class Service
    {
        /// <summary>向客户端发送信息(user：指定的客户，message：发送的信息)</summary>
        public static void SendToOne(User user, string message)
        {
            if (user.SWriter == null) return;
            try
            {
                user.SWriter.WriteLine(message);
                user.SWriter.Flush();
                Console.WriteLine($"向{user.UserName}发送{message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"向{user.UserName}发送信息失败：{ex.Message}");
            }
        }

        /// <summary>向同一桌的两个客户端发送信息（gameTable：指定游戏桌，str：信息）</summary>
        public static void SendToBoth(GameTable gameTable, string str)
        {
            for (int i = 0; i < 2; i++)
            {
                if (gameTable.Player[i].Sitdown)
                {
                    var user = gameTable.Player[i].PlayingUser;
                    if (user != null)
                    {
                        if (user.Client != null)
                        {
                            SendToOne(user, str);
                        }
                    }
                }
            }
        }

        /// <summary>向所有客户端发送信息（userList：客户列表，str：信息）</summary>
        public static void SendToAll(List<User> userList, string str)
        {
            foreach (User user in userList)
            {
                if (user.Client != null)
                {
                    SendToOne(user, str);
                }
            }
        }

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
