This is a tiny wrapper aar around the parts of the Azure Communication Services
that uses RetroFutures in its interface.

The RetroFutures do not play well with the Maui binding library.

The wrapper translates these futures into regular waits, which can then be
bound with a Maui binding library.

To build, just run "gradle build" from the command line(in the AzureCommunicationHelper folder), 
the output will be in the folder build/outputs/aar/AzureCommunicationCallingHelper-release.aar

Whenever there are changes, you need to pull in the new ACS dependency version in
build.gradle.kts and make relevant changes to:
AzureCommunicationCallingHelper/src/main/java/com/laerdal/azurecommunicationhelper/CallClientHelper.java

When you have a compiled aar you want to use, move it into 
Laerdal.Maui.AzureCommunicationCallingHelper.Android/Jars
up the version and compile it to produce new nuget.

