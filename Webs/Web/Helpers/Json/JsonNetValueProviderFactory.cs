using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;

namespace System.Web.Mvc
{
    public class JsonNetValueProviderFactory : ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (!context.HttpContext.Request.ContentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                return null;

            var streamReader = new StreamReader(context.HttpContext.Request.InputStream);

            var jsonTextReader = new JsonTextReader(streamReader);

            if (!jsonTextReader.Read()) return null;

            var jsonSerializer = new JsonSerializer();
            jsonSerializer.Converters.Add(new ExpandoObjectConverter());

            object jsonObject;

            if (jsonTextReader.TokenType == JsonToken.StartArray)
                jsonObject = jsonSerializer.Deserialize<List<ExpandoObject>>(jsonTextReader);
            else
                jsonObject = jsonSerializer.Deserialize<ExpandoObject>(jsonTextReader);

            var backingStore = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            AddToBackingStore(backingStore, string.Empty, jsonObject);

            return new DictionaryValueProvider<object>(backingStore, CultureInfo.CurrentCulture);
        }

        private static void AddToBackingStore(IDictionary<string, object> backingStore, string prefix, object value)
        {
            var dictionary = value as IDictionary<string, object>;

            if (dictionary != null)
            {
                foreach (var entry in dictionary)
                {
                    AddToBackingStore(backingStore, MakePropertyKey(prefix, entry.Key), entry.Value);
                }

                return;
            }

            var list = value as IList;

            if (list != null)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    AddToBackingStore(backingStore, MakeArrayKey(prefix, i), list[i]);
                }

                return;
            }

            backingStore[prefix] = value;
        }

        private static string MakeArrayKey(string prefix, int index)
        {
            return prefix + "[" + index.ToString(CultureInfo.InvariantCulture) + "]";
        }

        private static string MakePropertyKey(string prefix, string propertyName)
        {
            return (string.IsNullOrEmpty(prefix)) ? propertyName : prefix + "." + propertyName;
        }
    }
}