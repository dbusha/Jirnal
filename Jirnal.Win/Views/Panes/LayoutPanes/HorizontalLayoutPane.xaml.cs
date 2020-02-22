using System.Windows.Controls;
using Jirnal.Win.ViewModels;

namespace Jirnal.Win.Views.Panes.LayoutPanes
{
    public partial class HorizontalLayoutPane : UserControl
    {
        public HorizontalLayoutPane()
        {
            InitializeComponent();
        }
        
        
        
        public HorizontalLayoutPane(LayoutPaneVm dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}