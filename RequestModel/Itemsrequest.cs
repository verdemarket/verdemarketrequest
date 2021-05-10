using System.Text.Json.Serialization;

namespace RequestModel
{
    public class Itemsrequest : IItemsrequest
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
    }
}