using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Visibility
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}