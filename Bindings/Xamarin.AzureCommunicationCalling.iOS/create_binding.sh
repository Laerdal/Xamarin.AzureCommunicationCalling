#!/bin/sh

# First get the latest version of the native pods:
cd nativeLibs
sh fetchPods.sh
cd ..

# Now make a fat framework containing both x86 and arm64 binaries
cd nativeLibs/Pods/AzureCommunicationCalling/
mkdir AzureCommunicationCalling.framework
cp -R AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/* AzureCommunicationCalling.framework/.
lipo -create AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/AzureCommunicationCalling AzureCommunicationCalling.xcframework/ios-x86_64-simulator/AzureCommunicationCalling.framework/AzureCommunicationCalling -output AzureCommunicationCalling.framework/AzureCommunicationCalling
cd ../../../

# For this to work, change includes of azure deps(core and communicationCommon) header files
# in below .h file, to reltive includes.
# Instead of :
#
##import <AzureCommunicationCommon/AzureCommunicationCommon-Swift.h>
#
# Make it look like this:
#
#import "./../../AzureCommunicationCommon/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon/
#
patch -s -p0 -N < headers.patch

# Output "raw" bindings to tmp folder to keep a clean git history of binding changes
# Make sure you have the latest Sharpie version:
# 3.5 or greater. Download from here: http://aka.ms/objective-sharpie
sharpie bind \
    -sdk iphoneos15.0 \
    -o tmp \
    -namespace "Xamarin.AzureCommunicationCalling.iOS" \
    -scope nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers \
    nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h \
    -c -fmodules \

# Lastly: manually copy tmp bindings into this folder and make it work
echo "Remember to merge new tmp/*.cs into ./*.cs"
