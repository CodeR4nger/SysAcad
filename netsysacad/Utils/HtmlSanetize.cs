using System.Reflection;
using System.Text.RegularExpressions;

namespace netsysacad.Utils;

public class HtmlSanetizer
{
    public static string StripHtml(string input)
    {
        return string.IsNullOrEmpty(input)
            ? input
            : Regex.Replace(input, "<.*?>", string.Empty);
    }
    public static void SanetizeObject<T>(T obj)
    {
        var stringProperties = typeof(T)
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));
        
        foreach (var prop in stringProperties)
        {
            var value = prop.GetValue(obj) as string;
            if (!string.IsNullOrEmpty(value))
            {
                var sanitized = StripHtml(value);
                prop.SetValue(obj, sanitized);
            }
        }
    }
}
