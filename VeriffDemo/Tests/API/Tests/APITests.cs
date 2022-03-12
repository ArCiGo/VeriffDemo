using System;
using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
using VeriffDemo.Tests.API.Models;
using System.Net;
using VeriffDemo.Tests.API.Data;
using System.Text.Json;

namespace VeriffDemo.Tests.API.Tests
{
    [TestFixture]
    public class APITests
    {
        private Client veriffSessionClient = new Client();

        [Test, Order(1)]
        public async Task CreateSessionAsync()
        {
            RestResponse response = await veriffSessionClient.PostVeriffSessionAccountAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test, Order(2)]
        public async Task GetSessionAsync()
        {
            RestResponse response = await veriffSessionClient.GetVeriffSessionAccountAsync();
            VeriffSessionsRootModel values = JsonSerializer.Deserialize<VeriffSessionsRootModel>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(values.Status, "created");
            Assert.AreEqual(TestObjects.expectedValues["language"], values.InitData.Language);
            Assert.AreEqual(TestObjects.expectedValues["country"], values.InitData.PreselectedDocument.Country);
            Assert.AreEqual(TestObjects.expectedValues["type"], values.InitData.PreselectedDocument.Type);
            Assert.AreEqual(TestObjects.expectedValues["name"], values.VendorIntegration.Name);
        }
    }
}
