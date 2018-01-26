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
    }
}