using System.Text.Json.Serialization;

namespace RequestModel
{
    public class Service : IService
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("description")]
        public string[] description { get; set; }
        [JsonPropertyName("price")]
        public Price price { get; set; }
    }
}