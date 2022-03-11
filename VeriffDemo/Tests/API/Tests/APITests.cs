using System;
using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
using VeriffDemo.Tests.API.Models;
using System.Net;
using Newtonsoft.Json;

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
            Assert.AreEqual(values.InitData["language"].ToString(), "es-MX");
            Assert.AreEqual(values.InitData["preselectedDocument"]["country"].ToString(), "MX");
            Assert.AreEqual(values.InitData["preselectedDocument"]["type"].ToString(), "ID_CARD");
            Assert.AreEqual(values.VendorIntegration["name"].ToString(), "End User Web Demo (Production)");
        }
    }
}
