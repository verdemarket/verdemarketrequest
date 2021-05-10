using System.Text.Json.Serialization;

namespace RequestModel
{
    public class Total : ITotal
    {
        [JsonPropertyName("price")]
        public Price price { get; set; }
    }
}