using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AzureCommunicationVideoTest
{
    public interface IACSCallingManager
    {
        Task<bool> Init(string token);
        void JoinGroup(Guid groupID);
        void Hangup();
        void CallEchoService();
        event EventHandler<View> LocalVideoAdded;
        event EventHandler<View> RemoteVideoAdded;
        void CallPhone(string phoneNumber);
    }
}
