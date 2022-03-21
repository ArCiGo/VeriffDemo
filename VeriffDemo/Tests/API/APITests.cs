using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
using VeriffDemo.API.Models;
using System.Net;
using VeriffDemo.API.Data;
using System.Text.Json;
using VeriffDemo.API;

namespace VeriffDemo.Tests.API
{
    [TestFixture]
    public class APITests : BaseAPITest
    {
        [Test, Category("API"), Order(1)]
        public async Task CreateSessionAsync()
        {
            RestResponse response = await veriffSessionClient.PostVeriffSessionAccountAsync();
            VeriffCreatedSessionModel values = JsonSerializer.Deserialize<VeriffCreatedSessionModel>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotEmpty(values.IntegrationUrl);
        }

        [Test, Category("API"), Order(2)]
        public async Task GetSessionAsync()
        {
            RestResponse response = await veriffSessionClient.GetVeriffSessionAccountAsync();
            VeriffSessionsRootModel values = JsonSerializer.Deserialize<VeriffSessionsRootModel>(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotEmpty(values.ID);
            Assert.AreEqual(TestObjects.expectedValues["status"], values.Status);
            Assert.AreEqual(TestObjects.expectedValues["language"], values.InitData.Language);
            Assert.AreEqual(TestObjects.expectedValues["country"], values.InitData.PreselectedDocument.Country);
            Assert.AreEqual(TestObjects.expectedValues["type"], values.InitData.PreselectedDocument.Type);
            Assert.AreEqual(TestObjects.expectedValues["name"], values.VendorIntegration.Name);
        }
    }
}
