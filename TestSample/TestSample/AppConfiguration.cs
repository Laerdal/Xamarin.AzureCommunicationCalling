using Azure;
using Azure.Communication;
using Azure.Communication.Identity;
using Azure.Core;
using TestSample.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestSample
{
    public static class AppConfiguration
    {
        public static string DefaultMeetingCode = ""; // ex. cbd94812-7928-4a40-a5a8-136d978addc0
        public static string ConnectionString = "endpoint=https:// youradress .communication.azure.com/;accesskey=FsYdtHLv==";
        public static string APIFunctions = "https://ayouapifunctions.azurewebsites.net/api/Function";
        public static string SyncfusionLicense = "";//It's not really necessary, just use it so the checkbox doesn't look so ugly ;/

        public static string Token()
        {
            var token = "";
            if (Device.RuntimePlatform == Device.UWP)
                token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjEwNiIsIng1dCI6Im9QMWFxQnlfR3hZU3pSaXhuQ25zdE5PU2p2cyIsInR5cCI6IkpXVCJ9.eyJza3lwZWlkIjoiYWNzOjg3NmU2MDE3LTEwMzItNGY3NS05MTE2LWMyNmE3MzhiNWFhZl8wMDAwMDAxMi05Y2MzLTIwNDktNTcwYy0xMTNhMGQwMDFhMTIiLCJzY3AiOjE3OTIsImNzaSI6IjE2NTc4MDUwNDUiLCJleHAiOjE2NTc4OTE0NDUsImFjc1Njb3BlIjoidm9pcCIsInJlc291cmNlSWQiOiI4NzZlNjAxNy0xMDMyLTRmNzUtOTExNi1jMjZhNzM4YjVhYWYiLCJpYXQiOjE2NTc4MDUwNDV9.jJyRUpxd1sapj-LHqgz4EwHLO6nYhIy-no7xXuIRv6j88H-R_F-NzgXjqGZdhAtkCAkOk1PKM6gC0b0REE2Dw37G41eYxQ9f2Hv4hpzfLB-ReytP869TyKL3t9Zt9Uu5z-MI-oTRQUz1zlCNRCij-llDtGFVH3WXYH8SoKIwOIRd_dv_9NN4UJwu1_hkW18uJidfZD6RqYQsORNTuFZ-9Le9bJGnYaUJoaflewdS6Mae8Ip78BUrDMNHFJCIxm7W3cHqY-Bhip8P46Z3WtyTpFwCVLPVUEfqpbALCCXmuV3ZNS2hOg6JFqOLmAoF0tA1F1sZpTdb1oAJ0VbLVEaZcA";
            if (Device.RuntimePlatform == Device.Android)

                token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjEwNiIsIng1dCI6Im9QMWFxQnlfR3hZU3pSaXhuQ25zdE5PU2p2cyIsInR5cCI6IkpXVCJ9.eyJza3lwZWlkIjoiYWNzOjg3NmU2MDE3LTEwMzItNGY3NS05MTE2LWMyNmE3MzhiNWFhZl8wMDAwMDAxMi05Y2MzLTc0YTYtNzQwYS0xMTNhMGQwMGQ3MjEiLCJzY3AiOjE3OTIsImNzaSI6IjE2NTc4MDUwNjYiLCJleHAiOjE2NTc4OTE0NjYsImFjc1Njb3BlIjoidm9pcCIsInJlc291cmNlSWQiOiI4NzZlNjAxNy0xMDMyLTRmNzUtOTExNi1jMjZhNzM4YjVhYWYiLCJpYXQiOjE2NTc4MDUwNjZ9.sogpHe98FrVBi6uVdRKUDH1aVBzGfkCaezta-yA1Zc6nz1SHmdvtcn5OpRHQhKunrVNnaTzioZMstptowKnpRNycuOErOgePfkZ-1o_cy0OFbon7PWr5deu_eRVm80K2rQh2ePwxAxf1UkjOMbLTkKnTvuGcDio_5f-jbmIE_u0EdZJTso8ceyvhLPCGM2138P-_P5KNle4EeAIjp7spC6A6WCS531WVm1jRvuzhY_7Yo_1mLtCA2gzrnQdgp9FTdGzB7Pp4u_UYg3b39kFC-HdryKMT_-kiEypbX_Lw4Si3DZdD5QmJ14VdLeVn4bGDCpWMMG4-vyqSQ-LtdkRpOg";
            if (Device.RuntimePlatform == Device.iOS)
                token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjEwNiIsIng1dCI6Im9QMWFxQnlfR3hZU3pSaXhuQ25zdE5PU2p2cyIsInR5cCI6IkpXVCJ9.eyJza3lwZWlkIjoiYWNzOjg3NmU2MDE3LTEwMzItNGY3NS05MTE2LWMyNmE3MzhiNWFhZl8wMDAwMDAxMi05Y2MzLWJkZTctYjRmMS05YzNhMGQwMGQwNGQiLCJzY3AiOjE3OTIsImNzaSI6IjE2NTc4MDUwODUiLCJleHAiOjE2NTc4OTE0ODUsImFjc1Njb3BlIjoidm9pcCIsInJlc291cmNlSWQiOiI4NzZlNjAxNy0xMDMyLTRmNzUtOTExNi1jMjZhNzM4YjVhYWYiLCJpYXQiOjE2NTc4MDUwODV9.sy6els3d6bHkK_sXVm5DrATyoQiB858JpfNdDk447vWIHRwj4QSQEi1gWGw2pJNXvL9IOuYbvOcoRkwVD6KRWL-IpyZKcqENpOcoN-98qQ02fhMOqZDeLErGFOKJJShjIY8jv9gIfMOQ3o4d3gkPvzyRDtxW2xmEYGjcvZneQirheJlZ9YUB9_E36Lay5PANiPaYzCP8DMtEEn9SQInkM9maeqx5jFqR8xpvgDvGOWZSFw34uOH3CNRQhB057AFGt7sYGHnF_TMxH9NGoKfX-T4hkPXJamqSr1PBtJYulfUVx3MbfqhKZcmz8dNcEEgMXseyuw4QmO_kZzy1ijt15Q";

            return token;
        }
        //An alternative to getting user-based tokens for 1x1 calls quickly with the CreateACSToken method
        public static async Task<string> IdACS()
        {
            var user = "";
            if (Device.RuntimePlatform == Device.UWP)
                user = "8:acs:876e6017-1032-4f75-9116-c26a738b5aaf_00000013-9cf1-84cb-740a-113a0d00dd59";
            if (Device.RuntimePlatform == Device.Android)

                user = "8:acs:876e6017-1032-4f75-9116-c26a738b5aaf_00000014-9cf1-eaea-b4f1-9c3a0d00d5dc";
            if (Device.RuntimePlatform == Device.iOS)
                user = "8:acs:876e6017-1032-4f75-9116-c26a738b5aaf_00000015-b318-6220-740a-113a0d0049e9";
            user = await CreateACSToken(user);
            return user;
        }
        public static async Task<string> GetToken()
        {

            var client = new CommunicationIdentityClient(ConnectionString);
            var identityResponse = await client.CreateUserAsync();
            var identity = identityResponse.Value;
            var tokenResponse = await client.GetTokenAsync(identity, scopes: new[] { CommunicationTokenScope.VoIP });
            var expiresOn = tokenResponse.Value.ExpiresOn;
            var IdACS = identity.Id;
            var token = tokenResponse.Value.Token;

            return token;
        }
        public static async Task<string> GetTokenRestFull()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(APIFunctions);
            var response = await result.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<AzureCommunicationTokenRequest>(response);
            return tokenResponse.Token;
        }

        public static async Task<string> CreateACSToken(string acsUserId)
        {
            var tokenScopes = new[] { CommunicationTokenScope.VoIP };
            var identity = new CommunicationUserIdentifier(acsUserId);
            var client = new CommunicationIdentityClient(ConnectionString);
            Response<AccessToken> tokenResponse = await client.GetTokenAsync(identity, scopes: tokenScopes);

            return tokenResponse.Value.Token;
        }
        public static string DisplayName()
        {
            var name = "";
            if (Device.RuntimePlatform == Device.UWP)
                name = "Windows";
            if (Device.RuntimePlatform == Device.Android)
                name = "Android";
            if (Device.RuntimePlatform == Device.iOS)
                name = "iOS";
            return name;
        }
    }
}
