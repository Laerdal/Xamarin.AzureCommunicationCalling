using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AzureCommunicationVideoTest
{
    public class RestClient
    {
        public RestClient()
        {

        }

        /*
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        */

        private const string ApiUrl = "api/";
        private const string Ip = "192.168.3.241";
        //private const string Ip = "10.184.34.26";
        private static readonly string Server = $"https://{Ip}:5001/";
        
        private JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };
        


        public async Task<AzureCommunicationToken> GetToken(string userId)
        {
            var url = $"{Server}{ApiUrl}token?userId={HttpUtility.UrlEncode(userId)}";
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                using var wc = new HttpClient(clientHandler);
                var message = new HttpRequestMessage(HttpMethod.Get, url);

                var response = await wc.SendAsync(message);
                var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AzureCommunicationToken>(body, _jsonSerializerSettings);
            }
            catch (Exception e)
            {
                //Log.Error("Failed to call azure api: " + url, e, "CAMWW2");
                throw;
            }
        }

        public class AzureCommunicationToken
        {
            public string Token { get; set; }
            public string Expiration { get; set; }
        }

    }
}
