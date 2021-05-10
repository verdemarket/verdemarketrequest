using System.Text.Json.Serialization;

namespace RequestModel
{
    public class Itemsprocessed : IItemsprocessed
    {
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("sequenceitem")]
        public int sequenceitem { get; set; }
        [JsonPropertyName("itemname")]
        public string itemname { get; set; }
        [JsonPropertyName("quantity")]
        public int quantity { get; set; }
        [JsonPropertyName("observations")]
        public string[] observations { get; set; }
        [JsonPropertyName("price")]
        public Price price { get; set; }
    }
}