using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;
using Jirnal.Core;
using Jirnal.Core.JiraTypes;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class IssuesVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;
        private readonly ObservableCollection<IssueVm> issues_ = new ObservableCollection<IssueVm>();
        
        
        public IssuesVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            Issues = new ListCollectionView(issues_);
            
        }

        internal async Task InitializeAsync()
        {
            SearchRequest request = new SearchRequest();
            request.Jql = "issuekey in issueHistory() order by lastViewed DESC";
            request.MaxResults = 50;
            var response = await jirnalCore_.JiraProxy.SearchForIssues(request);
            foreach(var issue in response.Issues)
                issues_.Add(new IssueVm(issue));
        }
        
        
        public ListCollectionView Issues { get; }
    }
}