using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Attachment
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("mimeType")]
        public string MimeType { get; set; }

        [JsonProperty("content")]
        public Uri Content { get; set; }

        [JsonProperty("thumbnail")]
        public Uri Thumbnail { get; set; }
    }
}