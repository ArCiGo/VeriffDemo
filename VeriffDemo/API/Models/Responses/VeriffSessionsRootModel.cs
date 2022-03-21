using System.Text.Json.Serialization;

namespace VeriffDemo.API.Models
{
    public class VeriffSessionsRootModel
    {
        [JsonPropertyName("id")]
        public string ID { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("initData")]
        public VeriffInitDataModel InitData { get; set; }

        [JsonPropertyName("vendorIntegration")]
        public VeriffVendorIntegrationModel VendorIntegration { get; set; }
    }
}
