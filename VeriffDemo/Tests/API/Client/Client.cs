using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using VeriffDemo.Tests.API.Data;
using VeriffDemo.Tests.API.Models;

namespace VeriffDemo.Tests.API
{
    public class Client
    {
        // Attributes
        private string SessionToken { get; set; }

        // Endpoints
        private readonly RestClient restClient = new RestClient();
        private string veriffDemoSessionAPIClient = "https://demo.saas-3.veriff.me/";
        private string veriffMagicSessionAPIClient = "https://magic.saas-3.veriff.me/api/v2/sessions";

        // Actions
        public async Task<RestResponse> PostVeriffSessionAccountAsync()
        {
            /*var parameters = new
            {
                full_name = "Armando Cifuentes",
                lang = "es-MX",
                document_country = "MX",
                document_type = "ID_CARD",
                additionalData = new { isTest = false }
            };*/

            RestRequest postVeriffSessionRequest = new RestRequest(veriffDemoSessionAPIClient, Method.Post).AddHeader("Content-type", "application/json");            
            postVeriffSessionRequest.AddObject(TestObjects.parameters);

            RestResponse createResponse = await restClient.ExecutePostAsync(postVeriffSessionRequest);
            VeriffCreatedSessionModel values = JsonConvert.DeserializeObject<VeriffCreatedSessionModel>(createResponse.Content);
            SessionToken = values.SessionToken;

            return createResponse;
        }

        public async Task<RestResponse> GetVeriffSessionAccountAsync()
        {
            RestRequest getVeriffSessionRequest = new RestRequest(veriffMagicSessionAPIClient, Method.Get);
            restClient.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(SessionToken, "Bearer");

            return await restClient.ExecuteGetAsync(getVeriffSessionRequest);
        }
    }
}
