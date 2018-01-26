using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Exercise_4.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Exercise_4.Controllers
{
    public class OpenWeatherMapServices
    {
        private const string RootUrl = "http://api.openweathermap.org";

        private readonly RestClient restClient = new RestClient(RootUrl);

        private const string ApiKey = "b2baa28658ef1bcc7bb06834dce9b058";

        public WeatherInfo GetWeatherByCityName(string cityName)
        {
            var request = new RestRequest($"/data/2.5/weather?q={cityName}&appid={ApiKey}", Method.GET);
            var response = restClient.Execute(request);
            return (response.StatusCode.ToString().Equals("OK"))
                ? JsonConvert.DeserializeObject<WeatherInfo>(response.Content)
                : null;
        }
    }
}