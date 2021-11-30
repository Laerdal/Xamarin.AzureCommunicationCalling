When updating to new version:

Pre-Requisites:
* Cocoapods
* Latest sharpe version, 3.5 or greater. (As of now, download from here: http://aka.ms/objective-sharpie (3.5.41))


Folder `Xamarin.AzureCommunicationCalling.iOS/nativeLibs` contains a placeholder xcodeproj with Cocoapods dependencies set up.

On your first build, the following steps:

* Naviate to `Xamarin.AzureCommunicationCalling.iOS/nativeLibs`
* run `bundle exec pod install`
* run `sharpie bind -sdk iphoneos14.1 -o tmp -scope nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h -c -fmodules`

Edit generated files to fix namespace, and any "Verify".
Also, remove the generated nested Action\<Action\< attribute (constructor), which mono doesn't like

Then copy files into binding lib

The create_bindings.sh contains more info

2021.05.13: MS started bundling this as thin frameworks, need to use lipo to make a fat framework we can bind against, to be able to support simulators(x86) as well as arm64, command line looks something like this:

lipo -create ./ios-arm64/AzureCommunicationCalling.framework ./ios-x86_64-simulator/AzureCommunicationCalling.framework -ouput AzureCommunictionCalling
