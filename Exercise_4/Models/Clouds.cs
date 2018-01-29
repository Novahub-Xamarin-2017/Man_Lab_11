using Newtonsoft.Json;

namespace Exercise4.Models
{
    public class Clouds : EasyModel
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}