using System;
using System.Text.Json.Serialization;

namespace VeriffDemo.Tests.API.Models
{
    public class VeriffCreatedSessionModel
    {
        [JsonPropertyName("integrationUrl")]
        public string IntegrationUrl { get; set; }

        [JsonPropertyName("sessionToken")]
        public string SessionToken { get; set; }
    }
}
