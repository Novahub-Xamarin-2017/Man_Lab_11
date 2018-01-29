using Newtonsoft.Json;

namespace Exercise_2.Models
{
    public class Repo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}