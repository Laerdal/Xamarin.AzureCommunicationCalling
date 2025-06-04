#!/bin/sh

# First get the latest version of the native pods and download from
# release page: https://github.com/Azure/Communication/releases
cd nativeLibs

echo "Cleaning up old mess"
rm -rf Pods/*

echo "Installing pods from cocoapods"
arch -x86_64 pod install

echo "Downloading zip file from github"
cd Pods
wget https://github.com/Azure/Communication/releases/download/v2.16.0-beta.1/AzureCommunicationCalling-2.16.0-beta.1.zip
unzip AzureCommunicationCalling*.zip

echo "Move zip framework into pod-structure"
rm -rf AzureCommunicationCalling/*
cp -R AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework \
  AzureCommunicationCalling/.

echo "Move symlink to actual folder(dotnet does not like symlinks...)"
rm -rf AzureCommunicationCommon
mkdir AzureCommunicationCommon
cp -R _Prebuild/GeneratedFrameworks/AzureCommunicationCommon/AzureCommunicationCommon.framework \
  AzureCommunicationCommon/.

# NB: NU5123 warnings are abundant...
# I tried shortening paths(renaming framework etc)
# but got build time errors: is not a valid framework and one other...
# Probably framework names are hardcoded somewhere :(

echo "Now make fat frameworks containing just the arm64 binaries"
lipo -extract arm64 \
  _Prebuild/GeneratedFrameworks/AzureCommunicationCommon/AzureCommunicationCommon.framework/AzureCommunicationCommon \
  -output AzureCommunicationCommon/AzureCommunicationCommon.framework/AzureCommunicationCommon
lipo -create AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/AzureCommunicationCalling \
  -output AzureCommunicationCalling/AzureCommunicationCalling.framework/AzureCommunicationCalling

echo "Fix calling header file link to common header"
cd AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers
sed -i.bak 's@<AzureCommunicationCommon/AzureCommunicationCommon-Swift.h>@"../../../AzureCommunicationCommon/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon-Swift.h"@' \
  AzureCommunicationCalling.h
cd ../../../../../

# Output "raw" bindings to tmp folder to keep a clean git history of binding changes
# Make sure you have the latest Sharpie version:
# 3.5 or greater. Download from here: http://aka.ms/objective-sharpie
# If you get "invalid sdk", list yours with "xcodebuild -showsdks"
sharpie bind \
  -sdk iphoneos18.2 \
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

echo "Finally, build npm with 'dotnet build -c Release'"
echo "Built npm package will be in bin/Release"
