using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace Model.Constants
{
    public class Resources
    {
        private static IDictionary<string, string> ToDictionary(ResourceManager resourceManager)
        {
            return resourceManager
                .GetResourceSet(CultureInfo.CurrentCulture, true, true)
                .Cast<DictionaryEntry>()
                .ToDictionary(x => x.Key.ToString(), x => x.Value.ToString());
        }

        public readonly object Texts = ToDictionary(TEXTS.ResourceManager);
    }
}