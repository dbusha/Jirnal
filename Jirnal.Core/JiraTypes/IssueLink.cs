using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class IssueLink
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("type")]
        public IssueLinkType Type { get; set; }

        [JsonProperty("outwardIssue", NullValueHandling = NullValueHandling.Ignore)]
        public OutwardIssue OutwardIssue { get; set; }

        [JsonProperty("inwardIssue", NullValueHandling = NullValueHandling.Ignore)]
        public OutwardIssue InwardIssue { get; set; }
    }
}