using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EatEasy.Domain.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OrderStatus
    {
        Received,
        Preparing,
        Completed,
        Done
    }
}
