using System.Text.Json.Serialization;

namespace RequestModel
{
    
    public class RequestModel : IRequestModel
    {
        public RequestModel()
        {

        }
        [JsonPropertyName("id")]
        public string id { get; set; }
        [JsonPropertyName("client")]
        public Client client { get; set; }
        [JsonPropertyName("delivery")]        
        public Delivery[] delivery { get; set; }
        [JsonPropertyName("itemrequest")]
        public Itemsrequest[] itemsrequest { get; set; }
        [JsonPropertyName("itemsprocessed")]
        public Itemsprocessed[] itemsprocessed { get; set; }
        [JsonPropertyName("services")]
        public Service[] services { get; set; }
        [JsonPropertyName("others")]
        public string[] others { get; set; }
        [JsonPropertyName("total")]
        public Total total { get; set; }
        [JsonPropertyName("status")]
        public Status[] status { get; set; }
    }
}
