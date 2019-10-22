using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class IssueType
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("subtask")]
        public bool SubTask { get; set; }

        [JsonProperty("avatarId")]
        public long AvatarId { get; set; }
    }
}