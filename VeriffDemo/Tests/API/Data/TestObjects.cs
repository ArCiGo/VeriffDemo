using System;
using System.Collections.Generic;
using VeriffDemo.Tests.API.Models;

namespace VeriffDemo.Tests.API.Data
{
    public class TestObjects
    {
        public static Dictionary<string, string> expectedValues = new Dictionary<string, string>()
        {
            { "language", "es-MX" },
            { "country", "MX" },
            { "type", "ID_CARD" },
            { "name", "End User Web Demo (Production)" }
        };

        public static VeriffSessionRootPayloadModel parameters = new VeriffSessionRootPayloadModel()
        {
            FullName = "Armando Cifuentes",
            Language = "es-MX",
            DocumentCountry = "MX",
            DocumentType = "ID_CARD",
            AdditionalData = new VeriffSessionAdditionalDataModel { IsTest = false }
        };
    }
}
