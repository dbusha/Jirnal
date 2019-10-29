using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Data;
using Jirnal.Core;
using Jirnal.Core.Events;
using Jirnal.Core.JiraTypes;
using Tools.ExtensionMethods;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels.IssuePanes
{
    public abstract class IssuesPaneBaseVm : ViewModelBase
    {
        protected readonly JirnalCore jirnalCore_;
        protected readonly ObservableCollection<IssueVm> issues_ = new ObservableCollection<IssueVm>();
        private IssueVm selectedIssue_;
        protected string selectedProject_;

        public IssuesPaneBaseVm(JirnalCore jirnalCore, string header)
        {
            Header = header;
            jirnalCore_ = jirnalCore;
            Issues = new ListCollectionView(issues_);
            Issues.Filter = IssueFilter;
            jirnalCore_.MessageBus.SelectedProjectChanged += OnSelectedProjectChanged;

        }


        internal abstract Task InitializeAsync();
        
        
        public ListCollectionView Issues { get; }
        public string Header { get; }


        public IssueVm SelectedIssue
        {
            get => selectedIssue_;
            set => SetValue(ref selectedIssue_, value, nameof(SelectedIssue)); 
        }


        protected virtual void OnSelectedProjectChanged(object sender, ProjectChangedEventArgs e)
        {
            if (e.ProjectName.IsEqualToCI(selectedProject_))
                return;
            selectedProject_ = e.ProjectName;
            Issues.Refresh();
        }

        
        protected virtual bool IssueFilter(object obj)
        {
            if (!(obj is IssueVm issue))
                return false;
            return  selectedProject_.IsNullOrWhitespace()
                    || selectedProject_.IsEqualToCI(issue.ProjectName) 
                    || selectedProject_.IsEqualToCI(ConstStrings.All);
        }
    }
}