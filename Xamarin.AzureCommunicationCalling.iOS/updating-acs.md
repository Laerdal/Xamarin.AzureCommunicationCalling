When updating to new version:

iOS:
====

Pre-Requisites:
* Cocoapods
* Latest sharpe version, 3.5 or greater. (As of now, download from here: http://aka.ms/objective-sharpie)


Folder `Xamarin.AzureCommunicationCalling.iOS/nativeLibs` contains a placeholder xcodeproj with Cocoapods dependencies set up.

On your first build, the following steps:

* Naviate to `Xamarin.AzureCommunicationCalling.iOS/nativeLibs`
* run `bundle exec pod install`
* run `sharpie bind -sdk iphoneos14.1 -o tmp -scope nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h -c -fmodules`

Edit generated files to fix namespace, and any "Verify".
Also, remove the generated nested Action\<Action\< attribute (constructor), which mono doesn't like

Then copy files into binding lib

Android:
========

Download latest version of all three aar lib:

    AzureCommunicationCalling, AzureCommunicationCommon and AzureCore

Since each binding lib can only hold one aar, we need 3 binding libs :(
Copy into these, and check if deps have changed(update/add changed/new jars)