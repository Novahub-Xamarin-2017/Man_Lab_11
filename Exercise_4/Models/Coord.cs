﻿using Newtonsoft.Json;

namespace Exercise4.Models
{
    public class Coord : EasyModel
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}