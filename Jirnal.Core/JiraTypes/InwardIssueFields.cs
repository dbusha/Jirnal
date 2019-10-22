using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class InwardIssueFields
    {
        [JsonProperty("status")]
        public Status Status { get; set; }
    }
}