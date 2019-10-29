using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class SubTask
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("type")]
        public JiraType Type { get; set; }

        [JsonProperty("outwardIssue")]
        public OutwardIssue OutwardIssue { get; set; } 
    }
}