using Newtonsoft.Json;
using System.Collections;
using System.Data;

namespace Utility.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this IList list)
        {
            return JsonConvert.SerializeObject(list);
        }
        public static string ToJson(this DataTable table)
        {
            return JsonConvert.SerializeObject(table);
        }
        public static T MapToObject<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
