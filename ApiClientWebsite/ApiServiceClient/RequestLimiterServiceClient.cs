using Microsoft.AspNetCore.WebUtilities;
using RestSharp;

namespace ApiClientWebsite.ApiServiceClient
{
    public class RequestLimiterServiceClient : IServiceClient
    {
        private RestClient _client = new RestClient("https://localhost:7071/");
        private const string USER_HEADER_NAME = "Client-Authentication-Key";
        public string? GetData()
        {
            return _client.Get<string>(GetRequestWithAuthenticationKey());
        }

        private RestRequest GetRequestWithAuthenticationKey()
        {
            var request = new RestRequest();
            request.AddHeader(USER_HEADER_NAME, "1234567890");
            return request;
        }
    }
}
