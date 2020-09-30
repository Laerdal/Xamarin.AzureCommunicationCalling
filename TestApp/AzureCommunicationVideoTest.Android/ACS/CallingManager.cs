using System;
using System.Threading.Tasks;
using Xamarin.Forms;
//using Com.Azure.Communication.Calling;
//using Com.Azure.Communication;
using Com.Azure.Android.Communication.Common;

namespace AzureCommunicationVideoTest.Droid.ACS
{
    public class CallingManager : IACSCallingManager
    {
        //private CallAgent _callAgent;
        //private CallClient _callClient;

        public CallingManager()
        {
        }

        public Task<bool> Init(string token)
        {
            var credentials = new CommunicationUserCredential(token);
            throw new NotImplementedException();
            //_callClient = new CallClient();
        }

        public void JoinGroup(Guid groupID)
        {
            throw new NotImplementedException();
        }

        public void Hangup()
        {
            throw new NotImplementedException();
        }

        public void CallEchoService()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<View> LocalVideoAdded;
        public event EventHandler<View> RemoteVideoAdded;
        public void CallPhone(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
