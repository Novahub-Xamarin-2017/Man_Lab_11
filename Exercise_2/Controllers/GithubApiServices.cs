using System.Collections.Generic;
using System.Linq;
using Exercise_2.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Exercise_2.Controllers
{
    public class GithubApiServices
    {
        private const string RootUrl = "https://api.github.com/";

        private readonly RestClient restClient = new RestClient(RootUrl);

        public ListUser SeachUsers(string searchString)
        {
            var searchRequest = new RestRequest($"/search/users?q={searchString}", Method.GET);
            var searchResponse = restClient.Execute(searchRequest);
            return JsonConvert.DeserializeObject<ListUser>(searchResponse.Content);
        }

        public UserDetail GetUserDetail(string login)
        {
            var request = new RestRequest($"users/{login}", Method.GET);
            var response = restClient.Execute(request);
            return JsonConvert.DeserializeObject<UserDetail>(response.Content);
        }

        public List<string> GetUserReposList(string login)
        {
            var request = new RestRequest($"users/{login}/repos", Method.GET);
            var response = restClient.Execute(request);
            return JsonConvert.DeserializeObject<List<Repo>>(response.Content).Select(r => r.Name).ToList();
        }
    }
}