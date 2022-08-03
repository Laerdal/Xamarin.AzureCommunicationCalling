using System;
using System.Collections.Generic;
using System.Text;

namespace TestSample.Enums
{
    public enum ConferenceEndingReason
    {
        Unset,
        LocalHangup,
        RemoteHangup,
        RemoteBusy,
        LocalDecline,
        RemoteDecline,
        Failure,
        AnsweredElsewhere,
        Unanswered
    }

    public enum ConferenceFailure
    {
        ErrorOnStartLocalMedia = 100,
        ErrorOnStopLocalMedia = 101,
        ErrorOnJoinConference = 102,
    }
}
