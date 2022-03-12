using System.Text.Json.Serialization;

namespace VeriffDemo.Tests.API.Models
{
    public class VeriffVendorIntegrationModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
