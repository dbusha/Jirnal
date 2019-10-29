using System.Windows;
using System.Windows.Controls;
using Jirnal.Win.ViewModels;
using Jirnal.Win.Views.Windows;

namespace Jirnal.Win.Views.Panes
{
    public partial class AddCommentPane : UserControl
    {
        public AddCommentPane()
        {
            InitializeComponent();
        }

        
        private void OnOpenCommentWindow_(object sender, RoutedEventArgs e)
        {
            var window = new IssueCommentWindow(new IssueVm(DataContext as IssueVm));
            window.Show();
        }
    }
}