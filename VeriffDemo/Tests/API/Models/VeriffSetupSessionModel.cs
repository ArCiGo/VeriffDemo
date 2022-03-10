using System;
using Newtonsoft.Json;

namespace VeriffDemo.Tests.API.Models
{
    public class VeriffSetupSessionModel
    {
        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("lang")]
        public string Language { get; set; }

        [JsonProperty("document_country")]
        public string DocumentCountry { get; set; }

        [JsonProperty("document_type")]
        public string DocumentType { get; set; }

        [JsonProperty("additionalData")]
        public VeriffSetupSessionAdditionalDataModel AdditionalData { get; set; }
    }
}
