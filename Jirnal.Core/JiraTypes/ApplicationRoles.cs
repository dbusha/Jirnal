using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class ApplicationRoles
    {
        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }
}