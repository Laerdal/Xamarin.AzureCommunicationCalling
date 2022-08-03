using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Azure.Android.Communication.Calling;
using Com.Azure.Android.Communication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSample.Droid.Implementations
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