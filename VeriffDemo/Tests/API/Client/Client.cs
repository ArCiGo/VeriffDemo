using System;
using System.Text.Json;
using System.Threading.Tasks;
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
            RestRequest postVeriffSessionRequest = new RestRequest(veriffDemoSessionAPIClient, Method.Post)
                .AddJsonBody(TestObjects.parameters);

            RestResponse createResponse = await restClient.ExecutePostAsync(postVeriffSessionRequest);
            VeriffCreatedSessionModel values = JsonSerializer.Deserialize<VeriffCreatedSessionModel>(createResponse.Content);
            SessionToken = values.SessionToken;

            return createResponse;
        }

        public async Task<RestResponse> GetVeriffSessionAccountAsync()
        {
            RestRequest getVeriffSessionRequest = new RestRequest(veriffMagicSessionAPIClient, Method.Get)
                .AddHeader("Authorization", $"Bearer {SessionToken}");

            return await restClient.ExecuteGetAsync(getVeriffSessionRequest);
        }
    }
}
