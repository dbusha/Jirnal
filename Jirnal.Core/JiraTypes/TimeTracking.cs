using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class TimeTracking
    {
        [JsonProperty("originalEstimate")]
        public string OriginalEstimate { get; set; }

        [JsonProperty("remainingEstimate")]
        public string RemainingEstimate { get; set; }

        [JsonProperty("timeSpent")]
        public string TimeSpent { get; set; }

        [JsonProperty("originalEstimateSeconds")]
        public long OriginalEstimateSeconds { get; set; }

        [JsonProperty("remainingEstimateSeconds")]
        public long RemainingEstimateSeconds { get; set; }

        [JsonProperty("timeSpentSeconds")]
        public long TimeSpentSeconds { get; set; }
    }
}