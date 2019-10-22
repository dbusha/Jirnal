using System.Windows;
using Jirnal.Core;
using Jirnal.Win.ViewModels;

namespace Jirnal.Win.Views.Windows
{
    public partial class MainWindow : Window
    {
        private readonly MainVm mainVm_;

        
        public MainWindow()
        {
            var core = new JirnalCore();
            mainVm_ = new MainVm(core);
            DataContext = mainVm_;
            Loaded += OnLoaded_;
            
            InitializeComponent();

            MainMenuBar.Close += Close;
            WindowManager.Singleton.Initialize(core);
        }

        
        private async void OnLoaded_(object sender, RoutedEventArgs e)
        {
            await mainVm_.InitializeAsync();
        }
    }
}