iOS and Android binding library for Azure Communication Services
================================================================

Use this library to consume Azure Communication Services on Xamarin,
e.g. make video and voice calls.

On iOS, you need to install the nuget Xamarin.AzureCommunicationCalling.iOS,
while on Android you need to install 3 nugets: Xamarin.AzureCore.Android,
Xamarin.AzureCommunicationCommon.Android and Xamarin.AzureCommunicationCalling.Android.
(The reason for 3 on Android is that one Xamarin binding library can only contain one aar-file)

N.B. For ACS, Minimum iOS version is 12.0 and minimum Android is 21 (5.0).
Also, on Android only x86_64 and arm64-v8a ABIs are supported. You will get some
strange error messages if trying to run on e.g. x86(which is default ABI for the emulator...)
Support for 32 bit is expected to come soon.

These library are native to each platform, you need to make a common abstraction on top
yourself if you want to use them in a forms project. See the TestApp for a simple example.

To run the TestApp, you need to implement the rest service providing the ACS token, 
afterwards the app should look like this:

![alt "Test app"](testapp.jpg "Test app")
