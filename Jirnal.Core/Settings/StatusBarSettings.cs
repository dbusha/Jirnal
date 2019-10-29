using System.ComponentModel;
using Tools.Settings;

namespace Jirnal.Core.Settings
{
    public class StatusBarSettings : SqliteSettings
    {
        public StatusBarSettings() : base("StatusBar") { }
        public StatusBarSettings(string databasePath) : base(databasePath, "StatusBar") { }


        [DefaultValue((int)Core.LayoutDirection.Vertical)]
        public int LayoutDirection
        {
            get => (int) this[nameof(LayoutDirection)];
            set => this[nameof(LayoutDirection)] = value;
        } 
    }
}