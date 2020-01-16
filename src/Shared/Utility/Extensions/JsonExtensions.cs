using Newtonsoft.Json;
using System.Collections;

namespace Utility.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson(this IList list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
