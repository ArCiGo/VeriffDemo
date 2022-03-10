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

        // Body object
        private VeriffSetupSessionModel bodyJSONRequest = new VeriffSetupSessionModel()
        {
            FullName = "Armando Cifuentes",
            Language = "es-MX",
            DocumentCountry = "MX",
            DocumentType = "ID_CARD",
            AdditionalData = { IsTest = false }
        };

        // Actions
        // check if works
        public async Task<RestResponse> PostVeriffSessionAccountAsync()
        {
            RestRequest postVeriffSessionRequest = new RestRequest();
            postVeriffSessionRequest.Method = Method.Post;
            postVeriffSessionRequest.AddJsonBody(bodyJSONRequest);

            RestResponse createResponse = await veriffDemoSessionAPIClient.ExecuteAsync(postVeriffSessionRequest);

            // validate what returns the response to save the token
            // Console.WriteLine(createResponse.content);

            return createResponse;
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
