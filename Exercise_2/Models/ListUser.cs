using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exercise_2.Models
{
    public class ListUser
    {
        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        [JsonProperty("items")]
        public List<User> Users { get; set; }
    }
}