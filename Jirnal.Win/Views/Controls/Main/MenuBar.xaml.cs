using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Jirnal.Win.Views.Controls.Main
{
    public partial class MainMenuBar : UserControl
    {
        public MainMenuBar()
        {
            InitializeComponent();
        }

        
        public event Action Close;
        
        
        private void OnClose_(object sender, ExecutedRoutedEventArgs e) => Close?.Invoke();
    }
}