using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JiraOAuth.Client;
using Jirnal.Core.JiraTypes;
using Jirnal.Core.Settings;
using Newtonsoft.Json;
using NLog;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using Tools.Settings;


namespace Jirnal.Core
{
    public class JiraProxy
    {
        private static readonly Logger logger_ = LogManager.GetCurrentClassLogger();
        private readonly RestClient client_;

        private readonly Dictionary<string, string> requestUrls_;

        private const string ProjectUrl = "project";
        private const string SearchUrl = "search";


        public JiraProxy(string baseUrl)
        {
            client_ = new RestClient(baseUrl);
            requestUrls_ = new Dictionary<string, string>
            {
                {SearchUrl, $"{baseUrl}/rest/api/2/search"},
                {ProjectUrl, $"{baseUrl}/rest/api/2/project"}
            };
        }


        public void SetAuthenticator(IAuthenticator authenticator) => client_.Authenticator = authenticator;


        public void LoadAuthenticator(OAuthSettings settings)
        {
            var consumer = new ConsumerCredentials(settings.ConsumerKey, settings.ConsumerSecret);
            client_.Authenticator = OAuth1Authenticator.ForProtectedResource(
                consumer.Key,
                consumer.Secret,
                settings.AccessToken,
                settings.AccessTokenSecret,
                OAuthSignatureMethod.RsaSha1);
        }


        public async Task<ICollection<JiraProject>> GetProjects()
        {
            try {
                var request = new RestRequest(requestUrls_[ProjectUrl]);
                var response = await client_.ExecuteTaskAsync(request);
                var projects = JsonConvert.DeserializeObject<JiraProject[]>(response.Content, Converter.Settings);
                return projects;
            } catch (Exception err) {
                logger_.Error(err);
            }

            return null;
        }


        public async Task<SearchResult> SearchForIssues(SearchRequest searchRequest)
        {
            try {
                var jsonSearch = JsonConvert.SerializeObject(searchRequest);
                var request = new RestRequest(requestUrls_[SearchUrl], Method.POST);
                request.AddJsonBody(jsonSearch);
                var response = await client_.ExecuteTaskAsync(request);
                var issues = JsonConvert.DeserializeObject<SearchResult>(response.Content, Converter.Settings);
                return issues;
            } catch (Exception err) {
                logger_.Error(err);
            }

            return null;
        }
    }
}