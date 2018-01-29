using System.Collections.Generic;
using Newtonsoft.Json;

namespace Exercise_3.Models
{
    public class Image
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("asset_family")]
        public string AssetFamily { get; set; }

        [JsonProperty("caption ")]
        public string Caption { get; set; }

        [JsonProperty("collection_code")]
        public string CollectionCode { get; set; }

        [JsonProperty("collection_id")]
        public int CollectionId { get; set; }

        [JsonProperty("collection_name")]
        public string CollectionName { get; set; }

        [JsonProperty("display_sizes")]
        public List<DisplaySize> DisplaySizes { get; set; }

        [JsonProperty("license_model")]
        public string LicenseModel { get; set; }

        [JsonProperty("max_dimensions")]
        public MaxDimensions MaxDimensions { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
