using System;
using System.Windows;
using Jirnal.Core;
using Jirnal.Win.Views.Windows;


namespace Jirnal.Win.ViewModels
{
    public class WindowManager
    {
        private static readonly Lazy<WindowManager> lazy_ = new Lazy<WindowManager>(()=> new WindowManager());
        private JirnalCore jirnalCore_;


        private WindowManager() { }


        public static WindowManager  Singleton => lazy_.Value;
        public MainWindow MainWindow => (MainWindow)Application.Current?.MainWindow;
        public AuthenticationWindow AuthenticationWindow { get; private set; }
        public IssueFieldManagerWindow IssueFieldManager { get; private set; }


        public void Initialize(JirnalCore core)
        {
            jirnalCore_ = core;
        }
        
        
        public void OpenAuthWindow()
        {
            if (AuthenticationWindow == null) {
                AuthenticationWindow = new AuthenticationWindow(jirnalCore_) {Owner = MainWindow};
                AuthenticationWindow.Closed += (sender, args) => AuthenticationWindow = null; 
                AuthenticationWindow.Show();
            }

            AuthenticationWindow.Activate();
        }

        public void OpenIssueFieldManager()
        {
            if (IssueFieldManager == null) {
                var vm = new IssueFieldManagerVm(jirnalCore_);
                IssueFieldManager = new IssueFieldManagerWindow(vm) {Owner = MainWindow};
                IssueFieldManager.Closed += (sender, args) => IssueFieldManager = null; 
                IssueFieldManager.Show();
            }

            IssueFieldManager.Activate();
        }
    }
}