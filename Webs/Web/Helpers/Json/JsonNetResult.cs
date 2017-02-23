using Newtonsoft.Json;

namespace System.Web.Mvc
{
    public class JsonNetResult : JsonResult
    {
        public JsonNetResult()
        {
            if (HttpContext.Current.IsDebuggingEnabled)
            {
                Formatting = Formatting.Indented;
            }
        }

        private Formatting Formatting { get; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException("JSON GET is not allowed");

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            if (Data == null) return;

            var writer = new JsonTextWriter(response.Output) { Formatting = Formatting };

            var serializer = JsonSerializer.Create(JsonNetSettings.JsonSerializerSettings);

            serializer.Serialize(writer, Data);

            writer.Flush();
        }
    }
}