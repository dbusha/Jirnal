using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jirnal.Win.Views.Controls
{
    public partial class CommentList : UserControl
    {
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
    }
}