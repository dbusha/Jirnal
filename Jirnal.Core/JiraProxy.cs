using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using JiraOAuth.Client;
using Jirnal.Core.JiraTypes;
using Newtonsoft.Json;
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
        private readonly Dictionary<string, CustomField> customFieldLookup_ = new Dictionary<string, CustomField>();

        private const string ProjectUrl = "Project";
        private const string SearchUrl = "Search";
        private const string CommentsUrl = "Comments";
        private const string UpdateOrDeleteCommentUrl = "UpdateComments";
        private const string GetCustomFieldsUrl = "GetCustomFields";


        public JiraProxy(string baseUrl)
        {
            client_ = new RestClient(baseUrl);
            var apiPath = $"{baseUrl}/rest/api/2";
            requestUrls_ = new Dictionary<string, string>
            {
                {SearchUrl, $"{apiPath}/search"},
                {ProjectUrl, $"{apiPath}/project"},
                {CommentsUrl, $"{apiPath}/issue/{{0}}/comment"},
                {UpdateOrDeleteCommentUrl, $"{apiPath}/issue/{{0}}/comment/{{1}}"},
                {GetCustomFieldsUrl, $"{apiPath}/customFields"},
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
                if(response.Content.IsNullOrWhitespace())
                    return new Collection<JiraProject>();
                var projects = JsonConvert.DeserializeObject<JiraProject[]>(response.Content, JsonConverterSettings.Settings);
                return projects;
            } catch (Exception err) { logger_.Error(err); }

            return new Collection<JiraProject>();
        }


        public async Task<SearchResult> SearchForIssues(SearchRequest searchRequest)
        {
            try {
                var jsonSearch = JsonConvert.SerializeObject(searchRequest);
                var request = new RestRequest(requestUrls_[SearchUrl], Method.POST);
                request.AddJsonBody(jsonSearch);
                var response = await client_.ExecuteTaskAsync(request);
                
                // ToDo: Handle error response from search
                if (response.Content.IsNullOrWhitespace())
                    return null;
                
                var issues = JsonConvert.DeserializeObject<SearchResult>(response.Content, JsonConverterSettings.Settings);
                return issues;
            } catch (Exception err) { logger_.Error(err); }

            return null;
        }

        
        public void GetCustomFields()
        {
            try {
                var url = requestUrls_[GetCustomFieldsUrl];
                var request = new RestRequest(url, Method.GET);
                var response = client_.Execute(request);

                if (response.StatusCode == HttpStatusCode.NotFound) {
                    logger_.Error($"Failed to get comments: {response.Content}");
                    return;
                }

                var fields = JsonConvert.DeserializeObject<CustomFields>(response.Content, JsonConverterSettings.Settings);
                foreach(var field in fields.Fields)
                    customFieldLookup_.Add(field.Id, field);

            } catch (Exception err) {
                logger_.Error(err);
            }
        }
        
        
        public async Task<Comments> GetComments(string key)
        {
            try {
                var url = string.Format(requestUrls_[CommentsUrl], key);
                var request = new RestRequest(url, Method.GET);
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode == HttpStatusCode.NotFound) {
                    logger_.Error($"Failed to get comments: {response.Content}");
                    return null;
                }

                return JsonConvert.DeserializeObject<Comments>(response.Content, JsonConverterSettings.Settings);

            } catch (Exception err) {
                logger_.Error(err);
                return null; 
            }
        }
        

        public async Task<bool> AddComment(string commentText, string issueKey)
        {
            try {
                var comment = new CommentAddUpdate {Body = commentText};
                var url = string.Format(requestUrls_[CommentsUrl], issueKey);
                var request = new RestRequest(url, Method.POST);
                request.AddJsonBody(JsonConvert.SerializeObject(comment));
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode == HttpStatusCode.BadRequest) {
                    logger_.Error($"Failed to add comment: {response.Content}");
                    return false;
                }

                return true;
                
            } catch (Exception err) {
                logger_.Error(err);
                return false; 
            }
        }
        
        
        public async Task<bool> EditComment(string commentText, string issueKey, int commentId)
        {
            try {
                var comment = new CommentAddUpdate {Body = commentText};
                var url = string.Format(requestUrls_[UpdateOrDeleteCommentUrl], issueKey, commentId);
                var request = new RestRequest(url, Method.PUT);
                request.AddJsonBody(JsonConvert.SerializeObject(comment));
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode == HttpStatusCode.BadRequest) {
                    logger_.Error($"Failed to edit comment: {response.Content}");
                    return false;
                }

                return true;
                
            } catch (Exception err) {
                logger_.Error(err);
                return false;
            }
        }
        
        
        public async Task<bool> DeleteComment(string issueKey, long commentId)
        {
            try {
                var url = string.Format(requestUrls_[UpdateOrDeleteCommentUrl], issueKey, commentId);
                var request = new RestRequest(url, Method.DELETE);
                var response = await client_.ExecuteTaskAsync(request);

                if (response.StatusCode == HttpStatusCode.NoContent)
                    return true;
                
                logger_.Error($"Failed to edit comment: {response.Content}");
                return false;
            } catch (Exception err) {
                logger_.Error(err);
                return false;
            }
        }
    }
}