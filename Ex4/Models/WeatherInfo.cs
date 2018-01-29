using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ex4.Models
{
    public class WeatherInfo
    {
        [JsonProperty("coord")]
        public Coord Coord { get; set; }

        [JsonProperty("weather")]
        public List<Weather> Weather { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("main")]
        public Main Main { get; set; }

        [JsonProperty("visibility")]
        public int Visibility { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("dt")]
        public int Dt { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cod")]
        public int Cod { get; set; }

        public override string ToString() => $"Coord :\n{Coord}" +
                                             $"\nWeather:\n{Weather[0]}" +
                                             $"\nBase: {Base}" +
                                             $"\nMain:\n{Main}" +
                                             $"\nVisibility: {Visibility}" +
                                             $"\nWind:\n{Wind}" +
                                             $"\nClouds:\n{Clouds}" +
                                             $"\nDt: {Dt}" +
                                             $"\nSys:\n{Sys}" +
                                             $"\nId: {Id}" +
                                             $"\nName: {Name}" +
                                             $"\nCod: {Cod}";
    }
}