using System.Windows;
using System.Windows.Controls;

namespace Jirnal.Win.Views.Controls
{
    public partial class LabelAndValueField : UserControl
    {
        public LabelAndValueField()
        {
            InitializeComponent();
        }
        
        
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", 
            typeof(string),
            typeof(LabelAndValueField),
            new FrameworkPropertyMetadata(""));
        
        
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", 
            typeof(string),
            typeof(LabelAndValueField),
            new FrameworkPropertyMetadata(""));


        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }
        
        
        public string Value
        {
            get => (string)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        
        
    }
}