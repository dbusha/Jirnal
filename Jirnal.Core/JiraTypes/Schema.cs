using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Schema
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("system")]
        public string System { get; set; }
    }
}