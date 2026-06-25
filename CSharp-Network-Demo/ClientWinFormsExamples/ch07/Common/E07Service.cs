using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientWinFormsExamples.ch07.Common
{
    internal class E07Service
    {

        public static string GetIpV4AddressString()
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
            return localIPv4Address == null ? "127.0.0.1" : localIPv4Address.ToString();
        }
    }
}
