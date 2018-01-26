using Newtonsoft.Json;

namespace Exercise_4.Models
{
    public class Clouds : EasyModel
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}