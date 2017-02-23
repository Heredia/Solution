using Helper.Security;

namespace System.Web.Mvc
{
    public static class JsonWebTokenHeaderHelper
    {
        private static readonly string Key = AppSettingsHelper.Guid;
        private static readonly string Salt = RequestHelper.IP;

        public static T Get<T>(string name)
        {
            var headers = HttpContext.Current.Request.Headers;
            return JsonWebTokenHelper.ValidateToken<T>(Key, Salt, headers[name]);
        }

        public static void Set(string name, object data)
        {
            var token = JsonWebTokenHelper.GenerateToken(Key, Salt, data);
            HttpContext.Current.Response.AddHeader(name, token);
        }
    }
}