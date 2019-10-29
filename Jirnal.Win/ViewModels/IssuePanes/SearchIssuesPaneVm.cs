using System.Threading.Tasks;
using Jirnal.Core;

namespace Jirnal.Win.ViewModels.IssuePanes
{
    public class SearchIssuesPaneVm : IssuesPaneBaseVm
    {
        public SearchIssuesPaneVm(JirnalCore jirnalCore, string header) : base(jirnalCore, header)
        {
        }

        
        internal override Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}