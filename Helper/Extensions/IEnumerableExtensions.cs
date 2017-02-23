using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

public static class IEnumerableExtensions
{
    public static void ToFile<TIEnumerable>(this IEnumerable<TIEnumerable> items, string separator, string path)
    {
        var properties = typeof(TIEnumerable).GetProperties(BindingFlags.Public | BindingFlags.Instance).OrderBy(p => p.Name);

        using (var streamWriter = new StreamWriter(path))
        {
            streamWriter.WriteLine(string.Join(separator, properties.Select(p => p.Name)));

            foreach (var item in items)
            {
                streamWriter.WriteLine(string.Join(separator, properties.Select(p => p.GetValue(item, null))));
            }
        }
    }
}