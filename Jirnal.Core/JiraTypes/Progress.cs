using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Progress
    {
        [JsonProperty("progress")]
        public long ProgressProgress { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }
    }
}
