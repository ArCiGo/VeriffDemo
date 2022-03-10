using System;
using NUnit.Framework;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

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
        }
    }
}
