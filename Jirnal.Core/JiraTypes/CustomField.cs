using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class CustomFields
    {
        [JsonProperty("maxResults")]
        public long MaxResults { get; set; }

        [JsonProperty("startAt")]
        public long StartAt { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("isLast")]
        public bool IsLast { get; set; }

        [JsonProperty("values")]
        public CustomField[] Fields { get; set; }
    }

    
    public class CustomField
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("searcherKey")]
        public string SearcherKey { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("numericId")]
        public long NumericId { get; set; }

        [JsonProperty("isLocked")]
        public bool IsLocked { get; set; }

        [JsonProperty("isManaged")]
        public bool IsManaged { get; set; }

        [JsonProperty("isAllProjects")]
        public bool IsAllProjects { get; set; }

        [JsonProperty("projectsCount")]
        public long ProjectsCount { get; set; }

        [JsonProperty("screensCount")]
        public long ScreensCount { get; set; }
    }
}