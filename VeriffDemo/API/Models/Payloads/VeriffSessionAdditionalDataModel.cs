using System.Text.Json.Serialization;

namespace VeriffDemo.API.Models
{
    public class VeriffSessionAdditionalDataModel
    {
        [JsonPropertyName("isTest")]
        public bool IsTest { get; set; }
    }
}
