using System.Threading.Tasks;
using Jirnal.Core;

namespace Jirnal.Win.ViewModels.IssuePanes
{
    public class PinnedIssuesPaneVm : IssuesPaneBaseVm
    {
        public PinnedIssuesPaneVm(JirnalCore jirnalCore, string header) : base(jirnalCore, header)
        {
        }

        internal override async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }
    }
}