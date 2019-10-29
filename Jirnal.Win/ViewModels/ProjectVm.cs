using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class ProjectVm : ViewModelBase
    {
        public ProjectVm(string projectName)
        {
            Name = projectName;
        }
        
        
        
        public ProjectVm(Core.JiraTypes.JiraProject project)
        {
            Name = project.Name;
            Key = project.Key;
            Description = project.Description;
            Category = project.ProjectCategory?.Name;
        }

        public string Description { get; }
        public string Name { get; }
        public string Key { get; }
        public string Category { get; }
        
    }
}