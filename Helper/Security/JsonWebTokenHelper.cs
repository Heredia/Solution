using JWT;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Helper.Security
{
    public static class JsonWebTokenHelper
    {
        private const JwtHashAlgorithm Algorithm = JwtHashAlgorithm.HS256;
        private const int Expires = 60;

        public static string GenerateToken(string key, string salt, object data)
        {
            var payload = new Dictionary<string, object>()
            {
                { data.GetType().Name, data },
                { "exp", GetExpires() }
            };

            return JsonWebToken.Encode(payload, GetKeySalt(key, salt), Algorithm);
        }

        public static T ValidateToken<T>(string key, string salt, string token)
        {
            try
            {
                var decodedToken = JsonWebToken.Decode(token, GetKeySalt(key, salt));
                var jsonObject = JObject.Parse(decodedToken);
                var jsonT = jsonObject[typeof(T).Name].ToString();
                return JsonConvert.DeserializeObject<T>(jsonT);
            }
            catch { return default(T); }
        }

        private static double GetExpires()
        {
            var expireInicial = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Math.Round((DateTime.UtcNow.AddMinutes(Expires) - expireInicial).TotalSeconds);
        }

        private static string GetKeySalt(string key, string salt)
        {
            return string.Concat(key, salt);
        }
    }
}