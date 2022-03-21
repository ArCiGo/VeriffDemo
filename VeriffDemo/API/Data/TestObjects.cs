using System.Collections.Generic;
using VeriffDemo.API.Models;

namespace VeriffDemo.API.Data
{
    public class TestObjects
    {
        public static Dictionary<string, string> expectedValues = new Dictionary<string, string>()
        {
            { "status", "created" },
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
