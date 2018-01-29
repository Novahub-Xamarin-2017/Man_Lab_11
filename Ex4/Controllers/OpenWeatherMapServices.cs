using System.Net;
using Android.Util;
using Ex4.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Ex4.Controllers
{
    public class OpenWeatherMapServices
    {
        private const string RootUrl = "http://api.openweathermap.org";

        private readonly RestClient restClient = new RestClient(RootUrl);

        private const string ApiKey = "b2baa28658ef1bcc7bb06834dce9b058";

        public WeatherInfo GetWeatherByCityName(string cityName)
        {
            try
            {
                var request = new RestRequest($"/data/2.5/weather?q={cityName}&appid={ApiKey}", Method.GET);
                var response = restClient.Execute(request);
                return (response.StatusCode == HttpStatusCode.OK)
                    ? JsonConvert.DeserializeObject<WeatherInfo>(response.Content)
                    : null;
            }
            catch (WebException e)
            {
                Log.Info("WebException", e.Message);
                throw;
            }
        }
    }
}