#!/bin/sh

rm -rf */Jars/*

gradle downloadCalling
gradle downloadCommon
gradle downloadCore
gradle downloadLogging
