using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Status
    {
        [JsonProperty("iconUrl")]
        public Uri IconUrl { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}