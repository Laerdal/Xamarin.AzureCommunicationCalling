#!/bin/bash

# This script builds the entire solution for a specified configuration.
# Usage: ./build.sh [Release | Debug]
# Defaults to Release if no configuration is provided.

# Exit immediately if a command exits with a non-zero status.
set -e

# 1. Determine the build configuration
CONFIGURATION=${1:-Release}
echo "Building all projects for configuration: $CONFIGURATION"

# --- Build Native Helper ---
echo "STEP 1: Building native Android helper library (.aar)..."
./AzureCommunicationCallingHelper/gradlew -p AzureCommunicationCallingHelper assembleRelease
echo "Native helper library built successfully."
echo ""

# --- Copy Helper AAR ---
echo "STEP 2: Copying helper .aar to the .NET binding project..."
mkdir -p Laerdal.Maui.AzureCommunicationCallingHelper.Android/Jars/
cp AzureCommunicationCallingHelper/AzureCommunicationHelper/build/outputs/aar/AzureCommunicationHelper-release.aar Laerdal.Maui.AzureCommunicationCallingHelper.Android/Jars/
echo "Helper .aar copied successfully."
echo ""

# --- Build Main .NET Binding ---
MAIN_PROJECT_PATH="Laerdal.Maui.AzureCommunicationCalling.Android/Laerdal.Maui.AzureCommunicationCalling.Android.csproj"
echo "STEP 3: Building main .NET binding project..."
dotnet build "$MAIN_PROJECT_PATH" -c "$CONFIGURATION"
echo "Main .NET binding project built successfully."
echo ""

# --- Build Helper .NET Binding ---
HELPER_PROJECT_PATH="Laerdal.Maui.AzureCommunicationCallingHelper.Android/Laerdal.Maui.AzureCommunicationCallingHelper.Android.csproj"
# Use an absolute path for the local NuGet source to avoid any ambiguity
MAIN_PROJECT_OUTPUT_PATH="$(pwd)/Laerdal.Maui.AzureCommunicationCalling.Android/bin/$CONFIGURATION"
echo "STEP 4: Building helper .NET binding project..."
echo "(Using local NuGet source: $MAIN_PROJECT_OUTPUT_PATH)"
dotnet build "$HELPER_PROJECT_PATH" -c "$CONFIGURATION" --source "$MAIN_PROJECT_OUTPUT_PATH"
echo "Helper .NET binding project built successfully."
echo ""

echo "---------------------------------------------------"
echo "Build complete."
echo "NuGet packages are available in the bin/$CONFIGURATION directories of their respective projects."
echo "---------------------------------------------------"
