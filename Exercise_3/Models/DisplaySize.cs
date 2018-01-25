using Newtonsoft.Json;

namespace Exercise_3.Models
{
    public class DisplaySize
    {
        [JsonProperty(PropertyName = "is_watermarked")]
        public bool IsWatermarked { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }
    }
}
