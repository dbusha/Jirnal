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

        
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
            "Description", typeof(string), typeof(CommentEditorPane), new PropertyMetadata("Add Comment:"));

        public static readonly DependencyProperty IsInAddModeProperty = DependencyProperty.Register(
            "IsInAddMode", typeof(bool), typeof(CommentEditorPane), new PropertyMetadata(true));
        
        public static readonly DependencyProperty IsInEditModeProperty = DependencyProperty.Register(
            "IsInEditMode", typeof(bool), typeof(CommentEditorPane), new PropertyMetadata(false));
        
        public static readonly DependencyProperty CanOpenWindowProperty = DependencyProperty.Register(
            "CanOpenWindow", typeof(bool), typeof(CommentEditorPane), new PropertyMetadata(false));

        
        public string Description
        {
            get => (string)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }
        
        
        public bool IsInAddMode 
        {
            get => (bool)GetValue(IsInAddModeProperty);
            set => SetValue(IsInAddModeProperty, value);
        }
        
        
        public bool IsInEditMode 
        {
            get => (bool)GetValue(IsInEditModeProperty);
            set => SetValue(IsInEditModeProperty, value);
        }
        
        
        public bool CanOpenWindow
        {
            get => (bool)GetValue(CanOpenWindowProperty);
            set => SetValue(CanOpenWindowProperty, value);
        }
        
        
        private void OnOpenCommentWindow_(object sender, RoutedEventArgs e)
        {
            if (!(DataContext is IssueVm issueVm))
                return;
            
            var window = new IssueCommentWindow(new IssueVm(issueVm));
            window.Show();
            issueVm.CancelCommentCmd.Execute(null);
        }
    }
}