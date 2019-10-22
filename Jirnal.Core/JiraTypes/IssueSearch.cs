using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public partial class IssueSearch
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("startAt")]
        public long StartAt { get; set; }

        [JsonProperty("maxResults")]
        public long MaxResults { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("issues")]
        public Issue[] Issues { get; set; }
    }
}