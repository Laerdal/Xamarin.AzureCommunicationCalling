#!/bin/sh

set -e

# Get absolute path to the script's directory
SCRIPT_DIR="$(dirname "$0")"
PROJECT_ROOT="$(cd "$SCRIPT_DIR" && pwd)"

# Define key directories using absolute paths
NATIVE_LIBS_DIR="$PROJECT_ROOT/nativeLibs"
TMP_DIR="$PROJECT_ROOT/tmp"
ARCHIVES_DIR="$NATIVE_LIBS_DIR/archives"
PODS_DIR="$NATIVE_LIBS_DIR/Pods"
COMMON_REPO_PATH="$NATIVE_LIBS_DIR/azure-sdk-for-ios"

# Clean up previous builds
echo "--- Cleaning up old frameworks, archives, and bindings ---"
rm -rf "$NATIVE_LIBS_DIR"
rm -rf "$TMP_DIR"

# Create directory for native libraries
mkdir -p "$NATIVE_LIBS_DIR"

# --- AzureCommunicationCalling ---
CALLING_ZIP="AzureCommunicationCalling-2.16.0.zip"
CALLING_URL="https://github.com/Azure/Communication/releases/download/v2.16.0/${CALLING_ZIP}"
FULL_CALLING_ZIP_PATH="$NATIVE_LIBS_DIR/$CALLING_ZIP"

# Download Calling framework
if [ ! -f "$FULL_CALLING_ZIP_PATH" ]; then
  echo "--- Downloading AzureCommunicationCalling zip file ---"
  wget -q --show-progress "$CALLING_URL" -P "$NATIVE_LIBS_DIR"
else
  echo "--- AzureCommunicationCalling zip file already exists. Skipping download. ---"
fi

# --- AzureCommunicationCommon ---
COMMON_REPO="https://github.com/Azure/azure-sdk-for-ios.git"
COMMON_TAG="AzureCommunicationCommon_1.3.0"

# Clone Common framework repo
if [ ! -d "$COMMON_REPO_PATH" ]; then
  echo "--- Cloning AzureCommunicationCommon repository ---"
  git clone --depth 1 --branch "$COMMON_TAG" "$COMMON_REPO" "$COMMON_REPO_PATH"
else
  echo "--- AzureCommunicationCommon repository already exists. Skipping clone. ---"
fi

echo "--- Installing pods for AzureCommunicationCommon ---"
# Run pod install from the cloned repo directory
arch -x86_64 pod install --project-directory="$COMMON_REPO_PATH"

echo "--- Building AzureCommunicationCommon.xcframework ---"
mkdir -p "$ARCHIVES_DIR"
COMMON_WORKSPACE="$COMMON_REPO_PATH/AzureSDK.xcworkspace"
COMMON_SCHEME="AzureCommunicationCommon"

# Build for iOS device
echo "--- Archiving for iphoneos ---"
xcodebuild clean archive \
  -workspace "$COMMON_WORKSPACE" \
  -scheme "$COMMON_SCHEME" \
  -sdk iphoneos \
  -archivePath "$ARCHIVES_DIR/AzureCommunicationCommon-iOS.xcarchive" \
  SKIP_INSTALL=NO \
  BUILD_LIBRARY_FOR_DISTRIBUTION=YES

# Build for iOS simulator
echo "--- Archiving for iphonesimulator ---"
xcodebuild clean archive \
  -workspace "$COMMON_WORKSPACE" \
  -scheme "$COMMON_SCHEME" \
  -sdk iphonesimulator \
  -archivePath "$ARCHIVES_DIR/AzureCommunicationCommon-iOS_Simulator.xcarchive" \
  SKIP_INSTALL=NO \
  BUILD_LIBRARY_FOR_DISTRIBUTION=YES

# Create the XCFramework
echo "--- Creating AzureCommunicationCommon.xcframework ---"
mkdir -p "$PODS_DIR"
COMMON_XCFRAMEWORK_OUTPUT="$PODS_DIR/AzureCommunicationCommon.xcframework"
xcodebuild -create-xcframework \
  -framework "$ARCHIVES_DIR/AzureCommunicationCommon-iOS.xcarchive/Products/Library/Frameworks/AzureCommunicationCommon.framework" \
  -framework "$ARCHIVES_DIR/AzureCommunicationCommon-iOS_Simulator.xcarchive/Products/Library/Frameworks/AzureCommunicationCommon.framework" \
  -output "$COMMON_XCFRAMEWORK_OUTPUT"

# Define paths for flattening using absolute paths
DEVICE_COMMON_FRAMEWORK="$COMMON_XCFRAMEWORK_OUTPUT/ios-arm64/AzureCommunicationCommon.framework"
SIMULATOR_COMMON_FRAMEWORK="$COMMON_XCFRAMEWORK_OUTPUT/ios-arm64_x86_64-simulator/AzureCommunicationCommon.framework"

DEVICE_NESTED_FRAMEWORK_PATH="$DEVICE_COMMON_FRAMEWORK/Frameworks/Pods_AzureCommunicationCommon.framework"
SIMULATOR_NESTED_FRAMEWORK_PATH="$SIMULATOR_COMMON_FRAMEWORK/Frameworks/Pods_AzureCommunicationCommon.framework"

