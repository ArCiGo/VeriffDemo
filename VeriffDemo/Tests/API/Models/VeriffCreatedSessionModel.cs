using System;
using Newtonsoft.Json;
using RestSharp;

namespace VeriffDemo.Tests.API.Models
{
    public class VeriffCreatedSessionModel
    {
        [JsonProperty("integrationUrl")]
        public string IntegrationUrl { get; set; }

        [JsonProperty("sessionToken")]
        public string SessionToken { get; set; }
    }
}
