using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace Xamarin.AzureCommunicationCalling.iOS
{
	[StructLayout(LayoutKind.Sequential)]
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
		NoMultipleConnectionsWithSameIdentity = 0x200,
		InvalidServerCallId = 0x400,
		LocalVideoStreamSwitchSourceFailure = 0x800,
		IncomingCallAlreadyUnplaced = 0x1000,
		InvalidMeetingLink = 0x4000,
		ParticipantAddedToUnconnectedCall = 0x8000,
		ParticipantAlreadyAddedToCall = 0x10000,
		CallFeatureExtensionNotFound = 0x20000,
		DuplicateDeviceId = 0x40000,
		DelegateIsRequired = 0x80000,
		VirtualDeviceNotStarted = 0x100000,
		InvalidVideoStreamCombination = 0x400000,
		DisplayNameLengthLongerThanSupported = 0x800000,
		FailedToHangupForEveryone = 0x1000000,
		NoMultipleConnectionsWithDifferentClouds = 0x2000000,
		NoActiveAudioStreamToStop = 0x4000000,
	}

	[Native]
	public enum ACSMediaStreamType : long
	{
		Video = 1,
		ScreenSharing = 2,
	}

	[Native]
	public enum ACSOutgoingVideoStreamKind : long
	{
		None = 0,
		Local = 1,
		Virtual = 2,
		ScreenShare = 3,
	}

	[Native]
	public enum ACSOutgoingVideoStreamState : long
	{
		None = 0,
		Started = 1,
		Stopped = 2,
		Failed = 3,
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
		RightFront = 6,
	}

	[Native]
	public enum ACSVideoDeviceType : long
	{
		Unknown = 0,
		UsbCamera = 1,
		CaptureAdapter = 2,
		Virtual = 3,
	}

	[Native]
	public enum ACSAudioStreamKind : long
	{
		None = 0,
		Local = 1,
		Virtual = 2,
	}

	public enum ACSParticipantRole : long
	{
		Unknown = 0,
		Attendee = 1,
		Consumer = 2,
		Presenter = 3,
		Organizer = 4,
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
		Ringing = 7,
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
		RemoteHold = 10,
	}
	[Native]
	public enum ACSCallDirection : long
	{
		Outgoing = 1,
		Incoming = 2,
	}

	[Native]
	public enum ACSMediaStreamDirection : long
	{
		None = 0,
		Incoming = 1,
		Outgoing = 2,
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
		Flash = 16,
	}

	[Native]
	public enum ACSScalingMode : long
	{
		Crop = 1,
		Fit = 2,
	}

	[Native]
	public enum ACSRecordingState : long
	{
		Started = 0,
		Paused = 1,
		Ended = 2,
	}

	[Native]
	public enum ACSVideoFrameKind : long
	{
		None = 0,
		VideoSoftware = 1,
		VideoHardware = 2,
	}

	[Native]
	public enum ACSPixelFormat : long
	{
		None = 0,
		Bgrx = 1,
		Bgr24 = 2,
		Rgbx = 3,
		Rgba = 4,
		Nv12 = 5,
		I420 = 6,
	}

	[Native]
	public enum ACSResultType : long
	{
		Intermediate = 0,
		Final = 1,
	}
}