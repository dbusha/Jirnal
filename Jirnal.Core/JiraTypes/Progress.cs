using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class JiraProgress
    {
        [JsonProperty("progress")]
        public long Progress { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}
