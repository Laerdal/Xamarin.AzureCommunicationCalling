#!/bin/sh

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

sharpie bind \
    -sdk iphoneos14.1 \
    -o tmp \
    -namespace "Xamarin.AzureCommunicationCalling.iOS" \
    -scope nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers \
    nativeLibs/Pods/AzureCommunicationCalling/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h \
    -c -fmodules \

