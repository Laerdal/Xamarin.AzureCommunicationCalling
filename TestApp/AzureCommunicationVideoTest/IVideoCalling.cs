using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AzureCommunicationVideoTest
{
    public interface IVideoCalling
    {
        public Task<bool> Init(string token);
        public View JoinGroup(Guid groupID);
        public void CallEchoService();
    }
}
