using System.Windows;
using System.Windows.Controls;
using Jirnal.Win.ViewModels;
using Jirnal.Win.Views.Windows;

namespace Jirnal.Win.Views.Panes
{
    public partial class CommentEditorPane : UserControl
    {
        public CommentEditorPane()
        {
            InitializeComponent();
        }

        
        private void OnOpenCommentWindow_(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is IssueVm issueVm))
                return;
            
            var window = new EditCommentWindow(new IssueVm(issueVm), null);
            window.Show();
            issueVm.CancelCommentCmd.Execute(null);
        }
    }
}