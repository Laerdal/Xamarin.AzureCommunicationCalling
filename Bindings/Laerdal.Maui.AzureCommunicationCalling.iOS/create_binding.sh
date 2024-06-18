#!/bin/sh

# First get the latest version of the native pods:
# (if the version you want is not in cocoapod yet,
#  skip the below steps and instead unzip file from
#  github release page in nativeLibs/Pods/AzureCommunicationCalling)
# Release page: https://github.com/Azure/Communication/releases
#
# If pod complains, run pod install --repo-update
cd nativeLibs
sh fetchPods.sh
cd ..

# Now make a fat framework containing both x86 and arm64 binaries
cd nativeLibs/Pods/AzureCommunicationCalling/
rm -rf AzureCommunicationCalling.framework
mkdir AzureCommunicationCalling.framework
cp -R AzureCommunicationCalling.xcframework/ios-arm64_x86_64-simulator/AzureCommunicationCalling.framework/* \
    AzureCommunicationCalling.framework/.

cd ..
rm -rf AzureCommunicationCommon # delete the symlink
mkdir AzureCommunicationCommon  # create real folder
cd AzureCommunicationCommon
mkdir AzureCommunicationCommon.framework   # create .framework subfolder
cd ..
cp -R _Prebuild/GeneratedFrameworks/AzureCommunicationCommon/AzureCommunicationCommon.framework/* \
    AzureCommunicationCommon/AzureCommunicationCommon.framework/.
# since AzureCommunicationCalling uses ios-arm64_x86_64-simulator lipo is potentialy not needed?
# lipo -create \
#     AzureCommunicationCalling.xcframework/ios-arm64_x86_64-simulator/AzureCommunicationCalling.framework/AzureCommunicationCalling \
#     -output AzureCommunicationCalling.framework/AzureCommunicationCalling
cd ../../    # go back to folder of the

# For this to work, change includes of azure deps(core and communicationCommon) header files
# in below .h file, to reltive includes.
# Instead of :
#
##import <AzureCommunicationCommon/AzureCommunicationCommon-Swift.h>
#
# Make it look like this:
#
#import "../../../AzureCommunicationCommon/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon-Swift.h"#

sed -i '' 's|import <AzureCommunicationCommon/AzureCommunicationCommon-Swift.h>|import "../../../AzureCommunicationCommon/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon-Swift.h"|' \
 nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h

# Output "raw" bindings to tmp folder to keep a clean git history of binding changes
# Make sure you have the latest Sharpie version:
# 3.5 or greater. Download from here: http://aka.ms/objective-sharpie
# If you get "invalid sdk", list yours with "xcodebuild -showsdks"
sharpie bind \
    -sdk iphoneos \
    -o tmp \
    -namespace "Laerdal.Maui.AzureCommunicationCalling.iOS" \
    -scope nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers \
    nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h \
    -c -fmodules

# Lastly: manually copy tmp bindings into this folder and make it work
# This is the time consuming work: to through bindings, sometimes sharpie
# fails to get method name, sometime there is a check annotation etc....
# WHAT SHOULD BE DONE
# NativeHandle to IntPtr
# CXHandle to IntPtr
# comment out body of CommunicationTokenRefreshOptions
# get rid of all [Verify] tags
echo "Remember to merge new tmp/*.cs into ./*.cs"
