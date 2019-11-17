using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class JiraProfile
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("avatarUrls")]
        public AvatarUrls AvatarUrls { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("timeZone")]
        public string TimeZone { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("groups")]
        public JiraApplicationRoles Groups { get; set; }

        [JsonProperty("applicationRoles")]
        public JiraApplicationRoles ApplicationRoles { get; set; }

        [JsonProperty("expand")]
        public string Expand { get; set; }
    }

    
    public class JiraApplicationRoles
    {
        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("items")]
        public JiraItem[] Items { get; set; }
    }
    

    public class JiraItem 
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }
    }
}