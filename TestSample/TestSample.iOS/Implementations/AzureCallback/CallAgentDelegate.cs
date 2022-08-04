using CallKit;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.AzureCommunicationCalling.iOS;

namespace TestSample.iOS.Implementations
{
    public class CallAgentDelegate : ACSCallAgentDelegate
    {
        private readonly CallingCallbackManager _videoCallbackManager;

        public CallAgentDelegate(CallingCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }
        public override void OnIncomingCall(ACSCallAgent callAgent, ACSIncomingCall incomingCall)
        {           
            incomingCall.Delegate = new IncomingCallDelegate(_videoCallbackManager);
            _videoCallbackManager.IncomingCall?.Invoke(incomingCall);
        }
        public override void OnCallsUpdated(ACSCallAgent callAgent, ACSCallsUpdatedEventArgs args)
        {
            foreach (var call in args.AddedCalls)
            {
              
            }
        }

    }
    public class IncomingCallDelegate : ACSIncomingCallDelegate
    {
        private readonly CallingCallbackManager _videoCallbackManager;

        public IncomingCallDelegate(CallingCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }
        public override void OnCallEnded(ACSIncomingCall incomingCall, ACSPropertyChangedEventArgs args)
        {
            _videoCallbackManager.CallEnded?.Invoke(incomingCall);
        }
    }
}