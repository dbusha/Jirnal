using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Component
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("lead")]
        public Lead Lead { get; set; }

        [JsonProperty("assigneeType")]
        public string AssigneeType { get; set; }

        [JsonProperty("assignee")]
        public Lead Assignee { get; set; }

        [JsonProperty("realAssigneeType")]
        public string RealAssigneeType { get; set; }

        [JsonProperty("realAssignee")]
        public Lead RealAssignee { get; set; }

        [JsonProperty("isAssigneeTypeValid")]
        public bool IsAssigneeTypeValid { get; set; }

        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }
    }
}