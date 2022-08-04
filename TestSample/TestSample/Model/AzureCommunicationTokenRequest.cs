using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestSample.Model
{
    public class AzureCommunicationTokenRequest
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("expiresOn")]
        public DateTime ExpiresOn { get; set; }
    }
}
