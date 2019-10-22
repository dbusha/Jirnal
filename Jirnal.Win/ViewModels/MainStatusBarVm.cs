using Jirnal.Core;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class MainStatusBarVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;
        private bool isRunning_;
        private string status_;
        

        public MainStatusBarVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            Status = "Test";
        }


        public string Status
        {
            get => status_;
            set => SetValue(ref status_, value, nameof(Status));
        }


        public bool IsRunning
        {
            get => isRunning_;
            set => SetValue(ref isRunning_, value, nameof(IsRunning));
        }
    }
}