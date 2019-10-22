using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class Votes
    {
        [JsonProperty("self")]
        public Uri Self { get; set; }

        [JsonProperty("votes")]
        public long VotesVotes { get; set; }

        [JsonProperty("hasVoted")]
        public bool HasVoted { get; set; }
    }
}