using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Names
    {
        [JsonProperty("watcher")]
        public string Watcher { get; set; }

        [JsonProperty("attachment")]
        public string Attachment { get; set; }

        [JsonProperty("sub-tasks")]
        public string SubTasks { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("issuelinks")]
        public string IssueLinks { get; set; }

        [JsonProperty("worklog")]
        public string WorkLog { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("timetracking")]
        public string TimeTracking { get; set; }
    }
}