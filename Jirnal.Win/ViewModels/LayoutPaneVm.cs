using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;
using Jirnal.Core;
using Jirnal.Win.ViewModels.IssuePanes;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class LayoutPaneVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;
        private readonly ObservableCollection<IssuesPaneBaseVm> issuePanes_ = new ObservableCollection<IssuesPaneBaseVm>();
        private IssuesPaneBaseVm selectedTab_;

        public LayoutPaneVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            Projects = new ProjectsVm(jirnalCore_);
            IssuePanes = new ListCollectionView(issuePanes_);
            issuePanes_.Add(new RecentIssuesPaneVm(jirnalCore, "Recent"));
            issuePanes_.Add(new SearchIssuesPaneVm(jirnalCore, "Search"));
        }

        
        internal async Task InitializeAsync()
        {
            await Projects.InitializeAsync();
            foreach (var pane in issuePanes_)
                await pane.InitializeAsync();
        }
        
        
        public ProjectsVm Projects { get; }
        public ListCollectionView IssuePanes { get; }

        public IssuesPaneBaseVm SelectedTab
        {
            get => selectedTab_;
            set => SetValue(ref selectedTab_, value, nameof(SelectedTab));
        }
    }
}