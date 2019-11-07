using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes {
    public class Issue
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("fields")]
        [JsonConverter(typeof(JiraCustomFieldConverter<IssueFields>))]
        public IssueFields Fields { get; set; }

        [JsonProperty("names")]
        public Names Names { get; set; }

        [JsonProperty("schema")]
        public Schema Schema { get; set; }
    }
}
