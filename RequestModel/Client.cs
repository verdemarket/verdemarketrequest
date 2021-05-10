using System.Text.Json.Serialization;

namespace RequestModel
{
    public class Client : IClient
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("id")]
        public string id { get; set; }
    }
}