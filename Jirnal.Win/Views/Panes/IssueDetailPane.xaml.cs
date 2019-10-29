using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Jirnal.Win.ViewModels;
using Jirnal.Win.Views.Windows;

namespace Jirnal.Win.Views.Panes
{
    public partial class IssueDetailPane : UserControl
    {
        public IssueDetailPane()
        {
            this.DataContextChanged += OnDataContextChanged_;
            InitializeComponent();
        }

        private async void OnDataContextChanged_(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null || !(e.NewValue is IssueVm issue))
                return;
            await issue.GetComments();
        }

       

        
        private void OnNewWindowClick_(object sender, RoutedEventArgs e)
        {
            var window = new IssueDetailWindow();
            window.DataContext = new IssueVm((IssueVm) DataContext);
            window.Show();
        }

        
        private void OnAddCommentCmdClicked(object sender, RoutedEventArgs e)
        {
            ScrollViewer.ScrollToBottom();
        }
    }
}