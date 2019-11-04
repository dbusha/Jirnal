using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public class IssueFields
    {
        [JsonProperty("issuetype")]
        public IssueType IssueType { get; set; }

        [JsonProperty("timespent")]
        public object TimeSpent { get; set; }

        [JsonProperty("project")]
        public JiraProject Project { get; set; }

        [JsonProperty("fixVersions")]
        public object[] FixVersions { get; set; }

        [JsonProperty("aggregatetimespent")]
        public object AggregateTimeSpent { get; set; }

        [JsonProperty("resolution")]
        public Resolution Resolution { get; set; }

        [JsonProperty("resolutiondate")]
        public DateTime? ResolutionDate { get; set; }

        [JsonProperty("workratio")]
        public long WorkRatio { get; set; }

        [JsonProperty("lastViewed")]
        public DateTime LastViewed { get; set; }

        [JsonProperty("watches")]
        public Watches Watches { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("labels")]
        public string[] Labels { get; set; }

        [JsonProperty("timeestimate")]
        public object TimeEstimate { get; set; }

        [JsonProperty("aggregatetimeoriginalestimate")]
        public object AggregateTimeOriginalEstimate { get; set; }

        [JsonProperty("versions")]
        public Version[] Versions { get; set; }

        [JsonProperty("issuelinks")]
        public IssueLink[] IssueLinks { get; set; }

        [JsonProperty("assignee")]
        public JiraUser Assignee { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("components")]
        public Component[] Components { get; set; }

        [JsonProperty("timeoriginalestimate")]
        public object TimeOriginalEstimate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("timetracking")]
        public TimeTracking TimeTracking { get; set; }

        [JsonProperty("attachment")]
        public object[] Attachment { get; set; }

        [JsonProperty("aggregatetimeestimate")]
        public object AggregatEtimeesTimate { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("creator")]
        public Creator Creator { get; set; }

        [JsonProperty("subtasks")]
        public SubTask[] SubTasks { get; set; }

        [JsonProperty("reporter")]
        public Creator Reporter { get; set; }

        [JsonProperty("aggregateprogress")]
        public JiraProgress AggregateProgress { get; set; }

        [JsonProperty("environment")]
        public object Environment { get; set; }

        [JsonProperty("duedate")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("progress")]
        public JiraProgress Progress { get; set; }

        [JsonProperty("comment")]
        public Comment[] Comments { get; set; }

        [JsonProperty("votes")]
        public Votes Votes { get; set; }

        [JsonProperty("worklog")]
        public WorkLog WorkLog { get; set; }
        
        [JsonProperty("customfield_10501")]
        public string[] RawSprintField { get; set; }
        
        public string[] Sprints {
            get {
                var sprints = new List<string>();
                if (RawSprintField == null || !RawSprintField.Any())
                    return sprints.ToArray();
                
                foreach (var sprint in RawSprintField) {
                    var array = sprint.Split(new[] {'[', ']'}, StringSplitOptions.RemoveEmptyEntries);
                    var keyValuePairs = array[1].Split(',', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var kv in keyValuePairs) {
                        var pair = kv.Split('=', StringSplitOptions.RemoveEmptyEntries);
                        if(pair.Length>1 && pair[0].Equals("name"))
                            sprints.Add(pair[1]);
                    }
                }
                return sprints.ToArray();
            }
            
        }
    }
}