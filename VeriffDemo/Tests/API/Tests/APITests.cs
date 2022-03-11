using System;
using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
using VeriffDemo.Tests.API.Models;
using System.Net;
using Newtonsoft.Json;
using VeriffDemo.Tests.API.Data;

namespace VeriffDemo.Tests.API.Tests
{
    [TestFixture]
    public class APITests
    {
        private Client veriffSessionClient = new Client();

        [Test, Order(1)]
        public async Task CreateSessionAsync()
        {
            RestResponse postSessionResponse = await veriffSessionClient.PostVeriffSessionAccountAsync();

            Assert.AreEqual(HttpStatusCode.OK, postSessionResponse.StatusCode);
        }

        [Test, Order(2)]
        public async Task GetSessionAsync()
        {
            RestResponse getSessionResponse = await veriffSessionClient.GetVeriffSessionAccountAsync();
            VeriffSessionsModel values = JsonConvert.DeserializeObject<VeriffSessionsModel>(getSessionResponse.Content);

            Assert.AreEqual(HttpStatusCode.OK, getSessionResponse.StatusCode);
            Assert.AreEqual(values.Status, "created");
            Assert.AreEqual(TestObjects.expectedValues["language"], values.InitData["language"].ToString());
            Assert.AreEqual(TestObjects.expectedValues["country"], values.InitData["preselectedDocument"]["country"].ToString());
            Assert.AreEqual(TestObjects.expectedValues["type"], values.InitData["preselectedDocument"]["type"].ToString());
            Assert.AreEqual(TestObjects.expectedValues["name"], values.VendorIntegration["name"].ToString());
        }
    }
}
