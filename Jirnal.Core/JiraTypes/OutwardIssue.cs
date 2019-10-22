using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class OutwardIssue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("fields")]
        public InwardIssueFields Fields { get; set; }
    }
}