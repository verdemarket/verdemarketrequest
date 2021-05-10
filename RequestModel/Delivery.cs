using System.Text.Json.Serialization;

namespace RequestModel
{
    public class Delivery : IDelivery
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("address")]
        public string address { get; set; }
        [JsonPropertyName("observation")]
        public string[] observation { get; set; }
    }
}