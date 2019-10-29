using System;

namespace Jirnal.Core.Events
{
    public class MessageBus
    {
        public event EventHandler<LayoutChangedEventArgs> LayoutChangeRequest;
        public event EventHandler<ProjectChangedEventArgs> SelectedProjectChanged;


        public void Publish(EventArgs message)
        {
            switch (message) {
                case LayoutChangedEventArgs layoutChange: {
                    LayoutChangeRequest?.Invoke(layoutChange.Sender, layoutChange);
                    break;
                }
                case ProjectChangedEventArgs project: {
                    SelectedProjectChanged?.Invoke(project.Sender, project);
                    break;
                }
                default: break;
            }
        }
    }
}