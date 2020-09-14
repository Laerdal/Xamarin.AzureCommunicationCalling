iOS binding library for project spool
=====================================

Use this library to make spool calls(AzureCommunicationCalling).

The native package is so big(120MB) that github wont accept it in a regular repo,
so you need to install LFS to get all the files:

https://docs.github.com/en/github/managing-large-files/installing-git-large-file-storage

* Update library

When updating to new version:

Extract all deps, and make sure header files points to deps correctly, then run this sharpie command:
Make sure you have latest sharpie version.
Latest is NOT what is shown at ms docs.. docs say 3.4,
but 3.5 is latest as of now, download from here: http://aka.ms/objective-sharpie

Run this command:
sharpie bind -o SpoolCalling -sdk iphoneos13.7 -scope . Headers/\*.h

Edit generated files to fix namesapce, and any "Verify".
Also, remove the generated nested Action\<Action\< attribute (constructor), which mono doesnt like

Then copy files into binding lib

An example of using this to join a group call:

```csharp
   public class SpoolCallManager
    {
        private ACSCallClient _callClient;
        private ACSDeviceManager _deviceManager;
        private ACSCallAgent _callAgent;
        private ACSCall _call;

        public Task<bool> Init(string token)
        {
            var _initTask = new TaskCompletionSource<bool>();
            _callClient = new ACSCallClient();

            void OnCallAgenttCreated(ACSCallAgent callAgent, NSError callAgentError)
            {
                if (callAgentError != null)
                {
                    _initTask.TrySetCanceled();
                    throw new Exception(callAgentError.Description);
                }
                _callAgent = callAgent;
                _callAgent.Delegate = new CallAgentDelegate();

                // Create device manager AFTER callagent
                void OnDeviceManagerCreated(ACSDeviceManager deviceManager, NSError deviceManagerError)
                {
                    if (deviceManagerError != null)
                    {
                        throw new Exception(deviceManagerError.Description);
                    }
                    _deviceManager = deviceManager;
                    _initTask.TrySetResult(true);
                }
                _callClient.GetDeviceManagerWithCompletionHandler(OnDeviceManagerCreated);
            }

            var credentials = new CommunicationUserCredential(token, out var nSError);
            if (nSError != null)
            {
                _initTask.TrySetCanceled();
                throw new Exception(nSError.Description);
            }
            _callClient.CreateCallAgent(credentials, OnCallAgenttCreated);

            return _initTask.Task;
        }


        public void JoinGroup(string groupID)
        {
            Log.Debug($"Starting group call: {groupID}");
            var groupCallContext = new ACSGroupCallContext(groupID);

            var camera = _deviceManager.CameraList.FirstOrDefault(c => c.CameraFacing == ACSCameraFacing.Front);
            var callOptions = new ACSJoinCallOptions();
            callOptions.AudioOptions = new ACSAudioOptions();
            callOptions.AudioOptions.Muted = true;
            var localVideoStream = new ACSLocalVideoStream(camera);
            callOptions.VideoOptions = new ACSVideoOptions(localVideoStream);

            _call = _callAgent.JoinWithGroupCallContext(groupCallContext, callOptions);
            _call.StartVideo(localVideoStream, OnVideoStarted);
            Log.Debug($"Started group call: {groupID}");
        }

        void OnVideoStarted(NSError error)
        {
            if (error != null) throw new Exception(error.Description);
            Log.Debug($"Started local video");
        }
    }
```
