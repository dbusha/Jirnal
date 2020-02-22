using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Net;
using System.Security.Authentication;
using System.Threading.Tasks;
using JiraOAuth.Client;
using Jirnal.Core.JiraTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NLog;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using Tools.ExtensionMethods;
using Tools.Settings;


namespace Jirnal.Core
{
    public class JiraProxy
    {
        private static readonly Logger logger_ = LogManager.GetCurrentClassLogger();
        private readonly RestClient client_;
        private readonly Dictionary<string, string> requestUrls_;

        private const string ProjectUrl = "Project";
        private const string SearchUrl = "Search";
        private const string CommentsUrl = "Comments";
        private const string UpdateOrDeleteCommentUrl = "UpdateComments";
        private const string GetCustomFieldsUrl = "GetCustomFields";
        private const string GetMyself = "GetMyself";
        private const string GetFields = "GetFields";

        
        private readonly JsonSerializerSettings serializerSettings_ = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = { new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal } },
        };
        
        
        public JiraProxy(string baseUrl)
        {
            client_ = new RestClient(baseUrl);
            var apiPath = $"{baseUrl}/rest/api/2";
            
            requestUrls_ = new Dictionary<string, string>
            {
                {GetMyself, $"{apiPath}/myself"},
                {SearchUrl, $"{apiPath}/search"},
                {ProjectUrl, $"{apiPath}/project"},
                {CommentsUrl, $"{apiPath}/issue/{{0}}/comment"},
                {UpdateOrDeleteCommentUrl, $"{apiPath}/issue/{{0}}/comment/{{1}}"},
                {GetCustomFieldsUrl, $"{apiPath}/customFields"},
                {GetFields, $"{apiPath}/field"},
            };
        }


        
        
        public void SetAuthenticator(IAuthenticator authenticator) => client_.Authenticator = authenticator;


        public void LoadOAuthAuthenticator(OAuthSettings settings)
        {
            if (settings.AccessToken.IsNullOrWhitespace() || settings.AccessTokenSecret.IsNullOrWhitespace())
                throw new AuthenticationException("Missing access token or secret. Cannot create Authenticator");
            
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
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<JiraProject[]>(response.Content, serializerSettings_);
                
                logger_.Error(BuildError_(response, "Failed to get projects"));
            } 
            catch (Exception err) { logger_.Error(err); }
            return new Collection<JiraProject>();
        }


        public async Task<SearchResult> SearchForIssues(SearchRequest searchRequest)
        {
            try {
                var jsonSearch = JsonConvert.SerializeObject(searchRequest);
                var request = new RestRequest(requestUrls_[SearchUrl], Method.POST);
                request.AddJsonBody(jsonSearch);
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode == HttpStatusCode.OK) 
                    return JsonConvert.DeserializeObject<SearchResult>(response.Content, serializerSettings_);

                logger_.Error(BuildError_(response, "Issue search failed"));
            } catch (Exception err) { logger_.Error(err); }
            return null;
        }

        
        public CustomFields GetCustomFields()
        {
            try {
                var url = requestUrls_[GetCustomFieldsUrl];
                var request = new RestRequest(url, Method.GET);
                var response = client_.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK) 
                    return JsonConvert.DeserializeObject<CustomFields>(response.Content, serializerSettings_);
                
                logger_.Error(BuildError_(response, "Failed to get comments"));
            } 
            catch (Exception err) { logger_.Error(err); }
            return null;
        }
        
        
        public async Task<Comments> GetComments(string key)
        {
            try {
                var url = string.Format(requestUrls_[CommentsUrl], key);
                var request = new RestRequest(url, Method.GET);
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode != HttpStatusCode.NotFound) 
                    return JsonConvert.DeserializeObject<Comments>(response.Content, serializerSettings_);

                logger_.Error(BuildError_(response, "Failed to get comments"));
            } 
            catch (Exception err) { logger_.Error(err); }
            return null;
        }
        

        public async Task<bool> AddComment(string commentText, string issueKey)
        {
            try {
                var comment = new CommentAddUpdate {Body = commentText};
                var url = string.Format(requestUrls_[CommentsUrl], issueKey);
                var request = new RestRequest(url, Method.POST);
                request.AddJsonBody(JsonConvert.SerializeObject(comment));
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode == HttpStatusCode.Created) 
                    return true;
                
                logger_.Error(BuildError_(response, "Failed to add comment"));
            } 
            catch (Exception err) { logger_.Error(err); }
            return false; 
        }


        public async Task<bool> EditComment(string commentText, string issueKey, int commentId)
        {
            try {
                var comment = new CommentAddUpdate {Body = commentText};
                var url = string.Format(requestUrls_[UpdateOrDeleteCommentUrl], issueKey, commentId);
                var request = new RestRequest(url, Method.PUT);
                request.AddJsonBody(JsonConvert.SerializeObject(comment));
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode == HttpStatusCode.OK) 
                    return true;
                
                logger_.Error(BuildError_(response, "Failed to edit comment"));
            } 
            catch (Exception err) { logger_.Error(err); }
            return false;
        }
        
        
        public async Task<bool> DeleteComment(string issueKey, long commentId)
        {
            try {
                var url = string.Format(requestUrls_[UpdateOrDeleteCommentUrl], issueKey, commentId);
                var request = new RestRequest(url, Method.DELETE);
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
                
                logger_.Error($"{response.StatusCode} Failed to edit comment: {response.Content}");
                return false;
            } catch (Exception err) {
                logger_.Error(err);
                return false;
            }
        }

        
        public async Task<JiraProfile> GetProfile()
        {
            try {
                var url = requestUrls_[GetMyself];
                var request = new RestRequest(url, Method.GET);
                var response = await client_.ExecuteTaskAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<JiraProfile>(response.Content);
                
                logger_.Error(BuildError_(response, "Couldn't fetch profile"));
            } 
            catch (Exception err) { logger_.Error(err);} 
            return null;
        }
        

        public async Task<FieldDefinition[]> GetAllFields()
        {
            try {
                var url = requestUrls_[GetFields];
                var request = new RestRequest(url, Method.GET);
                var response = await client_.ExecuteTaskAsync(request);
                if (response.StatusCode == HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<FieldDefinition[]>(response.Content);
                    
                logger_.Error(BuildError_(response, "Couldn't fetch profile"));
            } 
            catch (Exception err) { logger_.Error(err);} 
            return null; 
        }
        
        
        private string BuildError_(IRestResponse response, string message) => $"{response.StatusCode} {message}: {response.Content}";
    }
}