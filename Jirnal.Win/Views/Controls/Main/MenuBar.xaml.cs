using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Jirnal.Win.ViewModels;
using Jirnal.Win.Views.Windows;

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