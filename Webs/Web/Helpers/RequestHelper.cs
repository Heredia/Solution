using System.Linq;
using System.Net;

namespace System.Web.Mvc
{
    public static class RequestHelper
    {
        public static string IP
        {
            get
            {
                try
                {
                    var userHostAddress = HttpContext.Current.Request.UserHostAddress;

                    if (string.IsNullOrEmpty(userHostAddress)) { return string.Empty; }

                    IPAddress.Parse(userHostAddress);

                    var xForwardedFor = HttpContext.Current.Request.ServerVariables["X_FORWARDED_FOR"];

                    if (string.IsNullOrEmpty(xForwardedFor)) return userHostAddress;

                    var publicForwardingIps = xForwardedFor.Split(',').Where(ip => !IsPrivateIP(ip)).ToList();

                    return publicForwardingIps.Any() ? publicForwardingIps.Last() : userHostAddress;
                }
                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        private static bool IsPrivateIP(string ip)
        {
            var ipAddress = IPAddress.Parse(ip);
            var octets = ipAddress.GetAddressBytes();

            var is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true;

            var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true;

            var is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true;

            var isLocal = octets[0] == 169 && octets[1] == 254;
            return isLocal;
        }
    }
}