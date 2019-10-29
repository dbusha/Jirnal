using System;

namespace Jirnal.Core.Events
{
    public class LayoutChangedEventArgs : EventArgs 
    {
        public LayoutChangedEventArgs(object sender, LayoutDirection direction)
        {
            Sender = sender;
            Direction = direction;
        }
        
        public LayoutDirection Direction { get; }
        public object Sender { get; }
    }
}