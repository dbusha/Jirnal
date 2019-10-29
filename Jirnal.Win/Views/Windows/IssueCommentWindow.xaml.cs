using System.Windows;
using Jirnal.Win.ViewModels;

namespace Jirnal.Win.Views.Windows
{
    public partial class IssueCommentWindow : Window
    {
        public IssueCommentWindow(IssueVm issueVm)
        {
            DataContext = issueVm;
            InitializeComponent();
        }
    }
}