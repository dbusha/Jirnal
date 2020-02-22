using System.Threading.Tasks;
using Jirnal.Core;
using Jirnal.Core.Events;
using Jirnal.Core.JiraTypes;

namespace Jirnal.Win.ViewModels.IssuePanes
{
    public class RecentIssuesPaneVm : IssuesPaneBaseVm
    {
        public RecentIssuesPaneVm(JirnalCore jirnalCore, string header) : base(jirnalCore, header)
        {
            Projects = new ProjectsVm(jirnalCore_);
        }

        
        public ProjectsVm Projects { get; }
        
        
        internal override async Task InitializeAsync()
        {
            await Projects.InitializeAsync();
            
            SearchRequest request = new SearchRequest();
            request.Jql = "issuekey in issueHistory() order by lastViewed DESC";
            request.MaxResults = 50;
            var response = await jirnalCore_.JiraProxy.SearchForIssues(request);
            if (response != null)
                foreach (var issue in response.Issues) {
                    issues_.Add(new IssueVm(jirnalCore_, issue));
                }
        }
    }
}