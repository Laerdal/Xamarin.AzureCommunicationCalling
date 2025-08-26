#!/bin/sh

set -e

# Change to the script's directory
cd "$(dirname "$0")"

# Clean up previous builds
echo "--- Cleaning up old frameworks and archives ---"
rm -rf nativeLibs

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
pod install
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
echo "--- Creating XCFramework ---"
mkdir -p Pods
xcodebuild -create-xcframework \
  -framework "$ARCHIVES_PATH/AzureCommunicationCommon-iOS.xcarchive/Products/Library/Frameworks/AzureCommunicationCommon.framework" \
  -framework "$ARCHIVES_PATH/AzureCommunicationCommon-iOS_Simulator.xcarchive/Products/Library/Frameworks/AzureCommunicationCommon.framework" \
  -output Pods/AzureCommunicationCommon.xcframework

cd Pods

echo "--- Unzipping Calling framework ---"
unzip -q ../"$CALLING_ZIP"

cd .. # back to nativeLibs

# --- Cleanup ---
echo "--- Cleaning up intermediate files ---"
rm "$CALLING_ZIP"
rm -rf "$COMMON_REPO_DIR"
rm -rf "$ARCHIVES_PATH"

echo "--- Native libraries are updated. ---"
echo "You may need to re-run 'sharpie bind' if the native API has changed."
echo "Finally, build the project with 'dotnet build -c Release'"
echo "Built nuget package will be in bin/Release"
