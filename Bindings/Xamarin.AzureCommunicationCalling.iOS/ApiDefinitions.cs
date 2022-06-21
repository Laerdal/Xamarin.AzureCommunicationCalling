using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using CallKit;

namespace Xamarin.AzureCommunicationCalling.iOS
{
	[Static]
	partial interface Constants
	{
		// extern double AzureCommunicationCommonVersionNumber;
		[Field("AzureCommunicationCommonVersionNumber", "__Internal")]
		double AzureCommunicationCommonVersionNumber { get; }

		// extern const unsigned char [] AzureCommunicationCommonVersionString;
		[Field("AzureCommunicationCommonVersionString", "__Internal")]
		NSString AzureCommunicationCommonVersionString { get; }
	}

	// @interface CommunicationAccessToken : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC24AzureCommunicationCommon24CommunicationAccessToken")]
	[DisableDefaultCtor]
	interface CommunicationAccessToken
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull token;
		[Export("token")]
		string Token { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull expiresOn;
		[Export("expiresOn", ArgumentSemantic.Copy)]
		NSDate ExpiresOn { get; }

		// -(instancetype _Nonnull)initWithToken:(NSString * _Nonnull)token expiresOn:(NSDate * _Nonnull)expiresOn __attribute__((objc_designated_initializer));
		[Export("initWithToken:expiresOn:")]
		[DesignatedInitializer]
		IntPtr Constructor(string token, NSDate expiresOn);
	}

