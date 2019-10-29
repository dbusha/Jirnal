using System.Windows.Controls;
using System.Windows.Input;
using Jirnal.Win.ViewModels;

namespace Jirnal.Win.Views.Panes
{
    public partial class ProjectsPane : UserControl
    {
        public ProjectsPane()
        {
            InitializeComponent();
        }

        
        private void OnListBoxItemClicked_(object sender, MouseButtonEventArgs e)
        {
            if (!(DataContext is ProjectsVm projectPaneVm) || !(FavoritesList.SelectedItem is ProjectVm project))
                return;
            projectPaneVm.SetSelectedProject(project);
        }
    }
}