using System;
using System.Security.Cryptography;
using System.Text;

namespace Helper.Security
{
    public static class HashHelper
    {
        public static string GenerateHash(string text)
        {
            using (var sHa512Managed = new SHA512Managed())
            {
                var hashBytes = sHa512Managed.ComputeHash(Encoding.ASCII.GetBytes(text));
                return Convert.ToBase64String(hashBytes, 0, hashBytes.Length);
            }
        }
    }
}