using System;
using System.Threading.Tasks;

namespace AzureCommunicationVideoTest
{
    public interface IVideoCalling
    {
        public Task<bool> Init(string token);
        public void JoinGroup(Guid groupID);
        public void CallEchoService();
    }
}
