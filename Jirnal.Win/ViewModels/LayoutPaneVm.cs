using System.Threading.Tasks;
using Jirnal.Core;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class LayoutPaneVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;

        public LayoutPaneVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            Projects = new ProjectsVm(jirnalCore_);
            Issues = new IssuesVm(jirnalCore);
        }

        
        internal async Task InitializeAsync()
        {
            await Projects.InitializeAsync();
            await Issues.InitializeAsync();

        }
        
        
        public ProjectsVm Projects { get; }
        public IssuesVm Issues { get; }
        public IssueVm Issue { get; }
    }
}