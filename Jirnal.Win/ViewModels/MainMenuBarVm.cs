using System.Windows.Input;
using Jirnal.Core;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class MainMenuBarVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;
        private ICommand openAuthCmd_;

        public MainMenuBarVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
        }


        public ICommand OpenAuthenticationCmd => CommandHelper(ref openAuthCmd_, WindowManager.Singleton.OpenAuthWindow);
    }
}