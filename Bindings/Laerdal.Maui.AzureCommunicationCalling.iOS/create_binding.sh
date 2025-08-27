#!/bin/sh

set -e

# Change to the script's directory
cd "$(dirname "$0")"

# Clean up previous builds
echo "--- Cleaning up old frameworks, archives, and bindings ---"
rm -rf nativeLibs
rm -rf tmp

# Create directory for native libraries
mkdir -p nativeLibs
cd nativeLibs

# --- AzureCommunicationCalling ---
CALLING_ZIP="AzureCommunicationCalling-2.16.0.zip"
CALLING_URL="https://github.com/Azure/Communication/releases/download/v2.16.0/${CALLING_ZIP}"

# Download Calling framework
if [ ! -f "$CALLING_ZIP" ]; then
    echo "--- Downloading AzureCommunicationCalling zip file ---"
    wget -q --show-progress "$CALLING_URL"
else
    echo "--- AzureCommunicationCalling zip file already exists. Skipping download. ---"
fi

# --- AzureCommunicationCommon ---
COMMON_REPO="https://github.com/Azure/azure-sdk-for-ios.git"
COMMON_REPO_DIR="azure-sdk-for-ios"
COMMON_TAG="AzureCommunicationCommon_1.3.0"

# Clone Common framework repo
if [ ! -d "$COMMON_REPO_DIR" ]; then
    echo "--- Cloning AzureCommunicationCommon repository ---"
    git clone --depth 1 --branch "$COMMON_TAG" "$COMMON_REPO"
else
    echo "--- AzureCommunicationCommon repository already exists. Skipping clone. ---"
fi

echo "--- Installing pods for AzureCommunicationCommon ---"
cd "$COMMON_REPO_DIR"
arch -x86_64 pod install
cd .. # back to nativeLibs

echo "--- Building AzureCommunicationCommon.xcframework ---"
ARCHIVES_PATH="archives"
mkdir -p "$ARCHIVES_PATH"
COMMON_WORKSPACE="$COMMON_REPO_DIR/AzureSDK.xcworkspace"
COMMON_SCHEME="AzureCommunicationCommon"

# Build for iOS device
echo "--- Archiving for iphoneos ---"
xcodebuild archive \
  -workspace "$COMMON_WORKSPACE" \
  -scheme "$COMMON_SCHEME" \
  -sdk iphoneos \
  -archivePath "$ARCHIVES_PATH/AzureCommunicationCommon-iOS.xcarchive" \
  SKIP_INSTALL=NO \
  BUILD_LIBRARY_FOR_DISTRIBUTION=YES

# Build for iOS simulator
echo "--- Archiving for iphonesimulator ---"
xcodebuild archive \
  -workspace "$COMMON_WORKSPACE" \
  -scheme "$COMMON_SCHEME" \
  -sdk iphonesimulator \
  -archivePath "$ARCHIVES_PATH/AzureCommunicationCommon-iOS_Simulator.xcarchive" \
  SKIP_INSTALL=NO \
  BUILD_LIBRARY_FOR_DISTRIBUTION=YES

# Create the XCFramework
echo "--- Creating AzureCommunicationCommon.xcframework ---"
mkdir -p Pods
xcodebuild -create-xcframework \
  -framework "$ARCHIVES_PATH/AzureCommunicationCommon-iOS.xcarchive/Products/Library/Frameworks/AzureCommunicationCommon.framework" \
  -framework "$ARCHIVES_PATH/AzureCommunicationCommon-iOS_Simulator.xcarchive/Products/Library/Frameworks/AzureCommunicationCommon.framework" \
  -output Pods/AzureCommunicationCommon.xcframework

cd Pods

echo "--- Unzipping AzureCommunicationCalling framework ---"
unzip -q ../"$CALLING_ZIP"

cd .. # back to nativeLibs

# --- Patching headers ---
echo "--- Patching header files to use relative paths for xcframeworks ---"
CALLING_ARM64_HEADER="Pods/AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h"
CALLING_SIM_HEADER="Pods/AzureCommunicationCalling.xcframework/ios-arm64_x86_64-simulator/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h"

# Check if files exist before patching
if [ -f "$CALLING_ARM64_HEADER" ] && [ -f "$CALLING_SIM_HEADER" ]; then
    # For arm64
    sed -i.bak 's|@import AzureCommunicationCommon;|#import "../../../../AzureCommunicationCommon.xcframework/ios-arm64/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon-Swift.h"|' "$CALLING_ARM64_HEADER"
    # For simulator
    sed -i.bak 's|@import AzureCommunicationCommon;|#import "../../../../AzureCommunicationCommon.xcframework/ios-arm64_x86_64-simulator/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon-Swift.h"|' "$CALLING_SIM_HEADER"
else
    echo "Header files not found, skipping patch."
fi

# --- Cleanup ---
echo "--- Cleaning up intermediate files ---"
rm "$CALLING_ZIP"
rm -rf "$COMMON_REPO_DIR"
rm -rf "$ARCHIVES_PATH"

# --- Sharpie Bind ---
echo "--- Generating bindings with Objective Sharpie ---"
# Output "raw" bindings to tmp folder to keep a clean git history of binding changes
# Make sure you have the latest Sharpie version:
# 3.5 or greater. Download from here: http://aka.ms/objective-sharpie
# If you get "invalid sdk", list yours with "xcodebuild -showsdks"
sharpie bind \
  -sdk iphonesimulator \
  -o ../tmp \
  -namespace "Laerdal.Maui.AzureCommunicationCalling.iOS" \
  -scope Pods/AzureCommunicationCalling.xcframework/ios-arm64_x86_64-simulator/AzureCommunicationCalling.framework/Headers \
  Pods/AzureCommunicationCalling.xcframework/ios-arm64_x86_64-simulator/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h \
  -c -fmodules

# --- Final instructions ---
echo ""
echo "--- Manual steps required ---"
echo "Remember to merge new tmp/*.cs into ./*.cs"
echo "This is the time consuming work: go through bindings, sometimes sharpie"
echo "fails to get method name, sometime there is a check annotation etc...."
echo "WHAT SHOULD BE DONE:"
echo "- NativeHandle to IntPtr"
echo "- CXHandle to IntPtr"
echo "- comment out body of CommunicationTokenRefreshOptions"
echo "- get rid of all [Verify] tags"
echo ""
echo "--- Build ---"
echo "Finally, build the project with 'dotnet build -c Release'"
echo "Built nuget package will be in bin/Release"
