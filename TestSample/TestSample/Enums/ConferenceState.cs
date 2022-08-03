using System;
using System.Collections.Generic;
using System.Text;

namespace TestSample.Enums
{
    public enum ConferenceState
    {
        Unset,
        Dialing,
        Receiving,
        Accepting,
        Accepted,
        Initializing,
        Connecting,
        Connected,
        Reconnecting,
        Reconnected,
        Disconnecting,
        Disconnected,
        InLobby
    }
}
