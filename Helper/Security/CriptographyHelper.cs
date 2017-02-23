using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Helper.Security
{
    public class CriptographyHelper
    {
        private readonly string _key;
        private readonly string _salt;

        public CriptographyHelper()
        {
            if (ConfigurationManager.AppSettings["Guid"] == null)
                throw new Exception("AppSettings \'Guid\' not exists in .config file.");

            _key = ConfigurationManager.AppSettings["Guid"];
            _salt = _key;
        }

        public CriptographyHelper(string key, string salt)
        {
            _key = key;
            _salt = salt;
        }

        public string Decrypt(string cipherText)
        {
            var algorithm = GetSymmetricAlgorithm();
            var decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);
            var cipher = Convert.FromBase64String(cipherText);

            using (var memoryStream = new MemoryStream(cipher))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }

        public string Encrypt(string text)
        {
            var algorithm = GetSymmetricAlgorithm();
            var encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);
            var memoryStream = new MemoryStream();

            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    streamWriter.Write(text);
                }
            }

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        private SymmetricAlgorithm GetSymmetricAlgorithm()
        {
            using (var key = new Rfc2898DeriveBytes(_key, Encoding.ASCII.GetBytes(_salt)))
            {
                var algorithm = new RijndaelManaged();
                algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
                algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);
                return algorithm;
            }
        }
    }
}