using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class SearchRequest
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }
        
        [JsonProperty("jql")]
        public string Jql { get; set; }

        [JsonProperty("startAt")]
        public long StartAt { get; set; }

        [JsonProperty("maxResults")]
        public long MaxResults { get; set; }

        [JsonProperty("fields")]
        public string[] Fields { get; set; }
    }
}