echo "--- Flattening Pods_AzureCommunicationCommon.framework ---"
sleep 5 # Give the file system a moment to settle after xcframework creation

# Function to flatten a specific slice
flatten_framework_slice() {
  local parent_framework_path="$1" # e.g., /absolute/path/to/AzureCommunicationCommon.xcframework/ios-arm64/AzureCommunicationCommon.framework
  local nested_framework_path="$2" # e.g., /absolute/path/to/AzureCommunicationCommon.xcframework/ios-arm64/AzureCommunicationCommon.framework/Frameworks/Pods_AzureCommunicationCommon.framework
  local nested_binary_name="Pods_AzureCommunicationCommon"

  echo "Inside flatten_framework_slice:"
  echo "  Parent framework path: $parent_framework_path"
  echo "  Nested framework path: $nested_framework_path"
  echo "  Contents of nested framework parent directory: $(dirname "$nested_framework_path")"
  ls -l "$(dirname "$nested_framework_path")"

  if [ -d "$nested_framework_path" ]; then
    echo "Found nested framework directory: $nested_framework_path"
    ls -l "$nested_framework_path"
    
    # Remove the nested framework entirely
    rm -rf "$nested_framework_path"
    echo "Removed nested framework directory: $nested_framework_path"

    # Also remove the binary if it was moved to the parent framework in a previous attempt
    local target_binary_path="${parent_framework_path}/${nested_binary_name}"
    if [ -f "$target_binary_path" ]; then
      rm -f "$target_binary_path"
      echo "Removed nested binary '$nested_binary_name' from '$parent_framework_path/'"
    fi

    # Check if the 'Frameworks' directory is now empty and remove it if so
    local frameworks_dir="${parent_framework_path}/Frameworks"
    if [ -d "${frameworks_dir}" ] && [ -z "$(ls -A "${frameworks_dir}")" ]; then
      rm -rf "${frameworks_dir}"
      echo "Removed empty Frameworks directory: ${frameworks_dir}"
    fi
  else
    echo "Nested framework directory not found for flattening: $nested_framework_path"
  fi

  # Additionally, check if Pods_AzureCommunicationCommon exists directly in the parent framework and remove it
  local direct_nested_item="${parent_framework_path}/${nested_binary_name}"
  if [ -e "$direct_nested_item" ]; then # -e checks for existence of file or directory
    rm -rf "$direct_nested_item"
    echo "Removed direct nested item '$direct_nested_item' from '$parent_framework_path/'"
  fi
}

# Apply flattening to both device and simulator slices
flatten_framework_slice "$DEVICE_COMMON_FRAMEWORK" "$DEVICE_NESTED_FRAMEWORK_PATH"
flatten_framework_slice "$SIMULATOR_COMMON_FRAMEWORK" "$SIMULATOR_NESTED_FRAMEWORK_PATH"

# --- Unzipping AzureCommunicationCalling framework ---
unzip -q "$NATIVE_LIBS_DIR/$CALLING_ZIP" -d "$PODS_DIR"

# --- Patching headers ---
echo "--- Patching header files to use relative paths for xcframeworks ---"
CALLING_ARM64_HEADER="$PODS_DIR/AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h"
CALLING_SIM_HEADER="$PODS_DIR/AzureCommunicationCalling.xcframework/ios-arm64_x86_64-simulator/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h"

# Check if files exist before patching
if [ -f "$CALLING_ARM64_HEADER" ] && [ -f "$CALLING_SIM_HEADER" ]; then
  # For arm64
  sed -i.bak 's|#import <AzureCommunicationCommon/AzureCommunicationCommon-Swift.h>|#import "../../../../AzureCommunicationCommon.xcframework/ios-arm64/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon-Swift.h"|' "$CALLING_ARM64_HEADER"
  # For simulator
  sed -i.bak 's|#import <AzureCommunicationCommon/AzureCommunicationCommon-Swift.h>|#import "../../../../AzureCommunicationCommon.xcframework/ios-arm64_x86_64-simulator/AzureCommunicationCommon.framework/Headers/AzureCommunicationCommon-Swift.h"|' "$CALLING_SIM_HEADER"
else
  echo "Header files not found, skipping patch."
fi

# --- Cleanup ---
echo "--- Cleaning up intermediate files ---"
rm -rf "$COMMON_REPO_PATH"
rm -rf "$ARCHIVES_DIR"

# --- Sharpie Bind ---
echo "--- Generating bindings with Objective Sharpie ---"
# Output "raw" bindings to tmp folder to keep a clean git history of binding changes
# Make sure you have the latest Sharpie version:
# 3.5 or greater. Download from here: http://aka.ms/objective-sharpie
# If you get "invalid sdk", list yours with "xcodebuild -showsdks"

# Explicitly point to the correct Xcode Developer directory (sharpie is not compatible with xcode above 16.2)
# export DEVELOPER_DIR="/Applications/Xcode16.2.app/Contents/Developer"

sharpie bind \
  -sdk iphoneos18.2 \
  -o "$TMP_DIR" \
  -namespace "Laerdal.Maui.AzureCommunicationCalling.iOS" \
  -scope "$PODS_DIR/AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/Headers" \
  "$PODS_DIR/AzureCommunicationCalling.xcframework/ios-arm64/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h" \
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
