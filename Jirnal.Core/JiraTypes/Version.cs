using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Version
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("archived")]
        public bool Archived { get; set; }

        [JsonProperty("released")]
        public bool Released { get; set; }

        [JsonProperty("releaseDate")]
        public DateTimeOffset ReleaseDate { get; set; }

        [JsonProperty("overdue")]
        public bool Overdue { get; set; }

        [JsonProperty("userReleaseDate")]
        public string UserReleaseDate { get; set; }

        [JsonProperty("projectId")]
        public long ProjectId { get; set; }
    }
}