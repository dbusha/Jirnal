using JiraOAuth.Client;
using Jirnal.Core.Events;
using Jirnal.Core.Settings;
using Tools.ExtensionMethods;
using Tools.Settings;

namespace Jirnal.Core
{
    public class JirnalCore
    {
        private readonly OAuthSettings oauthSettings_;
        
        public JirnalCore()
        {
            oauthSettings_ = new OAuthSettings();
            ProjectSettings = new ProjectSettings();
            JiraProxy = new JiraProxy(oauthSettings_.BaseUrl);
            JiraOAuthClient = new JiraOAuthClient(oauthSettings_.BaseUrl, oauthSettings_.ConsumerKey, oauthSettings_.ConsumerSecret);
            MessageBus = new MessageBus();
            
            if (!oauthSettings_.AccessToken.IsNullOrWhitespace()) {
                JiraProxy.LoadAuthenticator(oauthSettings_);
            }

        }

        
        public JiraOAuthClient JiraOAuthClient { get; }
        public ProjectSettings ProjectSettings { get; }
        public JiraProxy JiraProxy { get; }
        public MessageBus MessageBus { get; }

        
        public void SaveOAuthSettings()
        {
            oauthSettings_.AccessToken = JiraOAuthClient.AccessToken.Token;
            oauthSettings_.AccessTokenSecret = JiraOAuthClient.AccessToken.TokenSecret;
            oauthSettings_.Session = JiraOAuthClient.AccessToken.SessionHandle;
        }

        public void Sample()
        {
           
            
        }
    }
}