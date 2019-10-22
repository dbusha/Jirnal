using System.Windows;
using System.Windows.Forms;
using Jirnal.Core;
using Jirnal.Win.ViewModels;
using Tools.ExtensionMethods;


namespace Jirnal.Win.Views.Windows
{
    public partial class AuthenticationWindow : Window
    {
        private readonly JirnalCore jirnalCore_;
        private readonly AuthenticationVm authVm_;
        
        
        public AuthenticationWindow(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            authVm_ = new AuthenticationVm(jirnalCore);
            DataContext = authVm_;
            InitializeComponent();
            Loaded += OnLoaded_;
            Browser.DocumentCompleted += OnDocumentLoaded_;
        }

        
        private void OnLoaded_(object sender, RoutedEventArgs e)
        {
            authVm_.GetRequestToken();
            Browser.Navigate(jirnalCore_.JiraOAuthClient.GetAuthorizationUrlWithCredentials());
        }


        private void OnDocumentLoaded_(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var url = e.Url.ToString();
            if (DataContext is AuthenticationVm authVm && url.IsEqualToCI(jirnalCore_.JiraOAuthClient.AuthorizationUrl)) {
                // Assume the user has clicked 'Accept'
                authVm.GetAccessToken();
            }
        }


        private void OnCloseClick_(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
    }
}