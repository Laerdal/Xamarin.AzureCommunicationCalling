#!/bin/sh

rm -rf */Jars/*

gradle downloadAzureCalling
gradle downloadAzureCommon
gradle downloadAzureCore
gradle downloadAzureCoreLogging
gradle downloadTrouterClient

echo "Remember to delete Jars that are included in depended upon nugets"
