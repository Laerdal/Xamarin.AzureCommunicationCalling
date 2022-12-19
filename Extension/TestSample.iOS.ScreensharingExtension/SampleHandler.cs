using Foundation;
using ReplayKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace TestSample.iOS.ScreensharingExtension
{
    public class SampleHandler: RPBroadcastSampleHandler
    {
        public override void ProcessSampleBuffer(CoreMedia.CMSampleBuffer sampleBuffer, RPSampleBufferType sampleBufferType)
        {
            switch (sampleBufferType)
            {
                case RPSampleBufferType.Video:
                    break;
                case RPSampleBufferType.AudioApp:
                    break;
                case RPSampleBufferType.AudioMic:
                    break;
            }
        }
        public override void BroadcastPaused()
        {
            Console.WriteLine("BroadcastPaused");
        }

        public override void BroadcastResumed()
        {
            Console.WriteLine("BroadcastResumed");
        }

        public override void BroadcastFinished()
        {
            Console.WriteLine("BroadcastFinished");
        }
    }
}