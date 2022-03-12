using System;
using System.Text.Json.Serialization;

namespace VeriffDemo.Tests.API.Models
{
    public class VeriffSessionAdditionalDataModel
    {
        [JsonPropertyName("isTest")]
        public bool IsTest { get; set; }
    }
}
