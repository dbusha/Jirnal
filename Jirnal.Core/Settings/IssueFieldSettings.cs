namespace Jirnal.Core.Settings
{
    public class IssueFieldSettings : Tools.Settings.SqliteSettings
    {
        public IssueFieldSettings() : base("IssueFieldSettings")
        {
            
        }

        public IssueFieldSettings(string databasePath) : base(databasePath, "IssueFieldSettings")
        {
            
        }
    }
}