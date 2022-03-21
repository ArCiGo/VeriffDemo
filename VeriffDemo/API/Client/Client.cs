using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;
using VeriffDemo.API.Data;
using VeriffDemo.API.Models;

namespace VeriffDemo.API
{
    public class Client
    {
        // Properties
        private string SessionToken { get; set; }

        // Variables & Constants
        private readonly RestClient restClient;

        // Endpoints
        private string veriffDemoSessionAPIClient = "https://demo.saas-3.veriff.me/";
        private string veriffMagicSessionAPIClient = "https://magic.saas-3.veriff.me/api/v2/sessions";

        // Constructor
        public Client()
        {
             restClient = new RestClient();
        }

        // Actions
        public async Task<RestResponse> PostVeriffSessionAccountAsync()
        {
            RestRequest postVeriffSessionRequest = new RestRequest(veriffDemoSessionAPIClient, Method.Post)
                .AddJsonBody(TestObjects.parameters);

            RestResponse response = await restClient.ExecutePostAsync(postVeriffSessionRequest);

            // I prefer to handle the token here than in the test, for security reasons
            VeriffCreatedSessionModel values = JsonSerializer.Deserialize<VeriffCreatedSessionModel>(response.Content);
            SessionToken = values.SessionToken;

            return response;
        }

        public async Task<RestResponse> GetVeriffSessionAccountAsync()
        {
            RestRequest getVeriffSessionRequest = new RestRequest(veriffMagicSessionAPIClient, Method.Get)
                .AddHeader("Authorization", $"Bearer {SessionToken}");

            return await restClient.ExecuteGetAsync(getVeriffSessionRequest);
        }
    }
}
