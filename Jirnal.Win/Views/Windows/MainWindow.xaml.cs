using System.Windows;
using System.Windows.Forms;
using Jirnal.Core;
using Jirnal.Core.Events;
using Jirnal.Win.ViewModels;
using Jirnal.Win.Views.Controls.Main;
using Jirnal.Win.Views.Panes;

namespace Jirnal.Win.Views.Windows
{
    public partial class MainWindow : Window
    {
        private readonly MainVm mainVm_;
        private JirnalCore jirnalCore_; 
            
            
        public MainWindow()
        {
            jirnalCore_ = new JirnalCore();
            mainVm_ = new MainVm(jirnalCore_);
            DataContext = mainVm_;
            Loaded += OnLoaded_;
            
            InitializeComponent();

            MainMenuBar.Close += Close;
            WindowManager.Singleton.Initialize(jirnalCore_);
            jirnalCore_.MessageBus.LayoutChangeRequest += OnLayoutChangeRequest_;
            mainVm_.StatusBar.SetSelectedLayout();
        }
        

        private void OnLayoutChangeRequest_(object sender, LayoutChangedEventArgs e)
        {
            if (!(sender is MainStatusBarVm))
                return;
            LayoutGrid.Children.Clear();
            if (e.Direction == LayoutDirection.Vertical) {
                LayoutGrid.Children.Add(new VerticalLayoutPane(mainVm_.Layout));
            }
            else {
                LayoutGrid.Children.Add(new HorizontalLayoutPane(mainVm_.Layout));
            }
        }


        private async void OnLoaded_(object sender, RoutedEventArgs e)
        {
            var (isAuthenticated, reason) = await jirnalCore_.Authenticate();
            if (isAuthenticated) {
                await mainVm_.InitializeAsync();
                mainVm_.StatusBar.Status = "Ready";
            }
            else
                mainVm_.StatusBar.Status = reason;
        }
    }
}