#!/bin/sh

# First get the latest version of the native pods:
# (if the version you want is not in cocoapod yet,
#  skip the below steps and instead unzip file from
#  github release page in nativeLibs/Pods/AzureCommunicationCalling)
# Release page: https://github.com/Azure/Communication/releases
cd nativeLibs
sh fetchPods.sh
cd ..

# Now make a fat framework containing both x86 and arm64 binaries
cd nativeLibs/Pods/AzureCommunicationCalling/
mkdir AzureCommunicationCalling.framework
cp -R AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/* \
    AzureCommunicationCalling.framework/.
lipo -create \
    AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/AzureCommunicationCalling \
    AzureCommunicationCalling.xcframework/ios-x86_64-simulator/AzureCommunicationCalling.framework/AzureCommunicationCalling \
    -output AzureCommunicationCalling.framework/AzureCommunicationCalling
cd ../../../

# For this to work, change includes of azure deps(core and communicationCommon) header files
# in below .h file, to reltive includes.
# Instead of :
#
##import <AzureCommunicationCommon/AzureCommunicationCommon-Swift.h>
#
# Make it look like this:
#
#import "../../../AzureCommunicationCommon/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon-Swift.h"
#
# The below patch command worked a long time ago, its not maintained.... just do it manually....
# patch -s -p0 -N < headers.patch


# Output "raw" bindings to tmp folder to keep a clean git history of binding changes
# Make sure you have the latest Sharpie version:
# 3.5 or greater. Download from here: http://aka.ms/objective-sharpie
# If you get "invalid sdk", list yours with "xcodebuild -showsdks"
sharpie bind \
    -sdk iphoneos16.2 \
    -o tmp \
    -namespace "Laerdal.Maui.AzureCommunicationCalling.iOS" \
    -scope nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers \
    nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h \
    -c -fmodules

# Lastly: manually copy tmp bindings into this folder and make it work
# This is the time consuming work: to through bindings, sometimes sharpie
# fails to get method name, sometime there is a check annotation etc....
echo "Remember to merge new tmp/*.cs into ./*.cs"
