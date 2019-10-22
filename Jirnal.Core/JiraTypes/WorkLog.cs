using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class WorkLog
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("updateAuthor")]
        public Author UpdateAuthor { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("updated")]
        public string Updated { get; set; }

        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }

        [JsonProperty("started")]
        public string Started { get; set; }

        [JsonProperty("timeSpent")]
        public string TimeSpent { get; set; }

        [JsonProperty("timeSpentSeconds")]
        public long TimeSpentSeconds { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("issueId")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long IssueId { get; set; }
    }
}