using Azure;
using Azure.Communication;
using Azure.Communication.Identity;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestSample.Interfaces
{
    public interface IACSService
    {
        Task<string> CreateACSUserIdentity();
        Task<AccessToken> CreateACSToken(string acsUserId);
        //Task<AccessToken> GetACSTokenForTeamsUser(string aadToken);
        Task<CommunicationUserIdentifierAndToken> CreateACSUserIdentityAndToken();
        Task DeleteACSUserIdentity(string acsUserId);
    }
    public sealed class ACSService : IACSService
    {
        private readonly CommunicationIdentityClient _communicationIdentityClient;
        public ACSService(CommunicationIdentityClient communicationIdentityClient = null)
        {
            _communicationIdentityClient = communicationIdentityClient ?? new CommunicationIdentityClient(AppConfiguration.ConnectionString);
        }
        public async Task<string> CreateACSUserIdentity()
        {
            Response<CommunicationUserIdentifier> identityResponse = await _communicationIdentityClient.CreateUserAsync();
            return identityResponse.Value.Id;
        }
        public async Task<AccessToken> CreateACSToken(string acsUserId)
        {
            var tokenScopes = GetCommunicationTokenScopes();
            var identity = new CommunicationUserIdentifier(acsUserId);
            Response<AccessToken> tokenResponse = await _communicationIdentityClient.GetTokenAsync(identity, scopes: tokenScopes);

            return tokenResponse.Value;
        }
        //public async Task<AccessToken> GetACSTokenForTeamsUser(string aadToken)
        //{
        //    Response<AccessToken> tokenResponse = await _communicationIdentityClient.GetTokenForTeamsUserAsync(aadToken);
        //    return tokenResponse.Value;
        //}
        public async Task<CommunicationUserIdentifierAndToken> CreateACSUserIdentityAndToken()
        {
            var tokenScopes = GetCommunicationTokenScopes();
            Response<CommunicationUserIdentifierAndToken> identityAndTokenResponse = await _communicationIdentityClient.CreateUserAndTokenAsync(scopes: tokenScopes);
            return identityAndTokenResponse.Value;
        }
        public async Task DeleteACSUserIdentity(string acsUserId)
        {
            var identity = new CommunicationUserIdentifier(acsUserId);
            await _communicationIdentityClient.DeleteUserAsync(identity);
        }
        private CommunicationTokenScope[] GetCommunicationTokenScopes()
        {
            var tokenScopes = new[] { CommunicationTokenScope.VoIP };
            return tokenScopes;
        }
    }
}
