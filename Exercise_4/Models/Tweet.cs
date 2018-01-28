using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exercise_1.Models
{
    public class Tweet
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("images")]
        public List<string> Images { get; set; }
    }
}