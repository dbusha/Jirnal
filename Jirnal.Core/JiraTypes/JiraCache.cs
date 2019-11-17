namespace Jirnal.Core.JiraTypes
{
    public class JiraCache
    {
        public JiraProfile Profile { get; set; }
        public JiraFieldLookup JiraFieldLookup { get; } = new JiraFieldLookup();
    }
}