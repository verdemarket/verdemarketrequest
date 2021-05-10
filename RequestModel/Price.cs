using System.Text.Json.Serialization;

namespace RequestModel
{
    public class Price : IPrice
    {
        [JsonPropertyName("value")]
        public float value { get; set; }
        [JsonPropertyName("currency")]
        public string currency { get; set; }
    }
}