using System;
using Newtonsoft.Json;


namespace Jirnal.Core.JiraTypes
{
    public class JiraProject
    {
        [JsonProperty("expand")]
        public string Expand { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("lead")]
        public Lead Lead { get; set; }

        [JsonProperty("components")]
        public Component[] Components { get; set; }

        [JsonProperty("issueTypes")]
        public IssueType[] IssueTypes { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("assigneeType")]
        public string AssigneeType { get; set; }

        [JsonProperty("versions")]
        public object[] Versions { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roles")]
        public Roles Roles { get; set; }

        [JsonProperty("avatarUrls")]
        public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("projectCategory")]
        public ProjectCategory ProjectCategory { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }
    }
}