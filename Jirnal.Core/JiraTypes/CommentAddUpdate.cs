using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class CommentAddUpdate
    {
        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("visibility")]
        public Visibility Visibility { get; set; }
    }
}