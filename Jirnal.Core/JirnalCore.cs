using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using JiraOAuth.Client;
using Jirnal.Core.Events;
using Jirnal.Core.JiraTypes;
using Jirnal.Core.Settings;
using Tools.ExtensionMethods;
using Tools.Settings;


namespace Jirnal.Core
{
    public class JirnalCore
    {
        private bool isAuthenticated_;
        private readonly OAuthSettings oauthSettings_;
        private readonly JiraProxy jiraProxy_;

        public JirnalCore()
        {
            oauthSettings_ = new OAuthSettings();
            ProjectSettings = new ProjectSettings();
            jiraProxy_ = new JiraProxy(oauthSettings_.BaseUrl);
            JiraOAuthClient = new JiraOAuthClient(oauthSettings_.BaseUrl, oauthSettings_.ConsumerKey, oauthSettings_.ConsumerSecret);
            MessageBus = new MessageBus();
        }

        
        public JiraOAuthClient JiraOAuthClient { get; }
        public ProjectSettings ProjectSettings { get; }
        public JiraProxy JiraProxy => isAuthenticated_ ? jiraProxy_ : throw new AuthenticationException("Not Authenticated");
        public MessageBus MessageBus { get; }
        public JiraCache JiraCache { get; }= new JiraCache();

        
        public async Task<(bool,string)> Authenticate()
        {
            if (oauthSettings_.AccessToken.IsNullOrWhitespace()) 
                return (false, "No OAuth credentials");

            jiraProxy_.LoadOAuthAuthenticator(oauthSettings_);
            var profile = await jiraProxy_.GetProfile();
            if (profile == null) 
                return (false, "Could not verify login");

            isAuthenticated_ = true;
            JiraCache.Profile = profile;
            JiraCache.JiraFieldLookup.AddFields(await JiraProxy.GetAllFields());
            return (isAuthenticated_, "");
        }
        

        public void SaveOAuthSettings()
        {
            oauthSettings_.AccessToken = JiraOAuthClient.AccessToken.Token;
            oauthSettings_.AccessTokenSecret = JiraOAuthClient.AccessToken.TokenSecret;
            oauthSettings_.Session = JiraOAuthClient.AccessToken.SessionHandle;
        }

        
        public void SaveColumnLayout(IEnumerable<FieldDefinition> fields)
        {
            
        }
    }
}