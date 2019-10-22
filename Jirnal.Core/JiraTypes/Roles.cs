using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public partial class Roles
    {
        [JsonProperty("Developers")]
        public Uri Developers { get; set; }
    }
}