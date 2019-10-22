using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Watcher
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("isWatching")]
        public bool IsWatching { get; set; }

        [JsonProperty("watchCount")]
        public long WatchCount { get; set; }

        [JsonProperty("watchers")]
        public Author[] Watchers { get; set; }
    }
}