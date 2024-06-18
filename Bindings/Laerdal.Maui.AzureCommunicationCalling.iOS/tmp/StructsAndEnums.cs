using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace Laerdal.Maui.AzureCommunicationCalling.iOS
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
		NoMultipleConnectionsWithSameIdentity = 0x200,
		InvalidServerCallId = 0x400,
		LocalVideoStreamSwitchSourceFailure = 0x800,
		IncomingCallAlreadyUnplaced = 0x1000,
		InvalidMeetingLink = 0x4000,
		ParticipantAddedToUnconnectedCall = 0x8000,
		ParticipantAlreadyAddedToCall = 0x10000,
		CallFeatureExtensionNotFound = 0x20000,
		DisplayNameLengthLongerThanSupported = 0x800000,
		FailedToHangupForEveryone = 0x1000000,
		NoMultipleConnectionsWithDifferentClouds = 0x2000000,
		DuplicateDeviceId = 0x40000,
		VirtualDeviceNotStarted = 0x100000,
		InvalidVideoStreamCombination = 0x400000,
		InvalidVideoFormat = 0x101,
		InvalidBuffer = 0x102,
		RawVideoFrameNotSent = 0x103,
		UnsupportedVideoStreamResolution = 0x104,
		FeatureExtensionNotFound = 0x4000000,
		VideoEffectNotSupported = 0x8000000,
		FailedToSendRawAudioBuffer = 0x5,
		CannotMuteVirtualAudioStream = 0x6,
		CaptionsFailedToStart = 0x105,
		CaptionsDisabledByConfigurations = 0x106,
		CaptionsPolicyDisabled = 0x107,
		CaptionsNotActive = 0x108,
		CaptionsRequestedLanguageNotSupported = 0x109,
		FailedToSetCaptionLanguage = 0x10a,
		SetCaptionLanguageDisabled = 0x10b,
		SetCaptionLanguageTeamsPremiumLicenseNeeded = 0x10c,
		CaptionsFailedToSetSpokenLanguage = 0x10d,
		CaptionsSetSpokenLanguageDisabled = 0x10e,
		GetCaptionsFailedCallStateNotConnected = 0x10f,
		GetCaptionsFailed = 0x110,
		SpotlightDisabledByConfigurations = 0x111,
		MaxSpotlightReached = 0x112,
		SpotlightParticipantEmptyList = 0x113,
		SignalingOperationFailed = 0x114,
		MusicModeNotEnabled = 0x115,
		LobbyDisabledByConfigurations = 0x11a,
		LobbyConversationTypeNotSupported = 0x11b,
		LobbyMeetingRoleNotAllowed = 0x11c,
		LobbyParticipantNotExist = 0x11d,
		RemoveParticipantOperationFailure = 0x11e,
		LobbyAdmitOperationFailure = 0x11f,
		ProxyNotAvailableForTeams = 0x120,
		FailedToSetMediaProxy = 0x121,
		MediaStatisticsInvalidReportInterval = 0x122,
		DataChannelFailedToStart = 0x123,
		DataChannelSenderClosed = 0x124,
		DataChannelRandomIdNotAvailable = 0x125,
		DataChannelMessageSizeOverLimit = 0x126,
		DataChannelMessageFailureForBandwidth = 0x127,
		DataChannelMessageFailureForTrafficLimit = 0x128,
		InvalidParticipantAddedToCall = 0x20000000,
		InvalidTokenProvider = 0x129,
		TeamsForLifeMeetingJoinNotSupported = 0x12a,
		SwitchSourceBlocked = 0x131
	}

	[Native]
	public enum ACSVideoStreamType : long
	{
		RemoteIncoming = 1,
		RawIncoming = 2,
		LocalOutgoing = 3,
		VirtualOutgoing = 4,
		ScreenShareOutgoing = 5
	}

	[Native]
	public enum ACSVideoStreamSourceType : long
	{
		Video = 1,
		ScreenSharing = 2
	}

	[Native]
	public enum ACSVideoStreamState : long
	{
		Available = 0,
		Started = 1,
		Stopping = 2,
		Stopped = 3,
		NotAvailable = 4
	}

	[Native]
	public enum ACSStreamDirection : long
	{
		Incoming = 0,
		Outgoing = 1
	}

	[Native]
	public enum ACSMediaStreamType : long
	{
		Video = 1,
		ScreenSharing = 2
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
	public enum ACSNoiseSuppressionMode : long
	{
		Off = 0,
		Auto = 1,
		Low = 2,
		High = 3
	}

	[Native]
	public enum ACSPushNotificationEventType : long
	{
		IncomingCall = 107,
		IncomingGroupCall = 109,
		IncomingPstnCall = 111,
		StopRinging = 110
	}

	[Native]
	public enum ACSCallParticipantRole : long
	{
		Uninitialized = 0,
		Attendee = 1,
		Consumer = 2,
		Presenter = 3,
		Organizer = 4,
		CoOrganizer = 5
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
	public enum ACSCommunicationCallType : long
	{
		Call = 0,
		TeamsCall = 1
	}

	[Native]
	public enum ACSScalingMode : long
	{
		Crop = 1,
		Fit = 2
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
	public enum ACSCallDirection : long
	{
		Outgoing = 1,
		Incoming = 2
	}

	[Native]
	public enum ACSCaptionsResultType : long
	{
		Partial = 0,
		Final = 1
	}

	[Native]
	public enum ACSCaptionsType : long
	{
		ACSCaptionsTypeTeamsCaptions = 0
	}

	[Native]
	public enum ACSRawVideoFrameType : long
	{
		Buffer = 0,
		Texture = 1
	}

	[Native]
	public enum ACSVideoStreamPixelFormat : long
	{
		Bgrx = 0,
		Bgr24 = 1,
		Rgbx = 2,
		Rgba = 3,
		Nv12 = 4,
		I420 = 5
	}

	[Native]
	public enum ACSVideoStreamResolution : long
	{
		Unknown = 0,
		P1080 = 1,
		P720 = 2,
		P540 = 3,
		P480 = 4,
		P360 = 5,
		P270 = 6,
		P240 = 7,
		P180 = 8,
		FullHd = 9,
		Hd = 10,
		Vga = 11,
		Qvga = 12
	}

	[Native]
	public enum ACSAudioStreamState : long
	{
		arted = 0,
		opped = 1
	}

	[Native]
	public enum ACSAudioStreamSampleRate : long
	{
		ACSAudioStreamSampleRateHz_16000 = 0,
		ACSAudioStreamSampleRateHz_22050 = 1,
		ACSAudioStreamSampleRateHz_24000 = 2,
		ACSAudioStreamSampleRateHz_32000 = 3,
		ACSAudioStreamSampleRateHz_44100 = 4,
		ACSAudioStreamSampleRateHz_48000 = 5
	}

	[Native]
	public enum ACSAudioStreamChannelMode : long
	{
		Mono = 0,
		Stereo = 1
	}

	[Native]
	public enum ACSAudioStreamFormat : long
	{
		ACSAudioStreamFormatPcm16Bit = 0
	}

	[Native]
	public enum ACSAudioStreamBufferDuration : long
	{
		ACSAudioStreamBufferDurationMs10 = 0,
		ACSAudioStreamBufferDurationMs20 = 1
	}

	[Native]
	public enum ACSAudioStreamType : long
	{
		RemoteIncoming = 1,
		RawIncoming = 2,
		LocalOutgoing = 3,
		VirtualOutgoing = 4
	}

	[Native]
	public enum ACSDiagnosticQuality : long
	{
		Unknown = 0,
		Good = 1,
		Poor = 2,
		Bad = 3
	}

	[Native]
	public enum ACSDataChannelPriority : long
	{
		Normal = 0,
		High = 1
	}

	[Native]
	public enum ACSDataChannelReliability : long
	{
		ACSDataChannelReliabilityLossy = 0
	}

	[Native]
	public enum ACSParticipantCapabilityType : long
	{
		TurnVideoOn = 0,
		UnmuteMicrophone = 1,
		ShareScreen = 2,
		RemoveParticipant = 3,
		HangUpForEveryone = 4,
		AddTeamsUser = 5,
		AddCommunicationUser = 6,
		AddPhoneNumber = 7,
		ManageLobby = 8,
		SpotlightParticipant = 9,
		RemoveParticipantSpotlight = 10,
		BlurBackground = 11,
		CustomBackground = 12,
		StartLiveCaptions = 13,
		RaiseHand = 14
	}

	[Native]
	public enum ACSCapabilitiesChangedReason : long
	{
		RoleChanged = 0,
		UserPolicyChanged = 1,
		MeetingDetailsChanged = 2
	}

	[Native]
	public enum ACSCapabilityResolutionReason : long
	{
		Capable = 0,
		CallTypeRestricted = 1,
		UserPolicyRestricted = 2,
		RoleRestricted = 3,
		MeetingRestricted = 4,
		FeatureNotSupported = 5,
		NotInitialized = 6,
		NotCapable = 7
	}
}
