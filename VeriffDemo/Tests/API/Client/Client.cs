using System;
using System.Threading.Tasks;
using RestSharp;
using VeriffDemo.Tests.API.Models;

namespace VeriffDemo.Tests.API
{
    public class Client
    {
        // Attributes
        public string SessionToken { get; set; }

        // Endpoints
        private readonly RestClient veriffDemoSessionAPIClient = new RestClient("https://demo.saas-3.veriff.me/");
        private readonly RestClient veriffMagicSessionAPIClient = new RestClient("https://magic.saas-3.veriff.me/api/v2/sessions");

        // Actions
        public async Task<RestResponse> PostVeriffSessionAccountAsync()
        {
            var parameters = new
            {
                full_name = "Armando Cifuentes",
                lang = "es-MX",
                document_country = "MX",
                document_type = "ID_CARD",
                additionalData = new { isTest = false }
            };

            RestRequest postVeriffSessionRequest = new RestRequest();
            postVeriffSessionRequest.Method = Method.Post;
            postVeriffSessionRequest.AddObject(parameters);

            return await veriffDemoSessionAPIClient.ExecutePostAsync(postVeriffSessionRequest);
        }

        // check if works
        public async Task<RestResponse> GetVeriffSessionAccountAsync()
        {
            RestRequest getVeriffSessionRequest = new RestRequest();
            getVeriffSessionRequest.Method = Method.Get;
            getVeriffSessionRequest.AddParameter("sessionToken", SessionToken);

            // check if works
            RestResponse createResponse = await veriffMagicSessionAPIClient.ExecuteAsync<VeriffCreatedSessionModel>(getVeriffSessionRequest);

            return createResponse;
        }
    }
}
