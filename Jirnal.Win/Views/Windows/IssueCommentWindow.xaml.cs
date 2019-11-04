using System.Windows;
using Jirnal.Win.ViewModels;

namespace Jirnal.Win.Views.Windows
{
    public partial class IssueCommentWindow : Window
    {
        public IssueCommentWindow(IssueVm issueVm)
        {
            issueVm.CancelComment += Close;
            DataContext = issueVm;
            InitializeComponent();
            
            CommentPane.Description = "Add Comment:";
            CommentPane.IsInAddMode = true;
            CommentPane.IsInEditMode = false;
            CommentPane.CanOpenWindow = false;
        }
        
        
        public IssueCommentWindow(IssueVm issueVm, CommentVm comment)
        {
            issueVm.CancelComment += Close;
            DataContext = issueVm;
            issueVm.CommentText = comment.Body;
            
            InitializeComponent();
            CommentPane.Description = "Edit Comment:";
            CommentPane.IsInEditMode = true;
            CommentPane.IsInAddMode = false;
            CommentPane.CanOpenWindow = false;
        }
    }

}