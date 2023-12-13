using System;
using AVFoundation;
using CallKit;
using CoreVideo;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Laerdal.Maui.AzureCommunicationCalling.iOS
{
	[Static]
	//[Verify(ConstantsInterfaceAssociation)]
	partial interface Constants
	{
		// extern double AzureCommunicationCommonVersionNumber;
		[Field ("AzureCommunicationCommonVersionNumber", "__Internal")]
		double AzureCommunicationCommonVersionNumber { get; }

		// extern const unsigned char[] AzureCommunicationCommonVersionString;
		[Field ("AzureCommunicationCommonVersionString", "__Internal")]
		NSString AzureCommunicationCommonVersionString { get; }
	}

	// @interface CommunicationAccessToken : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC24AzureCommunicationCommon24CommunicationAccessToken")]
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
		IntPtr Constructor(string token, NSDate expiresOn);
	}

	// @interface CommunicationCloudEnvironment : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC24AzureCommunicationCommon29CommunicationCloudEnvironment")]
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
		IntPtr Constructor(string environmentValue);

		// -(NSString * _Nonnull)getEnvironmentValue __attribute__((warn_unused_result("")));
		[Export ("getEnvironmentValue")]
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
	[Protocol (Name = "_TtP24AzureCommunicationCommon23CommunicationIdentifier_")]
	[BaseType (typeof(NSObject), Name = "_TtP24AzureCommunicationCommon23CommunicationIdentifier_")]
	interface CommunicationIdentifier
	{
	}

	// @interface CommunicationTokenCredential : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC24AzureCommunicationCommon28CommunicationTokenCredential")]
	[DisableDefaultCtor]
	interface CommunicationTokenCredential
	{
		// -(instancetype _Nullable)initWithToken:(NSString * _Nonnull)token error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithToken:error:")]
		[DesignatedInitializer]
		IntPtr Constructor(string token, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithOptions:(CommunicationTokenRefreshOptions * _Nonnull)options error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithOptions:error:")]
		[DesignatedInitializer]
		IntPtr Constructor(CommunicationTokenRefreshOptions options, [NullAllowed] out NSError error);

		// -(void)tokenWithCompletionHandler:(void (^ _Nonnull)(CommunicationAccessToken * _Nullable, NSError * _Nullable))completionHandler;
		[Export ("tokenWithCompletionHandler:")]
		void TokenWithCompletionHandler (Action<CommunicationAccessToken, NSError> completionHandler);
	}

	// @interface CommunicationTokenRefreshOptions : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC24AzureCommunicationCommon32CommunicationTokenRefreshOptions")]
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
	interface CommunicationUserIdentifier 
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
		[Export ("rawId")]
		string RawId { get; }

		// @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
		[Export ("kind", ArgumentSemantic.Strong)]
		IdentifierKind Kind { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier);
	}

	// @interface IdentifierKind : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC24AzureCommunicationCommon14IdentifierKind")]
	[DisableDefaultCtor]
	interface IdentifierKind
	{
		// @property (readonly, nonatomic, strong, class) IdentifierKind * _Nonnull communicationUser;
		[Static]
		[Export ("communicationUser", ArgumentSemantic.Strong)]
		IdentifierKind CommunicationUser { get; }

		// @property (readonly, nonatomic, strong, class) IdentifierKind * _Nonnull phoneNumber;
		[Static]
		[Export ("phoneNumber", ArgumentSemantic.Strong)]
		IdentifierKind PhoneNumber { get; }

		// @property (readonly, nonatomic, strong, class) IdentifierKind * _Nonnull microsoftTeamsUser;
		[Static]
		[Export ("microsoftTeamsUser", ArgumentSemantic.Strong)]
		IdentifierKind MicrosoftTeamsUser { get; }

		// @property (readonly, nonatomic, strong, class) IdentifierKind * _Nonnull unknown;
		[Static]
		[Export ("unknown", ArgumentSemantic.Strong)]
		IdentifierKind Unknown { get; }

		// -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue __attribute__((objc_designated_initializer));
		[Export ("initWithRawValue:")]
		[DesignatedInitializer]
		IntPtr Constructor(string rawValue);
	}

	// @interface MicrosoftTeamsUserIdentifier : NSObject <CommunicationIdentifier>
	[BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon28MicrosoftTeamsUserIdentifier")]
	[DisableDefaultCtor]
	interface MicrosoftTeamsUserIdentifier : CommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull userId;
		[Export ("userId")]
		string UserId { get; }

		// @property (readonly, nonatomic) BOOL isAnonymous;
		[Export ("isAnonymous")]
		bool IsAnonymous { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
		[Export ("rawId")]
		string RawId { get; }

		// @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
		[Export ("kind", ArgumentSemantic.Strong)]
		IdentifierKind Kind { get; }

		// @property (readonly, nonatomic, strong) CommunicationCloudEnvironment * _Nonnull cloudEnviroment;
		[Export ("cloudEnviroment", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment CloudEnviroment { get; }

		// -(instancetype _Nonnull)initWithUserId:(NSString * _Nonnull)userId isAnonymous:(BOOL)isAnonymous rawId:(NSString * _Nullable)rawId cloudEnvironment:(CommunicationCloudEnvironment * _Nonnull)cloudEnvironment __attribute__((objc_designated_initializer));
		[Export ("initWithUserId:isAnonymous:rawId:cloudEnvironment:")]
		[DesignatedInitializer]
		IntPtr Constructor(string userId, bool isAnonymous, [NullAllowed] string rawId, CommunicationCloudEnvironment cloudEnvironment);

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface PhoneNumberIdentifier : NSObject <CommunicationIdentifier>
	[BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon21PhoneNumberIdentifier")]
	[DisableDefaultCtor]
	interface PhoneNumberIdentifier 
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull phoneNumber;
		[Export ("phoneNumber")]
		string PhoneNumber { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
		[Export ("rawId")]
		string RawId { get; }

		// @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
		[Export ("kind", ArgumentSemantic.Strong)]
		IdentifierKind Kind { get; }

		// -(instancetype _Nonnull)initWithPhoneNumber:(NSString * _Nonnull)phoneNumber rawId:(NSString * _Nullable)rawId __attribute__((objc_designated_initializer));
		[Export ("initWithPhoneNumber:rawId:")]
		[DesignatedInitializer]
		IntPtr Constructor(string phoneNumber, [NullAllowed] string rawId);

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool IsEqual ([NullAllowed] NSObject @object);
	}

	// @interface UnknownIdentifier : NSObject <CommunicationIdentifier>
	[BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon17UnknownIdentifier")]
	[DisableDefaultCtor]
	interface UnknownIdentifier 
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
		[Export ("rawId")]
		string RawId { get; }

		// @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
		[Export ("kind", ArgumentSemantic.Strong)]
		IdentifierKind Kind { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export ("initWithIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor(string identifier);
	}

	// @interface ACSCallKitRemoteInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallKitRemoteInfo
	{
		// @property (retain) CXHandle * _Nullable handle;
		[NullAllowed, Export ("handle", ArgumentSemantic.Retain)]
		IntPtr Handle { get; set; }

		// @property (retain) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; set; }
	}

	// @interface ACSCallKitOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallKitOptions
	{
		// -(instancetype _Nonnull)init:(CXProviderConfiguration * _Nonnull)providerConfiguration __attribute__((swift_name("init(with:)")));
		[Export ("init:")]
		IntPtr Constructor(CXProviderConfiguration providerConfiguration);

		// @property (readonly, retain) CXProviderConfiguration * _Nonnull providerConfiguration;
		[Export ("providerConfiguration", ArgumentSemantic.Retain)]
		CXProviderConfiguration ProviderConfiguration { get; }

		// @property (copy, nonatomic) ACSCallKitRemoteInfo * _Nullable (^ _Nullable)(ACSCallerInfo * _Nonnull) provideRemoteInfo;
		[NullAllowed, Export ("provideRemoteInfo", ArgumentSemantic.Copy)]
		Func<ACSCallerInfo, ACSCallKitRemoteInfo> ProvideRemoteInfo { get; set; }

		// @property (copy, nonatomic) NSError * _Nullable (^ _Nullable)(void) configureAudioSession;
		[NullAllowed, Export ("configureAudioSession", ArgumentSemantic.Copy)]
		Func<NSError> ConfigureAudioSession { get; set; }

		// @property BOOL isCallHoldSupported;
		[Export ("isCallHoldSupported")]
		bool IsCallHoldSupported { get; set; }
	}

	// @interface ACSVideoStreamRendererView : UIView
	[BaseType (typeof(UIView))]
	[DisableDefaultCtor]
    [Transient]
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
		//[Verify(MethodToProperty)]
		bool IsRendering { get; }

		// -(struct ACSStreamSize)videoFrameSize;
		[Export ("videoFrameSize")]
		//[Verify(MethodToProperty)]
		ACSStreamSize VideoFrameSize { get; }
	}

	// @protocol ACSVideoStreamRendererDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSVideoStreamRendererDelegate
	{
		// @required -(void)rendererFailedToStart:(ACSVideoStreamRenderer * _Nonnull)renderer __attribute__((swift_name("videoStreamRenderer(didFailToStart:)")));
		[Abstract]
		[Export ("rendererFailedToStart:")]
		void RendererFailedToStart (ACSVideoStreamRenderer renderer);

		// @optional -(void)onFirstFrameRendered:(ACSVideoStreamRenderer * _Nonnull)renderer __attribute__((swift_name("videoStreamRenderer(didRenderFirstFrame:)")));
		[Export ("onFirstFrameRendered:")]
		void OnFirstFrameRendered (ACSVideoStreamRenderer renderer);
	}

	// @interface ACSVideoStreamRenderer : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoStreamRenderer
	{
		// @property (readonly) struct ACSStreamSize size;
		[Export ("size")]
		ACSStreamSize Size { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSVideoStreamRendererDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<ACSVideoStreamRendererDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nonnull)initWithLocalVideoStream:(ACSLocalVideoStream * _Nonnull)localVideoStream withError:(NSError * _Nullable * _Nonnull)nonnull_error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("init(localVideoStream:)")));
		[Export ("initWithLocalVideoStream:withError:")]
		IntPtr Constructor(ACSLocalVideoStream localVideoStream, [NullAllowed] out NSError nonnull_error);

		// -(instancetype _Nonnull)initWithRemoteVideoStream:(ACSRemoteVideoStream * _Nonnull)remoteVideoStream withError:(NSError * _Nullable * _Nonnull)nonnull_error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("init(remoteVideoStream:)")));
		[Export ("initWithRemoteVideoStream:withError:")]
		IntPtr Constructor(ACSRemoteVideoStream remoteVideoStream, [NullAllowed] out NSError nonnull_error);

		// -(ACSVideoStreamRendererView * _Nonnull)createView:(NSError * _Nullable * _Nonnull)nonnull_error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("createView()")));
		[Export ("createView:")]
		ACSVideoStreamRendererView CreateView ([NullAllowed] out NSError nonnull_error);

		// -(ACSVideoStreamRendererView * _Nonnull)createViewWithOptions:(ACSCreateViewOptions * _Nullable)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("createView(withOptions:)")));
		[Export ("createViewWithOptions:withError:")]
		ACSVideoStreamRendererView CreateViewWithOptions ([NullAllowed] ACSCreateViewOptions options, [NullAllowed] out NSError error);

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();
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

		// @property (readonly, class) Class captions __attribute__((swift_private));
		[Static]
		[Export ("captions")]
		Class Captions { get; }

		// @property (readonly, class) Class dominantSpeakers __attribute__((swift_private));
		[Static]
		[Export ("dominantSpeakers")]
		Class DominantSpeakers { get; }

		// @property (readonly, class) Class localUserDiagnostics __attribute__((swift_private));
		[Static]
		[Export ("localUserDiagnostics")]
		Class LocalUserDiagnostics { get; }

		// @property (readonly, class) Class dataChannel __attribute__((swift_private));
		[Static]
		[Export ("dataChannel")]
		Class DataChannel { get; }

		// @property (readonly, class) Class raisedHands __attribute__((swift_private));
		[Static]
		[Export ("raisedHands")]
		Class RaisedHands { get; }

		// @property (readonly, class) Class localVideoEffects __attribute__((swift_private));
		[Static]
		[Export ("localVideoEffects")]
		Class LocalVideoEffects { get; }

		// @property (readonly, class) Class mediaStats __attribute__((swift_private));
		[Static]
		[Export ("mediaStats")]
		Class MediaStats { get; }

		// @property (readonly, class) Class spotlight __attribute__((swift_private));
		[Static]
		[Export ("spotlight")]
		Class Spotlight { get; }

		// @property (readonly, class) Class survey __attribute__((swift_private));
		[Static]
		[Export ("survey")]
		Class Survey { get; }
	}

	// @interface ACSLocalVideoStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSLocalVideoStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSVideoStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSVideoStreamStateChangedEventArgs> OnStateChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
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

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onRoleChanged;
		[NullAllowed, Export ("onRoleChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnRoleChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSParticipantsUpdatedEventArgs * _Nonnull) onRemoteParticipantsUpdated;
		[NullAllowed, Export ("onRemoteParticipantsUpdated", ArgumentSemantic.Copy)]
		Action<ACSParticipantsUpdatedEventArgs> OnRemoteParticipantsUpdated { get; set; }

		// @property (copy) DEPRECATED_MSG_ATTRIBUTE("Use onStateChanged in VideoStream types instead") void (^)(ACSLocalVideoStreamsUpdatedEventArgs * _Nonnull) onLocalVideoStreamsUpdated __attribute__((deprecated("Use onStateChanged in VideoStream types instead")));
		[Export ("onLocalVideoStreamsUpdated", ArgumentSemantic.Copy)]
		Action<ACSLocalVideoStreamsUpdatedEventArgs> OnLocalVideoStreamsUpdated { get; set; }

		// @property (copy) DEPRECATED_MSG_ATTRIBUTE("Use OnOutgoingAudioStateChanged instead") void (^)(ACSPropertyChangedEventArgs * _Nonnull) onIsMutedChanged __attribute__((deprecated("Use OnOutgoingAudioStateChanged instead")));
		[Export ("onIsMutedChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIsMutedChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onOutgoingAudioStateChanged;
		[NullAllowed, Export ("onOutgoingAudioStateChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnOutgoingAudioStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIncomingAudioStateChanged;
		[NullAllowed, Export ("onIncomingAudioStateChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIncomingAudioStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onTotalParticipantCountChanged;
		[NullAllowed, Export ("onTotalParticipantCountChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnTotalParticipantCountChanged { get; set; }

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

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onRoleChanged;
		[NullAllowed, Export ("onRoleChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnRoleChanged { get; set; }

		// @property (copy) DEPRECATED_MSG_ATTRIBUTE("Use remoteParticipant(_:didChangeVideoStreamState:)) instead") void (^)(ACSRemoteVideoStreamsEventArgs * _Nonnull) onVideoStreamsUpdated __attribute__((deprecated("Use remoteParticipant(_:didChangeVideoStreamState:)) instead")));
		[Export ("onVideoStreamsUpdated", ArgumentSemantic.Copy)]
		Action<ACSRemoteVideoStreamsEventArgs> OnVideoStreamsUpdated { get; set; }

		// @property (copy) void (^ _Nullable)(ACSVideoStreamStateChangedEventArgs * _Nonnull) onVideoStreamStateChanged;
		[NullAllowed, Export ("onVideoStreamStateChanged", ArgumentSemantic.Copy)]
		Action<ACSVideoStreamStateChangedEventArgs> OnVideoStreamStateChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSRemoteVideoStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRemoteVideoStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSVideoStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSVideoStreamStateChangedEventArgs> OnStateChanged { get; set; }

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

	// @interface ACSTeamsCallAgentEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSTeamsCallAgentEvents
	{
		// @property (copy) void (^ _Nullable)(ACSTeamsCallsUpdatedEventArgs * _Nonnull) onCallsUpdated;
		[NullAllowed, Export ("onCallsUpdated", ArgumentSemantic.Copy)]
		Action<ACSTeamsCallsUpdatedEventArgs> OnCallsUpdated { get; set; }

		// @property (copy) void (^ _Nullable)(ACSTeamsIncomingCall * _Nonnull) onIncomingCall;
		[NullAllowed, Export ("onIncomingCall", ArgumentSemantic.Copy)]
		Action<ACSTeamsIncomingCall> OnIncomingCall { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSTeamsCallEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSTeamsCallEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIdChanged;
		[NullAllowed, Export ("onIdChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIdChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onRoleChanged;
		[NullAllowed, Export ("onRoleChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnRoleChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSParticipantsUpdatedEventArgs * _Nonnull) onRemoteParticipantsUpdated;
		[NullAllowed, Export ("onRemoteParticipantsUpdated", ArgumentSemantic.Copy)]
		Action<ACSParticipantsUpdatedEventArgs> OnRemoteParticipantsUpdated { get; set; }

		// @property (copy) DEPRECATED_MSG_ATTRIBUTE("Use onStateChanged in VideoStream types instead") void (^)(ACSLocalVideoStreamsUpdatedEventArgs * _Nonnull) onLocalVideoStreamsUpdated __attribute__((deprecated("Use onStateChanged in VideoStream types instead")));
		[Export ("onLocalVideoStreamsUpdated", ArgumentSemantic.Copy)]
		Action<ACSLocalVideoStreamsUpdatedEventArgs> OnLocalVideoStreamsUpdated { get; set; }

		// @property (copy) DEPRECATED_MSG_ATTRIBUTE("Use OnOutgoingAudioStateChanged instead") void (^)(ACSPropertyChangedEventArgs * _Nonnull) onIsMutedChanged __attribute__((deprecated("Use OnOutgoingAudioStateChanged instead")));
		[Export ("onIsMutedChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIsMutedChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onOutgoingAudioStateChanged;
		[NullAllowed, Export ("onOutgoingAudioStateChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnOutgoingAudioStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIncomingAudioStateChanged;
		[NullAllowed, Export ("onIncomingAudioStateChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIncomingAudioStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onTotalParticipantCountChanged;
		[NullAllowed, Export ("onTotalParticipantCountChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnTotalParticipantCountChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSTeamsIncomingCallEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSTeamsIncomingCallEvents
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

	// @interface ACSCallLobbyEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallLobbyEvents
	{
		// @property (copy) void (^ _Nullable)(ACSParticipantsUpdatedEventArgs * _Nonnull) onLobbyParticipantsUpdated;
		[NullAllowed, Export ("onLobbyParticipantsUpdated", ArgumentSemantic.Copy)]
		Action<ACSParticipantsUpdatedEventArgs> OnLobbyParticipantsUpdated { get; set; }

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

		// @property (copy) void (^ _Nullable)(ACSRecordingUpdatedEventArgs * _Nonnull) onRecordingUpdated;
		[NullAllowed, Export ("onRecordingUpdated", ArgumentSemantic.Copy)]
		Action<ACSRecordingUpdatedEventArgs> OnRecordingUpdated { get; set; }

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

	// @interface ACSCommunicationCaptionsEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCommunicationCaptionsEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onActiveSpokenLanguageChanged;
		[NullAllowed, Export ("onActiveSpokenLanguageChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnActiveSpokenLanguageChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onCaptionsEnabledChanged;
		[NullAllowed, Export ("onCaptionsEnabledChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnCaptionsEnabledChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSCommunicationCaptionsReceivedEventArgs * _Nonnull) onCaptionsReceived;
		[NullAllowed, Export ("onCaptionsReceived", ArgumentSemantic.Copy)]
		Action<ACSCommunicationCaptionsReceivedEventArgs> OnCaptionsReceived { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSTeamsCaptionsEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSTeamsCaptionsEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onCaptionsEnabledChanged;
		[NullAllowed, Export ("onCaptionsEnabledChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnCaptionsEnabledChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onActiveSpokenLanguageChanged;
		[NullAllowed, Export ("onActiveSpokenLanguageChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnActiveSpokenLanguageChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onActiveCaptionLanguageChanged;
		[NullAllowed, Export ("onActiveCaptionLanguageChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnActiveCaptionLanguageChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSTeamsCaptionsReceivedEventArgs * _Nonnull) onCaptionsReceived;
		[NullAllowed, Export ("onCaptionsReceived", ArgumentSemantic.Copy)]
		Action<ACSTeamsCaptionsReceivedEventArgs> OnCaptionsReceived { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSCaptionsCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCaptionsCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onActiveCaptionsTypeChanged;
		[NullAllowed, Export ("onActiveCaptionsTypeChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnActiveCaptionsTypeChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSDominantSpeakersCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSDominantSpeakersCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onDominantSpeakersChanged;
		[NullAllowed, Export ("onDominantSpeakersChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnDominantSpeakersChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSRaiseHandCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRaiseHandCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSRaisedHandChangedEventArgs * _Nonnull) onHandRaised;
		[NullAllowed, Export ("onHandRaised", ArgumentSemantic.Copy)]
		Action<ACSRaisedHandChangedEventArgs> OnHandRaised { get; set; }

		// @property (copy) void (^ _Nullable)(ACSLoweredHandChangedEventArgs * _Nonnull) onHandLowered;
		[NullAllowed, Export ("onHandLowered", ArgumentSemantic.Copy)]
		Action<ACSLoweredHandChangedEventArgs> OnHandLowered { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSSpotlightCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSSpotlightCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSSpotlightChangedEventArgs * _Nonnull) onSpotlightChanged;
		[NullAllowed, Export ("onSpotlightChanged", ArgumentSemantic.Copy)]
		Action<ACSSpotlightChangedEventArgs> OnSpotlightChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSScreenShareOutgoingVideoStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSScreenShareOutgoingVideoStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSVideoStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSVideoStreamStateChangedEventArgs> OnStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSVideoStreamFormatChangedEventArgs * _Nonnull) onFormatChanged;
		[NullAllowed, Export ("onFormatChanged", ArgumentSemantic.Copy)]
		Action<ACSVideoStreamFormatChangedEventArgs> OnFormatChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSVirtualOutgoingVideoStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSVirtualOutgoingVideoStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSVideoStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSVideoStreamStateChangedEventArgs> OnStateChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSVideoStreamFormatChangedEventArgs * _Nonnull) onFormatChanged;
		[NullAllowed, Export ("onFormatChanged", ArgumentSemantic.Copy)]
		Action<ACSVideoStreamFormatChangedEventArgs> OnFormatChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSRawIncomingVideoStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRawIncomingVideoStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSRawVideoFrameReceivedEventArgs * _Nonnull) onRawVideoFrameReceived;
		[NullAllowed, Export ("onRawVideoFrameReceived", ArgumentSemantic.Copy)]
		Action<ACSRawVideoFrameReceivedEventArgs> OnRawVideoFrameReceived { get; set; }

		// @property (copy) void (^ _Nullable)(ACSVideoStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSVideoStreamStateChangedEventArgs> OnStateChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSLocalOutgoingAudioStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSLocalOutgoingAudioStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSAudioStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSAudioStreamStateChangedEventArgs> OnStateChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSRemoteIncomingAudioStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRemoteIncomingAudioStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSAudioStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSAudioStreamStateChangedEventArgs> OnStateChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSRawIncomingAudioStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRawIncomingAudioStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSIncomingMixedAudioEventArgs * _Nonnull) onMixedAudioBufferReceived;
		[NullAllowed, Export ("onMixedAudioBufferReceived", ArgumentSemantic.Copy)]
		Action<ACSIncomingMixedAudioEventArgs> OnMixedAudioBufferReceived { get; set; }

		// @property (copy) void (^ _Nullable)(ACSIncomingUnmixedAudioEventArgs * _Nonnull) onUnmixedAudioBufferReceived;
		[NullAllowed, Export ("onUnmixedAudioBufferReceived", ArgumentSemantic.Copy)]
		Action<ACSIncomingUnmixedAudioEventArgs> OnUnmixedAudioBufferReceived { get; set; }

		// @property (copy) void (^ _Nullable)(ACSAudioStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSAudioStreamStateChangedEventArgs> OnStateChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSRawOutgoingAudioStreamEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRawOutgoingAudioStreamEvents
	{
		// @property (copy) void (^ _Nullable)(ACSAudioStreamStateChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSAudioStreamStateChangedEventArgs> OnStateChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSLocalVideoEffectsFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSLocalVideoEffectsFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSVideoEffectEnabledEventArgs * _Nonnull) onVideoEffectEnabled;
		[NullAllowed, Export ("onVideoEffectEnabled", ArgumentSemantic.Copy)]
		Action<ACSVideoEffectEnabledEventArgs> OnVideoEffectEnabled { get; set; }

		// @property (copy) void (^ _Nullable)(ACSVideoEffectDisabledEventArgs * _Nonnull) onVideoEffectDisabled;
		[NullAllowed, Export ("onVideoEffectDisabled", ArgumentSemantic.Copy)]
		Action<ACSVideoEffectDisabledEventArgs> OnVideoEffectDisabled { get; set; }

		// @property (copy) void (^ _Nullable)(ACSVideoEffectErrorEventArgs * _Nonnull) onVideoEffectError;
		[NullAllowed, Export ("onVideoEffectError", ArgumentSemantic.Copy)]
		Action<ACSVideoEffectErrorEventArgs> OnVideoEffectError { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSDataChannelReceiverEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSDataChannelReceiverEvents
	{
		// @property (copy) void (^ _Nullable)(ACSDataChannelReceiverMessageReceivedEventArgs * _Nonnull) onMessageReceived;
		[NullAllowed, Export ("onMessageReceived", ArgumentSemantic.Copy)]
		Action<ACSDataChannelReceiverMessageReceivedEventArgs> OnMessageReceived { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDataChannelReceiverClosedEventArgs * _Nonnull) onClosed;
		[NullAllowed, Export ("onClosed", ArgumentSemantic.Copy)]
		Action<ACSDataChannelReceiverClosedEventArgs> OnClosed { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSDataChannelCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSDataChannelCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSDataChannelReceiverCreatedEventArgs * _Nonnull) onDataChannelReceiverCreated;
		[NullAllowed, Export ("onDataChannelReceiverCreated", ArgumentSemantic.Copy)]
		Action<ACSDataChannelReceiverCreatedEventArgs> OnDataChannelReceiverCreated { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSNetworkDiagnosticsEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSNetworkDiagnosticsEvents
	{
		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsNetworkUnavailableChanged;
		[NullAllowed, Export ("onIsNetworkUnavailableChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsNetworkUnavailableChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsNetworkRelaysUnreachableChanged;
		[NullAllowed, Export ("onIsNetworkRelaysUnreachableChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsNetworkRelaysUnreachableChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticQualityChangedEventArgs * _Nonnull) onNetworkReconnectionQualityChanged;
		[NullAllowed, Export ("onNetworkReconnectionQualityChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticQualityChangedEventArgs> OnNetworkReconnectionQualityChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticQualityChangedEventArgs * _Nonnull) onNetworkReceiveQualityChanged;
		[NullAllowed, Export ("onNetworkReceiveQualityChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticQualityChangedEventArgs> OnNetworkReceiveQualityChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticQualityChangedEventArgs * _Nonnull) onNetworkSendQualityChanged;
		[NullAllowed, Export ("onNetworkSendQualityChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticQualityChangedEventArgs> OnNetworkSendQualityChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSMediaDiagnosticsEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSMediaDiagnosticsEvents
	{
		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsSpeakerNotFunctioningChanged;
		[NullAllowed, Export ("onIsSpeakerNotFunctioningChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsSpeakerNotFunctioningChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsSpeakerBusyChanged;
		[NullAllowed, Export ("onIsSpeakerBusyChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsSpeakerBusyChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsSpeakerMutedChanged;
		[NullAllowed, Export ("onIsSpeakerMutedChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsSpeakerMutedChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsSpeakerVolumeZeroChanged;
		[NullAllowed, Export ("onIsSpeakerVolumeZeroChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsSpeakerVolumeZeroChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsNoSpeakerDevicesAvailableChanged;
		[NullAllowed, Export ("onIsNoSpeakerDevicesAvailableChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsNoSpeakerDevicesAvailableChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsSpeakingWhileMicrophoneIsMutedChanged;
		[NullAllowed, Export ("onIsSpeakingWhileMicrophoneIsMutedChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsSpeakingWhileMicrophoneIsMutedChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsNoMicrophoneDevicesAvailableChanged;
		[NullAllowed, Export ("onIsNoMicrophoneDevicesAvailableChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsNoMicrophoneDevicesAvailableChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsMicrophoneBusyChanged;
		[NullAllowed, Export ("onIsMicrophoneBusyChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsMicrophoneBusyChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsCameraFrozenChanged;
		[NullAllowed, Export ("onIsCameraFrozenChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsCameraFrozenChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsCameraStartFailedChanged;
		[NullAllowed, Export ("onIsCameraStartFailedChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsCameraStartFailedChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsCameraStartTimedOutChanged;
		[NullAllowed, Export ("onIsCameraStartTimedOutChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsCameraStartTimedOutChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsMicrophoneNotFunctioningChanged;
		[NullAllowed, Export ("onIsMicrophoneNotFunctioningChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsMicrophoneNotFunctioningChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsMicrophoneMutedUnexpectedlyChanged;
		[NullAllowed, Export ("onIsMicrophoneMutedUnexpectedlyChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsMicrophoneMutedUnexpectedlyChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSDiagnosticFlagChangedEventArgs * _Nonnull) onIsCameraPermissionDeniedChanged;
		[NullAllowed, Export ("onIsCameraPermissionDeniedChanged", ArgumentSemantic.Copy)]
		Action<ACSDiagnosticFlagChangedEventArgs> OnIsCameraPermissionDeniedChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSMediaStatsCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSMediaStatsCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSMediaStatsReportEventArgs * _Nonnull) onSampleReported;
		[NullAllowed, Export ("onSampleReported", ArgumentSemantic.Copy)]
		Action<ACSMediaStatsReportEventArgs> OnSampleReported { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @interface ACSContentSharingCallFeatureEvents : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSContentSharingCallFeatureEvents
	{
		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onContentSharingInfoChanged;
		[NullAllowed, Export ("onContentSharingInfoChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnContentSharingInfoChanged { get; set; }

		// @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onStateChanged;
		[NullAllowed, Export ("onStateChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnStateChanged { get; set; }

		// -(void)removeAll;
		[Export ("removeAll")]
		void RemoveAll ();
	}

	// @protocol ACSLocalVideoStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSLocalVideoStreamDelegate
	{
		// @optional -(void)onStateChanged:(ACSLocalVideoStream * _Nonnull)localVideoStream :(ACSVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("localVideoStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSLocalVideoStream localVideoStream, ACSVideoStreamStateChangedEventArgs args);
	}

	// @protocol ACSCallAgentDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSCallAgentDelegate
	{
		// @optional -(void)onCallsUpdated:(ACSCallAgent * _Nonnull)callAgent :(ACSCallsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("callAgent(_:didUpdateCalls:)")));
		[Export ("onCallsUpdated::")]
		void OnCallsUpdated (ACSCallAgent callAgent, ACSCallsUpdatedEventArgs args);

		// @optional -(void)onIncomingCall:(ACSCallAgent * _Nonnull)callAgent :(ACSIncomingCall * _Nonnull)incomingCall __attribute__((swift_name("callAgent(_:didRecieveIncomingCall:)")));
		[Export ("onIncomingCall::")]
		void OnIncomingCall (ACSCallAgent callAgent, ACSIncomingCall incomingCall);
	}

	// @protocol ACSCallDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSCallDelegate
	{
		// @optional -(void)onIdChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeId:)")));
		[Export ("onIdChanged::")]
		void OnIdChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onStateChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onRoleChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeRole:)")));
		[Export ("onRoleChanged::")]
		void OnRoleChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onRemoteParticipantsUpdated:(ACSCall * _Nonnull)call :(ACSParticipantsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateRemoteParticipant:)")));
		[Export ("onRemoteParticipantsUpdated::")]
		void OnRemoteParticipantsUpdated (ACSCall call, ACSParticipantsUpdatedEventArgs args);

		// @optional -(void)onLocalVideoStreamsUpdated:(ACSCall * _Nonnull)call :(ACSLocalVideoStreamsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateLocalVideoStreams:)"))) __attribute__((deprecated("Use didChangeState on VideoStream types instead.")));
		[Export ("onLocalVideoStreamsUpdated::")]
		void OnLocalVideoStreamsUpdated (ACSCall call, ACSLocalVideoStreamsUpdatedEventArgs args);

		// @optional -(void)onIsMutedChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeMuteState:)"))) __attribute__((deprecated("Use call(_:didUpdateOutgoingAudioState:) instead.")));
		[Export ("onIsMutedChanged::")]
		void OnIsMutedChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onOutgoingAudioStateChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateOutgoingAudioState:)")));
		[Export ("onOutgoingAudioStateChanged::")]
		void OnOutgoingAudioStateChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIncomingAudioStateChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateIncomingAudioState:)")));
		[Export ("onIncomingAudioStateChanged::")]
		void OnIncomingAudioStateChanged (ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onTotalParticipantCountChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeTotalParticipantCount:)")));
		[Export ("onTotalParticipantCountChanged::")]
		void OnTotalParticipantCountChanged (ACSCall call, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSRemoteParticipantDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRemoteParticipantDelegate
	{
		// @optional -(void)onStateChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsMutedChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeMuteState:)")));
		[Export ("onIsMutedChanged::")]
		void OnIsMutedChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsSpeakingChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeSpeakingState:)")));
		[Export ("onIsSpeakingChanged::")]
		void OnIsSpeakingChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onDisplayNameChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeDisplayName:)")));
		[Export ("onDisplayNameChanged::")]
		void OnDisplayNameChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onRoleChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeRole:)")));
		[Export ("onRoleChanged::")]
		void OnRoleChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onVideoStreamsUpdated:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSRemoteVideoStreamsEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didUpdateVideoStreams:)"))) __attribute__((deprecated("Use remoteParticipant(_:didChangeVideoStreamState:)) instead")));
		[Export ("onVideoStreamsUpdated::")]
		void OnVideoStreamsUpdated (ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args);

		// @optional -(void)onVideoStreamStateChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeVideoStreamState:)")));
		[Export ("onVideoStreamStateChanged::")]
		void OnVideoStreamStateChanged (ACSRemoteParticipant remoteParticipant, ACSVideoStreamStateChangedEventArgs args);
	}

	// @protocol ACSRemoteVideoStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRemoteVideoStreamDelegate
	{
		// @optional -(void)onStateChanged:(ACSRemoteVideoStream * _Nonnull)remoteVideoStream :(ACSVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteVideoStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged(ACSRemoteVideoStream remoteVideoStream, ACSVideoStreamStateChangedEventArgs args);
	}

	// @protocol ACSIncomingCallDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSIncomingCallDelegate
	{
		// @optional -(void)onCallEnded:(ACSIncomingCall * _Nonnull)incomingCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("incomingCall(_:didEnd:)")));
		[Export ("onCallEnded::")]
		void  OnCallEnded(ACSIncomingCall incomingCall, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSTeamsCallAgentDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSTeamsCallAgentDelegate
	{
		// @optional -(void)onCallsUpdated:(ACSTeamsCallAgent * _Nonnull)teamsCallAgent :(ACSTeamsCallsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCallAgent(_:didUpdateCalls:)")));
		[Export ("onCallsUpdated::")]
		void OnCallsUpdated (ACSTeamsCallAgent teamsCallAgent, ACSTeamsCallsUpdatedEventArgs args);

		// @optional -(void)onIncomingCall:(ACSTeamsCallAgent * _Nonnull)teamsCallAgent :(ACSTeamsIncomingCall * _Nonnull)incomingCall __attribute__((swift_name("teamsCallAgent(_:didRecieveIncomingCall:)")));
		[Export ("onIncomingCall::")]
		void OnIncomingCall (ACSTeamsCallAgent teamsCallAgent, ACSTeamsIncomingCall incomingCall);
	}

	// @protocol ACSTeamsCallDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSTeamsCallDelegate
	{
		// @optional -(void)onIdChanged:(ACSTeamsCall * _Nonnull)teamsCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCall(_:didChangeId:)")));
		[Export ("onIdChanged::")]
		void OnIdChanged (ACSTeamsCall teamsCall, ACSPropertyChangedEventArgs args);

		// @optional -(void)onStateChanged:(ACSTeamsCall * _Nonnull)teamsCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCall(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSTeamsCall teamsCall, ACSPropertyChangedEventArgs args);

		// @optional -(void)onRoleChanged:(ACSTeamsCall * _Nonnull)teamsCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCall(_:didChangeRole:)")));
		[Export ("onRoleChanged::")]
		void OnRoleChanged (ACSTeamsCall teamsCall, ACSPropertyChangedEventArgs args);

		// @optional -(void)onRemoteParticipantsUpdated:(ACSTeamsCall * _Nonnull)teamsCall :(ACSParticipantsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCall(_:didUpdateRemoteParticipant:)")));
		[Export ("onRemoteParticipantsUpdated::")]
		void OnRemoteParticipantsUpdated (ACSTeamsCall teamsCall, ACSParticipantsUpdatedEventArgs args);

		// @optional -(void)onLocalVideoStreamsUpdated:(ACSTeamsCall * _Nonnull)teamsCall :(ACSLocalVideoStreamsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCall(_:didUpdateLocalVideoStreams:)"))) __attribute__((deprecated("Use didChangeState on VideoStream types instead.")));
		[Export ("onLocalVideoStreamsUpdated::")]
		void OnLocalVideoStreamsUpdated (ACSTeamsCall teamsCall, ACSLocalVideoStreamsUpdatedEventArgs args);

		// @optional -(void)onIsMutedChanged:(ACSTeamsCall * _Nonnull)teamsCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCall(_:didChangeMuteState:)"))) __attribute__((deprecated("Use call(_:didUpdateOutgoingAudioState:) instead.")));
		[Export ("onIsMutedChanged::")]
		void OnIsMutedChanged (ACSTeamsCall teamsCall, ACSPropertyChangedEventArgs args);

		// @optional -(void)onOutgoingAudioStateChanged:(ACSTeamsCall * _Nonnull)teamsCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCall(_:didUpdateOutgoingAudioState:)")));
		[Export ("onOutgoingAudioStateChanged::")]
		void OnOutgoingAudioStateChanged (ACSTeamsCall teamsCall, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIncomingAudioStateChanged:(ACSTeamsCall * _Nonnull)teamsCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateIncomingAudioState:)")));
		[Export ("onIncomingAudioStateChanged::")]
		void OnIncomingAudioStateChanged (ACSTeamsCall teamsCall, ACSPropertyChangedEventArgs args);

		// @optional -(void)onTotalParticipantCountChanged:(ACSTeamsCall * _Nonnull)teamsCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCall(_:didChangeTotalParticipantCount:)")));
		[Export ("onTotalParticipantCountChanged::")]
		void OnTotalParticipantCountChanged (ACSTeamsCall teamsCall, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSTeamsIncomingCallDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSTeamsIncomingCallDelegate
	{
		// @optional -(void)onCallEnded:(ACSTeamsIncomingCall * _Nonnull)teamsIncomingCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsIncomingCall(_:didEnd:)")));
		[Export ("onCallEnded::")]
		void OnCallEnded(ACSTeamsIncomingCall teamsIncomingCall, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSDeviceManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSDeviceManagerDelegate
	{
		// @optional -(void)onCamerasUpdated:(ACSDeviceManager * _Nonnull)deviceManager :(ACSVideoDevicesUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("deviceManager(_:didUpdateCameras:)")));
		[Export ("onCamerasUpdated::")]
		void OnCamerasUpdated(ACSDeviceManager deviceManager, ACSVideoDevicesUpdatedEventArgs args);
	}

	// @protocol ACSCallLobbyDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSCallLobbyDelegate
	{
		// @optional -(void)onLobbyParticipantsUpdated:(ACSCallLobby * _Nonnull)callLobby :(ACSParticipantsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("callLobby(_:didUpdateLobbyParticipants:)")));
		[Export ("onLobbyParticipantsUpdated::")]
		void OnLobbyParticipantsUpdated(ACSCallLobby callLobby, ACSParticipantsUpdatedEventArgs args);
	}

	// @protocol ACSRecordingCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRecordingCallFeatureDelegate
	{
		// @optional -(void)onIsRecordingActiveChanged:(ACSRecordingCallFeature * _Nonnull)recordingCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("recordingCallFeature(_:didChangeRecordingState:)")));
		[Export ("onIsRecordingActiveChanged::")]
		void OnIsRecordingActiveChanged (ACSRecordingCallFeature recordingCallFeature, ACSPropertyChangedEventArgs args);

		// @optional -(void)onRecordingUpdated:(ACSRecordingCallFeature * _Nonnull)recordingCallFeature :(ACSRecordingUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("recordingCallFeature(_:didUpdateRecording:)")));
		[Export ("onRecordingUpdated::")]
		void OnRecordingUpdated (ACSRecordingCallFeature recordingCallFeature, ACSRecordingUpdatedEventArgs args);
	}

	// @protocol ACSTranscriptionCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSTranscriptionCallFeatureDelegate
	{
		// @optional -(void)onIsTranscriptionActiveChanged:(ACSTranscriptionCallFeature * _Nonnull)transcriptionCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("transcriptionCallFeature(_:didChangeTranscriptionState:)")));
		[Export ("onIsTranscriptionActiveChanged::")]
		void OnIsTranscriptionActiveChanged(ACSTranscriptionCallFeature transcriptionCallFeature, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSCommunicationCaptionsDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSCommunicationCaptionsDelegate
	{
		// @optional -(void)onActiveSpokenLanguageChanged:(ACSCommunicationCaptions * _Nonnull)communicationCaptions :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("communicationCaptions(_:didChangeActiveSpokenLanguageState:)")));
		[Export ("onActiveSpokenLanguageChanged::")]
		void OnActiveSpokenLanguageChanged (ACSCommunicationCaptions communicationCaptions, ACSPropertyChangedEventArgs args);

		// @optional -(void)onCaptionsEnabledChanged:(ACSCommunicationCaptions * _Nonnull)communicationCaptions :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("communicationCaptions(_:didChangeCaptionsEnabledState:)")));
		[Export ("onCaptionsEnabledChanged::")]
		void OnCaptionsEnabledChanged (ACSCommunicationCaptions communicationCaptions, ACSPropertyChangedEventArgs args);

		// @optional -(void)onCaptionsReceived:(ACSCommunicationCaptions * _Nonnull)communicationCaptions :(ACSCommunicationCaptionsReceivedEventArgs * _Nonnull)args __attribute__((swift_name("communicationCaptions(_:didReceiveCaptions:)")));
		[Export ("onCaptionsReceived::")]
		void OnCaptionsReceived (ACSCommunicationCaptions communicationCaptions, ACSCommunicationCaptionsReceivedEventArgs args);
	}

	// @protocol ACSTeamsCaptionsDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSTeamsCaptionsDelegate
	{
		// @optional -(void)onCaptionsEnabledChanged:(ACSTeamsCaptions * _Nonnull)teamsCaptions :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCaptions(_:didChangeCaptionsEnabledState:)")));
		[Export ("onCaptionsEnabledChanged::")]
		void OnCaptionsEnabledChanged (ACSTeamsCaptions teamsCaptions, ACSPropertyChangedEventArgs args);

		// @optional -(void)onActiveSpokenLanguageChanged:(ACSTeamsCaptions * _Nonnull)teamsCaptions :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCaptions(_:didChangeActiveSpokenLanguageState:)")));
		[Export ("onActiveSpokenLanguageChanged::")]
		void OnActiveSpokenLanguageChanged (ACSTeamsCaptions teamsCaptions, ACSPropertyChangedEventArgs args);

		// @optional -(void)onActiveCaptionLanguageChanged:(ACSTeamsCaptions * _Nonnull)teamsCaptions :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCaptions(_:didChangeActiveCaptionLanguageState:)")));
		[Export ("onActiveCaptionLanguageChanged::")]
		void OnActiveCaptionLanguageChanged (ACSTeamsCaptions teamsCaptions, ACSPropertyChangedEventArgs args);

		// @optional -(void)onCaptionsReceived:(ACSTeamsCaptions * _Nonnull)teamsCaptions :(ACSTeamsCaptionsReceivedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCaptions(_:didReceiveCaptions:)")));
		[Export ("onCaptionsReceived::")]
		void OnCaptionsReceived (ACSTeamsCaptions teamsCaptions, ACSTeamsCaptionsReceivedEventArgs args);
	}

	// @protocol ACSCaptionsCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSCaptionsCallFeatureDelegate
	{
		// @optional -(void)onActiveCaptionsTypeChanged:(ACSCaptionsCallFeature * _Nonnull)captionsCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("captionsCallFeature(_:didChangeActiveCaptionsType:)")));
		[Export ("onActiveCaptionsTypeChanged::")]
		void OnActiveCaptionsTypeChanged(ACSCaptionsCallFeature captionsCallFeature, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSDominantSpeakersCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSDominantSpeakersCallFeatureDelegate
	{
		// @optional -(void)onDominantSpeakersChanged:(ACSDominantSpeakersCallFeature * _Nonnull)dominantSpeakersCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("dominantSpeakersCallFeature(_:didChangeDominantSpeakers:)")));
		[Export ("onDominantSpeakersChanged::")]
		void OnDominantSpeakersChanged(ACSDominantSpeakersCallFeature dominantSpeakersCallFeature, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSRaiseHandCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRaiseHandCallFeatureDelegate
	{
		// @optional -(void)onHandRaised:(ACSRaiseHandCallFeature * _Nonnull)raiseHandCallFeature :(ACSRaisedHandChangedEventArgs * _Nonnull)args __attribute__((swift_name("raiseHandCallFeature(_:didRaiseHand:)")));
		[Export ("onHandRaised::")]
		void OnHandRaised (ACSRaiseHandCallFeature raiseHandCallFeature, ACSRaisedHandChangedEventArgs args);

		// @optional -(void)onHandLowered:(ACSRaiseHandCallFeature * _Nonnull)raiseHandCallFeature :(ACSLoweredHandChangedEventArgs * _Nonnull)args __attribute__((swift_name("raiseHandCallFeature(_:didLowerHand:)")));
		[Export ("onHandLowered::")]
		void OnHandLowered (ACSRaiseHandCallFeature raiseHandCallFeature, ACSLoweredHandChangedEventArgs args);
	}

	// @protocol ACSSpotlightCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSSpotlightCallFeatureDelegate
	{
		// @optional -(void)onSpotlightChanged:(ACSSpotlightCallFeature * _Nonnull)spotlightCallFeature :(ACSSpotlightChangedEventArgs * _Nonnull)args __attribute__((swift_name("spotlightCallFeature(_:didChangeSpotlight:)")));
		[Export ("onSpotlightChanged::")]
		void OnSpotlightChanged(ACSSpotlightCallFeature spotlightCallFeature, ACSSpotlightChangedEventArgs args);
	}

	// @protocol ACSScreenShareOutgoingVideoStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSScreenShareOutgoingVideoStreamDelegate
	{
		// @optional -(void)onStateChanged:(ACSScreenShareOutgoingVideoStream * _Nonnull)screenShareOutgoingVideoStream :(ACSVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("screenShareOutgoingVideoStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSScreenShareOutgoingVideoStream screenShareOutgoingVideoStream, ACSVideoStreamStateChangedEventArgs args);

		// @optional -(void)onFormatChanged:(ACSScreenShareOutgoingVideoStream * _Nonnull)screenShareOutgoingVideoStream :(ACSVideoStreamFormatChangedEventArgs * _Nonnull)args __attribute__((swift_name("screenShareOutgoingVideoStream(_:didChangeFormat:)")));
		[Export ("onFormatChanged::")]
		void OnFormatChanged (ACSScreenShareOutgoingVideoStream screenShareOutgoingVideoStream, ACSVideoStreamFormatChangedEventArgs args);
	}

	// @protocol ACSVirtualOutgoingVideoStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSVirtualOutgoingVideoStreamDelegate
	{
		// @optional -(void)onStateChanged:(ACSVirtualOutgoingVideoStream * _Nonnull)virtualOutgoingVideoStream :(ACSVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("virtualOutgoingVideoStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSVirtualOutgoingVideoStream virtualOutgoingVideoStream, ACSVideoStreamStateChangedEventArgs args);

		// @optional -(void)onFormatChanged:(ACSVirtualOutgoingVideoStream * _Nonnull)virtualOutgoingVideoStream :(ACSVideoStreamFormatChangedEventArgs * _Nonnull)args __attribute__((swift_name("virtualOutgoingVideoStream(_:didChangeFormat:)")));
		[Export ("onFormatChanged::")]
		void OnFormatChanged (ACSVirtualOutgoingVideoStream virtualOutgoingVideoStream, ACSVideoStreamFormatChangedEventArgs args);
	}

	// @protocol ACSRawIncomingVideoStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRawIncomingVideoStreamDelegate
	{
		// @optional -(void)onRawVideoFrameReceived:(ACSRawIncomingVideoStream * _Nonnull)rawIncomingVideoStream :(ACSRawVideoFrameReceivedEventArgs * _Nonnull)args __attribute__((swift_name("rawIncomingVideoStream(_:didReceiveRawVideoFrame:)")));
		[Export ("onRawVideoFrameReceived::")]
		void OnRawVideoFrameReceived (ACSRawIncomingVideoStream rawIncomingVideoStream, ACSRawVideoFrameReceivedEventArgs args);

		// @optional -(void)onStateChanged:(ACSRawIncomingVideoStream * _Nonnull)rawIncomingVideoStream :(ACSVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("rawIncomingVideoStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSRawIncomingVideoStream rawIncomingVideoStream, ACSVideoStreamStateChangedEventArgs args);
	}

	// @protocol ACSLocalOutgoingAudioStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSLocalOutgoingAudioStreamDelegate
	{
		// @optional -(void)onStateChanged:(ACSLocalOutgoingAudioStream * _Nonnull)localOutgoingAudioStream :(ACSAudioStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("localAudioStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged(ACSLocalOutgoingAudioStream localOutgoingAudioStream, ACSAudioStreamStateChangedEventArgs args);
	}

	// @protocol ACSRemoteIncomingAudioStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRemoteIncomingAudioStreamDelegate
	{
		// @optional -(void)onStateChanged:(ACSRemoteIncomingAudioStream * _Nonnull)remoteIncomingAudioStream :(ACSAudioStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteAudioStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged(ACSRemoteIncomingAudioStream remoteIncomingAudioStream, ACSAudioStreamStateChangedEventArgs args);
	}

	// @protocol ACSRawIncomingAudioStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRawIncomingAudioStreamDelegate
	{
		// @optional -(void)onMixedAudioBufferReceived:(ACSRawIncomingAudioStream * _Nonnull)rawIncomingAudioStream :(ACSIncomingMixedAudioEventArgs * _Nonnull)args __attribute__((swift_name("rawIncomingAudioStream(_:didReceiveMixedAudioBuffer:)")));
		[Export ("onMixedAudioBufferReceived::")]
		void OnMixedAudioBufferReceived (ACSRawIncomingAudioStream rawIncomingAudioStream, ACSIncomingMixedAudioEventArgs args);

		// @optional -(void)onUnmixedAudioBufferReceived:(ACSRawIncomingAudioStream * _Nonnull)rawIncomingAudioStream :(ACSIncomingUnmixedAudioEventArgs * _Nonnull)args __attribute__((swift_name("rawIncomingAudioStream(_:didReceiveUnmixedAudioBuffer:)")));
		[Export ("onUnmixedAudioBufferReceived::")]
		void OnUnmixedAudioBufferReceived (ACSRawIncomingAudioStream rawIncomingAudioStream, ACSIncomingUnmixedAudioEventArgs args);

		// @optional -(void)onStateChanged:(ACSRawIncomingAudioStream * _Nonnull)rawIncomingAudioStream :(ACSAudioStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("rawIncomingAudioStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSRawIncomingAudioStream rawIncomingAudioStream, ACSAudioStreamStateChangedEventArgs args);
	}

	// @protocol ACSRawOutgoingAudioStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRawOutgoingAudioStreamDelegate
	{
		// @optional -(void)onStateChanged:(ACSRawOutgoingAudioStream * _Nonnull)rawOutgoingAudioStream :(ACSAudioStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("rawOutgoingAudioStream(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged(ACSRawOutgoingAudioStream rawOutgoingAudioStream, ACSAudioStreamStateChangedEventArgs args);
	}

	// @protocol ACSLocalVideoEffectsFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSLocalVideoEffectsFeatureDelegate
	{
		// @optional -(void)onVideoEffectEnabled:(ACSLocalVideoEffectsFeature * _Nonnull)localVideoEffectsFeature :(ACSVideoEffectEnabledEventArgs * _Nonnull)args __attribute__((swift_name("localVideoEffectsFeature(_:didEnableVideoEffect:)")));
		[Export ("onVideoEffectEnabled::")]
		void OnVideoEffectEnabled (ACSLocalVideoEffectsFeature localVideoEffectsFeature, ACSVideoEffectEnabledEventArgs args);

		// @optional -(void)onVideoEffectDisabled:(ACSLocalVideoEffectsFeature * _Nonnull)localVideoEffectsFeature :(ACSVideoEffectDisabledEventArgs * _Nonnull)args __attribute__((swift_name("localVideoEffectsFeature(_:didDisableVideoEffect:)")));
		[Export ("onVideoEffectDisabled::")]
		void OnVideoEffectDisabled (ACSLocalVideoEffectsFeature localVideoEffectsFeature, ACSVideoEffectDisabledEventArgs args);

		// @optional -(void)onVideoEffectError:(ACSLocalVideoEffectsFeature * _Nonnull)localVideoEffectsFeature :(ACSVideoEffectErrorEventArgs * _Nonnull)args __attribute__((swift_name("localVideoEffectsFeature(_:didReceiveVideoEffectError:)")));
		[Export ("onVideoEffectError::")]
		void OnVideoEffectError (ACSLocalVideoEffectsFeature localVideoEffectsFeature, ACSVideoEffectErrorEventArgs args);
	}

	// @protocol ACSDataChannelReceiverDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSDataChannelReceiverDelegate
	{
		// @optional -(void)onMessageReceived:(ACSDataChannelReceiver * _Nonnull)dataChannelReceiver :(ACSDataChannelReceiverMessageReceivedEventArgs * _Nonnull)args __attribute__((swift_name("dataChannelReceiver(_:didReceiveMessage:)")));
		[Export ("onMessageReceived::")]
		void OnMessageReceived (ACSDataChannelReceiver dataChannelReceiver, ACSDataChannelReceiverMessageReceivedEventArgs args);

		// @optional -(void)onClosed:(ACSDataChannelReceiver * _Nonnull)dataChannelReceiver :(ACSDataChannelReceiverClosedEventArgs * _Nonnull)args __attribute__((swift_name("dataChannelReceiver(_:didClose:)")));
		[Export ("onClosed::")]
		void OnClosed (ACSDataChannelReceiver dataChannelReceiver, ACSDataChannelReceiverClosedEventArgs args);
	}

	// @protocol ACSDataChannelCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSDataChannelCallFeatureDelegate
	{
		// @optional -(void)onDataChannelReceiverCreated:(ACSDataChannelCallFeature * _Nonnull)dataChannelCallFeature :(ACSDataChannelReceiverCreatedEventArgs * _Nonnull)args __attribute__((swift_name("dataChannelCallFeature(_:didCreateDataChannelReceiver:)")));
		[Export ("onDataChannelReceiverCreated::")]
		void OnDataChannelReceiverCreated(ACSDataChannelCallFeature dataChannelCallFeature, ACSDataChannelReceiverCreatedEventArgs args);
	}

	// @protocol ACSNetworkDiagnosticsDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSNetworkDiagnosticsDelegate
	{
		// @optional -(void)onIsNetworkUnavailableChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeIsNetworkUnavailable:)")));
		[Export ("onIsNetworkUnavailableChanged::")]
		void OnIsNetworkUnavailableChanged (ACSNetworkDiagnostics networkDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsNetworkRelaysUnreachableChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeIsNetworkRelaysUnreachable:)")));
		[Export ("onIsNetworkRelaysUnreachableChanged::")]
		void OnIsNetworkRelaysUnreachableChanged (ACSNetworkDiagnostics networkDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onNetworkReconnectionQualityChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSDiagnosticQualityChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeNetworkReconnectionQuality:)")));
		[Export ("onNetworkReconnectionQualityChanged::")]
		void OnNetworkReconnectionQualityChanged (ACSNetworkDiagnostics networkDiagnostics, ACSDiagnosticQualityChangedEventArgs args);

		// @optional -(void)onNetworkReceiveQualityChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSDiagnosticQualityChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeNetworkReceiveQuality:)")));
		[Export ("onNetworkReceiveQualityChanged::")]
		void OnNetworkReceiveQualityChanged (ACSNetworkDiagnostics networkDiagnostics, ACSDiagnosticQualityChangedEventArgs args);

		// @optional -(void)onNetworkSendQualityChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSDiagnosticQualityChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeNetworkSendQuality:)")));
		[Export ("onNetworkSendQualityChanged::")]
		void OnNetworkSendQualityChanged (ACSNetworkDiagnostics networkDiagnostics, ACSDiagnosticQualityChangedEventArgs args);
	}

	// @protocol ACSMediaDiagnosticsDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSMediaDiagnosticsDelegate
	{
		// @optional -(void)onIsSpeakerNotFunctioningChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsSpeakerNotFunctioning:)")));
		[Export ("onIsSpeakerNotFunctioningChanged::")]
		void OnIsSpeakerNotFunctioningChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsSpeakerBusyChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsSpeakerBusy:)")));
		[Export ("onIsSpeakerBusyChanged::")]
		void OnIsSpeakerBusyChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsSpeakerMutedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsSpeakerMuted:)")));
		[Export ("onIsSpeakerMutedChanged::")]
		void OnIsSpeakerMutedChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsSpeakerVolumeZeroChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsSpeakerVolumeZero:)")));
		[Export ("onIsSpeakerVolumeZeroChanged::")]
		void OnIsSpeakerVolumeZeroChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsNoSpeakerDevicesAvailableChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsNoSpeakerDevicesAvailable:)")));
		[Export ("onIsNoSpeakerDevicesAvailableChanged::")]
		void OnIsNoSpeakerDevicesAvailableChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsSpeakingWhileMicrophoneIsMutedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsSpeakingWhileMicrophoneIsMuted:)")));
		[Export ("onIsSpeakingWhileMicrophoneIsMutedChanged::")]
		void OnIsSpeakingWhileMicrophoneIsMutedChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsNoMicrophoneDevicesAvailableChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsNoMicrophoneDevicesAvailable:)")));
		[Export ("onIsNoMicrophoneDevicesAvailableChanged::")]
		void OnIsNoMicrophoneDevicesAvailableChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsMicrophoneBusyChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsMicrophoneBusy:)")));
		[Export ("onIsMicrophoneBusyChanged::")]
		void OnIsMicrophoneBusyChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsCameraFrozenChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsCameraFrozen:)")));
		[Export ("onIsCameraFrozenChanged::")]
		void OnIsCameraFrozenChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsCameraStartFailedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsCameraStartFailed:)")));
		[Export ("onIsCameraStartFailedChanged::")]
		void OnIsCameraStartFailedChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsCameraStartTimedOutChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsCameraStartTimedOut:)")));
		[Export ("onIsCameraStartTimedOutChanged::")]
		void OnIsCameraStartTimedOutChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsMicrophoneNotFunctioningChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsMicrophoneNotFunctioning:)")));
		[Export ("onIsMicrophoneNotFunctioningChanged::")]
		void OnIsMicrophoneNotFunctioningChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsMicrophoneMutedUnexpectedlyChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsMicrophoneMutedUnexpectedly:)")));
		[Export ("onIsMicrophoneMutedUnexpectedlyChanged::")]
		void OnIsMicrophoneMutedUnexpectedlyChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);

		// @optional -(void)onIsCameraPermissionDeniedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSDiagnosticFlagChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeIsCameraPermissionDenied:)")));
		[Export ("onIsCameraPermissionDeniedChanged::")]
		void OnIsCameraPermissionDeniedChanged (ACSMediaDiagnostics mediaDiagnostics, ACSDiagnosticFlagChangedEventArgs args);
	}

	// @protocol ACSMediaStatsCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSMediaStatsCallFeatureDelegate
	{
		// @optional -(void)onSampleReported:(ACSMediaStatsCallFeature * _Nonnull)mediaStatsCallFeature :(ACSMediaStatsReportEventArgs * _Nonnull)args __attribute__((swift_name("mediaStatsCallFeature(_:didReceiveSample:)")));
		[Export ("onSampleReported::")]
		void OnSampleReported(ACSMediaStatsCallFeature mediaStatsCallFeature, ACSMediaStatsReportEventArgs args);
	}

	// @protocol ACSContentSharingCallFeatureDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSContentSharingCallFeatureDelegate
	{
		// @optional -(void)onContentSharingInfoChanged:(ACSContentSharingCallFeature * _Nonnull)contentSharingCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("ContentSharingCallFeature(_:didChangeContentSharing:)")));
		[Export ("onContentSharingInfoChanged::")]
		void OnContentSharingInfoChanged (ACSContentSharingCallFeature contentSharingCallFeature, ACSPropertyChangedEventArgs args);

		// @optional -(void)onStateChanged:(ACSContentSharingCallFeature * _Nonnull)contentSharingCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeState:)")));
		[Export ("onStateChanged::")]
		void OnStateChanged (ACSContentSharingCallFeature contentSharingCallFeature, ACSPropertyChangedEventArgs args);
	}

	// @interface ACSCallVideoStream : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallVideoStream
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) ACSVideoStreamType type;
		[Export ("type")]
		ACSVideoStreamType Type { get; }

		// @property (readonly) ACSVideoStreamSourceType sourceType;
		[Export ("sourceType")]
		ACSVideoStreamSourceType SourceType { get; }

		// @property (readonly) ACSVideoStreamState state;
		[Export ("state")]
		ACSVideoStreamState State { get; }

		// @property (readonly) ACSStreamDirection direction;
		[Export ("direction")]
		ACSStreamDirection Direction { get; }

		// @property (readonly) ACSMediaStreamType mediaStreamType __attribute__((deprecated("Use sourceType instead")));
		[Export ("mediaStreamType")]
		ACSMediaStreamType MediaStreamType { get; }

		// @property (readonly) int id;
		[Export ("id")]
		int Id { get; }
	}

	// @interface ACSOutgoingVideoStream : ACSCallVideoStream
	[BaseType (typeof(ACSCallVideoStream))]
	[DisableDefaultCtor]
	interface ACSOutgoingVideoStream
	{
	}

	// @interface ACSIncomingVideoStream : ACSCallVideoStream
	[BaseType (typeof(ACSCallVideoStream))]
	[DisableDefaultCtor]
	interface ACSIncomingVideoStream
	{
		// @property (readonly, retain) NSString * _Nonnull participantSourceId;
		[Export ("participantSourceId", ArgumentSemantic.Retain)]
		string ParticipantSourceId { get; }
	}

	// @interface ACSOutgoingVideoOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSOutgoingVideoOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (copy) NSArray<ACSOutgoingVideoStream *> * _Nonnull streams;
		[Export ("streams", ArgumentSemantic.Copy)]
		ACSOutgoingVideoStream[] Streams { get; set; }

		// @property (retain) ACSOutgoingVideoConstraints * _Nullable constraints;
		[NullAllowed, Export ("constraints", ArgumentSemantic.Retain)]
		ACSOutgoingVideoConstraints Constraints { get; set; }
	}

	// @interface ACSOutgoingVideoConstraints : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSOutgoingVideoConstraints
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property int maxHeight;
		[Export ("maxHeight")]
		int MaxHeight { get; set; }

		// @property int maxWidth;
		[Export ("maxWidth")]
		int MaxWidth { get; set; }

		// @property int maxFrameRate;
		[Export ("maxFrameRate")]
		int MaxFrameRate { get; set; }
	}

	// @interface ACSIncomingVideoOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIncomingVideoOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property ACSVideoStreamType streamType;
		[Export ("streamType", ArgumentSemantic.Assign)]
		ACSVideoStreamType StreamType { get; set; }

		// @property (retain) ACSIncomingVideoConstraints * _Nullable constraints;
		[NullAllowed, Export ("constraints", ArgumentSemantic.Retain)]
		ACSIncomingVideoConstraints Constraints { get; set; }
	}

	// @interface ACSIncomingVideoConstraints : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIncomingVideoConstraints
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property int maxHeight;
		[Export ("maxHeight")]
		int MaxHeight { get; set; }

		// @property int maxWidth;
		[Export ("maxWidth")]
		int MaxWidth { get; set; }
	}

	// @interface ACSVideoOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoOptions
	{
		// -(instancetype _Nonnull)init:(NSArray<ACSLocalVideoStream *> * _Nonnull)localVideoStreams __attribute__((swift_name("init(localVideoStreams:)")));
		[Export ("init:")]
		IntPtr Constructor(ACSLocalVideoStream[] localVideoStreams);

		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * _Nonnull localVideoStreams;
		[Export ("localVideoStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] LocalVideoStreams { get; }
	}

	// @interface ACSLocalVideoStream : ACSOutgoingVideoStream
	[BaseType (typeof(ACSOutgoingVideoStream))]
	[DisableDefaultCtor]
	interface ACSLocalVideoStream
	{
		// -(instancetype _Nonnull)init:(ACSVideoDeviceInfo * _Nonnull)camera __attribute__((swift_name("init(camera:)")));
		[Export ("init:")]
		IntPtr Constructor(ACSVideoDeviceInfo camera);

		// @property (readonly, retain) ACSVideoDeviceInfo * _Nonnull source;
		[Export ("source", ArgumentSemantic.Retain)]
		ACSVideoDeviceInfo Source { get; }

		// @property (readonly) BOOL isSending __attribute__((deprecated("Use state property instead")));
		[Export ("isSending")]
		bool IsSending { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSLocalVideoStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSLocalVideoStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSLocalVideoStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSLocalVideoStreamEvents Events { get; }

		// -(void)switchSource:(ACSVideoDeviceInfo * _Nonnull)camera withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("switchSource(camera:completionHandler:)")));
		[Export ("switchSource:withCompletionHandler:")]
		void SwitchSource (ACSVideoDeviceInfo camera, Action<NSError> completionHandler);

		// -(id _Nonnull)feature:(Class _Nonnull)featureClass __attribute__((swift_private));
		[Export ("feature:")]
		NSObject Feature (Class featureClass);
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

	// @interface ACSLocalVideoStreamFeature : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSLocalVideoStreamFeature
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }
	}

	// @interface ACSVideoStreamStateChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoStreamStateChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSCallVideoStream * _Nonnull stream;
		[Export ("stream", ArgumentSemantic.Retain)]
		ACSCallVideoStream Stream { get; }

		// @property (readonly, retain) NSString * _Nonnull message;
		[Export ("message", ArgumentSemantic.Retain)]
		string Message { get; }
	}

	// @interface ACSOutgoingAudioFilters : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSOutgoingAudioFilters
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property BOOL analogAutomaticGainControlEnabled;
		[Export ("analogAutomaticGainControlEnabled")]
		bool AnalogAutomaticGainControlEnabled { get; set; }

		// @property BOOL digitalAutomaticGainControlEnabled;
		[Export ("digitalAutomaticGainControlEnabled")]
		bool DigitalAutomaticGainControlEnabled { get; set; }

		// @property ACSNoiseSuppressionMode noiseSuppressionMode;
		[Export ("noiseSuppressionMode", ArgumentSemantic.Assign)]
		ACSNoiseSuppressionMode NoiseSuppressionMode { get; set; }

		// @property BOOL musicModeEnabled;
		[Export ("musicModeEnabled")]
		bool MusicModeEnabled { get; set; }

		// @property BOOL acousticEchoCancellationEnabled;
		[Export ("acousticEchoCancellationEnabled")]
		bool AcousticEchoCancellationEnabled { get; set; }
	}

	// @interface ACSLiveOutgoingAudioFilters : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSLiveOutgoingAudioFilters
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property ACSNoiseSuppressionMode noiseSuppressionMode;
		[Export ("noiseSuppressionMode", ArgumentSemantic.Assign)]
		ACSNoiseSuppressionMode NoiseSuppressionMode { get; set; }

		// @property BOOL musicModeEnabled;
		[Export ("musicModeEnabled")]
		bool MusicModeEnabled { get; set; }

		// @property BOOL acousticEchoCancellationEnabled;
		[Export ("acousticEchoCancellationEnabled")]
		bool AcousticEchoCancellationEnabled { get; set; }
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

	// @interface ACSIncomingAudioOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIncomingAudioOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property BOOL muted;
		[Export ("muted")]
		bool Muted { get; set; }

		// @property (retain) ACSIncomingAudioStream * _Nullable stream;
		[NullAllowed, Export ("stream", ArgumentSemantic.Retain)]
		ACSIncomingAudioStream Stream { get; set; }
	}

	// @interface ACSCallAudioStream : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallAudioStream
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) ACSAudioStreamType type;
		[Export ("type")]
		ACSAudioStreamType Type { get; }

		// @property (readonly) ACSAudioStreamState state;
		[Export ("state")]
		ACSAudioStreamState State { get; }

		// @property (readonly) ACSStreamDirection direction;
		[Export ("direction")]
		ACSStreamDirection Direction { get; }
	}

	// @interface ACSIncomingAudioStream : ACSCallAudioStream
	[BaseType (typeof(ACSCallAudioStream))]
	[DisableDefaultCtor]
	interface ACSIncomingAudioStream
	{
	}

	// @interface ACSOutgoingAudioOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSOutgoingAudioOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property BOOL muted;
		[Export ("muted")]
		bool Muted { get; set; }

		// @property (retain) ACSOutgoingAudioFilters * _Nullable filters;
		[NullAllowed, Export ("filters", ArgumentSemantic.Retain)]
		ACSOutgoingAudioFilters Filters { get; set; }

		// @property (retain) ACSOutgoingAudioStream * _Nullable stream;
		[NullAllowed, Export ("stream", ArgumentSemantic.Retain)]
		ACSOutgoingAudioStream Stream { get; set; }
	}

	// @interface ACSOutgoingAudioStream : ACSCallAudioStream
	[BaseType (typeof(ACSCallAudioStream))]
	[DisableDefaultCtor]
	interface ACSOutgoingAudioStream
	{
	}

	// @interface ACSCallOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) DEPRECATED_MSG_ATTRIBUTE("Use IncomingVideoOptions and OutgoingVideoOptions instead") ACSVideoOptions * videoOptions __attribute__((deprecated("Use IncomingVideoOptions and OutgoingVideoOptions instead")));
		[Export ("videoOptions", ArgumentSemantic.Retain)]
		ACSVideoOptions VideoOptions { get; set; }

		// @property (retain) DEPRECATED_MSG_ATTRIBUTE("Use incomingAudioOptions and outgoingAudioOptions instead.") ACSAudioOptions * audioOptions __attribute__((deprecated("Use incomingAudioOptions and outgoingAudioOptions instead.")));
		[Export ("audioOptions", ArgumentSemantic.Retain)]
		ACSAudioOptions AudioOptions { get; set; }

		// @property (retain) ACSIncomingVideoOptions * _Nullable incomingVideoOptions;
		[NullAllowed, Export ("incomingVideoOptions", ArgumentSemantic.Retain)]
		ACSIncomingVideoOptions IncomingVideoOptions { get; set; }

		// @property (retain) ACSOutgoingVideoOptions * _Nullable outgoingVideoOptions;
		[NullAllowed, Export ("outgoingVideoOptions", ArgumentSemantic.Retain)]
		ACSOutgoingVideoOptions OutgoingVideoOptions { get; set; }

		// @property (retain) ACSIncomingAudioOptions * _Nullable incomingAudioOptions;
		[NullAllowed, Export ("incomingAudioOptions", ArgumentSemantic.Retain)]
		ACSIncomingAudioOptions IncomingAudioOptions { get; set; }

		// @property (retain) ACSOutgoingAudioOptions * _Nullable outgoingAudioOptions;
		[NullAllowed, Export ("outgoingAudioOptions", ArgumentSemantic.Retain)]
		ACSOutgoingAudioOptions OutgoingAudioOptions { get; set; }

		// @property ACSCallKitRemoteInfo * _Nullable callKitRemoteInfo;
		[NullAllowed, Export ("callKitRemoteInfo", ArgumentSemantic.Assign)]
		ACSCallKitRemoteInfo CallKitRemoteInfo { get; set; }
	}

	// @interface ACSJoinCallOptions : ACSCallOptions
	[BaseType (typeof(ACSCallOptions))]
	interface ACSJoinCallOptions
	{
	}

	// @interface ACSAcceptCallOptions : ACSCallOptions
	[BaseType (typeof(ACSCallOptions))]
	interface ACSAcceptCallOptions
	{
	}

	// @interface ACSStartCallOptions : ACSCallOptions
	[BaseType (typeof(ACSCallOptions))]
	interface ACSStartCallOptions
	{
		// @property (nonatomic) PhoneNumberIdentifier * _Nonnull alternateCallerId;
		[Export ("alternateCallerId", ArgumentSemantic.Assign)]
		PhoneNumberIdentifier AlternateCallerId { get; set; }
	}

	// @interface ACSVideoConstraints : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSVideoConstraints
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSIncomingVideoConstraints * _Nullable incomingVideoConstraints;
		[NullAllowed, Export ("incomingVideoConstraints", ArgumentSemantic.Retain)]
		ACSIncomingVideoConstraints IncomingVideoConstraints { get; set; }

		// @property (retain) ACSOutgoingVideoConstraints * _Nullable outgoingVideoConstraints;
		[NullAllowed, Export ("outgoingVideoConstraints", ArgumentSemantic.Retain)]
		ACSOutgoingVideoConstraints OutgoingVideoConstraints { get; set; }
	}

	// @interface ACSAddPhoneNumberOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSAddPhoneNumberOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (nonatomic) PhoneNumberIdentifier * _Nonnull alternateCallerId;
		[Export ("alternateCallerId", ArgumentSemantic.Assign)]
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

	// @interface ACSGroupChatCallLocator : ACSJoinMeetingLocator
	[BaseType (typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSGroupChatCallLocator
	{
		// -(instancetype _Nonnull)init:(NSString * _Nonnull)threadId __attribute__((swift_name("init(threadId:)")));
		[Export ("init:")]
		NativeHandle Constructor (string threadId);

		// @property (readonly, retain) NSString * _Nonnull threadId;
		[Export ("threadId", ArgumentSemantic.Retain)]
		string ThreadId { get; }
	}

	// @interface ACSGroupCallLocator : ACSJoinMeetingLocator
	[BaseType (typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSGroupCallLocator
	{
		// -(instancetype _Nonnull)init:(NSUUID * _Nonnull)groupId __attribute__((swift_name("init(groupId:)")));
		[Export ("init:")]
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
		IntPtr Constructor(string threadId, NSUuid organizerId, NSUuid tenantId, string messageId);

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
		IntPtr Constructor(string meetingLink);

		// @property (readonly, retain) NSString * _Nonnull meetingLink;
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

		// @property (readonly, retain) NSString * _Nonnull displayName;
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

		// @property (readonly, retain) NSString * _Nonnull fromDisplayName;
		[Export ("fromDisplayName", ArgumentSemantic.Retain)]
		string FromDisplayName { get; }

		// @property (readonly) BOOL incomingWithVideo;
		[Export ("incomingWithVideo")]
		bool IncomingWithVideo { get; }

		// @property (readonly) ACSPushNotificationEventType eventType;
		[Export ("eventType")]
		ACSPushNotificationEventType EventType { get; }

		// @property (readonly, retain) id<CommunicationIdentifier> _Nonnull from;
		[Export ("from", ArgumentSemantic.Retain)]
		CommunicationIdentifier From { get; }

		// @property (readonly, retain) id<CommunicationIdentifier> _Nonnull to;
		[Export ("to", ArgumentSemantic.Retain)]
		CommunicationIdentifier To { get; }

		// @property (readonly, nonatomic) NSUUID * _Nonnull callId;
		[Export ("callId")]
		NSUuid CallId { get; }

		// +(ACSPushNotificationInfo * _Nonnull)fromDictionary:(NSDictionary * _Nonnull)payload;
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

		// @property (retain) NSString * _Nonnull displayName;
		[Export ("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; set; }

		// @property (retain) ACSEmergencyCallOptions * _Nullable emergencyCallOptions;
		[NullAllowed, Export ("emergencyCallOptions", ArgumentSemantic.Retain)]
		ACSEmergencyCallOptions EmergencyCallOptions { get; set; }

		// @property (retain) ACSCallKitOptions * _Nullable callKitOptions;
		[NullAllowed, Export ("callKitOptions", ArgumentSemantic.Retain)]
		ACSCallKitOptions CallKitOptions { get; set; }
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

	// @interface ACSCallAgentBase : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallAgentBase
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();

		// -(void)unregisterPushNotificationWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("unregisterPushNotification(completionHandler:)")));
		[Export ("unregisterPushNotificationWithCompletionHandler:")]
		void UnregisterPushNotificationWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)registerPushNotifications:(NSData * _Nonnull)deviceToken withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("registerPushNotifications(deviceToken:completionHandler:)")));
		[Export ("registerPushNotifications:withCompletionHandler:")]
		void RegisterPushNotifications (NSData deviceToken, Action<NSError> completionHandler);

		// -(void)handlePushNotification:(ACSPushNotificationInfo * _Nonnull)notification withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("handlePush(notification:completionHandler:)")));
		[Export ("handlePushNotification:withCompletionHandler:")]
		void HandlePushNotification (ACSPushNotificationInfo notification, Action<NSError> completionHandler);
	}

	// @interface ACSCallAgent : ACSCallAgentBase
	[BaseType (typeof(ACSCallAgentBase))]
	[DisableDefaultCtor]
	interface ACSCallAgent
	{
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

		// -(void)startCall:(NSArray<id<CommunicationIdentifier>> * _Nonnull)participants options:(ACSStartCallOptions * _Nullable)options withCompletionHandler:(void (^ _Nonnull)(ACSCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("startCall(participants:options:completionHandler:)")));
		[Export ("startCall:options:withCompletionHandler:")]
		void StartCall (CommunicationIdentifier[] participants, [NullAllowed] ACSStartCallOptions options, Action<ACSCall, NSError> completionHandler);

		// -(void)joinWithMeetingLocator:(ACSJoinMeetingLocator * _Nonnull)meetingLocator joinCallOptions:(ACSJoinCallOptions * _Nullable)joinCallOptions withCompletionHandler:(void (^ _Nonnull)(ACSCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("join(with:joinCallOptions:completionHandler:)")));
		[Export ("joinWithMeetingLocator:joinCallOptions:withCompletionHandler:")]
		void JoinWithMeetingLocator (ACSJoinMeetingLocator meetingLocator, [NullAllowed] ACSJoinCallOptions joinCallOptions, Action<ACSCall, NSError> completionHandler);
	}

	// @interface ACSCallBase : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallBase
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
		[Export ("direction")]
		ACSCallDirection Direction { get; }

		// @property (readonly) BOOL isMuted __attribute__((deprecated("Use isOutgoingAudioMuted instead.")));
		[Export ("isMuted")]
		bool IsMuted { get; }

		// @property (readonly) BOOL isOutgoingAudioMuted;
		[Export ("isOutgoingAudioMuted")]
		bool IsOutgoingAudioMuted { get; }

		// @property (readonly) BOOL isIncomingAudioMuted;
		[Export ("isIncomingAudioMuted")]
		bool IsIncomingAudioMuted { get; }

		// @property (readonly, retain) ACSCallerInfo * _Nonnull callerInfo;
		[Export ("callerInfo", ArgumentSemantic.Retain)]
		ACSCallerInfo CallerInfo { get; }

		// @property (readonly, retain) ACSCallLobby * _Nonnull callLobby;
		[Export ("callLobby", ArgumentSemantic.Retain)]
		ACSCallLobby CallLobby { get; }

		// @property (readonly, retain) ACSIncomingAudioStream * _Nonnull activeIncomingAudioStream;
		[Export ("activeIncomingAudioStream", ArgumentSemantic.Retain)]
		ACSIncomingAudioStream ActiveIncomingAudioStream { get; }

		// @property (readonly, retain) ACSOutgoingAudioStream * _Nonnull activeOutgoingAudioStream;
		[Export ("activeOutgoingAudioStream", ArgumentSemantic.Retain)]
		ACSOutgoingAudioStream ActiveOutgoingAudioStream { get; }

		// @property (readonly) ACSCallParticipantRole callParticipantRole;
		[Export ("callParticipantRole")]
		ACSCallParticipantRole CallParticipantRole { get; }

		// @property (readonly, copy) DEPRECATED_MSG_ATTRIBUTE("Use outgoingVideoStreams instead") NSArray<ACSLocalVideoStream *> * localVideoStreams __attribute__((deprecated("Use outgoingVideoStreams instead")));
		[Export ("localVideoStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] LocalVideoStreams { get; }

		// @property (readonly, copy) NSArray<ACSOutgoingVideoStream *> * _Nonnull outgoingVideoStreams;
		[Export ("outgoingVideoStreams", ArgumentSemantic.Copy)]
		ACSOutgoingVideoStream[] OutgoingVideoStreams { get; }

		// @property (readonly) int totalParticipantCount;
		[Export ("totalParticipantCount")]
		int TotalParticipantCount { get; }

		// @property (readonly, retain) ACSLiveOutgoingAudioFilters * _Nonnull liveOutgoingAudioFilters;
		[Export ("liveOutgoingAudioFilters", ArgumentSemantic.Retain)]
		ACSLiveOutgoingAudioFilters LiveOutgoingAudioFilters { get; }

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();

		// -(void)startAudio:(ACSCallAudioStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("startAudio(stream:completionHandler:)")));
		[Export ("startAudio:withCompletionHandler:")]
		void StartAudio (ACSCallAudioStream stream, Action<NSError> completionHandler);

		// -(void)stopAudio:(ACSCallAudioStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("stopAudio(stream:completionHandler:)")));
		[Export ("stopAudio:withCompletionHandler:")]
		void StopAudio (ACSCallAudioStream stream, Action<NSError> completionHandler);

		// -(void)muteAllRemoteParticipantsWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("muteAllRemoteParticipants(completionHandler:)")));
		[Export ("muteAllRemoteParticipantsWithCompletionHandler:")]
		void MuteAllRemoteParticipantsWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)muteWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("mute(completionHandler:)"))) __attribute__((deprecated("Use muteOutgoingAudio instead.")));
		[Export ("muteWithCompletionHandler:")]
		void MuteWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)unmuteWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("unmute(completionHandler:)"))) __attribute__((deprecated("Use unmuteOutgoingAudio instead.")));
		[Export ("unmuteWithCompletionHandler:")]
		void UnmuteWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)muteIncomingAudioWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("muteIncomingAudio(completionHandler:)")));
		[Export ("muteIncomingAudioWithCompletionHandler:")]
		void MuteIncomingAudioWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)unmuteIncomingAudioWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("unmuteIncomingAudio(completionHandler:)")));
		[Export ("unmuteIncomingAudioWithCompletionHandler:")]
		void UnmuteIncomingAudioWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)unmuteOutgoingAudioWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("unmuteOutgoingAudio(completionHandler:)")));
		[Export ("unmuteOutgoingAudioWithCompletionHandler:")]
		void UnmuteOutgoingAudioWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)muteOutgoingAudioWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("muteOutgoingAudio(completionHandler:)")));
		[Export ("muteOutgoingAudioWithCompletionHandler:")]
		void MuteOutgoingAudioWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)sendDtmf:(ACSDtmfTone)tone withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("sendDtmf(tone:completionHandler:)")));
		[Export ("sendDtmf:withCompletionHandler:")]
		void SendDtmf (ACSDtmfTone tone, Action<NSError> completionHandler);

		// -(void)startVideo:(ACSOutgoingVideoStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("startVideo(stream:completionHandler:)")));
		[Export ("startVideo:withCompletionHandler:")]
		void StartVideo (ACSOutgoingVideoStream stream, Action<NSError> completionHandler);

		// -(void)stopVideo:(ACSOutgoingVideoStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("stopVideo(stream:completionHandler:)")));
		[Export ("stopVideo:withCompletionHandler:")]
		void StopVideo (ACSOutgoingVideoStream stream, Action<NSError> completionHandler);

		// -(void)hangUp:(ACSHangUpOptions * _Nullable)options withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("hangUp(options:completionHandler:)")));
		[Export ("hangUp:withCompletionHandler:")]
		void HangUp ([NullAllowed] ACSHangUpOptions options, Action<NSError> completionHandler);

		// -(void)removeParticipant:(ACSRemoteParticipant * _Nonnull)participant withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("remove(participant:completionHandler:)")));
		[Export ("removeParticipant:withCompletionHandler:")]
		void RemoveParticipant (ACSRemoteParticipant participant, Action<NSError> completionHandler);

		// -(void)holdWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("hold(completionHandler:)")));
		[Export ("holdWithCompletionHandler:")]
		void HoldWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)resumeWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("resume(completionHandler:)")));
		[Export ("resumeWithCompletionHandler:")]
		void ResumeWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)setVideoConstraints:(ACSVideoConstraints * _Nonnull)constraints __attribute__((swift_name("set(videoConstraints:)")));
		[Export ("setVideoConstraints:")]
		void SetVideoConstraints (ACSVideoConstraints constraints);

		// -(id _Nonnull)feature:(Class _Nonnull)featureClass __attribute__((swift_private));
		[Export ("feature:")]
		NSObject Feature (Class featureClass);
	}

	// @interface ACSCall : ACSCallBase
	[BaseType (typeof(ACSCallBase))]
	[DisableDefaultCtor]
	interface ACSCall
	{
		// @property (readonly, retain) ACSCallInfo * _Nonnull info;
		[Export ("info", ArgumentSemantic.Retain)]
		ACSCallInfo Info { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSCallDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSCallDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSCallEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSCallEvents Events { get; }

		// -(ACSRemoteParticipant * _Nullable)addParticipant:(id<CommunicationIdentifier> _Nonnull)participant withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("add(participant:)")));
		[Export ("addParticipant:withError:")]
		[return: NullAllowed]
		ACSRemoteParticipant AddParticipant (CommunicationIdentifier participant, [NullAllowed] out NSError error);

		// -(ACSRemoteParticipant * _Nullable)addParticipant:(PhoneNumberIdentifier * _Nonnull)participant options:(ACSAddPhoneNumberOptions * _Nullable)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("add(participant:options:)")));
		[Export ("addParticipant:options:withError:")]
		[return: NullAllowed]
		ACSRemoteParticipant AddParticipant (PhoneNumberIdentifier participant, [NullAllowed] ACSAddPhoneNumberOptions options, [NullAllowed] out NSError error);
	}

	// @interface ACSCallInfoBase : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallInfoBase
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// -(void)getServerCallIdWithCompletionHandler:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("getServerCallId(completionHandler:)")));
		[Export ("getServerCallIdWithCompletionHandler:")]
		void GetServerCallIdWithCompletionHandler (Action<NSString, NSError> completionHandler);
	}

	// @interface ACSCallInfo : ACSCallInfoBase
	[BaseType (typeof(ACSCallInfoBase))]
	[DisableDefaultCtor]
	interface ACSCallInfo
	{
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

	// @interface ACSRemoteParticipant : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRemoteParticipant
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull displayName;
		[Export ("displayName", ArgumentSemantic.Retain)]
		string DisplayName { get; }

		// @property (readonly) ACSCallParticipantRole callParticipantRole;
		[Export ("callParticipantRole")]
		ACSCallParticipantRole CallParticipantRole { get; }

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

		// @property (readonly, copy) DEPRECATED_MSG_ATTRIBUTE("Use IncomingVideoStreams getter instead") NSArray<ACSRemoteVideoStream *> * videoStreams __attribute__((deprecated("Use IncomingVideoStreams getter instead")));
		[Export ("videoStreams", ArgumentSemantic.Copy)]
		ACSRemoteVideoStream[] VideoStreams { get; }

		// @property (readonly, copy) NSArray<ACSIncomingVideoStream *> * _Nonnull incomingVideoStreams;
		[Export ("incomingVideoStreams", ArgumentSemantic.Copy)]
		ACSIncomingVideoStream[] IncomingVideoStreams { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRemoteParticipantDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRemoteParticipantDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRemoteParticipantEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRemoteParticipantEvents Events { get; }

		// -(void)muteWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("mute(completionHandler:)")));
		[Export ("muteWithCompletionHandler:")]
		void MuteWithCompletionHandler (Action<NSError> completionHandler);

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

	// @interface ACSRemoteVideoStream : ACSIncomingVideoStream
	[BaseType (typeof(ACSIncomingVideoStream))]
	[DisableDefaultCtor]
	interface ACSRemoteVideoStream
	{
		// @property (readonly) BOOL isAvailable __attribute__((deprecated("Use state property instead")));
		[Export ("isAvailable")]
		bool IsAvailable { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRemoteVideoStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRemoteVideoStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRemoteVideoStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRemoteVideoStreamEvents Events { get; }
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

	// @interface ACSIncomingCallBase : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSIncomingCallBase
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSCallEndReason * _Nullable callEndReason;
		[NullAllowed, Export ("callEndReason", ArgumentSemantic.Retain)]
		ACSCallEndReason CallEndReason { get; }

		// @property (readonly, retain) ACSCallerInfo * _Nonnull callerInfo;
		[Export ("callerInfo", ArgumentSemantic.Retain)]
		ACSCallerInfo CallerInfo { get; }

		// @property (readonly, retain) NSString * _Nonnull id;
		[Export ("id", ArgumentSemantic.Retain)]
		string Id { get; }

		// @property (readonly) BOOL isVideoEnabled;
		[Export ("isVideoEnabled")]
		bool IsVideoEnabled { get; }

		// -(void)rejectWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("reject(completionHandler:)")));
		[Export ("rejectWithCompletionHandler:")]
		void RejectWithCompletionHandler (Action<NSError> completionHandler);
	}

	// @interface ACSIncomingCall : ACSIncomingCallBase
	[BaseType (typeof(ACSIncomingCallBase))]
	[DisableDefaultCtor]
	interface ACSIncomingCall
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSIncomingCallDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSIncomingCallDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSIncomingCallEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSIncomingCallEvents Events { get; }

		// -(void)accept:(ACSAcceptCallOptions * _Nonnull)options withCompletionHandler:(void (^ _Nonnull)(ACSCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("accept(options:completionHandler:)")));
		[Export ("accept:withCompletionHandler:")]
		void Accept (ACSAcceptCallOptions options, Action<ACSCall, NSError> completionHandler);
	}

	// @interface ACSCallDebugInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallDebugInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, nonatomic, strong) NSArray<NSURL *> * _Nonnull supportFiles;
		[Export ("supportFiles", ArgumentSemantic.Strong)]
		NSUrl[] SupportFiles { get; }
	}

	// @interface ACSCallClient : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallClient
	{
		// -(instancetype _Nonnull)init:(ACSCallClientOptions * _Nonnull)options __attribute__((swift_name("init(options:)")));
		[Export ("init:")]
		IntPtr Constructor(ACSCallClientOptions options);

		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSCallDebugInfo * _Nonnull debugInfo;
		[Export ("debugInfo", ArgumentSemantic.Retain)]
		ACSCallDebugInfo DebugInfo { get; }

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();

		// -(void)createCallAgent:(CommunicationTokenCredential * _Nonnull)userCredential withCompletionHandler:(void (^ _Nonnull)(ACSCallAgent * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("createCallAgent(userCredential:completionHandler:)")));
		[Export ("createCallAgent:withCompletionHandler:")]
		void CreateCallAgent (CommunicationTokenCredential userCredential, Action<ACSCallAgent, NSError> completionHandler);

		// -(void)createCallAgentWithOptions:(CommunicationTokenCredential * _Nonnull)userCredential callAgentOptions:(ACSCallAgentOptions * _Nullable)callAgentOptions withCompletionHandler:(void (^ _Nonnull)(ACSCallAgent * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("createCallAgent(userCredential:options:completionHandler:)")));
		[Export ("createCallAgentWithOptions:callAgentOptions:withCompletionHandler:")]
		void CreateCallAgentWithOptions (CommunicationTokenCredential userCredential, [NullAllowed] ACSCallAgentOptions callAgentOptions, Action<ACSCallAgent, NSError> completionHandler);

		// -(void)createTeamsCallAgent:(CommunicationTokenCredential * _Nonnull)userCredential withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCallAgent * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("createTeamsCallAgent(userCredential:completionHandler:)")));
		[Export ("createTeamsCallAgent:withCompletionHandler:")]
		void CreateTeamsCallAgent (CommunicationTokenCredential userCredential, Action<ACSTeamsCallAgent, NSError> completionHandler);

		// -(void)createTeamsCallAgentWithOptions:(CommunicationTokenCredential * _Nonnull)userCredential teamsCallAgentOptions:(ACSTeamsCallAgentOptions * _Nullable)options withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCallAgent * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("createTeamsCallAgent(userCredential:options:completionHandler:)")));
		[Export ("createTeamsCallAgentWithOptions:teamsCallAgentOptions:withCompletionHandler:")]
		void CreateTeamsCallAgentWithOptions (CommunicationTokenCredential userCredential, [NullAllowed] ACSTeamsCallAgentOptions options, Action<ACSTeamsCallAgent, NSError> completionHandler);

		// +(void)reportIncomingCall:(ACSPushNotificationInfo * _Nonnull)payload callKitOptions:(ACSCallKitOptions * _Nonnull)callKitOptions withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("reportIncomingCall(with:callKitOptions:completionHandler:)")));
		[Static]
		[Export ("reportIncomingCall:callKitOptions:withCompletionHandler:")]
		void ReportIncomingCall (ACSPushNotificationInfo payload, ACSCallKitOptions callKitOptions, Action<NSError> completionHandler);

		// -(void)getDeviceManagerWithCompletionHandler:(void (^ _Nonnull)(ACSDeviceManager * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("getDeviceManager(completionHandler:)")));
		[Export ("getDeviceManagerWithCompletionHandler:")]
		void GetDeviceManagerWithCompletionHandler (Action<ACSDeviceManager, NSError> completionHandler);

		// @property (retain) CommunicationTokenCredential * _Nonnull communicationCredential;
		[Export ("communicationCredential", ArgumentSemantic.Retain)]
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

		// @property (retain) ACSCallNetworkOptions * _Nullable networkOptions;
		[NullAllowed, Export ("networkOptions", ArgumentSemantic.Retain)]
		ACSCallNetworkOptions NetworkOptions { get; set; }
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

	// @interface ACSCallNetworkOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallNetworkOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) NSString * _Nonnull proxyAddress;
		[Export ("proxyAddress", ArgumentSemantic.Retain)]
		string ProxyAddress { get; set; }

		// @property (copy) NSArray<ACSIceServerInfo *> * _Nonnull iceServers;
		[Export ("iceServers", ArgumentSemantic.Copy)]
		ACSIceServerInfo[] IceServers { get; set; }
	}

	// @interface ACSIceServerInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIceServerInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (copy) NSArray<NSString *> * _Nonnull urls;
		[Export ("urls", ArgumentSemantic.Copy)]
		string[] Urls { get; set; }

		// @property (retain) NSString * _Nonnull realm;
		[Export ("realm", ArgumentSemantic.Retain)]
		string Realm { get; set; }

		// @property int tcpPort;
		[Export ("tcpPort")]
		int TcpPort { get; set; }

		// @property int udpPort;
		[Export ("udpPort")]
		int UdpPort { get; set; }

		// @property (retain) NSString * _Nonnull username;
		[Export ("username", ArgumentSemantic.Retain)]
		string Username { get; set; }

		// @property (retain) NSString * _Nonnull credential;
		[Export ("credential", ArgumentSemantic.Retain)]
		string Credential { get; set; }

		// @property BOOL standardTURN;
		[Export ("standardTURN")]
		bool StandardTURN { get; set; }
	}

	// @interface ACSTeamsCallAgentOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSTeamsCallAgentOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSCallKitOptions * _Nullable callKitOptions;
		[NullAllowed, Export ("callKitOptions", ArgumentSemantic.Retain)]
		ACSCallKitOptions CallKitOptions { get; set; }
	}

	// @interface ACSTeamsCallAgent : ACSCallAgentBase
	[BaseType (typeof(ACSCallAgentBase))]
	[DisableDefaultCtor]
	interface ACSTeamsCallAgent
	{
		// @property (readonly, copy) NSArray<ACSTeamsCall *> * _Nonnull calls;
		[Export ("calls", ArgumentSemantic.Copy)]
		ACSTeamsCall[] Calls { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSTeamsCallAgentDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSTeamsCallAgentDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSTeamsCallAgentEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSTeamsCallAgentEvents Events { get; }

		// -(void)startCallWithParticipantWithOptions:(id<CommunicationIdentifier> _Nonnull)participant options:(ACSStartTeamsCallOptions * _Nullable)options withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("startCall(participant:options:completionHandler:)")));
		[Export ("startCallWithParticipantWithOptions:options:withCompletionHandler:")]
		void StartCallWithParticipantWithOptions (CommunicationIdentifier participant, [NullAllowed] ACSStartTeamsCallOptions options, Action<ACSTeamsCall, NSError> completionHandler);

		// -(void)startCallWithParticipant:(id<CommunicationIdentifier> _Nonnull)participant withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("startCall(participant:completionHandler:)")));
		[Export ("startCallWithParticipant:withCompletionHandler:")]
		void StartCallWithParticipant (CommunicationIdentifier participant, Action<ACSTeamsCall, NSError> completionHandler);

		// -(void)startCallWithParticipants:(NSArray<id<CommunicationIdentifier>> * _Nonnull)participants options:(ACSStartTeamsGroupCallOptions * _Nonnull)options withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("startCall(participants:options:completionHandler:)")));
		[Export ("startCallWithParticipants:options:withCompletionHandler:")]
		void StartCallWithParticipants (CommunicationIdentifier[] participants, ACSStartTeamsGroupCallOptions options, Action<ACSTeamsCall, NSError> completionHandler);

		// -(void)joinWithTeamsMeetingLinkLocatorWithOptions:(ACSTeamsMeetingLinkLocator * _Nonnull)meetingLocator joinCallOptions:(ACSJoinCallOptions * _Nonnull)joinCallOptions withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("join(teamsMeetingLinkLocator:joinCallOptions:completionHandler:)")));
		[Export ("joinWithTeamsMeetingLinkLocatorWithOptions:joinCallOptions:withCompletionHandler:")]
		void JoinWithTeamsMeetingLinkLocatorWithOptions (ACSTeamsMeetingLinkLocator meetingLocator, ACSJoinCallOptions joinCallOptions, Action<ACSTeamsCall, NSError> completionHandler);

		// -(void)joinWithTeamsMeetingLinkLocator:(ACSTeamsMeetingLinkLocator * _Nonnull)meetingLocator withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("join(teamsMeetingLinkLocator:completionHandler:)")));
		[Export ("joinWithTeamsMeetingLinkLocator:withCompletionHandler:")]
		void JoinWithTeamsMeetingLinkLocator (ACSTeamsMeetingLinkLocator meetingLocator, Action<ACSTeamsCall, NSError> completionHandler);

		// -(void)joinWithMeetingCoordinatesLocatorWithOptions:(ACSTeamsMeetingCoordinatesLocator * _Nonnull)meetingLocator joinCallOptions:(ACSJoinCallOptions * _Nonnull)joinCallOptions withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("join(teamsMeetingCoordinatesLocator:joinCallOptions:completionHandler:)")));
		[Export ("joinWithMeetingCoordinatesLocatorWithOptions:joinCallOptions:withCompletionHandler:")]
		void JoinWithMeetingCoordinatesLocatorWithOptions (ACSTeamsMeetingCoordinatesLocator meetingLocator, ACSJoinCallOptions joinCallOptions, Action<ACSTeamsCall, NSError> completionHandler);

		// -(void)joinWithMeetingCoordinatesLocator:(ACSTeamsMeetingCoordinatesLocator * _Nonnull)meetingLocator withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("join(teamsMeetingCoordinatesLocator:completionHandler:)")));
		[Export ("joinWithMeetingCoordinatesLocator:withCompletionHandler:")]
		void JoinWithMeetingCoordinatesLocator (ACSTeamsMeetingCoordinatesLocator meetingLocator, Action<ACSTeamsCall, NSError> completionHandler);
	}

	// @interface ACSTeamsCall : ACSCallBase
	[BaseType (typeof(ACSCallBase))]
	[DisableDefaultCtor]
	interface ACSTeamsCall
	{
		// @property (readonly, retain) ACSTeamsCallInfo * _Nonnull info;
		[Export ("info", ArgumentSemantic.Retain)]
		ACSTeamsCallInfo Info { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSTeamsCallDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSTeamsCallDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSTeamsCallEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSTeamsCallEvents Events { get; }

		// -(ACSRemoteParticipant * _Nullable)addParticipant:(id<CommunicationIdentifier> _Nonnull)participant options:(ACSAddTeamsParticipantOptions * _Nonnull)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("add(participant:options:)")));
		[Export ("addParticipant:options:withError:")]
		[return: NullAllowed]
		ACSRemoteParticipant AddParticipant (CommunicationIdentifier participant, ACSAddTeamsParticipantOptions options, [NullAllowed] out NSError error);

		// -(ACSRemoteParticipant * _Nullable)addUnknownParticipant:(UnknownIdentifier * _Nonnull)participant options:(ACSAddTeamsParticipantOptions * _Nonnull)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("add(participant:options:)")));
		[Export ("addUnknownParticipant:options:withError:")]
		[return: NullAllowed]
		ACSRemoteParticipant AddUnknownParticipant (UnknownIdentifier participant, ACSAddTeamsParticipantOptions options, [NullAllowed] out NSError error);

		// -(ACSRemoteParticipant * _Nullable)addTeamsParticipant:(MicrosoftTeamsUserIdentifier * _Nonnull)participant options:(ACSAddTeamsParticipantOptions * _Nonnull)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("add(participant:options:)")));
		[Export ("addTeamsParticipant:options:withError:")]
		[return: NullAllowed]
		ACSRemoteParticipant AddTeamsParticipant (MicrosoftTeamsUserIdentifier participant, ACSAddTeamsParticipantOptions options, [NullAllowed] out NSError error);

		// -(ACSRemoteParticipant * _Nullable)addPhoneNumberParticipant:(PhoneNumberIdentifier * _Nonnull)participant options:(ACSAddTeamsParticipantOptions * _Nonnull)options withError:(NSError * _Nullable * _Nonnull)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_name("add(phoneNumber:options:)")));
		[Export ("addPhoneNumberParticipant:options:withError:")]
		[return: NullAllowed]
		ACSRemoteParticipant AddPhoneNumberParticipant (PhoneNumberIdentifier participant, ACSAddTeamsParticipantOptions options, [NullAllowed] out NSError error);
	}

	// @interface ACSTeamsCallInfo : ACSCallInfoBase
	[BaseType (typeof(ACSCallInfoBase))]
	[DisableDefaultCtor]
	interface ACSTeamsCallInfo
	{
		// @property (readonly, retain) NSString * _Nonnull threadId;
		[Export ("threadId", ArgumentSemantic.Retain)]
		string ThreadId { get; }
	}

	// @interface ACSAddTeamsParticipantOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSAddTeamsParticipantOptions
	{
		// -(instancetype _Nonnull)init:(NSString * _Nonnull)threadId __attribute__((swift_name("init(threadId:)")));
		[Export ("init:")]
		NativeHandle Constructor (string threadId);

		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull threadId;
		[Export ("threadId", ArgumentSemantic.Retain)]
		string ThreadId { get; }
	}

	// @interface ACSStartTeamsCallOptions : ACSCallOptions
	[BaseType (typeof(ACSCallOptions))]
	interface ACSStartTeamsCallOptions
	{
	}

	// @interface ACSStartTeamsGroupCallOptions : ACSStartTeamsCallOptions
	[BaseType (typeof(ACSStartTeamsCallOptions))]
	[DisableDefaultCtor]
	interface ACSStartTeamsGroupCallOptions
	{
		// -(instancetype _Nonnull)init:(NSString * _Nonnull)threadId __attribute__((swift_name("init(threadId:)")));
		[Export ("init:")]
		NativeHandle Constructor (string threadId);

		// @property (readonly, retain) NSString * _Nonnull threadId;
		[Export ("threadId", ArgumentSemantic.Retain)]
		string ThreadId { get; }
	}

	// @interface ACSTeamsCallsUpdatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSTeamsCallsUpdatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSTeamsCall *> * _Nonnull addedCalls;
		[Export ("addedCalls", ArgumentSemantic.Copy)]
		ACSTeamsCall[] AddedCalls { get; }

		// @property (readonly, copy) NSArray<ACSTeamsCall *> * _Nonnull removedCalls;
		[Export ("removedCalls", ArgumentSemantic.Copy)]
		ACSTeamsCall[] RemovedCalls { get; }
	}

	// @interface ACSTeamsIncomingCall : ACSIncomingCallBase
	[BaseType (typeof(ACSIncomingCallBase))]
	[DisableDefaultCtor]
	interface ACSTeamsIncomingCall
	{
		// @property (readonly, retain) ACSTeamsCallInfo * _Nonnull callInfo;
		[Export ("callInfo", ArgumentSemantic.Retain)]
		ACSTeamsCallInfo CallInfo { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSTeamsIncomingCallDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSTeamsIncomingCallDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSTeamsIncomingCallEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSTeamsIncomingCallEvents Events { get; }

		// -(void)accept:(ACSAcceptCallOptions * _Nonnull)options withCompletionHandler:(void (^ _Nonnull)(ACSTeamsCall * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("accept(options:completionHandler:)")));
		[Export ("accept:withCompletionHandler:")]
		void Accept (ACSAcceptCallOptions options, Action<ACSTeamsCall, NSError> completionHandler);
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
		[Export ("cameras", ArgumentSemantic.Copy)]
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

		// @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * _Nonnull addedVideoDevices;
		[Export ("addedVideoDevices", ArgumentSemantic.Copy)]
		ACSVideoDeviceInfo[] AddedVideoDevices { get; }

		// @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * _Nonnull removedVideoDevices;
		[Export ("removedVideoDevices", ArgumentSemantic.Copy)]
		ACSVideoDeviceInfo[] RemovedVideoDevices { get; }
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

	// @interface ACSRecordingUpdatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRecordingUpdatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSRecordingInfo * _Nonnull updatedRecording;
		[Export ("updatedRecording", ArgumentSemantic.Retain)]
		ACSRecordingInfo UpdatedRecording { get; }
	}

	// @interface ACSRecordingInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRecordingInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) ACSRecordingState state;
		[Export ("state")]
		ACSRecordingState State { get; }
	}

	// @interface ACSCallLobby : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallLobby
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSRemoteParticipant *> * _Nonnull participants;
		[Export ("participants", ArgumentSemantic.Copy)]
		ACSRemoteParticipant[] Participants { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSCallLobbyDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSCallLobbyDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSCallLobbyEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSCallLobbyEvents Events { get; }

		// -(void)admitAllWithCompletionHandler:(void (^ _Nonnull)(ACSAdmitAllParticipantsResult * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("admitAll(completionHandler:)")));
		[Export ("admitAllWithCompletionHandler:")]
		void AdmitAllWithCompletionHandler (Action<ACSAdmitAllParticipantsResult, NSError> completionHandler);

		// -(void)admit:(NSArray<id<CommunicationIdentifier>> * _Nonnull)identifiers withCompletionHandler:(void (^ _Nonnull)(ACSAdmitParticipantsResult * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("admit(identifiers:completionHandler:)")));
		[Export ("admit:withCompletionHandler:")]
		void Admit (CommunicationIdentifier[] identifiers, Action<ACSAdmitParticipantsResult, NSError> completionHandler);

		// -(void)reject:(id<CommunicationIdentifier> _Nonnull)identifier withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("reject(identifier:completionHandler:)")));
		[Export ("reject:withCompletionHandler:")]
		void Reject (CommunicationIdentifier identifier, Action<NSError> completionHandler);
	}

	// @interface ACSAdmitParticipantsResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSAdmitParticipantsResult
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) int successCount;
		[Export ("successCount")]
		int SuccessCount { get; }

		// @property (readonly, copy) NSArray<ACSRemoteParticipant *> * _Nonnull failedParticipants;
		[Export ("failedParticipants", ArgumentSemantic.Copy)]
		ACSRemoteParticipant[] FailedParticipants { get; }
	}

	// @interface ACSAdmitAllParticipantsResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSAdmitAllParticipantsResult
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) int successCount;
		[Export ("successCount")]
		int SuccessCount { get; }

		// @property (readonly) int failureCount;
		[Export ("failureCount")]
		int FailureCount { get; }
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

	// @interface ACSRecordingCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSRecordingCallFeature
	{
		// @property (readonly) BOOL isRecordingActive;
		[Export ("isRecordingActive")]
		bool IsRecordingActive { get; }

		// @property (readonly, copy) NSArray<ACSRecordingInfo *> * _Nonnull recordings;
		[Export ("recordings", ArgumentSemantic.Copy)]
		ACSRecordingInfo[] Recordings { get; }

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

	// @interface ACSStartCaptionsOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSStartCaptionsOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) NSString * _Nonnull spokenLanguage;
		[Export ("spokenLanguage", ArgumentSemantic.Retain)]
		string SpokenLanguage { get; set; }
	}

	// @interface ACSTeamsCaptionsReceivedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSTeamsCaptionsReceivedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSCallerInfo * _Nonnull speaker;
		[Export ("speaker", ArgumentSemantic.Retain)]
		ACSCallerInfo Speaker { get; }

		// @property (readonly, retain) NSString * _Nonnull spokenText;
		[Export ("spokenText", ArgumentSemantic.Retain)]
		string SpokenText { get; }

		// @property (readonly, retain) NSString * _Nonnull spokenLanguage;
		[Export ("spokenLanguage", ArgumentSemantic.Retain)]
		string SpokenLanguage { get; }

		// @property (readonly, retain) NSString * _Nonnull captionText;
		[Export ("captionText", ArgumentSemantic.Retain)]
		string CaptionText { get; }

		// @property (readonly, retain) NSString * _Nonnull captionLanguage;
		[Export ("captionLanguage", ArgumentSemantic.Retain)]
		string CaptionLanguage { get; }

		// @property (readonly) ACSCaptionsResultType resultType;
		[Export ("resultType")]
		ACSCaptionsResultType ResultType { get; }

		// @property (readonly, retain) NSDate * _Nonnull timestamp;
		[Export ("timestamp", ArgumentSemantic.Retain)]
		NSDate Timestamp { get; }
	}

	// @interface ACSCommunicationCaptionsReceivedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCommunicationCaptionsReceivedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSCallerInfo * _Nonnull speaker;
		[Export ("speaker", ArgumentSemantic.Retain)]
		ACSCallerInfo Speaker { get; }

		// @property (readonly) ACSCaptionsResultType resultType;
		[Export ("resultType")]
		ACSCaptionsResultType ResultType { get; }

		// @property (readonly, retain) NSDate * _Nonnull timestamp;
		[Export ("timestamp", ArgumentSemantic.Retain)]
		NSDate Timestamp { get; }

		// @property (readonly, retain) NSString * _Nonnull spokenText;
		[Export ("spokenText", ArgumentSemantic.Retain)]
		string SpokenText { get; }

		// @property (readonly, retain) NSString * _Nonnull spokenLanguage;
		[Export ("spokenLanguage", ArgumentSemantic.Retain)]
		string SpokenLanguage { get; }
	}

	// @interface ACSCallCaptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallCaptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<NSString *> * _Nonnull supportedSpokenLanguages;
		[Export ("supportedSpokenLanguages", ArgumentSemantic.Copy)]
		string[] SupportedSpokenLanguages { get; }

		// @property (readonly) BOOL isEnabled;
		[Export ("isEnabled")]
		bool IsEnabled { get; }

		// @property (readonly) ACSCaptionsType type;
		[Export ("type")]
		ACSCaptionsType Type { get; }

		// @property (readonly, retain) NSString * _Nonnull activeSpokenLanguage;
		[Export ("activeSpokenLanguage", ArgumentSemantic.Retain)]
		string ActiveSpokenLanguage { get; }

		// -(void)startCaptions:(ACSStartCaptionsOptions * _Nullable)options withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("startCaptions(options:completionHandler:)")));
		[Export ("startCaptions:withCompletionHandler:")]
		void StartCaptions ([NullAllowed] ACSStartCaptionsOptions options, Action<NSError> completionHandler);

		// -(void)stopCaptionsWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("stopCaptions(completionHandler:)")));
		[Export ("stopCaptionsWithCompletionHandler:")]
		void StopCaptionsWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)setSpokenLanguage:(NSString * _Nonnull)language withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("set(spokenLanguage:completionHandler:)")));
		[Export ("setSpokenLanguage:withCompletionHandler:")]
		void SetSpokenLanguage (string language, Action<NSError> completionHandler);
	}

	// @interface ACSCommunicationCaptions : ACSCallCaptions
	[BaseType (typeof(ACSCallCaptions))]
	[DisableDefaultCtor]
	interface ACSCommunicationCaptions
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSCommunicationCaptionsDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSCommunicationCaptionsDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSCommunicationCaptionsEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSCommunicationCaptionsEvents Events { get; }
	}

	// @interface ACSTeamsCaptions : ACSCallCaptions
	[BaseType (typeof(ACSCallCaptions))]
	[DisableDefaultCtor]
	interface ACSTeamsCaptions
	{
		// @property (readonly, retain) NSString * _Nonnull activeCaptionLanguage;
		[Export ("activeCaptionLanguage", ArgumentSemantic.Retain)]
		string ActiveCaptionLanguage { get; }

		// @property (readonly, copy) NSArray<NSString *> * _Nonnull supportedCaptionLanguages;
		[Export ("supportedCaptionLanguages", ArgumentSemantic.Copy)]
		string[] SupportedCaptionLanguages { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSTeamsCaptionsDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSTeamsCaptionsDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSTeamsCaptionsEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSTeamsCaptionsEvents Events { get; }

		// -(void)setCaptionLanguage:(NSString * _Nonnull)language withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("set(captionLanguage:completionHandler:)")));
		[Export ("setCaptionLanguage:withCompletionHandler:")]
		void SetCaptionLanguage (string language, Action<NSError> completionHandler);
	}

	// @interface ACSCaptionsCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSCaptionsCallFeature
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSCaptionsCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSCaptionsCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSCaptionsCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSCaptionsCallFeatureEvents Events { get; }

		// -(void)getCaptionsWithCompletionHandler:(void (^ _Nonnull)(ACSCallCaptions * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("getCaptions(completionHandler:)")));
		[Export ("getCaptionsWithCompletionHandler:")]
		void GetCaptionsWithCompletionHandler (Action<ACSCallCaptions, NSError> completionHandler);
	}

	// @interface ACSDominantSpeakersCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSDominantSpeakersCallFeature
	{
		// @property (readonly, retain) ACSDominantSpeakersInfo * _Nonnull dominantSpeakersInfo;
		[Export ("dominantSpeakersInfo", ArgumentSemantic.Retain)]
		ACSDominantSpeakersInfo DominantSpeakersInfo { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSDominantSpeakersCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSDominantSpeakersCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSDominantSpeakersCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSDominantSpeakersCallFeatureEvents Events { get; }
	}

	// @interface ACSDominantSpeakersInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSDominantSpeakersInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NS_SWIFT_NAME(lastUpdated) NSDate * lastUpdatedAt __attribute__((swift_name("lastUpdated")));
		[Export ("lastUpdatedAt", ArgumentSemantic.Retain)]
		NSDate LastUpdatedAt { get; }

		// @property (readonly, nonatomic) NSArray<id<CommunicationIdentifier>> * _Nonnull speakers;
		[Export ("speakers")]
		CommunicationIdentifier[] Speakers { get; }
	}

	// @interface ACSRaiseHandCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSRaiseHandCallFeature
	{
		// @property (readonly, copy) NSArray<ACSRaisedHand *> * _Nonnull raisedHands;
		[Export ("raisedHands", ArgumentSemantic.Copy)]
		ACSRaisedHand[] RaisedHands { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRaiseHandCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRaiseHandCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRaiseHandCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRaiseHandCallFeatureEvents Events { get; }

		// -(void)raiseHandWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("raiseHand(completionHandler:)")));
		[Export ("raiseHandWithCompletionHandler:")]
		void RaiseHandWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)lowerHandWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("lowerHand(completionHandler:)")));
		[Export ("lowerHandWithCompletionHandler:")]
		void LowerHandWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)lowerAllHandsWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("lowerAllHands(completionHandler:)")));
		[Export ("lowerAllHandsWithCompletionHandler:")]
		void LowerAllHandsWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)lowerHands:(NSArray<id<CommunicationIdentifier>> * _Nonnull)participants withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("lowerHands(participants:completionHandler:)")));
		[Export ("lowerHands:withCompletionHandler:")]
		void LowerHands (CommunicationIdentifier[] participants, Action<NSError> completionHandler);
	}

	// @interface ACSRaisedHand : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRaisedHand
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) int order;
		[Export ("order")]
		int Order { get; }

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export ("identifier")]
		CommunicationIdentifier Identifier { get; }
	}

	// @interface ACSRaisedHandChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRaisedHandChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export ("identifier")]
		CommunicationIdentifier Identifier { get; }
	}

	// @interface ACSLoweredHandChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSLoweredHandChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export ("identifier")]
		CommunicationIdentifier Identifier { get; }
	}

	// @interface ACSSpotlightCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSSpotlightCallFeature
	{
		// @property (readonly) int maxSpotlightedParticipants;
		[Export ("maxSpotlightedParticipants")]
		int MaxSpotlightedParticipants { get; }

		// @property (readonly, copy) NSArray<ACSSpotlightedParticipant *> * _Nonnull spotlightedParticipants;
		[Export ("spotlightedParticipants", ArgumentSemantic.Copy)]
		ACSSpotlightedParticipant[] SpotlightedParticipants { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSSpotlightCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSSpotlightCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSSpotlightCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSSpotlightCallFeatureEvents Events { get; }

		// -(void)cancelAllSpotlightsWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("cancelAllSpotlights(completionHandler:)")));
		[Export ("cancelAllSpotlightsWithCompletionHandler:")]
		void CancelAllSpotlightsWithCompletionHandler (Action<NSError> completionHandler);

		// -(void)spotlight:(NSArray<id<CommunicationIdentifier>> * _Nonnull)identifiers withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("spotlight(identifiers:completionHandler:)")));
		[Export ("spotlight:withCompletionHandler:")]
		void Spotlight (CommunicationIdentifier[] identifiers, Action<NSError> completionHandler);

		// -(void)cancelSpotlights:(NSArray<id<CommunicationIdentifier>> * _Nonnull)identifiers withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("cancelSpotlights(identifiers:completionHandler:)")));
		[Export ("cancelSpotlights:withCompletionHandler:")]
		void CancelSpotlights (CommunicationIdentifier[] identifiers, Action<NSError> completionHandler);
	}

	// @interface ACSSpotlightedParticipant : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSSpotlightedParticipant
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export ("identifier")]
		CommunicationIdentifier Identifier { get; }
	}

	// @interface ACSSpotlightChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSSpotlightChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSSpotlightedParticipant *> * _Nonnull added;
		[Export ("added", ArgumentSemantic.Copy)]
		ACSSpotlightedParticipant[] Added { get; }

		// @property (readonly, copy) NSArray<ACSSpotlightedParticipant *> * _Nonnull removed;
		[Export ("removed", ArgumentSemantic.Copy)]
		ACSSpotlightedParticipant[] Removed { get; }
	}

	// @interface ACSCreateViewOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCreateViewOptions
	{
		// -(instancetype _Nonnull)init:(ACSScalingMode)scalingMode __attribute__((swift_name("init(scalingMode:)")));
		[Export ("init:")]
		IntPtr Constructor(ACSScalingMode scalingMode);

		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property ACSScalingMode scalingMode;
		[Export ("scalingMode", ArgumentSemantic.Assign)]
		ACSScalingMode ScalingMode { get; set; }
	}

	// @interface ACSVideoStreamFormat : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSVideoStreamFormat
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property int width;
		[Export ("width")]
		int Width { get; set; }

		// @property int height;
		[Export ("height")]
		int Height { get; set; }

		// @property ACSVideoStreamResolution resolution;
		[Export ("resolution", ArgumentSemantic.Assign)]
		ACSVideoStreamResolution Resolution { get; set; }

		// @property ACSVideoStreamPixelFormat pixelFormat;
		[Export ("pixelFormat", ArgumentSemantic.Assign)]
		ACSVideoStreamPixelFormat PixelFormat { get; set; }

		// @property float framesPerSecond;
		[Export ("framesPerSecond")]
		float FramesPerSecond { get; set; }

		// @property int stride1;
		[Export ("stride1")]
		int Stride1 { get; set; }

		// @property int stride2;
		[Export ("stride2")]
		int Stride2 { get; set; }

		// @property int stride3;
		[Export ("stride3")]
		int Stride3 { get; set; }
	}

	// @interface ACSVideoStreamFormatChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoStreamFormatChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSVideoStreamFormat * _Nonnull format;
		[Export ("format", ArgumentSemantic.Retain)]
		ACSVideoStreamFormat Format { get; }
	}

	// @interface ACSRawVideoFrame : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRawVideoFrame
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) ACSRawVideoFrameType type;
		[Export ("type")]
		ACSRawVideoFrameType Type { get; }

		// @property (retain) ACSVideoStreamFormat * _Nonnull streamFormat;
		[Export ("streamFormat", ArgumentSemantic.Retain)]
		ACSVideoStreamFormat StreamFormat { get; set; }

		// @property int64_t timestampInTicks;
		[Export ("timestampInTicks")]
		long TimestampInTicks { get; set; }

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();
	}

	// @interface ACSRawVideoFrameBuffer : ACSRawVideoFrame
	[BaseType (typeof(ACSRawVideoFrame))]
	interface ACSRawVideoFrameBuffer
	{
		// @property CVPixelBufferRef _Nonnull buffer;
		[Export ("buffer", ArgumentSemantic.Assign)]
		CVPixelBuffer Buffer { get; set; }
	}

	// @interface ACSRawVideoFrameReceivedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRawVideoFrameReceivedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSRawVideoFrame * _Nonnull frame;
		[Export ("frame", ArgumentSemantic.Retain)]
		ACSRawVideoFrame Frame { get; }

		// @property (readonly) int videoStreamId;
		[Export ("videoStreamId")]
		int VideoStreamId { get; }
	}

	// @interface ACSRawOutgoingVideoStreamOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRawOutgoingVideoStreamOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (copy) NSArray<ACSVideoStreamFormat *> * _Nonnull formats;
		[Export ("formats", ArgumentSemantic.Copy)]
		ACSVideoStreamFormat[] Formats { get; set; }
	}

	// @interface ACSRawOutgoingVideoStream : ACSOutgoingVideoStream
	[BaseType (typeof(ACSOutgoingVideoStream))]
	[DisableDefaultCtor]
	interface ACSRawOutgoingVideoStream
	{
		// @property (readonly, retain) ACSVideoStreamFormat * _Nonnull format;
		[Export ("format", ArgumentSemantic.Retain)]
		ACSVideoStreamFormat Format { get; }

		// @property (readonly) int64_t timestampInTicks;
		[Export ("timestampInTicks")]
		long TimestampInTicks { get; }

		// -(void)sendRawVideoFrame:(ACSRawVideoFrame * _Nonnull)rawVideoFrame withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("send(frame:completionHandler:)")));
		[Export ("sendRawVideoFrame:withCompletionHandler:")]
		void SendRawVideoFrame (ACSRawVideoFrame rawVideoFrame, Action<NSError> completionHandler);
	}

	// @interface ACSScreenShareOutgoingVideoStream : ACSRawOutgoingVideoStream
	[BaseType (typeof(ACSRawOutgoingVideoStream))]
	[DisableDefaultCtor]
	interface ACSScreenShareOutgoingVideoStream
	{
		// -(instancetype _Nonnull)init:(ACSRawOutgoingVideoStreamOptions * _Nonnull)videoStreamOptions __attribute__((swift_name("init(videoStreamOptions:)")));
		[Export ("init:")]
		IntPtr Constructor(ACSRawOutgoingVideoStreamOptions videoStreamOptions);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSScreenShareOutgoingVideoStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSScreenShareOutgoingVideoStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSScreenShareOutgoingVideoStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSScreenShareOutgoingVideoStreamEvents Events { get; }
	}

	// @interface ACSVirtualOutgoingVideoStream : ACSRawOutgoingVideoStream
	[BaseType (typeof(ACSRawOutgoingVideoStream))]
	[DisableDefaultCtor]
	interface ACSVirtualOutgoingVideoStream
	{
		// -(instancetype _Nonnull)init:(ACSRawOutgoingVideoStreamOptions * _Nonnull)videoStreamOptions __attribute__((swift_name("init(videoStreamOptions:)")));
		[Export ("init:")]
		IntPtr Constructor(ACSRawOutgoingVideoStreamOptions videoStreamOptions);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSVirtualOutgoingVideoStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSVirtualOutgoingVideoStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSVirtualOutgoingVideoStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSVirtualOutgoingVideoStreamEvents Events { get; }
	}

	// @interface ACSRawIncomingVideoStream : ACSIncomingVideoStream
	[BaseType (typeof(ACSIncomingVideoStream))]
	[DisableDefaultCtor]
	interface ACSRawIncomingVideoStream
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRawIncomingVideoStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRawIncomingVideoStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRawIncomingVideoStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRawIncomingVideoStreamEvents Events { get; }

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)stop;
		[Export ("stop")]
		void Stop ();
	}

	// @interface ACSRoomCallLocator : ACSJoinMeetingLocator
	[BaseType (typeof(ACSJoinMeetingLocator))]
	[DisableDefaultCtor]
	interface ACSRoomCallLocator
	{
		// -(instancetype _Nonnull)init:(NSString * _Nonnull)roomId __attribute__((swift_name("init(roomId:)")));
		[Export ("init:")]
		NativeHandle Constructor (string roomId);

		// @property (readonly, retain) NSString * _Nonnull roomId;
		[Export ("roomId", ArgumentSemantic.Retain)]
		string RoomId { get; }
	}

	// @interface ACSIncomingMixedAudioEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSIncomingMixedAudioEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSRawIncomingAudioStreamProperties * _Nonnull streamProperties;
		[Export ("streamProperties", ArgumentSemantic.Retain)]
		ACSRawIncomingAudioStreamProperties StreamProperties { get; }

		// @property (readonly, retain) ACSRawAudioBuffer * _Nonnull audioBuffer;
		[Export ("audioBuffer", ArgumentSemantic.Retain)]
		ACSRawAudioBuffer AudioBuffer { get; }
	}

	// @interface ACSRawAudioStreamProperties : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRawAudioStreamProperties
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property ACSAudioStreamSampleRate sampleRate;
		[Export ("sampleRate", ArgumentSemantic.Assign)]
		ACSAudioStreamSampleRate SampleRate { get; set; }

		// @property ACSAudioStreamChannelMode channelMode;
		[Export ("channelMode", ArgumentSemantic.Assign)]
		ACSAudioStreamChannelMode ChannelMode { get; set; }

		// @property ACSAudioStreamFormat format;
		[Export ("format", ArgumentSemantic.Assign)]
		ACSAudioStreamFormat Format { get; set; }
	}

	// @interface ACSRawIncomingAudioStreamProperties : ACSRawAudioStreamProperties
	[BaseType (typeof(ACSRawAudioStreamProperties))]
	interface ACSRawIncomingAudioStreamProperties
	{
	}

	// @interface ACSRawAudioBuffer : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRawAudioBuffer
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property int64_t timestampInTicks;
		[Export ("timestampInTicks")]
		long TimestampInTicks { get; set; }

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();

		// @property (retain) AVAudioBuffer * _Nullable buffer;
		[NullAllowed, Export ("buffer", ArgumentSemantic.Retain)]
		AVAudioBuffer Buffer { get; set; }
	}

	// @interface ACSIncomingUnmixedAudioEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSIncomingUnmixedAudioEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSRawAudioBuffer *> * _Nonnull audioBuffer;
		[Export ("audioBuffer", ArgumentSemantic.Copy)]
		ACSRawAudioBuffer[] AudioBuffer { get; }

		// @property (readonly, copy) NSArray<NSString *> * _Nonnull remoteParticipantIds;
		[Export ("remoteParticipantIds", ArgumentSemantic.Copy)]
		string[] RemoteParticipantIds { get; }

		// @property (readonly, retain) ACSRawIncomingAudioStreamProperties * _Nonnull streamProperties;
		[Export ("streamProperties", ArgumentSemantic.Retain)]
		ACSRawIncomingAudioStreamProperties StreamProperties { get; }
	}

	// @interface ACSAudioStreamStateChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSAudioStreamStateChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSCallAudioStream * _Nonnull stream;
		[Export ("stream", ArgumentSemantic.Retain)]
		ACSCallAudioStream Stream { get; }

		// @property (readonly, retain) NSString * _Nonnull message;
		[Export ("message", ArgumentSemantic.Retain)]
		string Message { get; }
	}

	// @interface ACSRawOutgoingAudioStreamProperties : ACSRawAudioStreamProperties
	[BaseType (typeof(ACSRawAudioStreamProperties))]
	interface ACSRawOutgoingAudioStreamProperties
	{
		// @property ACSAudioStreamBufferDuration bufferDuration;
		[Export ("bufferDuration", ArgumentSemantic.Assign)]
		ACSAudioStreamBufferDuration BufferDuration { get; set; }
	}

	// @interface ACSRawAudioStreamOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRawAudioStreamOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();
	}

	// @interface ACSRawOutgoingAudioStreamOptions : ACSRawAudioStreamOptions
	[BaseType (typeof(ACSRawAudioStreamOptions))]
	interface ACSRawOutgoingAudioStreamOptions
	{
		// @property (retain) ACSRawOutgoingAudioStreamProperties * _Nonnull properties;
		[Export ("properties", ArgumentSemantic.Retain)]
		ACSRawOutgoingAudioStreamProperties Properties { get; set; }
	}

	// @interface ACSRawIncomingAudioStreamOptions : ACSRawAudioStreamOptions
	[BaseType (typeof(ACSRawAudioStreamOptions))]
	interface ACSRawIncomingAudioStreamOptions
	{
		// @property (retain) ACSRawIncomingAudioStreamProperties * _Nonnull properties;
		[Export ("properties", ArgumentSemantic.Retain)]
		ACSRawIncomingAudioStreamProperties Properties { get; set; }

		// @property BOOL receiveUnmixedAudio;
		[Export ("receiveUnmixedAudio")]
		bool ReceiveUnmixedAudio { get; set; }
	}

	// @interface ACSLocalOutgoingAudioStream : ACSOutgoingAudioStream
	[BaseType (typeof(ACSOutgoingAudioStream))]
	interface ACSLocalOutgoingAudioStream
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSLocalOutgoingAudioStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSLocalOutgoingAudioStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSLocalOutgoingAudioStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSLocalOutgoingAudioStreamEvents Events { get; }
	}

	// @interface ACSRemoteIncomingAudioStream : ACSIncomingAudioStream
	[BaseType (typeof(ACSIncomingAudioStream))]
	interface ACSRemoteIncomingAudioStream
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRemoteIncomingAudioStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRemoteIncomingAudioStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRemoteIncomingAudioStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRemoteIncomingAudioStreamEvents Events { get; }
	}

	// @interface ACSRawIncomingAudioStream : ACSIncomingAudioStream
	[BaseType (typeof(ACSIncomingAudioStream))]
	[DisableDefaultCtor]
	interface ACSRawIncomingAudioStream
	{
		// -(instancetype _Nonnull)init:(ACSRawIncomingAudioStreamOptions * _Nonnull)options __attribute__((swift_name("init(options:)")));
		[Export ("init:")]
		IntPtr Constructor(ACSRawIncomingAudioStreamOptions options);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRawIncomingAudioStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRawIncomingAudioStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRawIncomingAudioStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRawIncomingAudioStreamEvents Events { get; }
	}

	// @interface ACSRawOutgoingAudioStream : ACSOutgoingAudioStream
	[BaseType (typeof(ACSOutgoingAudioStream))]
	[DisableDefaultCtor]
	interface ACSRawOutgoingAudioStream
	{
		// -(instancetype _Nonnull)init:(ACSRawOutgoingAudioStreamOptions * _Nonnull)options __attribute__((swift_name("init(options:)")));
		[Export ("init:")]
		IntPtr Constructor(ACSRawOutgoingAudioStreamOptions options);

		// @property (readonly) int64_t expectedBufferSizeInBytes;
		[Export ("expectedBufferSizeInBytes")]
		long ExpectedBufferSizeInBytes { get; }

		// @property (readonly, retain) ACSRawOutgoingAudioStreamProperties * _Nonnull properties;
		[Export ("properties", ArgumentSemantic.Retain)]
		ACSRawOutgoingAudioStreamProperties Properties { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRawOutgoingAudioStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRawOutgoingAudioStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRawOutgoingAudioStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRawOutgoingAudioStreamEvents Events { get; }

		// -(void)sendRawAudioBuffer:(ACSRawAudioBuffer * _Nonnull)rawAudioBuffer withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("send(buffer:completionHandler:)")));
		[Export ("sendRawAudioBuffer:withCompletionHandler:")]
		void SendRawAudioBuffer (ACSRawAudioBuffer rawAudioBuffer, Action<NSError> completionHandler);
	}

	// @interface ACSVideoEffect : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoEffect
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }
	}

	// @interface ACSBackgroundBlurEffect : ACSVideoEffect
	[BaseType (typeof(ACSVideoEffect))]
	interface ACSBackgroundBlurEffect
	{
	}

	// @interface ACSLocalVideoEffectsFeature : ACSLocalVideoStreamFeature
	[BaseType (typeof(ACSLocalVideoStreamFeature))]
	[DisableDefaultCtor]
	interface ACSLocalVideoEffectsFeature
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSLocalVideoEffectsFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSLocalVideoEffectsFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSLocalVideoEffectsFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSLocalVideoEffectsFeatureEvents Events { get; }

		// -(BOOL)isEffectSupported:(ACSVideoEffect * _Nonnull)effect __attribute__((swift_name("isSupported(effect:)")));
		[Export ("isEffectSupported:")]
		bool IsEffectSupported (ACSVideoEffect effect);

		// -(void)enableEffect:(ACSVideoEffect * _Nonnull)effect __attribute__((swift_name("enable(effect:)")));
		[Export ("enableEffect:")]
		void EnableEffect (ACSVideoEffect effect);

		// -(void)disableEffect:(ACSVideoEffect * _Nonnull)effect __attribute__((swift_name("disable(effect:)")));
		[Export ("disableEffect:")]
		void DisableEffect (ACSVideoEffect effect);
	}

	// @interface ACSVideoEffectEnabledEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoEffectEnabledEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull videoEffectName;
		[Export ("videoEffectName", ArgumentSemantic.Retain)]
		string VideoEffectName { get; }
	}

	// @interface ACSVideoEffectDisabledEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoEffectDisabledEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull videoEffectName;
		[Export ("videoEffectName", ArgumentSemantic.Retain)]
		string VideoEffectName { get; }
	}

	// @interface ACSVideoEffectErrorEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoEffectErrorEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull videoEffectName;
		[Export ("videoEffectName", ArgumentSemantic.Retain)]
		string VideoEffectName { get; }

		// @property (readonly, retain) NSString * _Nonnull code;
		[Export ("code", ArgumentSemantic.Retain)]
		string Code { get; }

		// @property (readonly, retain) NSString * _Nonnull message;
		[Export ("message", ArgumentSemantic.Retain)]
		string Message { get; }
	}

	// @interface ACSDataChannelReceiverCreatedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSDataChannelReceiverCreatedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSDataChannelReceiver * _Nonnull receiver;
		[Export ("receiver", ArgumentSemantic.Retain)]
		ACSDataChannelReceiver Receiver { get; }
	}

	// @interface ACSDataChannelReceiver : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSDataChannelReceiver
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) int channelId;
		[Export ("channelId")]
		int ChannelId { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSDataChannelReceiverDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSDataChannelReceiverDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSDataChannelReceiverEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSDataChannelReceiverEvents Events { get; }

		// -(ACSDataChannelMessage * _Nonnull)readMessage;
		[Export ("readMessage")]
		//[Verify (MethodToProperty)]
		ACSDataChannelMessage ReadMessage { get; }

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull senderIdentifier;
		[Export ("senderIdentifier")]
		CommunicationIdentifier SenderIdentifier { get; }
	}

	// @interface ACSDataChannelMessage : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSDataChannelMessage
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) unsigned int sequenceNumber;
		[Export ("sequenceNumber")]
		uint SequenceNumber { get; }

		// @property (readonly, copy) NSData * _Nonnull data;
		[Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; }

		// -(void)dispose;
		[Export ("dispose")]
		void Dispose ();
	}

	// @interface ACSDataChannelReceiverMessageReceivedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSDataChannelReceiverMessageReceivedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSDataChannelReceiver * _Nonnull receiver;
		[Export ("receiver", ArgumentSemantic.Retain)]
		ACSDataChannelReceiver Receiver { get; }
	}

	// @interface ACSDataChannelReceiverClosedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSDataChannelReceiverClosedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSDataChannelReceiver * _Nonnull receiver;
		[Export ("receiver", ArgumentSemantic.Retain)]
		ACSDataChannelReceiver Receiver { get; }
	}

	// @interface ACSDataChannelSenderCreateOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSDataChannelSenderCreateOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property int channelId;
		[Export ("channelId")]
		int ChannelId { get; set; }

		// @property int bitrateInKbps;
		[Export ("bitrateInKbps")]
		int BitrateInKbps { get; set; }

		// @property ACSDataChannelPriority priority;
		[Export ("priority", ArgumentSemantic.Assign)]
		ACSDataChannelPriority Priority { get; set; }

		// @property ACSDataChannelReliability reliability;
		[Export ("reliability", ArgumentSemantic.Assign)]
		ACSDataChannelReliability Reliability { get; set; }

		// @property (readonly, nonatomic) NSArray<id<CommunicationIdentifier>> * _Nonnull participants;
		[Export ("participants")]
		CommunicationIdentifier[] Participants { get; }
	}

	// @interface ACSDataChannelSender : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSDataChannelSender
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) int channelId;
		[Export ("channelId")]
		int ChannelId { get; }

		// @property (readonly) int maxMessageSize;
		[Export ("maxMessageSize")]
		int MaxMessageSize { get; }

		// -(void)sendMessage:(NSData * _Nonnull)data withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("sendMessage(data:completionHandler:)")));
		[Export ("sendMessage:withCompletionHandler:")]
		void SendMessage (NSData data, Action<NSError> completionHandler);

		// -(void)close;
		[Export ("close")]
		void Close ();

		// -(void)setParticipants:(NSArray<id<CommunicationIdentifier>> * _Nonnull)participants;
		[Export ("setParticipants:")]
		void SetParticipants (CommunicationIdentifier[] participants);
	}

	// @interface ACSDataChannelCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSDataChannelCallFeature
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSDataChannelCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSDataChannelCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSDataChannelCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSDataChannelCallFeatureEvents Events { get; }

		// -(ACSDataChannelSender * _Nonnull)createDataChannelSender:(ACSDataChannelSenderCreateOptions * _Nonnull)options __attribute__((swift_name("createDataChannelSender(options:)")));
		[Export ("createDataChannelSender:")]
		ACSDataChannelSender CreateDataChannelSender (ACSDataChannelSenderCreateOptions options);
	}

	// @interface ACSLocalUserDiagnosticsCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSLocalUserDiagnosticsCallFeature
	{
		// @property (readonly, retain) ACSNetworkDiagnostics * _Nonnull networkDiagnostics;
		[Export ("networkDiagnostics", ArgumentSemantic.Retain)]
		ACSNetworkDiagnostics NetworkDiagnostics { get; }

		// @property (readonly, retain) ACSMediaDiagnostics * _Nonnull mediaDiagnostics;
		[Export ("mediaDiagnostics", ArgumentSemantic.Retain)]
		ACSMediaDiagnostics MediaDiagnostics { get; }
	}

	// @interface ACSNetworkDiagnostics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSNetworkDiagnostics
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSNetworkDiagnosticValues * _Nonnull latest;
		[Export ("latest", ArgumentSemantic.Retain)]
		ACSNetworkDiagnosticValues Latest { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSNetworkDiagnosticsDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSNetworkDiagnosticsDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSNetworkDiagnosticsEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSNetworkDiagnosticsEvents Events { get; }
	}

	// @interface ACSNetworkDiagnosticValues : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSNetworkDiagnosticValues
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NS_SWIFT_NAME(lastUpdated) NSDate * lastUpdatedAt __attribute__((swift_name("lastUpdated")));
		[Export ("lastUpdatedAt", ArgumentSemantic.Retain)]
		NSDate LastUpdatedAt { get; }

		// -(BOOL)valueForNoNetwork:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForNoNetwork:")]
		bool ValueForNoNetwork ([NullAllowed] out NSError error);

		// -(BOOL)valueForNetworkRelaysNotReachable:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForNetworkRelaysNotReachable:")]
		bool ValueForNetworkRelaysNotReachable ([NullAllowed] out NSError error);

		// -(ACSDiagnosticQuality)valueForNetworkReconnect __attribute__((swift_private));
		[Export ("valueForNetworkReconnect")]
		//[Verify(MethodToProperty)]
		ACSDiagnosticQuality ValueForNetworkReconnect { get; }

		// -(ACSDiagnosticQuality)valueForNetworkReceiveQuality __attribute__((swift_private));
		[Export ("valueForNetworkReceiveQuality")]
		//[Verify(MethodToProperty)]
		ACSDiagnosticQuality ValueForNetworkReceiveQuality { get; }

		// -(ACSDiagnosticQuality)valueForNetworkSendQuality __attribute__((swift_private));
		[Export ("valueForNetworkSendQuality")]
		//[Verify(MethodToProperty)]
		ACSDiagnosticQuality ValueForNetworkSendQuality { get; }
	}

	// @interface ACSDiagnosticFlagChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSDiagnosticFlagChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) BOOL value;
		[Export ("value")]
		bool Value { get; }

		// @property (readonly, retain) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }
	}

	// @interface ACSDiagnosticQualityChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSDiagnosticQualityChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) ACSDiagnosticQuality value;
		[Export ("value")]
		ACSDiagnosticQuality Value { get; }

		// @property (readonly, retain) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Retain)]
		string Name { get; }
	}

	// @interface ACSMediaDiagnostics : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSMediaDiagnostics
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSMediaDiagnosticValues * _Nonnull latest;
		[Export ("latest", ArgumentSemantic.Retain)]
		ACSMediaDiagnosticValues Latest { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSMediaDiagnosticsDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSMediaDiagnosticsDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSMediaDiagnosticsEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSMediaDiagnosticsEvents Events { get; }
	}

	// @interface ACSMediaDiagnosticValues : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSMediaDiagnosticValues
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NS_SWIFT_NAME(lastUpdated) NSDate * lastUpdatedAt __attribute__((swift_name("lastUpdated")));
		[Export ("lastUpdatedAt", ArgumentSemantic.Retain)]
		NSDate LastUpdatedAt { get; }

		// -(BOOL)valueForSpeakerNotFunctioning:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForSpeakerNotFunctioning:")]
		bool ValueForSpeakerNotFunctioning ([NullAllowed] out NSError error);

		// -(BOOL)valueForSpeakerNotFunctioningDeviceInUse:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForSpeakerNotFunctioningDeviceInUse:")]
		bool ValueForSpeakerNotFunctioningDeviceInUse ([NullAllowed] out NSError error);

		// -(BOOL)valueForSpeakerMuted:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForSpeakerMuted:")]
		bool ValueForSpeakerMuted ([NullAllowed] out NSError error);

		// -(BOOL)valueForSpeakerVolumeIsZero:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForSpeakerVolumeIsZero:")]
		bool ValueForSpeakerVolumeIsZero ([NullAllowed] out NSError error);

		// -(BOOL)valueForNoSpeakerDevicesEnumerated:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForNoSpeakerDevicesEnumerated:")]
		bool ValueForNoSpeakerDevicesEnumerated ([NullAllowed] out NSError error);

		// -(BOOL)valueForSpeakingWhileMicrophoneIsMuted:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForSpeakingWhileMicrophoneIsMuted:")]
		bool ValueForSpeakingWhileMicrophoneIsMuted ([NullAllowed] out NSError error);

		// -(BOOL)valueForNoMicrophoneDevicesEnumerated:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForNoMicrophoneDevicesEnumerated:")]
		bool ValueForNoMicrophoneDevicesEnumerated ([NullAllowed] out NSError error);

		// -(BOOL)valueForMicrophoneNotFunctioningDeviceInUse:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForMicrophoneNotFunctioningDeviceInUse:")]
		bool ValueForMicrophoneNotFunctioningDeviceInUse ([NullAllowed] out NSError error);

		// -(BOOL)valueForCameraFreeze:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForCameraFreeze:")]
		bool ValueForCameraFreeze ([NullAllowed] out NSError error);

		// -(BOOL)valueForCameraStartFailed:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForCameraStartFailed:")]
		bool ValueForCameraStartFailed ([NullAllowed] out NSError error);

		// -(BOOL)valueForCameraStartTimedOut:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForCameraStartTimedOut:")]
		bool ValueForCameraStartTimedOut ([NullAllowed] out NSError error);

		// -(BOOL)valueForMicrophoneNotFunctioning:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForMicrophoneNotFunctioning:")]
		bool ValueForMicrophoneNotFunctioning ([NullAllowed] out NSError error);

		// -(BOOL)valueForMicrophoneMutedUnexpectedly:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForMicrophoneMutedUnexpectedly:")]
		bool ValueForMicrophoneMutedUnexpectedly ([NullAllowed] out NSError error);

		// -(BOOL)valueForCameraPermissionDenied:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
		[Export ("valueForCameraPermissionDenied:")]
		bool ValueForCameraPermissionDenied ([NullAllowed] out NSError error);
	}

	// @interface ACSMediaStatsCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSMediaStatsCallFeature
	{
		// @property int sampleIntervalInSeconds;
		[Export ("sampleIntervalInSeconds")]
		int SampleIntervalInSeconds { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSMediaStatsCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSMediaStatsCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSMediaStatsCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSMediaStatsCallFeatureEvents Events { get; }
	}

	// @interface ACSMediaStatsReportEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSMediaStatsReportEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSMediaStatsReport * _Nonnull report;
		[Export ("report", ArgumentSemantic.Retain)]
		ACSMediaStatsReport Report { get; }
	}

	// @interface ACSMediaStatsReport : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSMediaStatsReport
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSOutgoingMediaStatsInfo * _Nonnull outgoingMediaStats;
		[Export ("outgoingMediaStats", ArgumentSemantic.Retain)]
		ACSOutgoingMediaStatsInfo OutgoingMediaStats { get; }

		// @property (readonly, retain) ACSIncomingMediaStatsInfo * _Nonnull incomingMediaStats;
		[Export ("incomingMediaStats", ArgumentSemantic.Retain)]
		ACSIncomingMediaStatsInfo IncomingMediaStats { get; }

		// @property (readonly, retain) NSDate * _Nonnull generatedAt;
		[Export ("generatedAt", ArgumentSemantic.Retain)]
		NSDate GeneratedAt { get; }

		// -(ACSIncomingMediaStatsInfo * _Nonnull)incomingMediaStatsFromParticipant:(id<CommunicationIdentifier> _Nonnull)identifier;
		[Export ("incomingMediaStatsFromParticipant:")]
		ACSIncomingMediaStatsInfo IncomingMediaStatsFromParticipant (CommunicationIdentifier identifier);
	}

	// @interface ACSOutgoingMediaStatsInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSOutgoingMediaStatsInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSOutgoingAudioMediaStats *> * _Nonnull audio;
		[Export ("audio", ArgumentSemantic.Copy)]
		ACSOutgoingAudioMediaStats[] Audio { get; }

		// @property (readonly, copy) NSArray<ACSOutgoingVideoMediaStats *> * _Nonnull video;
		[Export ("video", ArgumentSemantic.Copy)]
		ACSOutgoingVideoMediaStats[] Video { get; }

		// @property (readonly, copy) NSArray<ACSOutgoingScreenShareMediaStats *> * _Nonnull screenShare;
		[Export ("screenShare", ArgumentSemantic.Copy)]
		ACSOutgoingScreenShareMediaStats[] ScreenShare { get; }
	}

	// @interface ACSOutgoingAudioMediaStats : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSOutgoingAudioMediaStats
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull codecName;
		[Export ("codecName", ArgumentSemantic.Retain)]
		string CodecName { get; }

		// @property (readonly) NSNumber * _Nullable bitrate;
		[NullAllowed, Export ("bitrate")]
		NSNumber Bitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterInMs;
		[NullAllowed, Export ("jitterInMs")]
		NSNumber JitterInMs { get; }

		// @property (readonly) NSNumber * _Nullable packetsPerSecond;
		[NullAllowed, Export ("packetsPerSecond")]
		NSNumber PacketsPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable packetsLostPerSecond;
		[NullAllowed, Export ("packetsLostPerSecond")]
		NSNumber PacketsLostPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable roundTripTimeInMs;
		[NullAllowed, Export ("roundTripTimeInMs")]
		NSNumber RoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable pairRoundTripTimeInMs;
		[NullAllowed, Export ("pairRoundTripTimeInMs")]
		NSNumber PairRoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable availableBitrate;
		[NullAllowed, Export ("availableBitrate")]
		NSNumber AvailableBitrate { get; }

		// @property (readonly) NSNumber * _Nullable audioInputLevel;
		[NullAllowed, Export ("audioInputLevel")]
		NSNumber AudioInputLevel { get; }
	}

	// @interface ACSOutgoingVideoMediaStats : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSOutgoingVideoMediaStats
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull codecName;
		[Export ("codecName", ArgumentSemantic.Retain)]
		string CodecName { get; }

		// @property (readonly) NSNumber * _Nullable bitrate;
		[NullAllowed, Export ("bitrate")]
		NSNumber Bitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterInMs;
		[NullAllowed, Export ("jitterInMs")]
		NSNumber JitterInMs { get; }

		// @property (readonly) NSNumber * _Nullable packetsPerSecond;
		[NullAllowed, Export ("packetsPerSecond")]
		NSNumber PacketsPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable packetsLostPerSecond;
		[NullAllowed, Export ("packetsLostPerSecond")]
		NSNumber PacketsLostPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable roundTripTimeInMs;
		[NullAllowed, Export ("roundTripTimeInMs")]
		NSNumber RoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable pairRoundTripTimeInMs;
		[NullAllowed, Export ("pairRoundTripTimeInMs")]
		NSNumber PairRoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable availableBitrate;
		[NullAllowed, Export ("availableBitrate")]
		NSNumber AvailableBitrate { get; }

		// @property (readonly) NSNumber * _Nullable frameRateInput;
		[NullAllowed, Export ("frameRateInput")]
		NSNumber FrameRateInput { get; }

		// @property (readonly) NSNumber * _Nullable frameWidthInput;
		[NullAllowed, Export ("frameWidthInput")]
		NSNumber FrameWidthInput { get; }

		// @property (readonly) NSNumber * _Nullable frameHeightInput;
		[NullAllowed, Export ("frameHeightInput")]
		NSNumber FrameHeightInput { get; }

		// @property (readonly) NSNumber * _Nullable frameRateEncoded;
		[NullAllowed, Export ("frameRateEncoded")]
		NSNumber FrameRateEncoded { get; }

		// @property (readonly) NSNumber * _Nullable frameRateSent;
		[NullAllowed, Export ("frameRateSent")]
		NSNumber FrameRateSent { get; }

		// @property (readonly) NSNumber * _Nullable frameWidthSent;
		[NullAllowed, Export ("frameWidthSent")]
		NSNumber FrameWidthSent { get; }

		// @property (readonly) NSNumber * _Nullable frameHeightSent;
		[NullAllowed, Export ("frameHeightSent")]
		NSNumber FrameHeightSent { get; }

		// @property (readonly) NSNumber * _Nullable framesSent;
		[NullAllowed, Export ("framesSent")]
		NSNumber FramesSent { get; }

		// @property (readonly) NSNumber * _Nullable framesEncoded;
		[NullAllowed, Export ("framesEncoded")]
		NSNumber FramesEncoded { get; }

		// @property (readonly) NSNumber * _Nullable keyFramesEncoded;
		[NullAllowed, Export ("keyFramesEncoded")]
		NSNumber KeyFramesEncoded { get; }
	}

	// @interface ACSOutgoingScreenShareMediaStats : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSOutgoingScreenShareMediaStats
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull codecName;
		[Export ("codecName", ArgumentSemantic.Retain)]
		string CodecName { get; }

		// @property (readonly) NSNumber * _Nullable bitrate;
		[NullAllowed, Export ("bitrate")]
		NSNumber Bitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterInMs;
		[NullAllowed, Export ("jitterInMs")]
		NSNumber JitterInMs { get; }

		// @property (readonly) NSNumber * _Nullable packetsPerSecond;
		[NullAllowed, Export ("packetsPerSecond")]
		NSNumber PacketsPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable packetsLostPerSecond;
		[NullAllowed, Export ("packetsLostPerSecond")]
		NSNumber PacketsLostPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable roundTripTimeInMs;
		[NullAllowed, Export ("roundTripTimeInMs")]
		NSNumber RoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable pairRoundTripTimeInMs;
		[NullAllowed, Export ("pairRoundTripTimeInMs")]
		NSNumber PairRoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable availableBitrate;
		[NullAllowed, Export ("availableBitrate")]
		NSNumber AvailableBitrate { get; }

		// @property (readonly) NSNumber * _Nullable frameRateInput;
		[NullAllowed, Export ("frameRateInput")]
		NSNumber FrameRateInput { get; }

		// @property (readonly) NSNumber * _Nullable frameWidthInput;
		[NullAllowed, Export ("frameWidthInput")]
		NSNumber FrameWidthInput { get; }

		// @property (readonly) NSNumber * _Nullable frameHeightInput;
		[NullAllowed, Export ("frameHeightInput")]
		NSNumber FrameHeightInput { get; }

		// @property (readonly) NSNumber * _Nullable frameRateEncoded;
		[NullAllowed, Export ("frameRateEncoded")]
		NSNumber FrameRateEncoded { get; }

		// @property (readonly) NSNumber * _Nullable frameRateSent;
		[NullAllowed, Export ("frameRateSent")]
		NSNumber FrameRateSent { get; }

		// @property (readonly) NSNumber * _Nullable frameWidthSent;
		[NullAllowed, Export ("frameWidthSent")]
		NSNumber FrameWidthSent { get; }

		// @property (readonly) NSNumber * _Nullable frameHeightSent;
		[NullAllowed, Export ("frameHeightSent")]
		NSNumber FrameHeightSent { get; }

		// @property (readonly) NSNumber * _Nullable framesSent;
		[NullAllowed, Export ("framesSent")]
		NSNumber FramesSent { get; }

		// @property (readonly) NSNumber * _Nullable framesEncoded;
		[NullAllowed, Export ("framesEncoded")]
		NSNumber FramesEncoded { get; }

		// @property (readonly) NSNumber * _Nullable keyFramesEncoded;
		[NullAllowed, Export ("keyFramesEncoded")]
		NSNumber KeyFramesEncoded { get; }
	}

	// @interface ACSIncomingMediaStatsInfo : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIncomingMediaStatsInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSIncomingAudioMediaStats *> * _Nonnull audio;
		[Export ("audio", ArgumentSemantic.Copy)]
		ACSIncomingAudioMediaStats[] Audio { get; }

		// @property (readonly, copy) NSArray<ACSIncomingVideoMediaStats *> * _Nonnull video;
		[Export ("video", ArgumentSemantic.Copy)]
		ACSIncomingVideoMediaStats[] Video { get; }

		// @property (readonly, copy) NSArray<ACSIncomingScreenShareMediaStats *> * _Nonnull screenShare;
		[Export ("screenShare", ArgumentSemantic.Copy)]
		ACSIncomingScreenShareMediaStats[] ScreenShare { get; }
	}

	// @interface ACSIncomingAudioMediaStats : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIncomingAudioMediaStats
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull codecName;
		[Export ("codecName", ArgumentSemantic.Retain)]
		string CodecName { get; }

		// @property (readonly) NSNumber * _Nullable bitrate;
		[NullAllowed, Export ("bitrate")]
		NSNumber Bitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterInMs;
		[NullAllowed, Export ("jitterInMs")]
		NSNumber JitterInMs { get; }

		// @property (readonly) NSNumber * _Nullable packetsPerSecond;
		[NullAllowed, Export ("packetsPerSecond")]
		NSNumber PacketsPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable packetsLostPerSecond;
		[NullAllowed, Export ("packetsLostPerSecond")]
		NSNumber PacketsLostPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable roundTripTimeInMs;
		[NullAllowed, Export ("roundTripTimeInMs")]
		NSNumber RoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable pairRoundTripTimeInMs;
		[NullAllowed, Export ("pairRoundTripTimeInMs")]
		NSNumber PairRoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable availableBitrate;
		[NullAllowed, Export ("availableBitrate")]
		NSNumber AvailableBitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterBufferInMs;
		[NullAllowed, Export ("jitterBufferInMs")]
		NSNumber JitterBufferInMs { get; }

		// @property (readonly) NSNumber * _Nullable audioOutputLevel;
		[NullAllowed, Export ("audioOutputLevel")]
		NSNumber AudioOutputLevel { get; }

		// @property (readonly) NSNumber * _Nullable healedRatio;
		[NullAllowed, Export ("healedRatio")]
		NSNumber HealedRatio { get; }
	}

	// @interface ACSIncomingVideoMediaStats : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIncomingVideoMediaStats
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull codecName;
		[Export ("codecName", ArgumentSemantic.Retain)]
		string CodecName { get; }

		// @property (readonly) NSNumber * _Nullable bitrate;
		[NullAllowed, Export ("bitrate")]
		NSNumber Bitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterInMs;
		[NullAllowed, Export ("jitterInMs")]
		NSNumber JitterInMs { get; }

		// @property (readonly) NSNumber * _Nullable packetsPerSecond;
		[NullAllowed, Export ("packetsPerSecond")]
		NSNumber PacketsPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable packetsLostPerSecond;
		[NullAllowed, Export ("packetsLostPerSecond")]
		NSNumber PacketsLostPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable roundTripTimeInMs;
		[NullAllowed, Export ("roundTripTimeInMs")]
		NSNumber RoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable pairRoundTripTimeInMs;
		[NullAllowed, Export ("pairRoundTripTimeInMs")]
		NSNumber PairRoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable availableBitrate;
		[NullAllowed, Export ("availableBitrate")]
		NSNumber AvailableBitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterBufferInMs;
		[NullAllowed, Export ("jitterBufferInMs")]
		NSNumber JitterBufferInMs { get; }

		// @property (readonly) NSNumber * _Nullable streamId;
		[NullAllowed, Export ("streamId")]
		NSNumber StreamId { get; }

		// @property (readonly) NSNumber * _Nullable frameRateOutput;
		[NullAllowed, Export ("frameRateOutput")]
		NSNumber FrameRateOutput { get; }

		// @property (readonly) NSNumber * _Nullable frameRateDecoded;
		[NullAllowed, Export ("frameRateDecoded")]
		NSNumber FrameRateDecoded { get; }

		// @property (readonly) NSNumber * _Nullable frameRateReceived;
		[NullAllowed, Export ("frameRateReceived")]
		NSNumber FrameRateReceived { get; }

		// @property (readonly) NSNumber * _Nullable frameWidthReceived;
		[NullAllowed, Export ("frameWidthReceived")]
		NSNumber FrameWidthReceived { get; }

		// @property (readonly) NSNumber * _Nullable frameHeightReceived;
		[NullAllowed, Export ("frameHeightReceived")]
		NSNumber FrameHeightReceived { get; }

		// @property (readonly) NSNumber * _Nullable longestFreezeDurationInMs;
		[NullAllowed, Export ("longestFreezeDurationInMs")]
		NSNumber LongestFreezeDurationInMs { get; }

		// @property (readonly) NSNumber * _Nullable totalFreezeDurationInMs;
		[NullAllowed, Export ("totalFreezeDurationInMs")]
		NSNumber TotalFreezeDurationInMs { get; }

		// @property (readonly) NSNumber * _Nullable framesReceived;
		[NullAllowed, Export ("framesReceived")]
		NSNumber FramesReceived { get; }

		// @property (readonly) NSNumber * _Nullable framesDropped;
		[NullAllowed, Export ("framesDropped")]
		NSNumber FramesDropped { get; }

		// @property (readonly) NSNumber * _Nullable framesDecoded;
		[NullAllowed, Export ("framesDecoded")]
		NSNumber FramesDecoded { get; }

		// @property (readonly) NSNumber * _Nullable keyFramesDecoded;
		[NullAllowed, Export ("keyFramesDecoded")]
		NSNumber KeyFramesDecoded { get; }
	}

	// @interface ACSIncomingScreenShareMediaStats : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSIncomingScreenShareMediaStats
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull codecName;
		[Export ("codecName", ArgumentSemantic.Retain)]
		string CodecName { get; }

		// @property (readonly) NSNumber * _Nullable bitrate;
		[NullAllowed, Export ("bitrate")]
		NSNumber Bitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterInMs;
		[NullAllowed, Export ("jitterInMs")]
		NSNumber JitterInMs { get; }

		// @property (readonly) NSNumber * _Nullable packetsPerSecond;
		[NullAllowed, Export ("packetsPerSecond")]
		NSNumber PacketsPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable packetsLostPerSecond;
		[NullAllowed, Export ("packetsLostPerSecond")]
		NSNumber PacketsLostPerSecond { get; }

		// @property (readonly) NSNumber * _Nullable roundTripTimeInMs;
		[NullAllowed, Export ("roundTripTimeInMs")]
		NSNumber RoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable pairRoundTripTimeInMs;
		[NullAllowed, Export ("pairRoundTripTimeInMs")]
		NSNumber PairRoundTripTimeInMs { get; }

		// @property (readonly) NSNumber * _Nullable availableBitrate;
		[NullAllowed, Export ("availableBitrate")]
		NSNumber AvailableBitrate { get; }

		// @property (readonly) NSNumber * _Nullable jitterBufferInMs;
		[NullAllowed, Export ("jitterBufferInMs")]
		NSNumber JitterBufferInMs { get; }

		// @property (readonly) NSNumber * _Nullable streamId;
		[NullAllowed, Export ("streamId")]
		NSNumber StreamId { get; }

		// @property (readonly) NSNumber * _Nullable frameRateOutput;
		[NullAllowed, Export ("frameRateOutput")]
		NSNumber FrameRateOutput { get; }

		// @property (readonly) NSNumber * _Nullable frameRateDecoded;
		[NullAllowed, Export ("frameRateDecoded")]
		NSNumber FrameRateDecoded { get; }

		// @property (readonly) NSNumber * _Nullable frameRateReceived;
		[NullAllowed, Export ("frameRateReceived")]
		NSNumber FrameRateReceived { get; }

		// @property (readonly) NSNumber * _Nullable frameWidthReceived;
		[NullAllowed, Export ("frameWidthReceived")]
		NSNumber FrameWidthReceived { get; }

		// @property (readonly) NSNumber * _Nullable frameHeightReceived;
		[NullAllowed, Export ("frameHeightReceived")]
		NSNumber FrameHeightReceived { get; }

		// @property (readonly) NSNumber * _Nullable longestFreezeDurationInMs;
		[NullAllowed, Export ("longestFreezeDurationInMs")]
		NSNumber LongestFreezeDurationInMs { get; }

		// @property (readonly) NSNumber * _Nullable totalFreezeDurationInMs;
		[NullAllowed, Export ("totalFreezeDurationInMs")]
		NSNumber TotalFreezeDurationInMs { get; }

		// @property (readonly) NSNumber * _Nullable framesReceived;
		[NullAllowed, Export ("framesReceived")]
		NSNumber FramesReceived { get; }

		// @property (readonly) NSNumber * _Nullable framesDropped;
		[NullAllowed, Export ("framesDropped")]
		NSNumber FramesDropped { get; }

		// @property (readonly) NSNumber * _Nullable framesDecoded;
		[NullAllowed, Export ("framesDecoded")]
		NSNumber FramesDecoded { get; }

		// @property (readonly) NSNumber * _Nullable keyFramesDecoded;
		[NullAllowed, Export ("keyFramesDecoded")]
		NSNumber KeyFramesDecoded { get; }
	}

	// @interface ACSCallSurveyResult : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallSurveyResult
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) NSString * _Nonnull surveyId;
		[Export ("surveyId", ArgumentSemantic.Retain)]
		string SurveyId { get; }

		// @property (readonly, retain) NSString * _Nonnull callId;
		[Export ("callId", ArgumentSemantic.Retain)]
		string CallId { get; }

		// @property (readonly, retain) NSString * _Nonnull anonymizedParticipantId;
		[Export ("anonymizedParticipantId", ArgumentSemantic.Retain)]
		string AnonymizedParticipantId { get; }
	}

	// @interface ACSSurveyCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSSurveyCallFeature
	{
		// -(void)startSurveyWithCompletionHandler:(void (^ _Nonnull)(ACSCallSurvey * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("startSurvey(completionHandler:)")));
		[Export ("startSurveyWithCompletionHandler:")]
		void StartSurveyWithCompletionHandler (Action<ACSCallSurvey, NSError> completionHandler);

		// -(void)submitSurvey:(ACSCallSurvey * _Nonnull)survey withCompletionHandler:(void (^ _Nonnull)(ACSCallSurveyResult * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("submit(survey:completionHandler:)")));
		[Export ("submitSurvey:withCompletionHandler:")]
		void SubmitSurvey (ACSCallSurvey survey, Action<ACSCallSurveyResult, NSError> completionHandler);
	}

	// @interface ACSCallSurvey : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSCallSurvey
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (retain) ACSCallSurveyScore * _Nonnull overallScore;
		[Export ("overallScore", ArgumentSemantic.Retain)]
		ACSCallSurveyScore OverallScore { get; set; }

		// @property (retain) ACSCallSurveyScore * _Nonnull audioScore;
		[Export ("audioScore", ArgumentSemantic.Retain)]
		ACSCallSurveyScore AudioScore { get; set; }

		// @property (retain) ACSCallSurveyScore * _Nonnull videoScore;
		[Export ("videoScore", ArgumentSemantic.Retain)]
		ACSCallSurveyScore VideoScore { get; set; }

		// @property (retain) ACSCallSurveyScore * _Nonnull screenShareScore;
		[Export ("screenShareScore", ArgumentSemantic.Retain)]
		ACSCallSurveyScore ScreenShareScore { get; set; }

		// @property ACSCallIssues overallIssues;
		[Export ("overallIssues", ArgumentSemantic.Assign)]
		ACSCallIssues OverallIssues { get; set; }

		// @property ACSAudioIssues audioIssues;
		[Export ("audioIssues", ArgumentSemantic.Assign)]
		ACSAudioIssues AudioIssues { get; set; }

		// @property ACSVideoIssues videoIssues;
		[Export ("videoIssues", ArgumentSemantic.Assign)]
		ACSVideoIssues VideoIssues { get; set; }

		// @property ACSScreenShareIssues screenShareIssues;
		[Export ("screenShareIssues", ArgumentSemantic.Assign)]
		ACSScreenShareIssues ScreenShareIssues { get; set; }
	}

	// @interface ACSCallSurveyScore : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallSurveyScore
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property int score;
		[Export ("score")]
		int Score { get; set; }

		// @property (retain) ACSCallSurveyRatingScale * _Nonnull scale;
		[Export ("scale", ArgumentSemantic.Retain)]
		ACSCallSurveyRatingScale Scale { get; set; }
	}

	// @interface ACSCallSurveyRatingScale : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSCallSurveyRatingScale
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property int lowerBound;
		[Export ("lowerBound")]
		int LowerBound { get; set; }

		// @property int upperBound;
		[Export ("upperBound")]
		int UpperBound { get; set; }

		// @property int lowScoreThreshold;
		[Export ("lowScoreThreshold")]
		int LowScoreThreshold { get; set; }
	}

	// @interface ACSContentSharingCallFeature : ACSCallFeature
	[BaseType (typeof(ACSCallFeature))]
	[DisableDefaultCtor]
	interface ACSContentSharingCallFeature
	{
		// @property (readonly) ACSContentSharingState state;
		[Export ("state")]
		ACSContentSharingState State { get; }

		// @property (readonly) ACSContentSharingType type;
		[Export ("type")]
		ACSContentSharingType Type { get; }

		// @property (readonly, retain) ACSContentSharingInfo * _Nonnull contentSharingInfo;
		[Export ("contentSharingInfo", ArgumentSemantic.Retain)]
		ACSContentSharingInfo ContentSharingInfo { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSContentSharingCallFeatureDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSContentSharingCallFeatureDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSContentSharingCallFeatureEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSContentSharingCallFeatureEvents Events { get; }
	}

	// @interface ACSContentSharingInfo : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSContentSharingInfo
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();
	}

	// @interface ACSPowerPointInfo : ACSContentSharingInfo
	[BaseType (typeof(ACSContentSharingInfo))]
	[DisableDefaultCtor]
	interface ACSPowerPointInfo
	{
		// @property (readonly) int slideIndex;
		[Export ("slideIndex")]
		int SlideIndex { get; }

		// @property (readonly) BOOL isPrivateViewingEnabled;
		[Export ("isPrivateViewingEnabled")]
		bool IsPrivateViewingEnabled { get; }
	}
}
