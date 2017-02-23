using Newtonsoft.Json;
using System.Globalization;

namespace System.Web.Mvc
{
    public static class JsonNetSettings
    {
        public static JsonSerializerSettings JsonSerializerSettings => new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore,
            Culture = CultureInfo.CurrentCulture,
            DateFormatString = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern
        };
    }
}