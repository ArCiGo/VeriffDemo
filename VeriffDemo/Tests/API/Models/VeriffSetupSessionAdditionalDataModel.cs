using System;
using Newtonsoft.Json;

namespace VeriffDemo.Tests.API.Models
{
    public class VeriffSetupSessionAdditionalDataModel
    {
        [JsonProperty("isTest")]
        public bool IsTest { get; set; }
    }
}
