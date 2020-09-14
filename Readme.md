iOS binding library for project spool
=====================================

Use this library to make spool calls(AzureCommunicationCalling).

The native package is so big(120MB) that github wont accept it in a regular repo,
so you need to install LFS to get all the files:

https://docs.github.com/en/github/managing-large-files/installing-git-large-file-storage

* Update library

When updating to new version:

Extract all deps, and make sure header files points to deps correctly, then run this sharpie command:
Make sure you have latest sharpie version.
Latest is NOT what is shown at ms docs.. docs say 3.4,
but 3.5 is latest as of now, download from here: http://aka.ms/objective-sharpie

Run this command:
sharpie bind -o SpoolCalling -sdk iphoneos13.7 -scope . Headers/\*.h

Edit generated files to fix namesapce, and any "Verify".
Also, remove the generated nested Action\<Action\< attribute (constructor), which mono doesnt like

Then copy files into binding lib
