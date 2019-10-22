using System.Threading.Tasks;
using Jirnal.Core;

namespace Jirnal.Win.ViewModels
{
    public class MainVm
    {
        private JirnalCore jirnalCore_;

        public MainVm(JirnalCore core)
        {
            jirnalCore_ = core;

            StatusBar = new MainStatusBarVm(jirnalCore_);
            MenuBar = new MainMenuBarVm(jirnalCore_);
            Layout = new LayoutPaneVm(jirnalCore_);
        }

        internal async Task InitializeAsync()
        {
            await Layout.InitializeAsync();
        }
        
        
        public MainStatusBarVm StatusBar { get; }
        public MainMenuBarVm MenuBar { get; }
        public LayoutPaneVm Layout { get; }
    }
}