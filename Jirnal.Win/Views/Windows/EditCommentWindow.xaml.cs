using System.Windows;
using Jirnal.Win.ViewModels;

namespace Jirnal.Win.Views.Windows
{
    public partial class EditCommentWindow : Window
    {
        public EditCommentWindow(IssueVm issueVm, CommentVm comment)
        {
            issueVm.CancelComment += Close;
            DataContext = issueVm;
            issueVm.CommentText = comment.Body;
            
            InitializeComponent();
        }
    }

}