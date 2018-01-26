using System.Collections.Generic;
using System.Linq;
using Exercise_1.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Exercise_1.Controllers
{
    public class TweetController
    {
        private const string RootUrl = "https://salty-mesa-4348.herokuapp.com";


        private readonly RestClient restClient = new RestClient(RootUrl);

        public TweetController()
        {
            
        }

        public string Login(string login, string password)
        {
            var loginRequest = new RestRequest("/login", Method.POST) {RequestFormat = DataFormat.Json};
            loginRequest.AddBody(new
            {
                login,
                password
            });
            var loginResponse = restClient.Execute(loginRequest);
            return !loginResponse.StatusCode.ToString().Equals("OK") ? null : loginResponse.Headers.First(c => c.Name.Equals("Set-Cookie")).Value.ToString().Split(';')[0];
        }

        public List<Tweet> Get(string cookie)
        {
            var getRequest = new RestRequest("/tweets", Method.GET);
            getRequest.AddHeader("Content-Type", "application/json");
            getRequest.AddCookie(cookie.Split('=')[0], cookie.Split('=')[1]);
            return JsonConvert.DeserializeObject<List<Tweet>>(restClient.Execute(getRequest).Content);
        }

        public bool Logout()
        {
            var logoutRequest = new RestRequest("/logout", Method.DELETE);
            logoutRequest.AddHeader("Content-Type", "application/json");
            var logoutResponse = restClient.Execute(logoutRequest);
            return logoutResponse.StatusCode.ToString().Equals("OK");
        }
    }
}