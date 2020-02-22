using System.Windows.Controls;
using Jirnal.Win.ViewModels;

namespace Jirnal.Win.Views.Panes.LayoutPanes
{
    public partial class VerticalLayoutPane : UserControl
    {
        public VerticalLayoutPane()
        {
            InitializeComponent();
        }
        
        
        public VerticalLayoutPane(LayoutPaneVm dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}