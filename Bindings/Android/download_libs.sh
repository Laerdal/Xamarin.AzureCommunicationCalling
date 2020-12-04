#!/bin/sh

rm */Jars/*

gradle -b calling.gradle download
gradle -b common.gradle download
gradle -b core.gradle download
