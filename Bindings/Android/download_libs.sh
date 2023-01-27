#!/bin/sh

rm -rf */Jars/*

gradle downloadCalling
gradle downloadCommon
gradle downloadCore
gradle downloadLogging

echo "Remember to delete Jars that are included in depended upon nugets"

