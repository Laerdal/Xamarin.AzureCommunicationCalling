using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.AzureCommunicationCalling.iOS;

namespace TestSample.iOS.Implementations
{
    public class ScreenSharingDelegate : ACSRawOutgoingVideoStreamOptionsDelegate
    {
        private readonly CallingCallbackManager _videoCallbackManager;
        private Action<ACSRawOutgoingVideoStreamOptions, ACSOutgoingVideoStreamStateChangedEventArgs> remoteParticipants;
        public static ACSVideoFrameSender aCSVideoFrameSender;
        public ScreenSharingDelegate(CallingCallbackManager videoCallbackManager)
        {
            _videoCallbackManager = videoCallbackManager;
        }

        public override void OnOutgoingVideoStreamStateChanged(ACSRawOutgoingVideoStreamOptions rawOutgoingVideoStreamOptions, ACSOutgoingVideoStreamStateChangedEventArgs args)
        {
            _videoCallbackManager.ScreenSharing?.Invoke(rawOutgoingVideoStreamOptions, args);
        }
        public override void OnVideoFrameSenderChanged(ACSRawOutgoingVideoStreamOptions rawOutgoingVideoStreamOptions, ACSVideoFrameSenderChangedEventArgs args)
        {
            aCSVideoFrameSender = args.VideoFrameSender;
        }
    }
}