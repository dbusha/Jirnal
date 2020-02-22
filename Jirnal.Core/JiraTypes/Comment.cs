using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Comment
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("id")]
        [JsonConverter(typeof(StringToLongConverter))]
        public long Id { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("updateAuthor")]
        public Author UpdateAuthor { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("updated")]
        public DateTime? Updated { get; set; }

        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }


        [JsonIgnore]
        public DateTime UpdatedOrCreated => Updated ?? Created;
    }
}