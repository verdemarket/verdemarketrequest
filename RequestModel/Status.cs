using System.Text.Json.Serialization;

namespace RequestModel
{
    public class Status : IStatus
    {
        [JsonPropertyName("description")]
        public string description { get; set; }
        [JsonPropertyName("statusid")]
        public string statusid { get ; set; }
        [JsonPropertyName("statussequence")]
        public int statussequence { get; set; }
    }
}