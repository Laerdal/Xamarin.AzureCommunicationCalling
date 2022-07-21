using AVFoundation;
using CallKit;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;

namespace AzureSample.iOS.Implementations
{
    public class ProviderDelegate : CXProviderDelegate
    {
        public override void DidReset(CXProvider provider)
        {

        }
        public override void PerformAnswerCallAction(CXProvider provider, CXAnswerCallAction action)
        {
        }
        public override void DidBegin(CXProvider provider)
        {
        }
        public override void DidActivateAudioSession(CXProvider provider, AVAudioSession audioSession)
        {
        }
        public override void PerformEndCallAction(CXProvider provider, CXEndCallAction action)
        {
        }
        public override void PerformStartCallAction(CXProvider provider, CXStartCallAction action)
        {
        }
        public override void PerformSetMutedCallAction(CXProvider provider, CXSetMutedCallAction action)
        {
        }
        public override void PerformSetHeldCallAction(CXProvider provider, CXSetHeldCallAction action)
        {
        }
        
    }
}