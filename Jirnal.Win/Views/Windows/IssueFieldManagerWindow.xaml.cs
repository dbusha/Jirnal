using System.Windows;
using System.Windows.Input;
using Jirnal.Win.ViewModels;

namespace Jirnal.Win.Views.Windows
{
    public partial class IssueFieldManagerWindow : Window
    {
        public IssueFieldManagerWindow()
        {
            InitializeComponent();
        }
        
        
        public IssueFieldManagerWindow(IssueFieldManagerVm issueFieldManagerVm)
        {
            DataContext = issueFieldManagerVm;
            InitializeComponent();
        }

        private void OnCloseCmd_(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}