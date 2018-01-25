using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exercise_3.Models
{
    public class SearchResult
    {
        [JsonProperty("result_count")]
        public int ResultCount { get; set; }

        [JsonProperty("images")]
        public List<Image> Images { get; set; }
    }
}