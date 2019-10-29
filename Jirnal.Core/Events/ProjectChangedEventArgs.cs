namespace Jirnal.Core.Events
{
    public class ProjectChangedEventArgs : System.EventArgs
    {
        public ProjectChangedEventArgs(object sender, string projectName)
        {
            Sender = sender;
            ProjectName = projectName;
        }


        public object Sender { get; }
        public string ProjectName { get; }

    }
}