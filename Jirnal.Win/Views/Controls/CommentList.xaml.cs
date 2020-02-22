using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Jirnal.Win.ViewModels;
using Jirnal.Win.Views.Windows;
using NLog;

namespace Jirnal.Win.Views.Controls
{
    public partial class CommentList : UserControl
    {
        private readonly Logger logger_ = LogManager.GetCurrentClassLogger();
        
        
        public CommentList()
        {
            InitializeComponent();
        }
        
        
        public static readonly DependencyProperty ItemWidthProperty = DependencyProperty.Register(
            "ItemWidth",
            typeof(double),
            typeof(CommentList),
            new PropertyMetadata()
        );

        
        public double ItemWidth
        {
            get => (double) GetValue(ItemWidthProperty);
            set => SetValue(ItemWidthProperty, value);
        }
        
        
        private void OnPreviewMouseWheel_(object sender, MouseWheelEventArgs e)
        {
            if (e.Handled || !(sender is Control control) || !(control.Parent is UIElement parent)) 
                return;
            
            e.Handled = true;
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta) {
                RoutedEvent = MouseWheelEvent, 
                Source = sender
            };
            parent.RaiseEvent(eventArg);
        }
        

        private void OnEditClicked_(object sender, RoutedEventArgs e)
        {
            var (issue, comment) = GetContext_(e);
            if (issue == null || comment == null)
                return;
            var editWindow = new EditCommentWindow(issue, comment);
            editWindow.Show();
        }


        private (IssueVm, CommentVm) GetContext_(RoutedEventArgs e)
        {
            var frameworkElement = e.Source as FrameworkElement;
            var comment = frameworkElement?.DataContext as CommentVm;
            if (!(DataContext is IssueVm issue) || comment == null) {
                logger_.Error($"Unexecpected argument: DataContext is {DataContext?.GetType().Name ?? "null"}, " 
                              + $"Source is {frameworkElement?.GetType().Name ?? "null"}, and "
                              + $"Button DataContext is {frameworkElement?.DataContext.GetType().Name ?? "null"}");
                return (null, null);
            }

            return (issue, comment);
        }
    }
}