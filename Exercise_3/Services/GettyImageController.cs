using System;
using Exercise_3.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Exercise_3.Services
{
    public class GettyImageController
    {
        private const string ApiKey = "7y25xqzf9cpqmv7effd9d4dv";

        private const string RootUrl = "https://api.gettyimages.com";

        private readonly RestClient restClient = new RestClient(RootUrl);

        public SearchResult Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString)) return new SearchResult();
            var searhRequest = new RestRequest($"/v3/search/images?phrase={searchString}", Method.GET);
            searhRequest.AddHeader("Api-Key", ApiKey);
            var response = restClient.Execute(searhRequest);
            return JsonConvert.DeserializeObject<SearchResult>(response.Content);
        }
    }
}
