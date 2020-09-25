using System;
using Xamarin.AzureCommunicationCalling.iOS;

namespace AzureCommunicationVideoTest.iOS.ACS
{
    public class RemoteVideoStreamDelegate : ACSRendererDelegate
    {

        public RemoteVideoStreamDelegate()
        {
        }
        /*
        public override void onAvailabilityChanged(ACSRemoteVideoStream remoteVideoStream, ACSPropertyChangedEventArgs args)
        {
            base.onAvailabilityChanged(remoteVideoStream, args);

            if (remoteVideoStream.IsAvailable)
            {
                // TODO: Make this non static...
                var r = new ACSRenderer(remoteVideoStream);
                //r.CreateView()
                //SpoolCallManager.InvokeRemoteVideoStarted(remoteVideoStream, remoteVideoStream.VideoRenderers[0].Target);
            }
        }
        */
    }
}
