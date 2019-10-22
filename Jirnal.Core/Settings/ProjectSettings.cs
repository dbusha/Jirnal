using System.Collections.Generic;
using System.Linq;
using Tools.Settings;

namespace Jirnal.Core.Settings
{
    public class ProjectSettings : SqliteSettings
    {
        public ProjectSettings() : base("JiraProject")
        {
        }
        
        
        public ProjectSettings(string path) : base(path, "JiraProjects")
        { }

        
        public List<string> Favorites
        {
            get => ((string) this[nameof(Favorites)])?.Split(',').ToList() ?? new List<string>();
            set => this[nameof(Favorites)] = string.Join(',', value);
        }

    }
}