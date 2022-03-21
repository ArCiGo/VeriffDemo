using System.Text.Json.Serialization;

namespace VeriffDemo.API.Models
{
    public class VeriffPreselectedDocumentModel
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
