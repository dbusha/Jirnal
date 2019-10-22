using System;
using Jirnal.Core.JiraTypes;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class IssueVm : ViewModelBase
    {
        public IssueVm(Issue issue)
        {
            ProjectName = issue.Fields.Project.Name;
            Descritpion = issue.Fields.Description;
            Key = issue.Key;
            Updated = issue.Fields.Updated;
            Title = issue.Fields.Summary;
        }
        
        public string ProjectName { get; }
        public string Descritpion { get; }
        public string Key { get; }
        public DateTime Updated { get; }
        public string Title { get; }
    }
}