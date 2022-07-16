# Azure Communication Calling Sample Xamarin Forms

Additional documentation for this sample can be found on [Microsoft Docs](https://docs.microsoft.com/azure/communication-services/concepts/voice-video-calling/calling-sdk-features).

## Support platforms

- [x] Android
- [x] iOS 
- [x] UWP (Min Target: 10.0.18362)
- macOS (study in progress)

## Support Libraries

Mobile support is maintained by the community

Windows support is official.

# Features


| Features                                | iOS | Android |UWP |
| -----------------------------           | ----------- | --------------- | --------------- |
| Start or join in existing group call                  | ✅          |✅                 |✅        |
| Start a new PSTN call                   | ✅           | ✅               |✅               |
| Join an existing Teams Meeting          | ✅           | ✅               | ✅               |
| Start calls inside sdk                            | ✅             | ✅               |✅                |
| Receive calls inside sdk                             | :construction:	         | ✅               | ✅             |
| Add participants during calls                   | :construction:	         | :construction:               | :construction:             |
| call notification                             | :x:          | ✅               | ✅            |
| Switch layout between different call cases: only-local video view, one-on-one call view and group call with multiple participants                             | :hourglass:            | ✅               |✅               |
| Render remote participant video streams dynamically | :hourglass:            | ✅               |✅               |
| Show remote call participants                     | :hourglass:            | ✅               |✅               |
| Show remote participants with microphone on/off   | :hourglass:            | ✅               |✅               |
| Turning local video stream from camera on/off | ✅           | ✅               |✅               |
| switch between cameras                         | ✅            | ✅               |:x:                 |
| View remote screen sharing                     | :x:            | :x:                |:x:                 |
| Request permission to use audio and/or video   | ✅             | ✅               |✅               |
| Mute/unmute local microphone audio      | ✅           | ✅               |✅               |
| Show dominant speaker                         | :x:            | :x:                |:x:                 |
| Turn off screen on calls      | :x:           | ✅               |:x:               |
| Toggle audio output                       | ✅           | ✅               |:x:               |
| Screensharing                 | :x:               |:hourglass:            |:x:
| Background Voip API           | ✅  Services              |:hourglass:  Callkit           |:x:  VoipPhoneCall 
## Subtitle

in progress      :construction: 

In consideration :hourglass:

Not implemented  :x:

implemented      ✅   
# Screenshots
## Android
<img src="/Screenshots/Android_Intro.jpg" width="200" height="400" />   <img src="/Screenshots/Android_Join.jpg" width="200" height="400" /><img src="/Screenshots/Android_Setup.jpg" width="200" height="400" />

## iOS
<img src="/Screenshots/iOS_Intro.png" width="200" height="400" /> <img src="/Screenshots/iOS_Join.png" width="200" height="400" /><img src="/Screenshots/iOS_Setup.png" width="200" height="400" />
## UWP

<img src="/Screenshots/Windows_Intro.png" width="600" height="400" /> <img src="/Screenshots/Windows_Join.png" width="600" height="400" />
<img src="/Screenshots/Windows_Setup.png" width="600" height="400" />

## Prerequisites

- An Azure account with an active subscription. [Create an account for free](https://azure.microsoft.com/free/?WT.mc_id=A261C142F).
- An OS running [Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/vs/).
- A deployed Communication Services resource. [Create a Communication Services resource](https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource).
- An Authentication Endpoint that will return the Azure Communication Services Token. See [example](https://docs.microsoft.com/azure/communication-services/tutorials/trusted-service-tutorial)


## Run Sample

1. Build/Run in Visual Studio 2022

## Securing Authentication Endpoint

For simple demonstration purposes, this sample uses a publicly accessible endpoint by default to fetch an Azure Communication token. For production scenarios, it is recommended that the Azure Communication token is returned from a secured endpoint.  

## Required Libraries

- [Azure Communication Calling SDK Windows](https://www.nuget.org/packages/Azure.Communication.Calling)

- [Azure Communication Calling SDK Android](https://www.nuget.org/packages/Xamarin.AzureCommunicationCalling.Android)

- [Azure Communication Calling SDK Android Helper](https://www.nuget.org/packages/Xamarin.AzureCommunicationCallingHelper.Android)

- [Azure Communication Calling SDK Android Common](https://www.nuget.org/packages/Xamarin.AzureCommunicationCommon.Android)

- (No required) [Azure Communication Calling SDK Android Azure Core Logging](https://www.nuget.org/packages/Xamarin.AzureCoreLogging.Android)

- [Azure Communication Calling SDK iOS](https://www.nuget.org/packages/Xamarin.AzureCommunicationCalling.iOS)

# Known issues in the xamarin example

## Android

The camera on android doesn't seem to work during calls.

## UWP

The token initialization agent has a wait of up to 15 seconds
Incoming call and accept/or reject status does not update on event.
Video refresh event no longer works after a video is removed from the screen.

Please refer to the [wiki](https://github.com/Azure-Samples/communication-services-android-calling-hero/wiki/Known-Issues) for known issues related to this sample.
](https://docs.microsoft.com/en-us/azure/communication-services/concepts/voice-video-calling/calling-sdk-features)
