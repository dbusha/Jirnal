using System.Threading.Tasks;
using Jirnal.Core;
using Jirnal.Core.Events;
using Jirnal.Core.Settings;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class MainStatusBarVm : ViewModelBase
    {
        private readonly JirnalCore jirnalCore_;
        private bool isRunning_;
        private string status_;
        private bool isVerticalChecked_;
        private bool isHorizontalChecked_;


        public MainStatusBarVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            Settings = new StatusBarSettings();
            Status = "Test";
        }


        public StatusBarSettings Settings { get; }


        public string Status
        {
            get => status_;
            set => SetValue(ref status_, value, nameof(Status));
        }


        public bool IsRunning
        {
            get => isRunning_;
            set => SetValue(ref isRunning_, value, nameof(IsRunning));
        }

        
        public bool IsVerticalChecked
        {
            get => isVerticalChecked_;
            set {
                isHorizontalChecked_ = !value;
                SetValue(ref isVerticalChecked_, value, nameof(IsVerticalChecked), nameof(IsHorizontalChecked));
                jirnalCore_.MessageBus.Publish(new LayoutChangedEventArgs(this, LayoutDirection.Vertical));
                Settings.LayoutDirection = (int)LayoutDirection.Vertical;
            }
        }

        
        public bool IsHorizontalChecked
        {
            get => isHorizontalChecked_;
            set {
                isVerticalChecked_ = !value;
                SetValue(ref isHorizontalChecked_, value, nameof(IsHorizontalChecked), nameof(IsVerticalChecked));
                jirnalCore_.MessageBus.Publish(new LayoutChangedEventArgs(this, LayoutDirection.Horizontal));
                Settings.LayoutDirection = (int)LayoutDirection.Horizontal;
            }
        }
        
        
        public void SetSelectedLayout()
        {
            if ((LayoutDirection) Settings.LayoutDirection == LayoutDirection.Vertical)
                IsVerticalChecked = true;
            else {
                IsHorizontalChecked = true;
            }
        }
    }
}