using System;
using Newtonsoft.Json;

namespace Jirnal.Core.JiraTypes
{
    public partial class IssueFields
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
        public Priority Resolution { get; set; }

        [JsonProperty("resolutiondate")]
        public DateTime? ResolutionDate { get; set; }

        [JsonProperty("workratio")]
        public long WorkRatio { get; set; }

        [JsonProperty("lastViewed")]
        public object LastViewed { get; set; }

        [JsonProperty("watches")]
        public Watches Watches { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("labels")]
        public object[] Labels { get; set; }


        [JsonProperty("timeestimate")]
        public object TimeEstimate { get; set; }

        [JsonProperty("aggregatetimeoriginalestimate")]
        public object AggregateTimeOriginalEstimate { get; set; }

        [JsonProperty("versions")]
        public object[] Versions { get; set; }

        [JsonProperty("issuelinks")]
        public IssueLink[] IssueLinks { get; set; }

        [JsonProperty("assignee")]
        public object Assignee { get; set; }

        [JsonProperty("updated")]
        public DateTime Updated { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("components")]
        public Priority[] Components { get; set; }

        [JsonProperty("timeoriginalestimate")]
        public object TimeOriginalEstimate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("timetracking")]
        public TimeTracking TimeTracking { get; set; }

        [JsonProperty("customfield_10204")]
        public object Customfield10204 { get; set; }

        [JsonProperty("attachment")]
        public object[] Attachment { get; set; }

        [JsonProperty("aggregatetimeestimate")]
        public object AggregatEtimeesTimate { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("creator")]
        public Creator Creator { get; set; }

        [JsonProperty("subtasks")]
        public object[] SubTasks { get; set; }

        [JsonProperty("reporter")]
        public Creator Reporter { get; set; }

        [JsonProperty("aggregateprogress")]
        public Progress AggregateProgress { get; set; }

        [JsonProperty("environment")]
        public object Environment { get; set; }

        [JsonProperty("duedate")]
        public object DueDate { get; set; }

        [JsonProperty("progress")]
        public Progress Progress { get; set; }

        [JsonProperty("comment")]
        public Comment Comment { get; set; }

        [JsonProperty("votes")]
        public Votes Votes { get; set; }

        [JsonProperty("worklog")]
        public Comment WorKLog { get; set; }
    }
}