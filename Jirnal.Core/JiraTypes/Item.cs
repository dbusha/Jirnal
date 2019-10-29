using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Item
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("self")]
        public Uri Self { get; set; }
    }
}