	// @interface CommunicationCloudEnvironment : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC24AzureCommunicationCommon29CommunicationCloudEnvironment")]
	[DisableDefaultCtor]
	interface CommunicationCloudEnvironment
	{
		// @property (readonly, nonatomic, strong, class) CommunicationCloudEnvironment * _Nonnull Public;
		[Static]
		[Export("Public", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment Public { get; }

		// @property (readonly, nonatomic, strong, class) CommunicationCloudEnvironment * _Nonnull Dod;
		[Static]
		[Export("Dod", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment Dod { get; }

		// @property (readonly, nonatomic, strong, class) CommunicationCloudEnvironment * _Nonnull Gcch;
		[Static]
		[Export("Gcch", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment Gcch { get; }

		// -(instancetype _Nonnull)initWithEnvironmentValue:(NSString * _Nonnull)environmentValue __attribute__((objc_designated_initializer));
		[Export("initWithEnvironmentValue:")]
		[DesignatedInitializer]
		IntPtr Constructor(string environmentValue);

		// -(NSString * _Nonnull)getEnvironmentValue __attribute__((warn_unused_result("")));
		[Export("getEnvironmentValue")]
		string EnvironmentValue { get; }
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
*/
	[Protocol(Name = "_TtP24AzureCommunicationCommon23CommunicationIdentifier_")]
	[BaseType(typeof(NSObject), Name = "_TtP24AzureCommunicationCommon23CommunicationIdentifier_")]
	interface CommunicationIdentifier
	{
	}

	// @interface CommunicationTokenCredential : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC24AzureCommunicationCommon28CommunicationTokenCredential")]
	[DisableDefaultCtor]
	interface CommunicationTokenCredential
	{
		// -(instancetype _Nullable)initWithToken:(NSString * _Nonnull)token error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export("initWithToken:error:")]
		[DesignatedInitializer]
		IntPtr Constructor(string token, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(CommunicationTokenRefreshOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export("initWithOptions:error:")]
		[DesignatedInitializer]
		IntPtr Constructor(CommunicationTokenRefreshOptions options, [NullAllowed] out NSError error);

		// -(void)tokenWithCompletionHandler:(void (^ _Nonnull)(CommunicationAccessToken * _Nullable, NSError * _Nullable))completionHandler;
		[Export("tokenWithCompletionHandler:")]
		void TokenWithCompletionHandler(Action<CommunicationAccessToken, NSError> completionHandler);
	}

	// @interface CommunicationTokenRefreshOptions : NSObject
	[BaseType(typeof(NSObject), Name = "_TtC24AzureCommunicationCommon32CommunicationTokenRefreshOptions")]
	[DisableDefaultCtor]
	interface CommunicationTokenRefreshOptions
	{
		// -(instancetype _Nonnull)initWithInitialToken:(NSString * _Nullable)initialToken refreshProactively:(BOOL)refreshProactively tokenRefresher:(void (^ _Nonnull)(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable)))tokenRefresher __attribute__((objc_designated_initializer));
		//[Export("initWithInitialToken:refreshProactively:tokenRefresher:")]
		//[DesignatedInitializer]
		//IntPtr Constructor([NullAllowed] string initialToken, bool refreshProactively, Action<Action<NSString, NSError>> tokenRefresher);
	}


	// @interface CommunicationUserIdentifier : NSObject <CommunicationIdentifier>
	[BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon27CommunicationUserIdentifier")]
	[DisableDefaultCtor]
	interface CommunicationUserIdentifier : CommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier);
	}

	// @interface MicrosoftTeamsUserIdentifier : NSObject <CommunicationIdentifier>
	[BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon28MicrosoftTeamsUserIdentifier")]
	[DisableDefaultCtor]
	interface MicrosoftTeamsUserIdentifier : CommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull userId;
		[Export("userId")]
		string UserId { get; }

		// @property (readonly, nonatomic) BOOL isAnonymous;
		[Export("isAnonymous")]
		bool IsAnonymous { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable rawId;
		[NullAllowed, Export("rawId")]
		string RawId { get; }

		// @property (readonly, nonatomic, strong) CommunicationCloudEnvironment * _Nonnull cloudEnviroment;
		[Export("cloudEnviroment", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment CloudEnviroment { get; }

		// -(instancetype _Nonnull)initWithUserId:(NSString * _Nonnull)userId isAnonymous:(BOOL)isAnonymous rawId:(NSString * _Nullable)rawId cloudEnvironment:(CommunicationCloudEnvironment * _Nonnull)cloudEnvironment __attribute__((objc_designated_initializer));
		[Export("initWithUserId:isAnonymous:rawId:cloudEnvironment:")]
		[DesignatedInitializer]
		IntPtr Constructor(string userId, bool isAnonymous, [NullAllowed] string rawId, CommunicationCloudEnvironment cloudEnvironment);

		// -(instancetype _Nonnull)initWithUserId:(NSString * _Nonnull)userId isAnonymous:(BOOL)isAnonymous __attribute__((objc_designated_initializer));
		[Export("initWithUserId:isAnonymous:")]
		[DesignatedInitializer]
		IntPtr Constructor(string userId, bool isAnonymous);
	}

	// @interface PhoneNumberIdentifier : NSObject <CommunicationIdentifier>
	[BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon21PhoneNumberIdentifier")]
	[DisableDefaultCtor]
	interface PhoneNumberIdentifier : CommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull phoneNumber;
		[Export("phoneNumber")]
		string PhoneNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable rawId;
		[NullAllowed, Export("rawId")]
		string RawId { get; }

		// -(instancetype _Nonnull)initWithPhoneNumber:(NSString * _Nonnull)phoneNumber rawId:(NSString * _Nullable)rawId __attribute__((objc_designated_initializer));
		[Export("initWithPhoneNumber:rawId:")]
		[DesignatedInitializer]
		IntPtr Constructor(string phoneNumber, [NullAllowed] string rawId);
	}

	// @interface UnknownIdentifier : NSObject <CommunicationIdentifier>
	[BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon17UnknownIdentifier")]
	[DisableDefaultCtor]
	interface UnknownIdentifier : CommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export("identifier")]
		string Identifier { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier);
	}

	// @interface ACSVideoStreamRendererView : UIView
   	[BaseType (typeof(UIView))]
	[DisableDefaultCtor]
	interface ACSVideoStreamRendererView
	{
		// -(void)updateScalingMode:(ACSScalingMode)scalingMode __attribute__((swift_name("update(scalingMode:)")));
		[Export ("updateScalingMode:")]
		void UpdateScalingMode (ACSScalingMode scalingMode);

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();

		// -(_Bool)isRendering;
		[Export ("isRendering")]
		bool IsRendering { get; }
	}




	// @protocol ACSVideoStreamRendererDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSVideoStreamRendererDelegate
	{
		// @required -(void)rendererFailedToStart:(ACSVideoStreamRenderer * _Nonnull)renderer __attribute__((swift_name("videoStreamRenderer(didFailToStart:)")));
		[Abstract]
		[Export("rendererFailedToStart:")]
		void RendererFailedToStart(ACSVideoStreamRenderer renderer);

		// @optional -(void)onFirstFrameRendered:(ACSVideoStreamRenderer * _Nonnull)renderer __attribute__((swift_name("videoStreamRenderer(didRenderFirstFrame:)")));
		[Export("onFirstFrameRendered:")]
		void OnFirstFrameRendered(ACSVideoStreamRenderer renderer);
	}

	// @interface ACSVideoStreamRenderer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoStreamRenderer
	{
		// -(instancetype _Nonnull)initWithLocalVideoStream:(ACSLocalVideoStream * _Nonnull)localVideoStream withError:(NSError * _Nullable * _Nonnull)nonnull_error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("init(localVideoStream:)")));
		[Export ("initWithLocalVideoStream:withError:")]
		IntPtr Constructor(ACSLocalVideoStream localVideoStream, [NullAllowed] out NSError nonnull_error);

		// -(instancetype _Nonnull)initWithRemoteVideoStream:(ACSRemoteVideoStream * _Nonnull)remoteVideoStream withError:(NSError * _Nullable * _Nonnull)nonnull_error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("init(remoteVideoStream:)")));
		[Export ("initWithRemoteVideoStream:withError:")]
		IntPtr Constructor(ACSRemoteVideoStream remoteVideoStream, [NullAllowed] out NSError nonnull_error);

		// -(ACSVideoStreamRendererView * _Nonnull)createView:(NSError * _Nullable * _Nonnull)nonnull_error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("createView()")));
		[Export ("createView:")]
		ACSVideoStreamRendererView CreateView([NullAllowed] out NSError nonnull_error);

		// -(ACSVideoStreamRendererView * _Nonnull)createViewWithOptions:(ACSCreateViewOptions * _Nullable)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("createView(withOptions:)")));
		[Export("createViewWithOptions:withError:")]
		ACSVideoStreamRendererView CreateViewWithOptions([NullAllowed] ACSCreateViewOptions options, [NullAllowed] out NSError error);

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();

		// @property (readonly) struct ACSStreamSize size;
		[Export ("size")]
		ACSStreamSize Size { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSVideoStreamRendererDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSVideoStreamRendererDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }
	}
	
	// @interface ACSFeatures : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSFeatures
	{
		// @property (readonly, class) Class recording __attribute__((swift_private));
		[Static]
		[Export ("recording")]
		Class Recording { get; }

		// @property (readonly, class) Class transcription __attribute__((swift_private));
		[Static]
		[Export ("transcription")]
		Class Transcription { get; }
	}
	
	// @interface ACSCallAgentEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallAgentEvents
	{
		// @property (copy) void (^ _Nullable)(ACSCallsUpdatedEventArgs * _Nonnull) onCallsUpdated;
		[NullAllowed, Export ("onCallsUpdated", ArgumentSemantic.Copy)]
		Action<ACSCallsUpdatedEventArgs> OnCallsUpdated { get; set; }

		// @property (copy) void (^ _Nullable)(ACSIncomingCall * _Nonnull) onIncomingCall;
		[NullAllowed, Export ("onIncomingCall", ArgumentSemantic.Copy)]
		Action<ACSIncomingCall> OnIncomingCall { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSCallEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIdChanged;
		[NullAllowed, Export ("onIdChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIdChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSParticipantsUpdatedEventArgs * _Nonnull) onRemoteParticipantsUpdated;
		[NullAllowed, Export ("onRemoteParticipantsUpdated", ArgumentSemantic.Copy)]
		Action<ACSParticipantsUpdatedEventArgs> OnRemoteParticipantsUpdated { get; set; }

		// @property (copy) void (^ _Nullable)(ACSLocalVideoStreamsUpdatedEventArgs * _Nonnull) onLocalVideoStreamsUpdated;
		[NullAllowed, Export ("onLocalVideoStreamsUpdated", ArgumentSemantic.Copy)]
		Action<ACSLocalVideoStreamsUpdatedEventArgs> OnLocalVideoStreamsUpdated { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIsMutedChanged;
		[NullAllowed, Export ("onIsMutedChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIsMutedChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSRemoteParticipantEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRemoteParticipantEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIsMutedChanged;
		[NullAllowed, Export ("onIsMutedChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIsMutedChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIsSpeakingChanged;
		[NullAllowed, Export ("onIsSpeakingChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIsSpeakingChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onDisplayNameChanged;
		[NullAllowed, Export ("onDisplayNameChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnDisplayNameChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSRemoteVideoStreamsEventArgs * _Nonnull) onVideoStreamsUpdated;
		[NullAllowed, Export ("onVideoStreamsUpdated", ArgumentSemantic.Copy)]
		Action<ACSRemoteVideoStreamsEventArgs> OnVideoStreamsUpdated { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSIncomingCallEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIncomingCallEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onCallEnded;
		[NullAllowed, Export ("onCallEnded", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnCallEnded { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSDeviceManagerEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSDeviceManagerEvents
	{
		// @property (copy) void (^ _Nullable)(ACSVideoDevicesUpdatedEventArgs * _Nonnull) onCamerasUpdated;
		[NullAllowed, Export ("onCamerasUpdated", ArgumentSemantic.Copy)]
		Action<ACSVideoDevicesUpdatedEventArgs> OnCamerasUpdated { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSRecordingCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRecordingCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIsRecordingActiveChanged;
		[NullAllowed, Export ("onIsRecordingActiveChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIsRecordingActiveChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSTranscriptionCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSTranscriptionCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIsTranscriptionActiveChanged;
		[NullAllowed, Export ("onIsTranscriptionActiveChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIsTranscriptionActiveChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @protocol ACSCallAgentDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSCallAgentDelegate
	{
		// @optional -(void)onCallsUpdated:(ACSCallAgent * _Nonnull)callAgent :(ACSCallsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("callAgent(_:didUpdateCalls:)")));
		[Export("onCallsUpdated::")]
		void OnCallsUpdated(ACSCallAgent callAgent, ACSCallsUpdatedEventArgs args);

		// @optional -(void)onIncomingCall:(ACSCallAgent * _Nonnull)callAgent :(ACSIncomingCall * _Nonnull)incomingCall __attribute__((swift_name("callAgent(_:didRecieveIncomingCall:)")));
		[Export("onIncomingCall::")]
		void OnIncomingCall(ACSCallAgent callAgent, ACSIncomingCall incomingCall);
	}

	// @protocol ACSCallDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSCallDelegate
	{
		// @optional -(void)onIdChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeId:)")));
		[Export("onIdChanged::")]
		void OnIdChanged(ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onStateChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeState:)")));
		[Export("onStateChanged::")]
		void OnStateChanged(ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onRemoteParticipantsUpdated:(ACSCall * _Nonnull)call :(ACSParticipantsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateRemoteParticipant:)")));
		[Export("onRemoteParticipantsUpdated::")]
		void OnRemoteParticipantsUpdated(ACSCall call, ACSParticipantsUpdatedEventArgs args);

		// @optional -(void)onLocalVideoStreamsUpdated:(ACSCall * _Nonnull)call :(ACSLocalVideoStreamsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateLocalVideoStreams:)")));
		[Export("onLocalVideoStreamsUpdated::")]
		void OnLocalVideoStreamsUpdated(ACSCall call, ACSLocalVideoStreamsUpdatedEventArgs args);

		// @optional -(void)onIsMutedChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeMuteState:)")));
		[Export("onIsMutedChanged::")]
		void OnIsMutedChanged(ACSCall call, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSRemoteParticipantDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSRemoteParticipantDelegate
	{
		// @optional -(void)onStateChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeState:)")));
		[Export("onStateChanged::")]
		void OnStateChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsMutedChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeMuteState:)")));
		[Export("onIsMutedChanged::")]
		void OnIsMutedChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsSpeakingChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeSpeakingState:)")));
		[Export("onIsSpeakingChanged::")]
		void OnIsSpeakingChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onDisplayNameChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeDisplayName:)")));
		[Export("onDisplayNameChanged::")]
		void OnDisplayNameChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onVideoStreamsUpdated:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSRemoteVideoStreamsEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didUpdateVideoStreams:)")));
		[Export("onVideoStreamsUpdated::")]
		void OnVideoStreamsUpdated(ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args);
	}

	// @protocol ACSIncomingCallDelegate <NSObject>
	[Protocol, Model(AutoGeneratedName = true)]
	[BaseType(typeof(NSObject))]
	interface ACSIncomingCallDelegate
	{
		// @optional -(void)onCallEnded:(ACSIncomingCall * _Nonnull)incomingCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("incomingCall(_:didEnd:)")));
		[Export("onCallEnded::")]
		void OnCallEnded(ACSIncomingCall incomingCall, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSDeviceManagerDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSDeviceManagerDelegate
	{
		// @optional -(void) onCamerasUpdated:(ACSDeviceManager* _Nonnull) deviceManager :(ACSVideoDevicesUpdatedEventArgs* _Nonnull) args __attribute__((swift_name("deviceManager(_:didUpdateCameras:)")));
		[Export("onCamerasUpdated::")]
		void OnCamerasUpdated (ACSDeviceManager deviceManager, ACSVideoDevicesUpdatedEventArgs args);
 	}

	// @protocol ACSRecordingCallFeatureDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSRecordingCallFeatureDelegate
	{
		// @optional -(void)onIsRecordingActiveChanged:(ACSRecordingCallFeature * _Nonnull)recordingCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("recordingCallFeature(_:didChangeRecordingState:)")));
		[Export ("onIsRecordingActiveChanged::")]
		void OnIsRecordingActiveChanged(ACSRecordingCallFeature recordingCallFeature, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSTranscriptionCallFeatureDelegate <NSObject>
	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof(NSObject))]
	interface ACSTranscriptionCallFeatureDelegate
	{
		// @optional -(void)onIsTranscriptionActiveChanged:(ACSTranscriptionCallFeature * _Nonnull)transcriptionCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("transcriptionCallFeature(_:didChangeTranscriptionState:)")));
		[Export ("onIsTranscriptionActiveChanged::")]
		void OnIsTranscriptionActiveChanged(ACSTranscriptionCallFeature transcriptionCallFeature, ACSPropertyChangedEventArgs args);
	}

	// @interface ACSVideoOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoOptions
	{
		// -(instancetype _Nonnull)init:(NSArray<ACSLocalVideoStream *> * _Nonnull)localVideoStreams __attribute__((swift_name("init(localVideoStreams:)")));
		[Export ("init:")]
		IntPtr Constructor (ACSLocalVideoStream[] localVideoStreams);
		
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * _Nonnull localVideoStreams;
		[Export("localVideoStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] LocalVideoStreams { get; }
	}

	// @interface ACSLocalVideoStream : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSLocalVideoStream
	{
		// -(instancetype _Nonnull)init:(ACSVideoDeviceInfo * _Nonnull)camera __attribute__((swift_name("init(camera:)")));
		[Export ("init:")]
		IntPtr Constructor (ACSVideoDeviceInfo camera);

		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSVideoDeviceInfo * _Nonnull source;
		[Export ("source", ArgumentSemantic.Retain)]
		ACSVideoDeviceInfo Source { get; }

		// @property (readonly) BOOL isSending;
		[Export ("isSending")]
		bool IsSending { get; }

		// @property (readonly) ACSMediaStreamType mediaStreamType;
		[Export ("mediaStreamType")]
		ACSMediaStreamType MediaStreamType { get; }

		// -(void)switchSource:(ACSVideoDeviceInfo * _Nonnull)camera withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("switchSource(camera:completionHandler:)")));
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

		// @property (readonly, retain) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }

		// @property (readonly, retain) NSString * _Nonnull id;
		[Export ("id", ArgumentSemantic.Retain)]
		string Id { get; }

		// @property (readonly) ACSCameraFacing cameraFacing;
		[Export ("cameraFacing")]
		ACSCameraFacing CameraFacing { get; }

		// @property (readonly) ACSVideoDeviceType deviceType;
		[Export ("deviceType")]
		ACSVideoDeviceType DeviceType { get; }
	}

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

		// @property (retain) ACSVideoOptions * _Nullable videoOptions;
		[NullAllowed, Export("videoOptions", ArgumentSemantic.Retain)]
		ACSVideoOptions VideoOptions { get; set; }

		// @property (retain) ACSAudioOptions * _Nullable audioOptions;
		[NullAllowed, Export("audioOptions", ArgumentSemantic.Retain)]
		ACSAudioOptions AudioOptions { get; set; }
	}

	// @interface ACSAcceptCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSAcceptCallOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSVideoOptions * _Nonnull videoOptions;
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

		// @property (retain) ACSVideoOptions * _Nullable videoOptions;
		[NullAllowed, Export("videoOptions", ArgumentSemantic.Retain)]
		ACSVideoOptions VideoOptions { get; set; }

		// @property (retain) ACSAudioOptions * _Nullable audioOptions;
		[NullAllowed, Export("audioOptions", ArgumentSemantic.Retain)]
		ACSAudioOptions AudioOptions { get; set; }

		// @property (nonatomic) PhoneNumberIdentifier * _Nonnull alternateCallerId;
		[Export("alternateCallerId", ArgumentSemantic.Assign)]
		PhoneNumberIdentifier AlternateCallerId { get; set; }
	}

	// @interface ACSAddPhoneNumberOptions : NSObject
	[BaseType(typeof(NSObject))]
	interface ACSAddPhoneNumberOptions
	{
		// -(void)dealloc;
		[Export("dealloc")]
		void Dealloc();

		// @property (nonatomic) PhoneNumberIdentifier * _Nonnull alternateCallerId;
		[Export("alternateCallerId", ArgumentSemantic.Assign)]
		PhoneNumberIdentifier AlternateCallerId { get; set; }
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
    [BaseType(typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSGroupCallLocator
	{
		// -(instancetype _Nonnull)init:(NSUUID * _Nonnull)groupId __attribute__((swift_name("init(groupId:)")));
		[Export("init:")]
		IntPtr Constructor(NSUuid groupId);

		// @property (readonly, retain) NSUUID * _Nonnull groupId;
		[Export ("groupId", ArgumentSemantic.Retain)]
		NSUuid GroupId { get; }
	}
	
	// @interface ACSTeamsMeetingCoordinatesLocator : ACSJoinMeetingLocator
	[BaseType (typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSTeamsMeetingCoordinatesLocator
	{
		// -(instancetype _Nonnull)initWithThreadId:(NSString * _Nonnull)threadId organizerId:(NSUUID * _Nonnull)organizerId tenantId:(NSUUID * _Nonnull)tenantId messageId:(NSString * _Nonnull)messageId __attribute__((swift_name("init(withThreadId:organizerId:tenantId:messageId:)")));
		[Export ("initWithThreadId:organizerId:tenantId:messageId:")]
		IntPtr Constructor (string threadId, NSUuid organizerId, NSUuid tenantId, string messageId);

		// @property (readonly, retain) NSString * _Nonnull threadId;
		[Export ("threadId", ArgumentSemantic.Retain)]
		string ThreadId { get; }

		// @property (readonly, retain) NSUUID * _Nonnull organizerId;
		[Export ("organizerId", ArgumentSemantic.Retain)]
		NSUuid OrganizerId { get; }

		// @property (readonly, retain) NSUUID * _Nonnull tenantId;
		[Export ("tenantId", ArgumentSemantic.Retain)]
		NSUuid TenantId { get; }

		// @property (readonly, retain) NSString * _Nonnull messageId;
		[Export ("messageId", ArgumentSemantic.Retain)]
		string MessageId { get; }
	}

	// @interface ACSTeamsMeetingLinkLocator : ACSJoinMeetingLocator
	[BaseType (typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSTeamsMeetingLinkLocator
	{
		// -(instancetype _Nonnull)init:(NSString * _Nonnull)meetingLink __attribute__((swift_name("init(meetingLink:)")));
		[Export ("init:")]
		IntPtr Constructor (string meetingLink);

		// @property (readonly, retain) NSString * _Nonnull meetingLink;
		[Export ("meetingLink", ArgumentSemantic.Retain)]
		string MeetingLink { get; }
	}

	
	// @interface ACSCallerInfo : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallerInfo
	{
		// -(void)dealloc;
		[Export("dealloc")]
		void Dealloc();

		// @property (readonly, retain) NSString * _Nonnull displayName;
		[Export("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; }

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export("identifier")]
		CommunicationIdentifier Identifier { get; }
	}

	// @interface ACSPushNotificationInfo : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSPushNotificationInfo
	{
		// -(void)dealloc;
		[Export("dealloc")]
		void Dealloc();

		// @property (readonly, retain) NSString * _Nonnull fromDisplayName;
		[Export("fromDisplayName", ArgumentSemantic.Retain)]
		string FromDisplayName { get; }

		// @property(readonly) BOOL incomingWithVideo;
		[Export("incomingWithVideo")]
		bool IncomingWithVideo { get; }

		// @property (readonly, retain) id<CommunicationIdentifier> _Nonnull from;
		[Export("from", ArgumentSemantic.Retain)]
		CommunicationIdentifier From { get; }

		// @property (readonly, retain) id<CommunicationIdentifier> to;
		[Export("to", ArgumentSemantic.Retain)]
		CommunicationIdentifier To { get; }

		// @property (readonly, nonatomic) NSUUID * _Nonnull callId;
		[Export("callId")]
		NSUuid CallId { get; }

		// +(ACSPushNotificationInfo *)fromDictionary:(NSDictionary * _Nonnull)payload;
		[Static]
		[Export("fromDictionary:")]
		ACSPushNotificationInfo FromDictionary(NSDictionary payload);
	}

	// @interface ACSCallAgentOptions : NSObject
	[BaseType(typeof(NSObject))]
	interface ACSCallAgentOptions
	{
		// -(void)dealloc;
		[Export("dealloc")]
		void Dealloc();

		// @property (retain) NSString * _Nonnull displayName;
		[Export("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; set; }

		// @property (retain) ACSEmergencyCallOptions * _Nullable emergencyCallOptions;
		[NullAllowed, Export ("emergencyCallOptions", ArgumentSemantic.Retain)]
		ACSEmergencyCallOptions EmergencyCallOptions { get; set; }
	}
	
	// @interface ACSEmergencyCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSEmergencyCallOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) NSString * _Nonnull countryCode;
		[Export ("countryCode", ArgumentSemantic.Retain)]
		string CountryCode { get; set; }
	}

	// @interface ACSCallAgent : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallAgent
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSCall *> * _Nonnull calls;
		[Export ("calls", ArgumentSemantic.Copy)]
		ACSCall[] Calls { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSCallAgentDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSCallAgentDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSCallAgentEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSCallAgentEvents Events { get; }

		// -(void)dispose;
		[Export("dispose")]
		void Dispose();

		// -(void)unregisterPushNotificationWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("unregisterPushNotification(completionHandler:)")));
		[Export("unregisterPushNotificationWithCompletionHandler:")]
		void UnregisterPushNotificationWithCompletionHandler(Action<NSError> completionHandler);

		// -(void)startCall:(NSArray<id<CommunicationIdentifier>> * _Nonnull)participants options:(ACSStartCallOptions * _Nullable)options withCompletionHandler:(void (^ _Nonnull)(ACSCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("startCall(participants:options:completionHandler:)")));
		[Export("startCall:options:withCompletionHandler:")]
		void StartCall(CommunicationIdentifier[] participants, [NullAllowed] ACSStartCallOptions options, Action<ACSCall, NSError> completionHandler);

		// -(void)joinWithMeetingLocator:(ACSJoinMeetingLocator * _Nonnull)meetingLocator joinCallOptions:(ACSJoinCallOptions * _Nullable)joinCallOptions withCompletionHandler:(void (^ _Nonnull)(ACSCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("join(with:joinCallOptions:completionHandler:)")));
		[Export("joinWithMeetingLocator:joinCallOptions:withCompletionHandler:")]
		void JoinWithMeetingLocator(ACSJoinMeetingLocator meetingLocator, [NullAllowed] ACSJoinCallOptions joinCallOptions, Action<ACSCall, NSError> completionHandler);

		// -(void)registerPushNotifications:(NSData * _Nonnull)deviceToken withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("registerPushNotifications(deviceToken:completionHandler:)")));
		[Export("registerPushNotifications:withCompletionHandler:")]
		void RegisterPushNotifications(NSData deviceToken, Action<NSError> completionHandler);

		// -(void)handlePushNotification:(ACSPushNotificationInfo * _Nonnull)notification withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("handlePush(notification:completionHandler:)")));
		[Export("handlePushNotification:withCompletionHandler:")]
		void HandlePushNotification(ACSPushNotificationInfo notification, Action<NSError> completionHandler);
	}

	// @interface ACSCall : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCall
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSRemoteParticipant *> * _Nonnull remoteParticipants;
		[Export ("remoteParticipants", ArgumentSemantic.Copy)]
		ACSRemoteParticipant[] RemoteParticipants { get; }

		// @property (readonly, retain) NSString * _Nonnull id;
		[Export ("id", ArgumentSemantic.Retain)]
		string Id { get; }

		// @property (readonly) ACSCallState state;
		[Export ("state")]
		ACSCallState State { get; }

		// @property (readonly, retain) ACSCallEndReason * _Nonnull callEndReason;
		[Export ("callEndReason", ArgumentSemantic.Retain)]
		ACSCallEndReason CallEndReason { get; }

		// @property (readonly) ACSCallDirection direction;
		[Export("direction")]
		ACSCallDirection Direction { get; }
		
		// @property (readonly) BOOL isMuted;
		[Export("isMuted")]
		bool IsMuted { get; }

		// @property (readonly, retain) ACSCallerInfo * _Nonnull callerInfo;
		[Export("callerInfo", ArgumentSemantic.Retain)]
		ACSCallerInfo CallerInfo { get; }

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * _Nonnull localVideoStreams;
		[Export("localVideoStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] LocalVideoStreams { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSCallDelegate Delegate { get; set; }
		
		// @property (nonatomic, weak) id<ACSCallDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSCallEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSCallEvents Events { get; }
		
		// -(void)muteWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("mute(completionHandler:)")));
		[Export("muteWithCompletionHandler:")]
		void MuteWithCompletionHandler(Action<NSError> completionHandler);

		// -(void)unmuteWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("unmute(completionHandler:)")));
		[Export("unmuteWithCompletionHandler:")]
		void UnmuteWithCompletionHandler(Action<NSError> completionHandler);

		// -(void)sendDtmf:(ACSDtmfTone)tone withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("sendDtmf(tone:completionHandler:)")));
		[Export("sendDtmf:withCompletionHandler:")]
		void SendDtmf(ACSDtmfTone tone, Action<NSError> completionHandler);

		// -(void)startVideo:(ACSLocalVideoStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("startVideo(stream:completionHandler:)")));
		[Export("startVideo:withCompletionHandler:")]
		void StartVideo(ACSLocalVideoStream stream, Action<NSError> completionHandler);

		// -(void)stopVideo:(ACSLocalVideoStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("stopVideo(stream:completionHandler:)")));
		[Export("stopVideo:withCompletionHandler:")]
		void StopVideo(ACSLocalVideoStream stream, Action<NSError> completionHandler);

		// -(void)hangUp:(ACSHangUpOptions * _Nullable)options withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("hangUp(options:completionHandler:)")));
		[Export("hangUp:withCompletionHandler:")]
		void HangUp([NullAllowed] ACSHangUpOptions options, Action<NSError> completionHandler);

		// -(void)removeParticipant:(ACSRemoteParticipant * _Nonnull)participant withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("remove(participant:completionHandler:)")));
		[Export("removeParticipant:withCompletionHandler:")]
		void RemoveParticipant(ACSRemoteParticipant participant, Action<NSError> completionHandler);

		// -(void)holdWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("hold(completionHandler:)")));
		[Export("holdWithCompletionHandler:")]
		void HoldWithCompletionHandler(Action<NSError> completionHandler);

		// -(void)resumeWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("resume(completionHandler:)")));
		[Export("resumeWithCompletionHandler:")]
		void ResumeWithCompletionHandler(Action<NSError> completionHandler);

		// -(ACSRemoteParticipant * _Nullable)addParticipant:(id<CommunicationIdentifier> _Nonnull)participant withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("add(participant:)")));
		[Export ("addParticipant:withError:")]
		[return: NullAllowed]
		ACSRemoteParticipant AddParticipant (CommunicationIdentifier participant, [NullAllowed] out NSError error);

		// -(ACSRemoteParticipant * _Nullable)addParticipant:(PhoneNumberIdentifier * _Nonnull)participant options:(ACSAddPhoneNumberOptions * _Nullable)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("add(participant:options:)")));
		[Export ("addParticipant:options:withError:")]
		[return: NullAllowed]
		ACSRemoteParticipant AddParticipant (PhoneNumberIdentifier participant, [NullAllowed] ACSAddPhoneNumberOptions options, [NullAllowed] out NSError error);

		/// -(id _Nonnull)feature:(Class _Nonnull)featureClass __attribute__((swift_private));
		[Export ("feature:")]
		NSObject Feature (Class featureClass);
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

		// @property (readonly, retain) ACSCallEndReason * _Nonnull callEndReason;
		[Export ("callEndReason", ArgumentSemantic.Retain)]
		ACSCallEndReason CallEndReason { get; }

		// @property (readonly) ACSParticipantState state;
		[Export ("state")]
		ACSParticipantState State { get; }

		// @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * _Nonnull videoStreams;
		[Export ("videoStreams", ArgumentSemantic.Copy)]
		ACSRemoteVideoStream[] VideoStreams { get; }

		[Wrap ("WeakDelegate")]
		ACSRemoteParticipantDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRemoteParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRemoteParticipantEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRemoteParticipantEvents Events { get; }

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export("identifier")]
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
		[Export("mediaStreamType")]
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

		// @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * _Nonnull addedRemoteVideoStreams;
		[Export ("addedRemoteVideoStreams", ArgumentSemantic.Copy)]
		ACSRemoteVideoStream[] AddedRemoteVideoStreams { get; }

		// @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * _Nonnull removedRemoteVideoStreams;
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

		// @property (readonly, copy) NSArray<ACSRemoteParticipant *> * _Nonnull addedParticipants;
		[Export ("addedParticipants", ArgumentSemantic.Copy)]
		ACSRemoteParticipant[] AddedParticipants { get; }

		// @property (readonly, copy) NSArray<ACSRemoteParticipant *> * _Nonnull removedParticipants;
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

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * _Nonnull addedStreams;
		[Export ("addedStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] AddedStreams { get; }

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * _Nonnull removedStreams;
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
	
	// @interface ACSCallFeature : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallFeature
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }
	}
	
	// @interface ACSCallsUpdatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallsUpdatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSCall *> * _Nonnull addedCalls;
		[Export ("addedCalls", ArgumentSemantic.Copy)]
		ACSCall[] AddedCalls { get; }

		// @property (readonly, copy) NSArray<ACSCall *> * _Nonnull removedCalls;
		[Export ("removedCalls", ArgumentSemantic.Copy)]
		ACSCall[] RemovedCalls { get; }
	}
	
	// @interface ACSIncomingCall : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSIncomingCall
	{
		// -(void)dealloc;
		[Export("dealloc")]
		void Dealloc();

		// @property (readonly, retain) ACSCallEndReason * _Nonnull callEndReason;
		[NullAllowed, Export("callEndReason", ArgumentSemantic.Retain)]
		ACSCallEndReason CallEndReason { get; }

		// @property (readonly, retain) ACSCallerInfo * _Nonnull callerInfo;
		[Export("callerInfo", ArgumentSemantic.Retain)]
		ACSCallerInfo CallerInfo { get; }

		// @property (readonly, retain) NSString * _Nonnull id;
		[Export("id", ArgumentSemantic.Retain)]
		string Id { get; }
	
		// @property (readonly) BOOL isVideoEnabled;
		[Export("isVideoEnabled")]
		bool IsVideoEnabled { get; }
	
		[Wrap("WeakDelegate")]
		[NullAllowed] ACSIncomingCallDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSIncomingCallDelegate> _Nullable delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(void)accept:(ACSAcceptCallOptions * _Nonnull)options withCompletionHandler:(void (^ _Nonnull)(ACSCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("accept(options:completionHandler:)")));
		[Export("accept:withCompletionHandler:")]
		void Accept(ACSAcceptCallOptions options, Action<ACSCall, NSError> completionHandler);

		// -(void)rejectWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("reject(completionHandler:)")));
		[Export("rejectWithCompletionHandler:")]
		void RejectWithCompletionHandler(Action<NSError> completionHandler);
	}

	// @interface ACSCallClient : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallClient
	{
		// -(instancetype _Nonnull)init:(ACSCallClientOptions * _Nonnull)options __attribute__((swift_name("init(options:)")));
		[Export ("init:")]
		IntPtr Constructor (ACSCallClientOptions options);
		
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// -(void)dispose;
		[Export("dispose")]
		void Dispose();

		// -(void)createCallAgent:(CommunicationTokenCredential * _Nonnull)userCredential withCompletionHandler:(void (^ _Nonnull)(ACSCallAgent * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("createCallAgent(userCredential:completionHandler:)")));
		[Export("createCallAgent:withCompletionHandler:")]
		void CreateCallAgent(CommunicationTokenCredential userCredential, Action<ACSCallAgent, NSError> completionHandler);

		// -(void)createCallAgentWithOptions:(CommunicationTokenCredential * _Nonnull)userCredential callAgentOptions:(ACSCallAgentOptions * _Nullable)callAgentOptions withCompletionHandler:(void (^ _Nonnull)(ACSCallAgent * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("createCallAgent(userCredential:options:completionHandler:)")));
		[Export("createCallAgentWithOptions:callAgentOptions:withCompletionHandler:")]
		void CreateCallAgentWithOptions(CommunicationTokenCredential userCredential, [NullAllowed] ACSCallAgentOptions callAgentOptions, Action<ACSCallAgent, NSError> completionHandler);

		// -(void)getDeviceManagerWithCompletionHandler:(void (^ _Nonnull)(ACSDeviceManager * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("getDeviceManager(completionHandler:)")));
		[Export("getDeviceManagerWithCompletionHandler:")]
		void GetDeviceManagerWithCompletionHandler(Action<ACSDeviceManager, NSError> completionHandler);

		// @property (retain) CommunicationTokenCredential * _Nonnull communicationCredential;
		[Export("communicationCredential", ArgumentSemantic.Retain)]
		CommunicationTokenCredential CommunicationCredential { get; set; }
	}
	
	// @interface ACSCallClientOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallClientOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSCallDiagnosticsOptions * _Nullable diagnostics;
		[NullAllowed, Export ("diagnostics", ArgumentSemantic.Retain)]
		ACSCallDiagnosticsOptions Diagnostics { get; set; }
	}

	// @interface ACSCallDiagnosticsOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallDiagnosticsOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) NSString * _Nonnull appName;
		[Export ("appName", ArgumentSemantic.Retain)]
		string AppName { get; set; }

		// @property (retain) NSString * _Nonnull appVersion;
		[Export ("appVersion", ArgumentSemantic.Retain)]
		string AppVersion { get; set; }

		// @property (copy) NSArray<NSString *> * _Nonnull tags;
		[Export ("tags", ArgumentSemantic.Copy)]
		string[] Tags { get; set; }
	}
	
	// @interface ACSDeviceManager : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSDeviceManager
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * _Nonnull cameras;
		[Export("cameras", ArgumentSemantic.Copy)]
		ACSVideoDeviceInfo[] Cameras { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSDeviceManagerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSDeviceManagerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSDeviceManagerEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSDeviceManagerEvents Events { get; }

	}

	// @interface ACSVideoDevicesUpdatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoDevicesUpdatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * _Nullable addedVideoDevices;
		[Export ("addedVideoDevices", ArgumentSemantic.Copy)]
		ACSVideoDeviceInfo[] AddedVideoDevices { get; }

		// @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * _Nullable removedVideoDevices;
		[Export ("removedVideoDevices", ArgumentSemantic.Copy)]
		ACSVideoDeviceInfo[] RemovedVideoDevices { get; }
	}

	// @interface ACSRecordingCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSRecordingCallFeature
	{
		// @property (readonly) BOOL isRecordingActive;
		[Export ("isRecordingActive")]
		bool IsRecordingActive { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRecordingCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRecordingCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRecordingCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRecordingCallFeatureEvents Events { get; }
	}

	// @interface ACSTranscriptionCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSTranscriptionCallFeature
	{
		// @property (readonly) BOOL isTranscriptionActive;
		[Export ("isTranscriptionActive")]
		bool IsTranscriptionActive { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSTranscriptionCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSTranscriptionCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSTranscriptionCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSTranscriptionCallFeatureEvents Events { get; }
	}
	
	// @interface ACSCreateViewOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCreateViewOptions
	{
		// -(instancetype _Nonnull)init:(ACSScalingMode)scalingMode __attribute__((swift_name("init(scalingMode:)")));
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