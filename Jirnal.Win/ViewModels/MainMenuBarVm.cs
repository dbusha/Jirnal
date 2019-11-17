using System.Windows.Input;
using Jirnal.Core;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class MainMenuBarVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;
        private ICommand openAuthCmd_;
        private ICommand openFieldManagerCmd_;

        public MainMenuBarVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
        }


        public ICommand OpenAuthenticationCmd => CommandHelper(ref openAuthCmd_, WindowManager.Singleton.OpenAuthWindow);

        public ICommand OpenIssueFieldManager => CommandHelper(ref openFieldManagerCmd_, WindowManager.Singleton.OpenIssueFieldManager);
    }
}