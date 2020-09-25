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

sharpie bind \
    -sdk iphoneos14.0 \
    -o tmp \
    -namespace "Xamarin.AzureCommunicationCalling.iOS" \
    -scope NativeSDK/AzureCommunicationCalling.framework/Headers \
    NativeSDK/AzureCommunicationCalling.framework/Headers/AzureCommunicationCalling.h \
    -c -fmodules \
