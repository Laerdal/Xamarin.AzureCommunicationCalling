using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AzureCommunicationVideoTest
{
    public interface IACSCallingManager
    {
        public Task<bool> Init(string token);
        public void JoinGroup(Guid groupID);
        public void Hangup();
        public void CallEchoService();
        public event EventHandler<View> LocalVideoAdded;
        public event EventHandler<View> RemoteVideoAdded;
        void CallPhone(string phoneNumber);
    }
}
