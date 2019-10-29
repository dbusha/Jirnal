using Tools.Settings;

namespace Jirnal.Core.Settings
{
    public class WindowSettings : SqliteSettings
    {
        public WindowSettings(string section) : base(section)
        {
            
        }

        public WindowSettings(string databasePath, string section) : base(databasePath, section)
        {
        }


        public int Height
        {
            get => (int) this[nameof(Height)];
            set => this[nameof(Height)] = value;
        }
        
        
        public int Width
        {
            get => (int) this[nameof(Width)];
            set => this[nameof(Width)] = value;
        }
        
        
        public int Top 
        {
            get => (int) this[nameof(Top)];
            set => this[nameof(Top)] = value;
        }
        
        
        public int Left 
        {
            get => (int) this[nameof(Left)];
            set => this[nameof(Left)] = value;
        }
    }
}