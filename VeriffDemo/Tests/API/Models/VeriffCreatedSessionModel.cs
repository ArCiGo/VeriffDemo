using System;
using Newtonsoft.Json;
using RestSharp;

namespace VeriffDemo.Tests.API.Models
{
    public class VeriffCreatedSessionModel
    {
        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("initData")]
        public dynamic? InitData { get; set; }

        [JsonProperty("vendorIntegration")]
        public dynamic? VendorIntegration { get; set; }
    }
}
