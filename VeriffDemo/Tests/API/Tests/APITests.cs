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
            RestResponse createSessionResponse = await veriffSessionClient.PostVeriffSessionAccountAsync();
            VeriffCreatedSessionModel values = JsonConvert.DeserializeObject<VeriffCreatedSessionModel>(createSessionResponse.Content);

            veriffSessionClient.SessionToken = values.SessionToken;

            Assert.AreEqual(HttpStatusCode.OK, createSessionResponse.StatusCode);
        }
    }
}
