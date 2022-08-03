using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureSample.iOS.Implementations
{
    public static class CommunicationIdentifierExtension
    {
        public static string IdentifierExtension(ACSRemoteParticipant remoteParticipant)
        {
            if (remoteParticipant.Identifier is CommunicationUserIdentifier user)
            {
                return user.Identifier;
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
                return unknown.Identifier;
            }
            return remoteParticipant.DisplayName;
        }
    }
}