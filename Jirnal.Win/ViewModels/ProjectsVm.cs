using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using Jirnal.Core;
using Jirnal.Core.Events;
using Jirnal.Core.Settings;
using Tools.ExtensionMethods;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class ProjectsVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;
        private readonly ObservableCollection<ProjectVm> projects_ = new ObservableCollection<ProjectVm>();
        private readonly ProjectSettings settings_;
        private ICommand addToFavoritesCmd_, removeFromFavoritesCmd_;
        private ProjectVm selectedProject_;


        public ProjectsVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            settings_ = jirnalCore_.ProjectSettings;
            Projects = new ListCollectionView(projects_);
            Projects.GroupDescriptions.Add(new PropertyGroupDescription(nameof(ProjectVm.Category)));
            Projects.SortDescriptions.Add(new SortDescription(nameof(ProjectVm.Name), Ascend));
            
            Favorites = new ListCollectionView(projects_);
            Favorites.SortDescriptions.Add(new SortDescription(nameof(ProjectVm.Name), Ascend));
            Favorites.Filter = FavoritesFilter_;

        }
        
        
        public ListCollectionView Projects { get; }
        public ListCollectionView Favorites { get; }

        
        public ProjectVm SelectedProject
        {
            get => selectedProject_;
            set {
                SetValue(ref selectedProject_, value, nameof(SelectedProject));
                jirnalCore_.MessageBus.Publish(new ProjectChangedEventArgs(this, SelectedProject?.Name));
            }
        }

        
        public ICommand AddToFavoritesCmd => CommandHelper(ref addToFavoritesCmd_, AddToFavorites_);
        public ICommand RemoveFromFavoritesCmd => CommandHelper(ref removeFromFavoritesCmd_ , RemoveFromFavorites_);
        
        
        internal async Task InitializeAsync()
        {
            await RefreshProjectsAsync_();
        }
        
        
        private void RemoveFromFavorites_()
        {
            var project = SelectedProject;
            if (project == null)
                return;
            var list = settings_.Favorites;
            list.Remove(project.Key);
            settings_.Favorites = list;
            Favorites.Refresh();
        }


        private void AddToFavorites_()
        {
            var project = SelectedProject;
            if (project == null)
                return;
            var list = settings_.Favorites;
            list.Add(project.Key);
            settings_.Favorites = list;
            Favorites.Refresh();
        }

        
        private bool FavoritesFilter_(object obj)
        {
            if (!(obj is ProjectVm project))
                return false;
            return project.Name.IsEqualToCI(ConstStrings.All) || settings_.Favorites.Any(p => p.IsEqualToCI(project.Key));
        }

        
        private async Task RefreshProjectsAsync_()
        {
            projects_.Clear();
            projects_.Add(new ProjectVm("<ALL>"));
            foreach (var project in await jirnalCore_.JiraProxy.GetProjects()) {
                projects_.Add(new ProjectVm(project));
            } 
        }

        public void SetSelectedProject(ProjectVm project)
        {
            if (SelectedProject != project)
                SelectedProject = project;
            else {
                jirnalCore_.MessageBus.Publish(new ProjectChangedEventArgs(this, SelectedProject?.Name));
            }
        }
    }
}