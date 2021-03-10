using System;
using AzureCommunication;
using AzureCommunicationCalling;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin.AzureCommunicationCalling.iOS
{
	[Static]
	[Verify (ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double AzureCommunicationVersionNumber;
		[Field ("AzureCommunicationVersionNumber", "__Internal")]
		double AzureCommunicationVersionNumber { get; }

		// extern const unsigned char [] AzureCommunicationVersionString;
		[Field ("AzureCommunicationVersionString", "__Internal")]
		byte[] AzureCommunicationVersionString { get; }
	}

	// @interface CommunicationAccessToken : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC18AzureCommunication24CommunicationAccessToken")]
	[DisableDefaultCtor]
	interface CommunicationAccessToken
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull token;
		[Export ("token")]
		string Token { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull expiresOn;
		[Export ("expiresOn", ArgumentSemantic.Copy)]
		NSDate ExpiresOn { get; }

		// -(instancetype _Nonnull)initWithToken:(NSString * _Nonnull)token expiresOn:(NSDate * _Nonnull)expiresOn __attribute__((objc_designated_initializer));
		[Export ("initWithToken:expiresOn:")]
		[DesignatedInitializer]
		IntPtr Constructor (string token, NSDate expiresOn);
	}

	// @interface CommunicationCloudEnvironment : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC18AzureCommunication29CommunicationCloudEnvironment")]
	[DisableDefaultCtor]
	interface CommunicationCloudEnvironment
	{
		// @property (readonly, nonatomic, strong, class) CommunicationCloudEnvironment * _Nonnull Public;
		[Static]
		[Export ("Public", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment Public { get; }

		// @property (readonly, nonatomic, strong, class) CommunicationCloudEnvironment * _Nonnull Dod;
		[Static]
		[Export ("Dod", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment Dod { get; }

		// @property (readonly, nonatomic, strong, class) CommunicationCloudEnvironment * _Nonnull Gcch;
		[Static]
		[Export ("Gcch", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment Gcch { get; }

		// -(instancetype _Nonnull)initWithEnvironmentValue:(NSString * _Nonnull)environmentValue __attribute__((objc_designated_initializer));
		[Export ("initWithEnvironmentValue:")]
		[DesignatedInitializer]
		IntPtr Constructor (string environmentValue);
	}

	// @protocol CommunicationIdentifier <NSObject>
	/*
  Check whether adding [Model] to this declaration is appropriate.
  [Model] is used to generate a C# class that implements this protocol,
  and might be useful for protocols that consumers are supposed to implement,
  since consumers can subclass the generated class instead of implementing
  the generated interface. If consumers are not supposed to implement this
  protocol, then [Model] is redundant and will generate code that will never
  be used.
*/[Protocol (Name = "_TtP18AzureCommunication23CommunicationIdentifier_")]
	[BaseType (typeof(NSObject), Name = "_TtP18AzureCommunication23CommunicationIdentifier_")]
	interface CommunicationIdentifier
	{
	}

	// @interface CommunicationTokenCredential : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC18AzureCommunication28CommunicationTokenCredential")]
	[DisableDefaultCtor]
	interface CommunicationTokenCredential
	{
		// -(instancetype _Nullable)initWithToken:(NSString * _Nonnull)token error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithToken:error:")]
		[DesignatedInitializer]
		IntPtr Constructor (string token, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWith:(CommunicationTokenRefreshOptions * _Nonnull)option error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWith:error:")]
		[DesignatedInitializer]
		IntPtr Constructor (CommunicationTokenRefreshOptions option, [NullAllowed] out NSError error);

		// -(void)tokenWithCompletionHandler:(void (^ _Nonnull)(CommunicationAccessToken * _Nullable, NSError * _Nullable))completionHandler;
		[Export ("tokenWithCompletionHandler:")]
		void TokenWithCompletionHandler (Action<CommunicationAccessToken, NSError> completionHandler);
	}

	// @interface CommunicationTokenRefreshOptions : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC18AzureCommunication32CommunicationTokenRefreshOptions")]
	[DisableDefaultCtor]
	interface CommunicationTokenRefreshOptions
	{
		// -(instancetype _Nonnull)initWithInitialToken:(NSString * _Nullable)initialToken refreshProactively:(BOOL)refreshProactively tokenRefresher:(void (^ _Nonnull)(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable)))tokenRefresher __attribute__((objc_designated_initializer));
		[Export ("initWithInitialToken:refreshProactively:tokenRefresher:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] string initialToken, bool refreshProactively, Action<Action<NSString, NSError>> tokenRefresher);
	}

	// @interface CommunicationUserIdentifier : NSObject <CommunicationIdentifier>
	[BaseType (typeof(NSObject), Name = "_TtC18AzureCommunication27CommunicationUserIdentifier")]
	[DisableDefaultCtor]
	interface CommunicationUserIdentifier : ICommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor (string identifier);
	}

	// @interface MicrosoftTeamsUserIdentifier : NSObject <CommunicationIdentifier>
	[BaseType (typeof(NSObject), Name = "_TtC18AzureCommunication28MicrosoftTeamsUserIdentifier")]
	[DisableDefaultCtor]
	interface MicrosoftTeamsUserIdentifier : ICommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable rawId;
		[NullAllowed, Export ("rawId")]
		string RawId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull userId;
		[Export ("userId")]
		string UserId { get; }

		// @property (readonly, nonatomic) BOOL isAnonymous;
		[Export ("isAnonymous")]
		bool IsAnonymous { get; }

		// @property (readonly, nonatomic, strong) CommunicationCloudEnvironment * _Nonnull cloudEnviroment;
		[Export ("cloudEnviroment", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment CloudEnviroment { get; }

		// -(instancetype _Nonnull)initWithUserId:(NSString * _Nonnull)userId isAnonymous:(BOOL)isAnonymous rawId:(NSString * _Nullable)rawId cloudEnvironment:(CommunicationCloudEnvironment * _Nonnull)cloudEnvironment __attribute__((objc_designated_initializer));
		[Export ("initWithUserId:isAnonymous:rawId:cloudEnvironment:")]
		[DesignatedInitializer]
		IntPtr Constructor (string userId, bool isAnonymous, [NullAllowed] string rawId, CommunicationCloudEnvironment cloudEnvironment);

		// -(instancetype _Nonnull)initWithUserId:(NSString * _Nonnull)userId isAnonymous:(BOOL)isAnonymous __attribute__((objc_designated_initializer));
		[Export ("initWithUserId:isAnonymous:")]
		[DesignatedInitializer]
		IntPtr Constructor (string userId, bool isAnonymous);
	}

	// @interface PhoneNumberIdentifier : NSObject <CommunicationIdentifier>
	[BaseType (typeof(NSObject), Name = "_TtC18AzureCommunication21PhoneNumberIdentifier")]
	[DisableDefaultCtor]
	interface PhoneNumberIdentifier : ICommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull phoneNumber;
		[Export ("phoneNumber")]
		string PhoneNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable rawId;
		[NullAllowed, Export ("rawId")]
		string RawId { get; }

		// -(instancetype _Nonnull)initWithPhoneNumber:(NSString * _Nonnull)phoneNumber rawId:(NSString * _Nullable)rawId __attribute__((objc_designated_initializer));
		[Export ("initWithPhoneNumber:rawId:")]
		[DesignatedInitializer]
		IntPtr Constructor (string phoneNumber, [NullAllowed] string rawId);
	}

	// @interface UnknownIdentifier : NSObject <CommunicationIdentifier>
	[BaseType (typeof(NSObject), Name = "_TtC18AzureCommunication17UnknownIdentifier")]
	[DisableDefaultCtor]
	interface UnknownIdentifier : ICommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor (string identifier);
	}

	// @interface ACSRendererView : UIView
	[BaseType (typeof(UIView))]
	[DisableDefaultCtor]
	interface ACSRendererView
	{
		// -(void)updateScalingMode:(ACSScalingMode)scalingMode __attribute__((swift_name("update(scalingMode:)")));
		[Export ("updateScalingMode:")]
		void UpdateScalingMode (ACSScalingMode scalingMode);

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();

		// -(_Bool)isRendering;
		[Export ("isRendering")]
		[Verify (MethodToProperty)]
		bool IsRendering { get; }
	}

	// @interface ACSStreamSize : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSStreamSize
	{
		// -(instancetype)initWithWidth:(int)width height:(int)height __attribute__((swift_name("init(width:height:)")));
		[Export ("initWithWidth:height:")]
		IntPtr Constructor (int width, int height);

		// @property (readonly) int width;
		[Export ("width")]
		int Width { get; }

		// @property (readonly) int height;
		[Export ("height")]
		int Height { get; }
	}

	// @protocol ACSRendererDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSRendererDelegate
	{
		// @required -(void)rendererFailedToStart;
		[Abstract]
		[Export ("rendererFailedToStart")]
		void RendererFailedToStart ();

		// @optional -(void)onFirstFrameRendered;
		[Export ("onFirstFrameRendered")]
		void OnFirstFrameRendered ();
	}

	// @interface ACSVideoStreamRenderer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoStreamRenderer
	{
		// -(instancetype _Nonnull)initWithLocalVideoStream:(ACSLocalVideoStream * _Nonnull)localVideoStream withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("init(localVideoStream:)")));
		[Export ("initWithLocalVideoStream:withError:")]
		IntPtr Constructor (ACSLocalVideoStream localVideoStream, [NullAllowed] out NSError error);

		// -(instancetype _Nonnull)initWithRemoteVideoStream:(ACSRemoteVideoStream * _Nonnull)remoteVideoStream withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("init(remoteVideoStream:)")));
		[Export ("initWithRemoteVideoStream:withError:")]
		IntPtr Constructor (ACSRemoteVideoStream remoteVideoStream, [NullAllowed] out NSError error);

		// -(ACSRendererView * _Nonnull)createView:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("createView()")));
		[Export ("createView:")]
		ACSRendererView CreateView ([NullAllowed] out NSError error);

		// -(ACSRendererView * _Nonnull)createViewWithOptions:(ACSRenderingOptions * _Nullable)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("createView(with:)")));
		[Export ("createViewWithOptions:withError:")]
		ACSRendererView CreateViewWithOptions ([NullAllowed] ACSRenderingOptions options, [NullAllowed] out NSError error);

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();

		// @property (readonly) ACSStreamSize * _Nonnull size;
		[Export ("size")]
		ACSStreamSize Size { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRendererDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSRendererDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }
	}

	// @protocol ACSInternalTokenProviderDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSInternalTokenProviderDelegate
	{
		// @optional -(void)onTokenRequested:(ACSInternalTokenProvider *)internalTokenProvider :(ACSInternalTokenProvider *)sender __attribute__((swift_name("onTokenRequested(_:sender:)")));
		[Export ("onTokenRequested::")]
		void  (ACSInternalTokenProvider internalTokenProvider, ACSInternalTokenProvider sender);
	}

	// @protocol ACSCallAgentDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSCallAgentDelegate
	{
		// @optional -(void)onCallsUpdated:(ACSCallAgent *)callAgent :(ACSCallsUpdatedEventArgs *)args __attribute__((swift_name("onCallsUpdated(_:args:)")));
		[Export ("onCallsUpdated::")]
		void OnCallsUpdated (ACSCallAgent callAgent, ACSCallsUpdatedEventArgs args);

		// @optional -(void)onIncomingCall:(ACSCallAgent *)callAgent :(ACSIncomingCall *)incomingcall __attribute__((swift_name("onIncomingCall(_:incomingcall:)")));
		[Export ("onIncomingCall::")]
		void OnIncomingCall (ACSCallAgent callAgent, ACSIncomingCall incomingcall);
	}

	// @protocol ACSCallDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSCallDelegate
	{
		// @optional -(void)onIdChanged:(ACSCall *)call :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onIdChanged(_:args:)")));
		[Export ("onIdChanged::")]
		void OnIdChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onStateChanged:(ACSCall *)call :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onStateChanged(_:args:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onRemoteParticipantsUpdated:(ACSCall *)call :(ACSParticipantsUpdatedEventArgs *)args __attribute__((swift_name("onRemoteParticipantsUpdated(_:args:)")));
		[Export ("onRemoteParticipantsUpdated::")]
		void OnRemoteParticipantsUpdated (ACSCall call, ACSParticipantsUpdatedEventArgs args);

		// @optional -(void)onLocalVideoStreamsChanged:(ACSCall *)call :(ACSLocalVideoStreamsUpdatedEventArgs *)args __attribute__((swift_name("onLocalVideoStreamsChanged(_:args:)")));
		[Export ("onLocalVideoStreamsChanged::")]
		void OnLocalVideoStreamsChanged (ACSCall call, ACSLocalVideoStreamsUpdatedEventArgs args);

		// @optional -(void)onIsRecordingActiveChanged:(ACSCall *)call :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onIsRecordingActiveChanged(_:args:)")));
		[Export ("onIsRecordingActiveChanged::")]
		void OnIsRecordingActiveChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsTranscriptionActiveChanged:(ACSCall *)call :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onIsTranscriptionActiveChanged(_:args:)")));
		[Export ("onIsTranscriptionActiveChanged::")]
		void OnIsTranscriptionActiveChanged (ACSCall call, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSRemoteParticipantDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSRemoteParticipantDelegate
	{
		// @optional -(void)onStateChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onStateChanged(_:args:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsMutedChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onIsMutedChanged(_:args:)")));
		[Export ("onIsMutedChanged::")]
		void OnIsMutedChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsSpeakingChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onIsSpeakingChanged(_:args:)")));
		[Export ("onIsSpeakingChanged::")]
		void OnIsSpeakingChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onDisplayNameChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onDisplayNameChanged(_:args:)")));
		[Export ("onDisplayNameChanged::")]
		void OnDisplayNameChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onVideoStreamsUpdated:(ACSRemoteParticipant *)remoteParticipant :(ACSRemoteVideoStreamsEventArgs *)args __attribute__((swift_name("onVideoStreamsUpdated(_:args:)")));
		[Export ("onVideoStreamsUpdated::")]
		void OnVideoStreamsUpdated (ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args);
	}

	// @protocol ACSIncomingCallDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSIncomingCallDelegate
	{
		// @optional -(void)onCallEnded:(ACSIncomingCall *)incomingCall :(ACSPropertyChangedEventArgs *)args __attribute__((swift_name("onCallEnded(_:args:)")));
		[Export ("onCallEnded::")]
		void  (ACSIncomingCall incomingCall, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSDeviceManagerDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSDeviceManagerDelegate
	{
		// @optional -(void)onCamerasUpdated:(ACSDeviceManager *)deviceManager :(ACSVideoDevicesUpdatedEventArgs *)args __attribute__((swift_name("onCamerasUpdated(_:args:)")));
		[Export ("onCamerasUpdated::")]
		void  (ACSDeviceManager deviceManager, ACSVideoDevicesUpdatedEventArgs args);
	}

	// @interface ACSVideoOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoOptions
	{
		// -(instancetype)init:(ACSLocalVideoStream *)localVideoStream __attribute__((swift_name("init(localVideoStream:)")));
		[Export ("init:")]
		IntPtr Constructor (ACSLocalVideoStream localVideoStream);

		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSLocalVideoStream * localVideoStream;
		[Export ("localVideoStream", ArgumentSemantic.Retain)]
		ACSLocalVideoStream LocalVideoStream { get; set; }
	}

	// @interface ACSLocalVideoStream : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSLocalVideoStream
	{
		// -(instancetype)init:(ACSVideoDeviceInfo *)camera __attribute__((swift_name("init(camera:)")));
		[Export ("init:")]
		IntPtr Constructor (ACSVideoDeviceInfo camera);

		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSVideoDeviceInfo * source;
		[Export ("source", ArgumentSemantic.Retain)]
		ACSVideoDeviceInfo Source { get; }

		// @property (readonly) BOOL isSending;
		[Export ("isSending")]
		bool IsSending { get; }

		// @property (readonly) ACSMediaStreamType mediaStreamType;
		[Export ("mediaStreamType")]
		ACSMediaStreamType MediaStreamType { get; }

		// -(void)switchSource:(ACSVideoDeviceInfo *)camera withCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("switchSource(camera:completionHandler:)")));
		[Export ("switchSource:withCompletionHandler:")]
		void SwitchSource (ACSVideoDeviceInfo camera, Action<NSError> completionHandler);
	}

	// @interface ACSVideoDeviceInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoDeviceInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }

		// @property (readonly, retain) NSString * id;
		[Export ("id", ArgumentSemantic.Retain)]
		string Id { get; }

		// @property (readonly) ACSCameraFacing cameraFacing;
		[Export ("cameraFacing")]
		ACSCameraFacing CameraFacing { get; }

		// @property (readonly) ACSVideoDeviceType deviceType;
		[Export ("deviceType")]
		ACSVideoDeviceType DeviceType { get; }
	}

	// @interface ACSInternalTokenProvider : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSInternalTokenProvider
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		[Wrap ("WeakDelegate")]
		ACSInternalTokenProviderDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSInternalTokenProviderDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(void)setTokenWithToken:(NSString *)token accountIdentity:(NSString *)accountIdentity displayName:(NSString *)displayName resourceId:(NSString *)resourceId __attribute__((swift_name("set(with:accountIdentity:displayName:resourceId:)")));
		[Export ("setTokenWithToken:accountIdentity:displayName:resourceId:")]
		void SetTokenWithToken (string token, string accountIdentity, string displayName, string resourceId);

		// -(void)setError:(NSString *)error __attribute__((swift_name("set(error:)")));
		[Export ("setError:")]
		void SetError (string error);
	}

	// @interface ACSAudioOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSAudioOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property BOOL muted;
		[Export ("muted")]
		bool Muted { get; set; }
	}

	// @interface ACSJoinCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSJoinCallOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSVideoOptions * videoOptions;
		[Export ("videoOptions", ArgumentSemantic.Retain)]
		ACSVideoOptions VideoOptions { get; set; }

		// @property (retain) ACSAudioOptions * audioOptions;
		[Export ("audioOptions", ArgumentSemantic.Retain)]
		ACSAudioOptions AudioOptions { get; set; }
	}

	// @interface ACSAcceptCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSAcceptCallOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSVideoOptions * videoOptions;
		[Export ("videoOptions", ArgumentSemantic.Retain)]
		ACSVideoOptions VideoOptions { get; set; }
	}

	// @interface ACSStartCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSStartCallOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSVideoOptions * videoOptions;
		[Export ("videoOptions", ArgumentSemantic.Retain)]
		ACSVideoOptions VideoOptions { get; set; }

		// @property (retain) ACSAudioOptions * audioOptions;
		[Export ("audioOptions", ArgumentSemantic.Retain)]
		ACSAudioOptions AudioOptions { get; set; }

		// @property (nonatomic) PhoneNumberIdentifier * _Nonnull alternateCallerID;
		[Export ("alternateCallerID", ArgumentSemantic.Assign)]
		PhoneNumberIdentifier AlternateCallerID { get; set; }
	}

	// @interface ACSAddParticipantOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSAddParticipantOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();
	}

	// @interface ACSAddPhoneNumberOptions : ACSAddParticipantOptions
	[BaseType (typeof(ACSAddParticipantOptions))]
	interface ACSAddPhoneNumberOptions
	{
		// @property (nonatomic) PhoneNumberIdentifier * _Nonnull alternateCallerID;
		[Export ("alternateCallerID", ArgumentSemantic.Assign)]
		PhoneNumberIdentifier AlternateCallerID { get; set; }
	}

	// @interface ACSJoinMeetingLocator : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSJoinMeetingLocator
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();
	}

	// @interface ACSGroupCallLocator : ACSJoinMeetingLocator
	[BaseType (typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSGroupCallLocator
	{
		// -(instancetype)init:(NSUUID *)groupId __attribute__((swift_name("init(groupId:)")));
		[Export ("init:")]
		IntPtr Constructor (NSUuid groupId);

		// @property NSUUID * groupId;
		[Export ("groupId", ArgumentSemantic.Assign)]
		NSUuid GroupId { get; set; }
	}

	// @interface ACSTeamsMeetingCoordinatesLocator : ACSJoinMeetingLocator
	[BaseType (typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSTeamsMeetingCoordinatesLocator
	{
		// -(instancetype)initWithThreadId:(NSString *)threadId organizerId:(NSUUID *)organizerId tenantId:(NSUUID *)tenantId messageId:(NSString *)messageId __attribute__((swift_name("init(with:organizerId:tenantId:messageId:)")));
		[Export ("initWithThreadId:organizerId:tenantId:messageId:")]
		IntPtr Constructor (string threadId, NSUuid organizerId, NSUuid tenantId, string messageId);

		// @property (readonly, retain) NSString * threadId;
		[Export ("threadId", ArgumentSemantic.Retain)]
		string ThreadId { get; }

		// @property NSUUID * organizerId;
		[Export ("organizerId", ArgumentSemantic.Assign)]
		NSUuid OrganizerId { get; set; }

		// @property NSUUID * tenantId;
		[Export ("tenantId", ArgumentSemantic.Assign)]
		NSUuid TenantId { get; set; }

		// @property (readonly, retain) NSString * messageId;
		[Export ("messageId", ArgumentSemantic.Retain)]
		string MessageId { get; }
	}

	// @interface ACSTeamsMeetingLinkLocator : ACSJoinMeetingLocator
	[BaseType (typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSTeamsMeetingLinkLocator
	{
		// -(instancetype)init:(NSString *)meetingLink __attribute__((swift_name("init(meetingLink:)")));
		[Export ("init:")]
		IntPtr Constructor (string meetingLink);

		// @property (readonly, retain) NSString * meetingLink;
		[Export ("meetingLink", ArgumentSemantic.Retain)]
		string MeetingLink { get; }
	}

	// @interface ACSCallerInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallerInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * displayName;
		[Export ("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; }

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export ("identifier")]
		CommunicationIdentifier Identifier { get; }
	}

	// @interface ACSPushNotificationInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSPushNotificationInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * fromDisplayName;
		[Export ("fromDisplayName", ArgumentSemantic.Retain)]
		string FromDisplayName { get; }

		// @property (readonly) BOOL incomingWithVideo;
		[Export ("incomingWithVideo")]
		bool IncomingWithVideo { get; }

		// @property (readonly, retain) id<CommunicationIdentifier> from;
		[Export ("from", ArgumentSemantic.Retain)]
		CommunicationIdentifier From { get; }

		// @property (readonly, retain) id<CommunicationIdentifier> to;
		[Export ("to", ArgumentSemantic.Retain)]
		CommunicationIdentifier To { get; }

		// @property (readonly, nonatomic) NSUUID * _Nonnull callId;
		[Export ("callId")]
		NSUuid CallId { get; }

		// +(ACSPushNotificationInfo *)fromDictionary:(NSDictionary *)payload;
		[Static]
		[Export ("fromDictionary:")]
		ACSPushNotificationInfo FromDictionary (NSDictionary payload);
	}

	// @interface ACSCallAgentOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallAgentOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) NSString * displayName;
		[Export ("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; set; }
	}

	// @interface ACSCallAgent : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallAgent
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSCall *> * calls;
		[Export ("calls", ArgumentSemantic.Copy)]
		ACSCall[] Calls { get; }

		[Wrap ("WeakDelegate")]
		ACSCallAgentDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSCallAgentDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(void)handlePushNotification:(ACSPushNotificationInfo *)notification withCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("handlePush(notification:completionHandler:)")));
		[Export ("handlePushNotification:withCompletionHandler:")]
		void HandlePushNotification (ACSPushNotificationInfo notification, Action<NSError> completionHandler);

		// -(void)unregisterPushNotificationWithCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("unregisterPushNotification(completionHandler:)")));
		[Export ("unregisterPushNotificationWithCompletionHandler:")]
		void UnregisterPushNotificationWithCompletionHandler (Action<NSError> completionHandler);

		// -(ACSCall *)startCall:(NSArray<id<CommunicationIdentifier>> *)participants options:(ACSStartCallOptions *)options __attribute__((swift_name("startCall(participants:options:)")));
		[Export ("startCall:options:")]
		ACSCall StartCall (CommunicationIdentifier[] participants, ACSStartCallOptions options);

		// -(ACSCall *)joinWithMeetingLocator:(ACSJoinMeetingLocator *)meetingLocator joinCallOptions:(ACSJoinCallOptions *)joinCallOptions __attribute__((swift_name("join(with:joinCallOptions:)")));
		[Export ("joinWithMeetingLocator:joinCallOptions:")]
		ACSCall JoinWithMeetingLocator (ACSJoinMeetingLocator meetingLocator, ACSJoinCallOptions joinCallOptions);

		// -(void)registerPushNotifications:(NSData *)deviceToken withCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("registerPushNotifications(deviceToken:completionHandler:)")));
		[Export ("registerPushNotifications:withCompletionHandler:")]
		void RegisterPushNotifications (NSData deviceToken, Action<NSError> completionHandler);
	}

	// @interface ACSCall : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCall
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSRemoteParticipant *> * remoteParticipants;
		[Export ("remoteParticipants", ArgumentSemantic.Copy)]
		ACSRemoteParticipant[] RemoteParticipants { get; }

		// @property (readonly, retain) NSString * id;
		[Export ("id", ArgumentSemantic.Retain)]
		string Id { get; }

		// @property (readonly) ACSCallState state;
		[Export ("state")]
		ACSCallState State { get; }

		// @property (readonly, retain) ACSCallEndReason * callEndReason;
		[Export ("callEndReason", ArgumentSemantic.Retain)]
		ACSCallEndReason CallEndReason { get; }

		// @property (readonly) ACSCallDirection callDirection;
		[Export ("callDirection")]
		ACSCallDirection CallDirection { get; }

		// @property (readonly) BOOL isMicrophoneMuted;
		[Export ("isMicrophoneMuted")]
		bool IsMicrophoneMuted { get; }

		// @property (readonly, retain) ACSCallerInfo * callerInfo;
		[Export ("callerInfo", ArgumentSemantic.Retain)]
		ACSCallerInfo CallerInfo { get; }

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * localVideoStreams;
		[Export ("localVideoStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] LocalVideoStreams { get; }

		// @property (readonly) BOOL isRecordingActive;
		[Export ("isRecordingActive")]
		bool IsRecordingActive { get; }

		// @property (readonly) BOOL isTranscriptionActive;
		[Export ("isTranscriptionActive")]
		bool IsTranscriptionActive { get; }

		[Wrap ("WeakDelegate")]
		ACSCallDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSCallDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(void)muteWithCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("mute(completionHandler:)")));
		[Export ("muteWithCompletionHandler:")]
		void MuteWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)unmuteWithCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("unmute(completionHandler:)")));
		[Export ("unmuteWithCompletionHandler:")]
		void UnmuteWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)sendDtmf:(ACSDtmfTone)tone withCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("sendDtmf(tone:completionHandler:)")));
		[Export ("sendDtmf:withCompletionHandler:")]
		void SendDtmf (ACSDtmfTone tone, Action<NSError> completionHandler);

		// -(void)startVideo:(ACSLocalVideoStream *)stream withCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("startVideo(stream:completionHandler:)")));
		[Export ("startVideo:withCompletionHandler:")]
		void StartVideo (ACSLocalVideoStream stream, Action<NSError> completionHandler);

		// -(void)stopVideo:(ACSLocalVideoStream *)stream withCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("stopVideo(stream:completionHandler:)")));
		[Export ("stopVideo:withCompletionHandler:")]
		void StopVideo (ACSLocalVideoStream stream, Action<NSError> completionHandler);

		// -(void)hangUp:(ACSHangUpOptions *)options withCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("hangUp(options:completionHandler:)")));
		[Export ("hangUp:withCompletionHandler:")]
		void HangUp (ACSHangUpOptions options, Action<NSError> completionHandler);

		// -(void)removeParticipant:(ACSRemoteParticipant *)participant withCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("remove(participant:completionHandler:)")));
		[Export ("removeParticipant:withCompletionHandler:")]
		void RemoveParticipant (ACSRemoteParticipant participant, Action<NSError> completionHandler);

		// -(void)holdWithCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("hold(completionHandler:)")));
		[Export ("holdWithCompletionHandler:")]
		void HoldWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)resumeWithCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("resume(completionHandler:)")));
		[Export ("resumeWithCompletionHandler:")]
		void ResumeWithCompletionHandler (Action<NSError> completionHandler);

		// -(ACSRemoteParticipant *)addParticipant:(id<CommunicationIdentifier>)participant __attribute__((swift_name("add(participant:)")));
		[Export ("addParticipant:")]
		ACSRemoteParticipant AddParticipant (CommunicationIdentifier participant);

		// -(ACSRemoteParticipant *)addParticipant:(PhoneNumberIdentifier *)participant options:(ACSAddPhoneNumberOptions *)options __attribute__((swift_name("add(participant:options:)")));
		[Export ("addParticipant:options:")]
		ACSRemoteParticipant AddParticipant (PhoneNumberIdentifier participant, ACSAddPhoneNumberOptions options);
	}

	// @interface ACSRemoteParticipant : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRemoteParticipant
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * displayName;
		[Export ("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; }

		// @property (readonly) BOOL isMuted;
		[Export ("isMuted")]
		bool IsMuted { get; }

		// @property (readonly) BOOL isSpeaking;
		[Export ("isSpeaking")]
		bool IsSpeaking { get; }

		// @property (readonly, retain) ACSCallEndReason * callEndReason;
		[Export ("callEndReason", ArgumentSemantic.Retain)]
		ACSCallEndReason CallEndReason { get; }

		// @property (readonly) ACSParticipantState state;
		[Export ("state")]
		ACSParticipantState State { get; }

		// @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * videoStreams;
		[Export ("videoStreams", ArgumentSemantic.Copy)]
		ACSRemoteVideoStream[] VideoStreams { get; }

		[Wrap ("WeakDelegate")]
		ACSRemoteParticipantDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSRemoteParticipantDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export ("identifier")]
		CommunicationIdentifier Identifier { get; }
	}

	// @interface ACSCallEndReason : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallEndReason
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) int code;
		[Export ("code")]
		int Code { get; }

		// @property (readonly) int subcode;
		[Export ("subcode")]
		int Subcode { get; }
	}

	// @interface ACSRemoteVideoStream : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRemoteVideoStream
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) BOOL isAvailable;
		[Export ("isAvailable")]
		bool IsAvailable { get; }

		// @property (readonly) ACSMediaStreamType mediaStreamType;
		[Export ("mediaStreamType")]
		ACSMediaStreamType MediaStreamType { get; }

		// @property (readonly) int id;
		[Export ("id")]
		int Id { get; }
	}

	// @interface ACSPropertyChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSPropertyChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();
	}

	// @interface ACSRemoteVideoStreamsEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRemoteVideoStreamsEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * addedRemoteVideoStreams;
		[Export ("addedRemoteVideoStreams", ArgumentSemantic.Copy)]
		ACSRemoteVideoStream[] AddedRemoteVideoStreams { get; }

		// @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * removedRemoteVideoStreams;
		[Export ("removedRemoteVideoStreams", ArgumentSemantic.Copy)]
		ACSRemoteVideoStream[] RemovedRemoteVideoStreams { get; }
	}

	// @interface ACSParticipantsUpdatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSParticipantsUpdatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSRemoteParticipant *> * addedParticipants;
		[Export ("addedParticipants", ArgumentSemantic.Copy)]
		ACSRemoteParticipant[] AddedParticipants { get; }

		// @property (readonly, copy) NSArray<ACSRemoteParticipant *> * removedParticipants;
		[Export ("removedParticipants", ArgumentSemantic.Copy)]
		ACSRemoteParticipant[] RemovedParticipants { get; }
	}

	// @interface ACSLocalVideoStreamsUpdatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSLocalVideoStreamsUpdatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * addedStreams;
		[Export ("addedStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] AddedStreams { get; }

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * removedStreams;
		[Export ("removedStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] RemovedStreams { get; }
	}

	// @interface ACSHangUpOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSHangUpOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property BOOL forEveryone;
		[Export ("forEveryone")]
		bool ForEveryone { get; set; }
	}

	// @interface ACSCallsUpdatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallsUpdatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSCall *> * addedCalls;
		[Export ("addedCalls", ArgumentSemantic.Copy)]
		ACSCall[] AddedCalls { get; }

		// @property (readonly, copy) NSArray<ACSCall *> * removedCalls;
		[Export ("removedCalls", ArgumentSemantic.Copy)]
		ACSCall[] RemovedCalls { get; }
	}

	// @interface ACSIncomingCall : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSIncomingCall
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSCallEndReason * callEndReason;
		[Export ("callEndReason", ArgumentSemantic.Retain)]
		ACSCallEndReason CallEndReason { get; }

		// @property (readonly, retain) ACSCallerInfo * callerInfo;
		[Export ("callerInfo", ArgumentSemantic.Retain)]
		ACSCallerInfo CallerInfo { get; }

		// @property (readonly, retain) NSString * id;
		[Export ("id", ArgumentSemantic.Retain)]
		string Id { get; }

		// @property (readonly) BOOL isVideoEnabled;
		[Export ("isVideoEnabled")]
		bool IsVideoEnabled { get; }

		[Wrap ("WeakDelegate")]
		ACSIncomingCallDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSIncomingCallDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(void)accept:(ACSAcceptCallOptions *)options withCompletionHandler:(void (^)(ACSCall *, NSError *))completionHandler __attribute__((swift_name("accept(options:completionHandler:)")));
		[Export ("accept:withCompletionHandler:")]
		void Accept (ACSAcceptCallOptions options, Action<ACSCall, NSError> completionHandler);

		// -(void)rejectWithCompletionHandler:(void (^)(NSError *))completionHandler __attribute__((swift_name("reject(completionHandler:)")));
		[Export ("rejectWithCompletionHandler:")]
		void RejectWithCompletionHandler (Action<NSError> completionHandler);
	}

	// @interface ACSInitializationOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSInitializationOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) NSString * dataPath;
		[Export ("dataPath", ArgumentSemantic.Retain)]
		string DataPath { get; set; }

		// @property (retain) NSString * logFileName;
		[Export ("logFileName", ArgumentSemantic.Retain)]
		string LogFileName { get; set; }

		// @property BOOL isEncrypted;
		[Export ("isEncrypted")]
		bool IsEncrypted { get; set; }

		// @property BOOL stdoutLogging;
		[Export ("stdoutLogging")]
		bool StdoutLogging { get; set; }
	}

	// @interface ACSCallClient : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallClient
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// -(void)getDeviceManagerWithCompletionHandler:(void (^)(ACSDeviceManager *, NSError *))completionHandler __attribute__((swift_name("getDeviceManager(completionHandler:)")));
		[Export ("getDeviceManagerWithCompletionHandler:")]
		void GetDeviceManagerWithCompletionHandler (Action<ACSDeviceManager, NSError> completionHandler);

		// -(void)createCallAgentWithOptions:(CommunicationTokenCredential *)userCredential callAgentOptions:(ACSCallAgentOptions *)callAgentOptions withCompletionHandler:(void (^)(ACSCallAgent *, NSError *))completionHandler __attribute__((swift_name("createCallAgent(userCredential:options:completionHandler:)")));
		[Export ("createCallAgentWithOptions:callAgentOptions:withCompletionHandler:")]
		void CreateCallAgentWithOptions (CommunicationTokenCredential userCredential, ACSCallAgentOptions callAgentOptions, Action<ACSCallAgent, NSError> completionHandler);

		// -(void)createCallAgent:(CommunicationTokenCredential *)userCredential withCompletionHandler:(void (^)(ACSCallAgent *, NSError * _Nullable))completionHandler __attribute__((swift_name("createCallAgent(userCredential:completionHandler:)")));
		[Export ("createCallAgent:withCompletionHandler:")]
		void CreateCallAgent (CommunicationTokenCredential userCredential, Action<ACSCallAgent, NSError> completionHandler);

		// @property (retain) CommunicationTokenCredential * _Nonnull communicationCredential;
		[Export ("communicationCredential", ArgumentSemantic.Retain)]
		CommunicationTokenCredential CommunicationCredential { get; set; }
	}

	// @interface ACSDeviceManager : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSDeviceManager
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * cameras;
		[Export ("cameras", ArgumentSemantic.Copy)]
		ACSVideoDeviceInfo[] Cameras { get; }

		[Wrap ("WeakDelegate")]
		ACSDeviceManagerDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSDeviceManagerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }
	}

	// @interface ACSVideoDevicesUpdatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoDevicesUpdatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * addedVideoDevices;
		[Export ("addedVideoDevices", ArgumentSemantic.Copy)]
		ACSVideoDeviceInfo[] AddedVideoDevices { get; }

		// @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * removedVideoDevices;
		[Export ("removedVideoDevices", ArgumentSemantic.Copy)]
		ACSVideoDeviceInfo[] RemovedVideoDevices { get; }
	}

	// @interface ACSRenderingOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRenderingOptions
	{
		// -(instancetype)init:(ACSScalingMode)scalingMode __attribute__((swift_name("init(scalingMode:)")));
		[Export ("init:")]
		IntPtr Constructor (ACSScalingMode scalingMode);

		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property ACSScalingMode scalingMode;
		[Export ("scalingMode", ArgumentSemantic.Assign)]
		ACSScalingMode ScalingMode { get; set; }
	}
}
