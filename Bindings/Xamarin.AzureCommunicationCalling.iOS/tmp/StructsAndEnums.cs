using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace Xamarin.AzureCommunicationCalling.iOS
{
	[StructLayout (LayoutKind.Sequential)]
	public struct ACSStreamSize
	{
		public int width;

		public int height;
	}

	[Flags]
	[Native]
	public enum ACSCallingCommunicationErrors : long
	{
		None = 0x0,
		NoAudioPermission = 0x1,
		NoVideoPermission = 0x2,
		NoAudioAndVideoPermission = 0x3,
		ReceivedInvalidPushNotificationPayload = 0x4,
		FailedToProcessPushNotificationPayload = 0x8,
		InvalidGuidGroupId = 0x10,
		InvalidPushNotificationDeviceRegistrationToken = 0x20,
		MultipleRenderersNotSupported = 0x40,
		MultipleViewsNotSupported = 0x80,
		InvalidLocalVideoStreamForVideoOptions = 0x100,
		NoMultipleConnectionsWithSameIdentity = 0x200
	}

	[Native]
	public enum ACSCameraFacing : long
	{
		Unknown = 0,
		External = 1,
		Front = 2,
		Back = 3,
		Panoramic = 4,
		LeftFront = 5,
		RightFront = 6
	}

	[Native]
	public enum ACSVideoDeviceType : long
	{
		Unknown = 0,
		UsbCamera = 1,
		CaptureAdapter = 2,
		Virtual = 3
	}

	[Native]
	public enum ACSMediaStreamType : long
	{
		Video = 1,
		ScreenSharing = 2
	}

	[Native]
	public enum ACSParticipantState : long
	{
		Idle = 0,
		EarlyMedia = 1,
		Connecting = 2,
		Connected = 3,
		Hold = 4,
		InLobby = 5,
		Disconnected = 6,
		Ringing = 7
	}

	[Native]
	public enum ACSCallState : long
	{
		None = 0,
		EarlyMedia = 1,
		Connecting = 3,
		Ringing = 4,
		Connected = 5,
		LocalHold = 6,
		Disconnecting = 7,
		Disconnected = 8,
		InLobby = 9,
		RemoteHold = 10
	}

	[Native]
	public enum ACSCallDirection : long
	{
		Outgoing = 1,
		Incoming = 2
	}

	[Native]
	public enum ACSDtmfTone : long
	{
		Zero = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6,
		Seven = 7,
		Eight = 8,
		Nine = 9,
		Star = 10,
		Pound = 11,
		A = 12,
		B = 13,
		C = 14,
		D = 15,
		Flash = 16
	}

	[Native]
	public enum ACSScalingMode : long
	{
		Crop = 1,
		Fit = 2
	}

	[Native]
	public enum ACSHandleType : long
	{
		Unknown = 0,
		GroupCallLocator = 1
	}
}
