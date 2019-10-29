using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Comments
    {
        [JsonProperty("startAt")]
        public long StartAt { get; set; }

        [JsonProperty("maxResults")]
        public long MaxResults { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("comments")]
        public Comment[] CommentList { get; set; }
    }
}