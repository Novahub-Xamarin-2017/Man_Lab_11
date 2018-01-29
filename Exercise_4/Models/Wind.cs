using Newtonsoft.Json;

namespace Exercise4.Models
{
    public class Wind : EasyModel
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public int Deg { get; set; }
    }
}