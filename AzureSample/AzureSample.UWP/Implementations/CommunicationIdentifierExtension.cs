using Azure.Communication.Calling;
using Azure.WinRT.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSample.UWP.Implementations
{
    public static class CommunicationIdentifierExtension
    {
        public static string IdentifierExtension(RemoteParticipant remoteParticipant)
        {
            if (remoteParticipant.Identifier is CommunicationUserIdentifier user)
            {
                return user.Id;
            }
            if (remoteParticipant.Identifier is PhoneNumberIdentifier number)
            {
                return number.RawId;
            }
            if (remoteParticipant.Identifier is MicrosoftTeamsUserIdentifier teams)
            {
                return teams.UserId;
            }
            if (remoteParticipant.Identifier is UnknownIdentifier unknown)
            {
                return unknown.Id;
            }
            return remoteParticipant.DisplayName;
        }
    }
}
