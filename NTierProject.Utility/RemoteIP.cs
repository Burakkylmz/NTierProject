using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.Utility
{
    public static class RemoteIP
    {
        public static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily==AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Local Ip Address Not Found!";
        }

        public static string IpAddress { get { return GetIpAddress(); } }
    }
}
