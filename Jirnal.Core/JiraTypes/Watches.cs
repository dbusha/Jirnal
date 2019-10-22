using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Watches
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("watchCount")]
        public long WatchCount { get; set; }

        [JsonProperty("isWatching")]
        public bool IsWatching { get; set; }
    }
}