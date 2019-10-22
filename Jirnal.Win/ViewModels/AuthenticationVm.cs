using System;
using Jirnal.Core;
using NLog;
using Tools.UI.WPF;

namespace Jirnal.Win.ViewModels
{
    public class AuthenticationVm : ViewModelBase
    {
        private static Logger logger_ = LogManager.GetCurrentClassLogger();
        private readonly JirnalCore jirnalCore_;
        private bool isBrowserVisible_;
        private string status_;
        private bool isConfirmationVisible_;
        private bool hasError_;

        
        public AuthenticationVm(JirnalCore jirnalCore)
        {
            jirnalCore_ = jirnalCore;
            IsBrowserVisible = true;
            IsConfirmationVisible = false;
            HasError = false;
        }


        public bool IsBrowserVisible
        {
            get => isBrowserVisible_;
            set => SetValue(ref isBrowserVisible_, value, nameof(IsBrowserVisible));
        }

        
        public bool IsConfirmationVisible
        {
            get => isConfirmationVisible_;
            set => SetValue(ref isConfirmationVisible_, value, nameof(IsConfirmationVisible));
        }


        public bool HasError
        {
            get => hasError_;
            set => SetValue(ref hasError_, value, nameof(HasError));
        }


        public string Status
        {
            get => status_;
            set => SetValue(ref status_, value, nameof(Status));
        }

        
        public void GetRequestToken()
        {
            try { jirnalCore_.JiraOAuthClient.GetRequestToken(); } 
            catch (Exception err) {
                logger_.Error(err);
                HasError = true;
                Status = "An error has occurred. Check your log file and confirm your settings before attempting to re-authenticate."; 
                IsBrowserVisible = false;
                IsConfirmationVisible = true;
            }
        }
        
        
        public void GetAccessToken()
        {
            try {
                jirnalCore_.JiraOAuthClient.GetAccessToken();
                jirnalCore_.SaveOAuthSettings();
                
                Status = "Congratulations! You've successfully authorized Jirnal. Close this window to continue " +
                         "using the application.";
                
            } catch (Exception err) {
                logger_.Error(err);
                Status = "An error has occurred. Check your log file and confirm your settings before attempting to re-authenticate.";
                HasError = true;
            }
            IsBrowserVisible = false;
            IsConfirmationVisible = true;
        }
    }
}