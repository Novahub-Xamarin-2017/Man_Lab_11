using Newtonsoft.Json;

namespace Ex4.Models
{
    public class Clouds : EasyModel
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }
}