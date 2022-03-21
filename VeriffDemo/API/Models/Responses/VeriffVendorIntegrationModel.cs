using System.Text.Json.Serialization;

namespace VeriffDemo.API.Models
{
    public class VeriffVendorIntegrationModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
