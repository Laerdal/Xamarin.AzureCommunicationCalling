#!/bin/sh

# First get the latest version of the native pods:
cd nativeLibs
sh fetchPods.sh
cd ..

# For this to work, change includes of azure deps(core and communication) header files
# in below .h file, to reltive includes.
# Instead of :
#
#import <AzureCommunication/AzureCommunication-Swift.h>
#import <AzureCore/AzureCore-Swift.h>
#
# Make it look like this:
#
#import "../../AzureCommunication.framework/Headers/AzureCommunication-Swift.h"
#import "../../AzureCore.framework/Headers/AzureCore-Swift.h"
#
patch -s -p0 -N < AzureCommunicationCalling.h.patch

# Output "raw" bindings to tmp folder to keep a clean git history of binding changes
sharpie bind \
    -sdk iphoneos14.4 \
    -o tmp \
    -namespace "Xamarin.AzureCommunicationCalling.iOS" \
    -scope nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers \
    nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h \
    -c -fmodules \

# Lastly: manually copy tmp bindings into this folder and make it work
echo "Remember to merge new tmp/*.cs into ./*.cs"
