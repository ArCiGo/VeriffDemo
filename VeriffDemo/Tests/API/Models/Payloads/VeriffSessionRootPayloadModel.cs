using System;
using System.Text.Json.Serialization;

namespace VeriffDemo.Tests.API.Models
{
    public class VeriffSessionRootPayloadModel
    {
        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("lang")]
        public string Language { get; set; }

        [JsonPropertyName("document_country")]
        public string DocumentCountry { get; set; }

        [JsonPropertyName("document_type")]
        public string DocumentType { get; set; }

        [JsonPropertyName("additionalData")]
        public VeriffSessionAdditionalDataModel AdditionalData { get; set; }
    }
}
