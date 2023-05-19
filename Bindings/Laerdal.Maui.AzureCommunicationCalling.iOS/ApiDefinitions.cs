using System;
using Foundation;
using ObjCRuntime;
using UIKit;
using CallKit;
using CoreVideo;

namespace Laerdal.Maui.AzureCommunicationCalling.iOS
{
	[Static]
	partial interface Constants
	{
		// extern double AzureCommunicationCommonVersionNumber;
		[Field("AzureCommunicationCommonVersionNumber", "__Internal")]
		double AzureCommunicationCommonVersionNumber { get; }

		// extern const unsigned char[] AzureCommunicationCommonVersionString;
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
		/*
        // @required @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
        [Abstract]
        [Export("rawId")]
        string RawId { get; }

        // @required @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
        [Abstract]
        [Export("kind", ArgumentSemantic.Strong)]
        IdentifierKind Kind { get; }
		*/
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
        //NativeHandle Constructor ([NullAllowed] string initialToken, bool refreshProactively, Action<Action<NSString, NSError>> tokenRefresher);
    }

    // @interface CommunicationUserIdentifier : NSObject <CommunicationIdentifier>
    [BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon27CommunicationUserIdentifier")]
	[DisableDefaultCtor]
	interface CommunicationUserIdentifier : CommunicationIdentifier
	{
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
        [Export("rawId")]
        string RawId { get; }

        // @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
        [Export("kind", ArgumentSemantic.Strong)]
        IdentifierKind Kind { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Export("identifier")]
		string Identifier { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:")]
		[DesignatedInitializer]
        IntPtr Constructor(string identifier);
    }

    // @interface IdentifierKind : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC24AzureCommunicationCommon14IdentifierKind")]
    [DisableDefaultCtor]
    interface IdentifierKind
    {
        // @property (readonly, nonatomic, strong, class) IdentifierKind * _Nonnull communicationUser;
        [Static]
        [Export("communicationUser", ArgumentSemantic.Strong)]
        IdentifierKind CommunicationUser { get; }

        // @property (readonly, nonatomic, strong, class) IdentifierKind * _Nonnull phoneNumber;
        [Static]
        [Export("phoneNumber", ArgumentSemantic.Strong)]
        IdentifierKind PhoneNumber { get; }

        // @property (readonly, nonatomic, strong, class) IdentifierKind * _Nonnull microsoftTeamsUser;
        [Static]
        [Export("microsoftTeamsUser", ArgumentSemantic.Strong)]
        IdentifierKind MicrosoftTeamsUser { get; }

        // @property (readonly, nonatomic, strong, class) IdentifierKind * _Nonnull unknown;
        [Static]
        [Export("unknown", ArgumentSemantic.Strong)]
        IdentifierKind Unknown { get; }

        // -(instancetype _Nonnull)initWithRawValue:(NSString * _Nonnull)rawValue __attribute__((objc_designated_initializer));
        [Export("initWithRawValue:")]
        [DesignatedInitializer]
        IntPtr Constructor(string rawValue);
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

        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
        [Export("rawId")]
        string RawId { get; }

        // @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
        [Export("kind", ArgumentSemantic.Strong)]
        IdentifierKind Kind { get; }

        // @property (readonly, nonatomic, strong) CommunicationCloudEnvironment * _Nonnull cloudEnviroment;
        [Export("cloudEnviroment", ArgumentSemantic.Strong)]
		CommunicationCloudEnvironment CloudEnviroment { get; }

		// -(instancetype _Nonnull)initWithUserId:(NSString * _Nonnull)userId isAnonymous:(BOOL)isAnonymous rawId:(NSString * _Nullable)rawId cloudEnvironment:(CommunicationCloudEnvironment * _Nonnull)cloudEnvironment __attribute__((objc_designated_initializer));
		[Export("initWithUserId:isAnonymous:rawId:cloudEnvironment:")]
		[DesignatedInitializer]
        IntPtr Constructor(string userId, bool isAnonymous, [NullAllowed] string rawId, CommunicationCloudEnvironment cloudEnvironment);

        // -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
        [Export("isEqual:")]
        bool IsEqual([NullAllowed] NSObject @object);
    }

    // @interface PhoneNumberIdentifier : NSObject <CommunicationIdentifier>
    [BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon21PhoneNumberIdentifier")]
	[DisableDefaultCtor]
	interface PhoneNumberIdentifier : CommunicationIdentifier
	{
		// @property (readonly, copy, nonatomic) NSString * _Nonnull phoneNumber;
		[Export("phoneNumber")]
		string PhoneNumber { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
        [Export("rawId")]
        string RawId { get; }

        // @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
        [Export("kind", ArgumentSemantic.Strong)]
        IdentifierKind Kind { get; }

        // -(instancetype _Nonnull)initWithPhoneNumber:(NSString * _Nonnull)phoneNumber rawId:(NSString * _Nullable)rawId __attribute__((objc_designated_initializer));
        [Export("initWithPhoneNumber:rawId:")]
		[DesignatedInitializer]
        IntPtr Constructor(string phoneNumber, [NullAllowed] string rawId);

        // -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
        [Export("isEqual:")]
        bool IsEqual([NullAllowed] NSObject @object);
    }

	// @interface UnknownIdentifier : NSObject <CommunicationIdentifier>
	[BaseType(typeof(CommunicationIdentifier), Name = "_TtC24AzureCommunicationCommon17UnknownIdentifier")]
	[DisableDefaultCtor]
	interface UnknownIdentifier : CommunicationIdentifier
	{
        // @property (readonly, copy, nonatomic) NSString * _Nonnull rawId;
        [Export("rawId")]
        string RawId { get; }

        // @property (readonly, nonatomic, strong) IdentifierKind * _Nonnull kind;
        [Export("kind", ArgumentSemantic.Strong)]
        IdentifierKind Kind { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Export("identifier")]
		string Identifier { get; }

		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
		[Export("initWithIdentifier:")]
		[DesignatedInitializer]
        IntPtr Constructor(string identifier);
    }

    // @interface ACSCallKitRemoteInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSCallKitRemoteInfo
    {
        // @property (retain) CXHandle * _Nullable handle;
        [NullAllowed, Export("handle", ArgumentSemantic.Retain)]
        IntPtr Handle { get; set; }

        // @property (retain) NSString * _Nullable displayName;
        [NullAllowed, Export("displayName", ArgumentSemantic.Retain)]
        string DisplayName { get; set; }
    }

    // @interface ACSCallKitOptions : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSCallKitOptions
    {
        // -(instancetype _Nonnull)init:(CXProviderConfiguration * _Nonnull)providerConfiguration __attribute__((swift_name("init(with:)")));
        [Export("init:")]
        IntPtr Constructor(CXProviderConfiguration providerConfiguration);

        // @property (readonly, retain) CXProviderConfiguration * _Nonnull providerConfiguration;
        [Export("providerConfiguration", ArgumentSemantic.Retain)]
        CXProviderConfiguration ProviderConfiguration { get; }

        // @property (copy, nonatomic) ACSCallKitRemoteInfo * _Nullable (^ _Nullable)(ACSCallerInfo * _Nonnull) provideRemoteInfo;
        [NullAllowed, Export("provideRemoteInfo", ArgumentSemantic.Copy)]
        Func<ACSCallerInfo, ACSCallKitRemoteInfo> ProvideRemoteInfo { get; set; }

        // @property (copy, nonatomic) NSError * _Nullable (^ _Nullable)() configureAudioSession;
        [NullAllowed, Export("configureAudioSession", ArgumentSemantic.Copy)]
        Func<NSError> ConfigureAudioSession { get; set; }

        // @property BOOL isCallHoldSupported;
        [Export("isCallHoldSupported")]
        bool IsCallHoldSupported { get; set; }
    }

    // @interface ACSVideoStreamRendererView : UIView
    [BaseType (typeof(UIView))]
	[DisableDefaultCtor]
	// Trying out transient to see if this solves some strange cleanup behaviour
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
		bool IsRendering { get; }
	}

	// @protocol ACSVideoStreamRendererDelegate <NSObject>
	[Protocol, Model]
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

        // @property (readonly, class) Class dominantSpeakers __attribute__((swift_private));
        [Static]
        [Export("dominantSpeakers")]
        Class DominantSpeakers { get; }


        // @property (readonly, class) Class teamsCaptions __attribute__((swift_private));
        [Static]
        [Export("teamsCaptions")]
        Class TeamsCaptions { get; }

        // @property (readonly, class) Class raiseHand __attribute__((swift_private));
        [Static]
        [Export("raiseHand")]
        Class RaiseHand { get; }

        // @property (readonly, class) Class diagnostics __attribute__((swift_private));
        [Static]
        [Export("diagnostics")]
        Class Diagnostics { get; }
    }

    // @interface ACSLocalVideoStreamEvents : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSLocalVideoStreamEvents
    {
        // @property (copy) void (^ _Nullable)(ACSOutgoingVideoStreamStateChangedEventArgs * _Nonnull) onOutgoingVideoStreamStateChanged;
        [NullAllowed, Export("onOutgoingVideoStreamStateChanged", ArgumentSemantic.Copy)]
        Action<ACSOutgoingVideoStreamStateChangedEventArgs> OnOutgoingVideoStreamStateChanged { get; set; }

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();
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
        [NullAllowed, Export("onRoleChanged", ArgumentSemantic.Copy)]
        Action<ACSPropertyChangedEventArgs> OnRoleChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSParticipantsUpdatedEventArgs * _Nonnull) onRemoteParticipantsUpdated;
        [NullAllowed, Export ("onRemoteParticipantsUpdated", ArgumentSemantic.Copy)]
		Action<ACSParticipantsUpdatedEventArgs> OnRemoteParticipantsUpdated { get; set; }

        // @property (copy) DEPRECATED_MSG_ATTRIBUTE("Deprecated use OnIsOutgoingAudioStateChanged instead") void (^)(ACSPropertyChangedEventArgs * _Nonnull) onIsMutedChanged __attribute__((deprecated("Deprecated use OnIsOutgoingAudioStateChanged instead")));
        [Export("onIsMutedChanged", ArgumentSemantic.Copy)]
		[Obsolete("Deprecated use OnIsOutgoingAudioStateChanged instead")]
		Action<ACSLocalVideoStreamsUpdatedEventArgs> OnLocalVideoStreamsUpdated { get; set; }

        // @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIsOutgoingAudioStateChanged;
        [NullAllowed, Export("onIsOutgoingAudioStateChanged", ArgumentSemantic.Copy)]
        Action<ACSPropertyChangedEventArgs> OnIsOutgoingAudioStateChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onIsMutedChanged;
        [NullAllowed, Export ("onIsMutedChanged", ArgumentSemantic.Copy)]
		Action<ACSPropertyChangedEventArgs> OnIsMutedChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onTotalParticipantCountChanged;
        [NullAllowed, Export("onTotalParticipantCountChanged", ArgumentSemantic.Copy)]
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
        [NullAllowed, Export("onRoleChanged", ArgumentSemantic.Copy)]
        Action<ACSPropertyChangedEventArgs> OnRoleChanged { get; set; }

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

    // @interface ACSTeamsCaptionsCallFeatureEvents : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSTeamsCaptionsCallFeatureEvents
    {
        // @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onCaptionsActiveChanged;
        [NullAllowed, Export("onCaptionsActiveChanged", ArgumentSemantic.Copy)]
        Action<ACSPropertyChangedEventArgs> OnCaptionsActiveChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSTeamsCaptionsInfo * _Nonnull) onCaptionsReceived;
        [NullAllowed, Export("onCaptionsReceived", ArgumentSemantic.Copy)]
        Action<ACSTeamsCaptionsInfo> OnCaptionsReceived { get; set; }

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();
    }

	/// @interface ACSDominantSpeakersCallFeatureEvents : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSDominantSpeakersCallFeatureEvents
    {
        // @property (copy) void (^ _Nullable)(ACSPropertyChangedEventArgs * _Nonnull) onDominantSpeakersChanged;
        [NullAllowed, Export("onDominantSpeakersChanged", ArgumentSemantic.Copy)]
        Action<ACSPropertyChangedEventArgs> OnDominantSpeakersChanged { get; set; }

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();
    }

    // @interface ACSRaiseHandCallFeatureEvents : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSRaiseHandCallFeatureEvents
    {
        // @property (copy) void (^ _Nullable)(ACSRaisedHandChangedEventArgs * _Nonnull) onRaisedHandReceived;
        [NullAllowed, Export("onRaisedHandReceived", ArgumentSemantic.Copy)]
        Action<ACSRaisedHandChangedEventArgs> OnRaisedHandReceived { get; set; }

        // @property (copy) void (^ _Nullable)(ACSRaisedHandChangedEventArgs * _Nonnull) onLoweredHandReceived;
        [NullAllowed, Export("onLoweredHandReceived", ArgumentSemantic.Copy)]
        Action<ACSRaisedHandChangedEventArgs> OnLoweredHandReceived { get; set; }

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();
    }

    // @interface ACSRawOutgoingVideoStreamOptionsEvents : NSObject
    [BaseType (typeof(NSObject))]
    interface ACSRawOutgoingVideoStreamOptionsEvents
    {
	    // @property (copy) void (^ _Nullable)(ACSVideoFrameSenderChangedEventArgs * _Nonnull) onVideoFrameSenderChanged;
	    [NullAllowed, Export ("onVideoFrameSenderChanged", ArgumentSemantic.Copy)]
	    Action<ACSVideoFrameSenderChangedEventArgs> OnVideoFrameSenderChanged { get; set; }

	    // @property (copy) void (^ _Nullable)(ACSOutgoingVideoStreamStateChangedEventArgs * _Nonnull) onOutgoingVideoStreamStateChanged;
	    [NullAllowed, Export ("onOutgoingVideoStreamStateChanged", ArgumentSemantic.Copy)]
	    Action<ACSOutgoingVideoStreamStateChangedEventArgs> OnOutgoingVideoStreamStateChanged { get; set; }

	    // -(void)removeAll;
	    [Export ("removeAll")]
	    void RemoveAll ();
    }

    // @interface ACSScreenShareRawOutgoingVideoStreamEvents : NSObject
    [BaseType (typeof(NSObject))]
    interface ACSScreenShareRawOutgoingVideoStreamEvents
    {
	    // @property (copy) void (^ _Nullable)(ACSOutgoingVideoStreamStateChangedEventArgs * _Nonnull) onOutgoingVideoStreamStateChanged;
	    [NullAllowed, Export ("onOutgoingVideoStreamStateChanged", ArgumentSemantic.Copy)]
	    Action<ACSOutgoingVideoStreamStateChangedEventArgs> OnOutgoingVideoStreamStateChanged { get; set; }

	    // -(void)removeAll;
	    [Export ("removeAll")]
	    void RemoveAll ();
    }

    // @interface ACSVirtualRawOutgoingVideoStreamEvents : NSObject
    [BaseType (typeof(NSObject))]
    interface ACSVirtualRawOutgoingVideoStreamEvents
    {
	    // @property (copy) void (^ _Nullable)(ACSOutgoingVideoStreamStateChangedEventArgs * _Nonnull) onOutgoingVideoStreamStateChanged;
	    [NullAllowed, Export ("onOutgoingVideoStreamStateChanged", ArgumentSemantic.Copy)]
	    Action<ACSOutgoingVideoStreamStateChangedEventArgs> OnOutgoingVideoStreamStateChanged { get; set; }

	    // -(void)removeAll;
	    [Export ("removeAll")]
	    void RemoveAll ();
    }

    // @interface ACSNetworkDiagnosticsEvents : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSNetworkDiagnosticsEvents
    {
        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onNoNetworkChanged;
        [NullAllowed, Export("onNoNetworkChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnNoNetworkChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onNetworkRelaysNotReachableChanged;
        [NullAllowed, Export("onNetworkRelaysNotReachableChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnNetworkRelaysNotReachableChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSQualityDiagnosticChangedEventArgs * _Nonnull) onNetworkReconnectChanged;
        [NullAllowed, Export("onNetworkReconnectChanged", ArgumentSemantic.Copy)]
        Action<ACSQualityDiagnosticChangedEventArgs> OnNetworkReconnectChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSQualityDiagnosticChangedEventArgs * _Nonnull) onNetworkReceiveQualityChanged;
        [NullAllowed, Export("onNetworkReceiveQualityChanged", ArgumentSemantic.Copy)]
        Action<ACSQualityDiagnosticChangedEventArgs> OnNetworkReceiveQualityChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSQualityDiagnosticChangedEventArgs * _Nonnull) onNetworkSendQualityChanged;
        [NullAllowed, Export("onNetworkSendQualityChanged", ArgumentSemantic.Copy)]
        Action<ACSQualityDiagnosticChangedEventArgs> OnNetworkSendQualityChanged { get; set; }

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();
    }

    // @interface ACSMediaDiagnosticsEvents : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSMediaDiagnosticsEvents
    {
        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onSpeakerNotFunctioningChanged;
        [NullAllowed, Export("onSpeakerNotFunctioningChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnSpeakerNotFunctioningChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onSpeakerNotFunctioningDeviceInUseChanged;
        [NullAllowed, Export("onSpeakerNotFunctioningDeviceInUseChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnSpeakerNotFunctioningDeviceInUseChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onSpeakerMutedChanged;
        [NullAllowed, Export("onSpeakerMutedChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnSpeakerMutedChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onSpeakerVolumeIsZeroChanged;
        [NullAllowed, Export("onSpeakerVolumeIsZeroChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnSpeakerVolumeIsZeroChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onNoSpeakerDevicesEnumeratedChanged;
        [NullAllowed, Export("onNoSpeakerDevicesEnumeratedChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnNoSpeakerDevicesEnumeratedChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onSpeakingWhileMicrophoneIsMutedChanged;
        [NullAllowed, Export("onSpeakingWhileMicrophoneIsMutedChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnSpeakingWhileMicrophoneIsMutedChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onNoMicrophoneDevicesEnumeratedChanged;
        [NullAllowed, Export("onNoMicrophoneDevicesEnumeratedChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnNoMicrophoneDevicesEnumeratedChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onMicrophoneNotFunctioningDeviceInUseChanged;
        [NullAllowed, Export("onMicrophoneNotFunctioningDeviceInUseChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnMicrophoneNotFunctioningDeviceInUseChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onCameraFreezeChanged;
        [NullAllowed, Export("onCameraFreezeChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnCameraFreezeChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onCameraStartFailedChanged;
        [NullAllowed, Export("onCameraStartFailedChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnCameraStartFailedChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onCameraStartTimedOutChanged;
        [NullAllowed, Export("onCameraStartTimedOutChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnCameraStartTimedOutChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onMicrophoneNotFunctioningChanged;
        [NullAllowed, Export("onMicrophoneNotFunctioningChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnMicrophoneNotFunctioningChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onMicrophoneMuteUnexpectedlyChanged;
        [NullAllowed, Export("onMicrophoneMuteUnexpectedlyChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnMicrophoneMuteUnexpectedlyChanged { get; set; }

        // @property (copy) void (^ _Nullable)(ACSFlagDiagnosticChangedEventArgs * _Nonnull) onCameraPermissionDeniedChanged;
        [NullAllowed, Export("onCameraPermissionDeniedChanged", ArgumentSemantic.Copy)]
        Action<ACSFlagDiagnosticChangedEventArgs> OnCameraPermissionDeniedChanged { get; set; }

        // -(void)removeAll;
        [Export("removeAll")]
        void RemoveAll();
    }

    // @protocol ACSLocalVideoStreamDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ACSLocalVideoStreamDelegate
    {
        // @optional -(void)onOutgoingVideoStreamStateChanged:(ACSLocalVideoStream * _Nonnull)localVideoStream :(ACSOutgoingVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("localVideoStream(_:didChangeOutgoingVideoStreamState:)")));
        [Export("onOutgoingVideoStreamStateChanged::")]
        void OnOutgoingVideoStreamStateChanged(ACSLocalVideoStream localVideoStream, ACSOutgoingVideoStreamStateChangedEventArgs args);
	}

    // @protocol ACSCallAgentDelegate <NSObject>
    [Protocol, Model]
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
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSCallDelegate
	{
		// @optional -(void)onIdChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeId:)")));
		[Export("onIdChanged::")]
		void OnIdChanged(ACSCall call, ACSPropertyChangedEventArgs args);

		// @optional -(void)onStateChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeState:)")));
		[Export("onStateChanged::")]
		void OnStateChanged(ACSCall call, ACSPropertyChangedEventArgs args);

        // @optional -(void)onRoleChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeRole:)")));
        [Export("onRoleChanged::")]
        void OnRoleChanged(ACSCall call, ACSPropertyChangedEventArgs args);

        // @optional -(void)onRemoteParticipantsUpdated:(ACSCall * _Nonnull)call :(ACSParticipantsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateRemoteParticipant:)")));
        [Export("onRemoteParticipantsUpdated::")]
		void OnRemoteParticipantsUpdated(ACSCall call, ACSParticipantsUpdatedEventArgs args);

		// @optional -(void)onLocalVideoStreamsUpdated:(ACSCall * _Nonnull)call :(ACSLocalVideoStreamsUpdatedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateLocalVideoStreams:)")));
		[Export("onLocalVideoStreamsUpdated::")]
		void OnLocalVideoStreamsUpdated(ACSCall call, ACSLocalVideoStreamsUpdatedEventArgs args);

		// @optional -(void)onIsMutedChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeMuteState:)"))) __attribute__((deprecated("Deprecated use call(_:didUpdateOutgoingAudioState:) instead")));		
		[Obsolete("Deprecated use OnIsOutgoingAudioStateChanged(ACSCall call, ACSPropertyChangedEventArgs args) instead")]
		[Export("onIsMutedChanged::")]
        void OnIsMutedChanged(ACSCall call, ACSPropertyChangedEventArgs args);

        // @optional -(void)onIsOutgoingAudioStateChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didUpdateOutgoingAudioState:)")));
        [Export("onIsOutgoingAudioStateChanged::")]
        void OnIsOutgoingAudioStateChanged(ACSCall call, ACSPropertyChangedEventArgs args);

        // @optional -(void)onTotalParticipantCountChanged:(ACSCall * _Nonnull)call :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("call(_:didChangeTotalParticipantCount:)")));
        [Export("onTotalParticipantCountChanged::")]
        void OnTotalParticipantCountChanged(ACSCall call, ACSPropertyChangedEventArgs args);
    }

    // @protocol ACSRemoteParticipantDelegate <NSObject>
    [Protocol, Model]
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

        // @optional -(void)onRoleChanged:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didChangeRole:)")));
        [Export("onRoleChanged::")]
        void OnRoleChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

        // @optional -(void)onVideoStreamsUpdated:(ACSRemoteParticipant * _Nonnull)remoteParticipant :(ACSRemoteVideoStreamsEventArgs * _Nonnull)args __attribute__((swift_name("remoteParticipant(_:didUpdateVideoStreams:)")));
        [Export("onVideoStreamsUpdated::")]
		void OnVideoStreamsUpdated(ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args);
	}

	// @protocol ACSIncomingCallDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface ACSIncomingCallDelegate
	{
		// @optional -(void)onCallEnded:(ACSIncomingCall * _Nonnull)incomingCall :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("incomingCall(_:didEnd:)")));
		[Export("onCallEnded::")]
		void OnCallEnded(ACSIncomingCall incomingCall, ACSPropertyChangedEventArgs args);
	}

	// @protocol ACSDeviceManagerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSDeviceManagerDelegate
	{
		// @optional -(void) onCamerasUpdated:(ACSDeviceManager* _Nonnull) deviceManager :(ACSVideoDevicesUpdatedEventArgs* _Nonnull) args __attribute__((swift_name("deviceManager(_:didUpdateCameras:)")));
		[Export("onCamerasUpdated::")]
		void OnCamerasUpdated (ACSDeviceManager deviceManager, ACSVideoDevicesUpdatedEventArgs args);
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

    // @protocol ACSTeamsCaptionsCallFeatureDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ACSTeamsCaptionsCallFeatureDelegate
    {
        // @optional -(void)onCaptionsActiveChanged:(ACSTeamsCaptionsCallFeature * _Nonnull)teamsCaptionsCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("teamsCaptionsCallFeature(_:didChangeCaptionsActiveState:)")));
        [Export("onCaptionsActiveChanged::")]
        void OnCaptionsActiveChanged(ACSTeamsCaptionsCallFeature teamsCaptionsCallFeature, ACSPropertyChangedEventArgs args);

        // @optional -(void)onCaptionsReceived:(ACSTeamsCaptionsCallFeature * _Nonnull)teamsCaptionsCallFeature :(ACSTeamsCaptionsInfo * _Nonnull)captionsInfo __attribute__((swift_name("teamsCaptionsCallFeature(_:didReceiveCaptions:)")));
        [Export("onCaptionsReceived::")]
        void OnCaptionsReceived(ACSTeamsCaptionsCallFeature teamsCaptionsCallFeature, ACSTeamsCaptionsInfo captionsInfo);
    }

    // @protocol ACSDominantSpeakersCallFeatureDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ACSDominantSpeakersCallFeatureDelegate
    {
        // @optional -(void)onDominantSpeakersChanged:(ACSDominantSpeakersCallFeature * _Nonnull)dominantSpeakersCallFeature :(ACSPropertyChangedEventArgs * _Nonnull)args __attribute__((swift_name("dominantSpeakersCallFeature(_:didChangeDominantSpeakers:)")));
        [Export("onDominantSpeakersChanged::")]
        void OnDominantSpeakersChanged(ACSDominantSpeakersCallFeature dominantSpeakersCallFeature, ACSPropertyChangedEventArgs args);
	}

    // @protocol ACSRaiseHandCallFeatureDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ACSRaiseHandCallFeatureDelegate
    {
        // @optional -(void)onRaisedHandReceived:(ACSRaiseHandCallFeature * _Nonnull)raiseHandCallFeature :(ACSRaisedHandChangedEventArgs * _Nonnull)args __attribute__((swift_name("raiseHandCallFeature(_:didReceiveRaisedHand:)")));
        [Export("onRaisedHandReceived::")]
        void OnRaisedHandReceived(ACSRaiseHandCallFeature raiseHandCallFeature, ACSRaisedHandChangedEventArgs args);

        // @optional -(void)onLoweredHandReceived:(ACSRaiseHandCallFeature * _Nonnull)raiseHandCallFeature :(ACSRaisedHandChangedEventArgs * _Nonnull)args __attribute__((swift_name("raiseHandCallFeature(_:didReceiveLoweredHand:)")));
        [Export("onLoweredHandReceived::")]
        void OnLoweredHandReceived(ACSRaiseHandCallFeature raiseHandCallFeature, ACSRaisedHandChangedEventArgs args);
    }

    // @protocol ACSRawOutgoingVideoStreamOptionsDelegate <NSObject>
    [Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSRawOutgoingVideoStreamOptionsDelegate
	{
		// @optional -(void)onVideoFrameSenderChanged:(ACSRawOutgoingVideoStreamOptions * _Nonnull)rawOutgoingVideoStreamOptions :(ACSVideoFrameSenderChangedEventArgs * _Nonnull)args __attribute__((swift_name("rawOutgoingVideoStreamOptions(_:didChangeVideoFrameSender:)")));
		[Export ("onVideoFrameSenderChanged::")]
		void OnVideoFrameSenderChanged (ACSRawOutgoingVideoStreamOptions rawOutgoingVideoStreamOptions, ACSVideoFrameSenderChangedEventArgs args);

		// @optional -(void)onOutgoingVideoStreamStateChanged:(ACSRawOutgoingVideoStreamOptions * _Nonnull)rawOutgoingVideoStreamOptions :(ACSOutgoingVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("rawOutgoingVideoStreamOptions(_:didChangeOutgoingVideoStreamState:)")));
		[Export ("onOutgoingVideoStreamStateChanged::")]
		void OnOutgoingVideoStreamStateChanged (ACSRawOutgoingVideoStreamOptions rawOutgoingVideoStreamOptions, ACSOutgoingVideoStreamStateChangedEventArgs args);
	}

	// @protocol ACSScreenShareRawOutgoingVideoStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSScreenShareRawOutgoingVideoStreamDelegate
	{
		// @optional -(void)onOutgoingVideoStreamStateChanged:(ACSScreenShareRawOutgoingVideoStream * _Nonnull)screenShareRawOutgoingVideoStream :(ACSOutgoingVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("screenShareRawOutgoingVideoStream(_:didChangeOutgoingVideoStreamState:)")));
		[Export ("onOutgoingVideoStreamStateChanged::")]
		void  OnOutgoingVideoStreamStateChanged(ACSScreenShareRawOutgoingVideoStream screenShareRawOutgoingVideoStream, ACSOutgoingVideoStreamStateChangedEventArgs args);
	}

	// @protocol ACSVirtualRawOutgoingVideoStreamDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface ACSVirtualRawOutgoingVideoStreamDelegate
	{
		// @optional -(void)onOutgoingVideoStreamStateChanged:(ACSVirtualRawOutgoingVideoStream * _Nonnull)virtualRawOutgoingVideoStream :(ACSOutgoingVideoStreamStateChangedEventArgs * _Nonnull)args __attribute__((swift_name("virtualRawOutgoingVideoStream(_:didChangeOutgoingVideoStreamState:)")));
		[Export ("onOutgoingVideoStreamStateChanged::")]
		void OnOutgoingVideoStreamStateChanged(ACSVirtualRawOutgoingVideoStream virtualRawOutgoingVideoStream, ACSOutgoingVideoStreamStateChangedEventArgs args);
	}

    // @protocol ACSNetworkDiagnosticsDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ACSNetworkDiagnosticsDelegate
    {
        // @optional -(void)onNoNetworkChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeNoNetworkValue:)")));
        [Export("onNoNetworkChanged::")]
        void OnNoNetworkChanged(ACSNetworkDiagnostics networkDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onNetworkRelaysNotReachableChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeNetworkRelaysNotReachableValue:)")));
        [Export("onNetworkRelaysNotReachableChanged::")]
        void OnNetworkRelaysNotReachableChanged(ACSNetworkDiagnostics networkDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onNetworkReconnectChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSQualityDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeNetworkReconnectValue:)")));
        [Export("onNetworkReconnectChanged::")]
        void OnNetworkReconnectChanged(ACSNetworkDiagnostics networkDiagnostics, ACSQualityDiagnosticChangedEventArgs args);

        // @optional -(void)onNetworkReceiveQualityChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSQualityDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeNetworkReceiveQualityValue:)")));
        [Export("onNetworkReceiveQualityChanged::")]
        void OnNetworkReceiveQualityChanged(ACSNetworkDiagnostics networkDiagnostics, ACSQualityDiagnosticChangedEventArgs args);

        // @optional -(void)onNetworkSendQualityChanged:(ACSNetworkDiagnostics * _Nonnull)networkDiagnostics :(ACSQualityDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("networkDiagnostics(_:didChangeNetworkSendQualityValue:)")));
        [Export("onNetworkSendQualityChanged::")]
        void OnNetworkSendQualityChanged(ACSNetworkDiagnostics networkDiagnostics, ACSQualityDiagnosticChangedEventArgs args);
    }

    // @protocol ACSMediaDiagnosticsDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ACSMediaDiagnosticsDelegate
    {
        // @optional -(void)onSpeakerNotFunctioningChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeSpeakerNotFunctioningValue:)")));
        [Export("onSpeakerNotFunctioningChanged::")]
        void OnSpeakerNotFunctioningChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onSpeakerNotFunctioningDeviceInUseChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeSpeakerNotFunctioningDeviceInUseValue:)")));
        [Export("onSpeakerNotFunctioningDeviceInUseChanged::")]
        void OnSpeakerNotFunctioningDeviceInUseChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onSpeakerMutedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeSpeakerMutedValue:)")));
        [Export("onSpeakerMutedChanged::")]
        void OnSpeakerMutedChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onSpeakerVolumeIsZeroChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeSpeakerVolumeIsZeroValue:)")));
        [Export("onSpeakerVolumeIsZeroChanged::")]
        void OnSpeakerVolumeIsZeroChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onNoSpeakerDevicesEnumeratedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeNoSpeakerDevicesEnumeratedValue:)")));
        [Export("onNoSpeakerDevicesEnumeratedChanged::")]
        void OnNoSpeakerDevicesEnumeratedChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onSpeakingWhileMicrophoneIsMutedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeSpeakingWhileMicrophoneIsMutedValue:)")));
        [Export("onSpeakingWhileMicrophoneIsMutedChanged::")]
        void OnSpeakingWhileMicrophoneIsMutedChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onNoMicrophoneDevicesEnumeratedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeNoMicrophoneDevicesEnumeratedValue:)")));
        [Export("onNoMicrophoneDevicesEnumeratedChanged::")]
        void OnNoMicrophoneDevicesEnumeratedChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onMicrophoneNotFunctioningDeviceInUseChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeMicrophoneNotFunctioningDeviceInUseValue:)")));
        [Export("onMicrophoneNotFunctioningDeviceInUseChanged::")]
        void OnMicrophoneNotFunctioningDeviceInUseChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onCameraFreezeChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeCameraFreezeValue:)")));
        [Export("onCameraFreezeChanged::")]
        void OnCameraFreezeChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onCameraStartFailedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeCameraStartFailedValue:)")));
        [Export("onCameraStartFailedChanged::")]
        void OnCameraStartFailedChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onCameraStartTimedOutChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeCameraStartTimedOutValue:)")));
        [Export("onCameraStartTimedOutChanged::")]
        void OnCameraStartTimedOutChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onMicrophoneNotFunctioningChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeMicrophoneNotFunctioningValue:)")));
        [Export("onMicrophoneNotFunctioningChanged::")]
        void OnMicrophoneNotFunctioningChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onMicrophoneMuteUnexpectedlyChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeMicrophoneMuteUnexpectedlyValue:)")));
        [Export("onMicrophoneMuteUnexpectedlyChanged::")]
        void OnMicrophoneMuteUnexpectedlyChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);

        // @optional -(void)onCameraPermissionDeniedChanged:(ACSMediaDiagnostics * _Nonnull)mediaDiagnostics :(ACSFlagDiagnosticChangedEventArgs * _Nonnull)args __attribute__((swift_name("mediaDiagnostics(_:didChangeCameraPermissionDeniedValue:)")));
        [Export("onCameraPermissionDeniedChanged::")]
        void OnCameraPermissionDeniedChanged(ACSMediaDiagnostics mediaDiagnostics, ACSFlagDiagnosticChangedEventArgs args);
    }

    // @interface ACSOutgoingVideoStream : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSOutgoingVideoStream
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly) ACSMediaStreamType mediaStreamType;
        [Export("mediaStreamType")]
        ACSMediaStreamType MediaStreamType { get; }

        // @property (readonly) ACSOutgoingVideoStreamKind outgoingVideoStreamKind;
        [Export("outgoingVideoStreamKind")]
        ACSOutgoingVideoStreamKind OutgoingVideoStreamKind { get; }

        // @property (readonly) ACSOutgoingVideoStreamState outgoingVideoStreamState;
        [Export("outgoingVideoStreamState")]
        ACSOutgoingVideoStreamState OutgoingVideoStreamState { get; }
    }

    // @interface ACSVideoOptions : NSObject
    [BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoOptions
	{
        // -(instancetype _Nonnull)init:(NSArray<ACSOutgoingVideoStream *> * _Nonnull)outgoingVideoStreams __attribute__((swift_name("init(outgoingVideoStreams:)")));
        [Export("init:")]
        NativeHandle Constructor(ACSOutgoingVideoStream[] outgoingVideoStreams);

        // -(void)dealloc;
        [Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * _Nonnull localVideoStreams;
		[Export("localVideoStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] LocalVideoStreams { get; }

        // -(instancetype _Nonnull)initWithLocalVideoStreams:(NSArray<ACSLocalVideoStream *> * _Nonnull)localVideoStreams __attribute__((swift_name("init(localVideoStreams:)")));
        [Export("initWithLocalVideoStreams:")]
        IntPtr Constructor(ACSLocalVideoStream[] localVideoStreams);
    }

    // @interface ACSLocalVideoStream : ACSOutgoingVideoStream
    [BaseType(typeof(ACSOutgoingVideoStream))]
    [DisableDefaultCtor]
	interface ACSLocalVideoStream
	{
		// -(instancetype _Nonnull)init:(ACSVideoDeviceInfo * _Nonnull)camera __attribute__((swift_name("init(camera:)")));
		[Export ("init:")]
        IntPtr Constructor(ACSVideoDeviceInfo camera);

        // @property (readonly, retain) ACSVideoDeviceInfo * _Nonnull source;
        [Export ("source", ArgumentSemantic.Retain)]
		ACSVideoDeviceInfo Source { get; }

		// @property (readonly) BOOL isSending;
		[Export ("isSending")]
		bool IsSending { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        ACSLocalVideoStreamDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ACSLocalVideoStreamDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) ACSLocalVideoStreamEvents * _Nonnull events;
        [Export("events", ArgumentSemantic.Strong)]
        ACSLocalVideoStreamEvents Events { get; }

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

    // @interface ACSOutgoingVideoStreamStateChangedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSOutgoingVideoStreamStateChangedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly) ACSOutgoingVideoStreamState outgoingVideoStreamState;
        [Export("outgoingVideoStreamState")]
        ACSOutgoingVideoStreamState OutgoingVideoStreamState { get; }

        // @property (readonly, retain) NSString * _Nonnull message;
        [Export("message", ArgumentSemantic.Retain)]
        string Message { get; }
    }

    [BaseType (typeof(NSObject))]
	interface ACSAudioOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

        // @property BOOL muted __attribute__((deprecated("Deprecated use outgoingAudioMuted instead")));
		[Export ("muted")]
		[Obsolete("Deprecated use OutgoingAudioMuted instead")]
        bool Muted { get; set; }

        // @property BOOL outgoingAudioMuted;
        [Export("outgoingAudioMuted")]
        bool OutgoingAudioMuted { get; set; }

        // @property BOOL incomingAudioMuted;
        [Export("incomingAudioMuted")]
        bool IncomingAudioMuted { get; set; }

        // @property (retain) ACSIncomingAudioStream * _Nullable incomingAudioStream;
        [NullAllowed, Export ("incomingAudioStream", ArgumentSemantic.Retain)]
		ACSIncomingAudioStream IncomingAudioStream { get; set; }

		// @property (retain) ACSOutgoingAudioStream * _Nullable outgoingAudioStream;
		[NullAllowed, Export ("outgoingAudioStream", ArgumentSemantic.Retain)]
		ACSOutgoingAudioStream OutgoingAudioStream { get; set; }
	}

	// @interface ACSAudioStream : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSAudioStream
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) ACSAudioStreamKind audioStreamKind;
		[Export ("audioStreamKind")]
		ACSAudioStreamKind AudioStreamKind { get; }
	}

	// @interface ACSIncomingAudioStream : ACSAudioStream
	[BaseType (typeof(ACSAudioStream))]
	[DisableDefaultCtor]
	interface ACSIncomingAudioStream
	{
	}

	// @interface ACSOutgoingAudioStream : ACSAudioStream
	[BaseType (typeof(ACSAudioStream))]
	[DisableDefaultCtor]
	interface ACSOutgoingAudioStream
	{
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

        // @property ACSCallKitRemoteInfo * _Nullable callKitRemoteInfo;
        [NullAllowed, Export("callKitRemoteInfo", ArgumentSemantic.Assign)]
        ACSCallKitRemoteInfo CallKitRemoteInfo { get; set; }

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

		// @property (retain) ACSAudioOptions * _Nullable audioOptions;
		[NullAllowed, Export ("audioOptions", ArgumentSemantic.Retain)]
		ACSAudioOptions AudioOptions { get; set; }
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

        // @property ACSCallKitRemoteInfo * _Nullable callKitRemoteInfo;
        [NullAllowed, Export("callKitRemoteInfo", ArgumentSemantic.Assign)]
        ACSCallKitRemoteInfo CallKitRemoteInfo { get; set; }
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

        // @property (readonly) ACSPushNotificationEventType eventType;
        [Export("eventType")]
        ACSPushNotificationEventType EventType { get; }

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

        // @property (retain) ACSCallKitOptions * _Nullable callKitOptions;
        [NullAllowed, Export("callKitOptions", ArgumentSemantic.Retain)]
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

	// @interface ACSCallAgent : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
    // Trying out transient to see if this solves some strange cleanup behaviour
    [Transient]
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

        // @property (readonly, retain) ACSCallInfo * _Nonnull info;
        [Export("info", ArgumentSemantic.Retain)]
        ACSCallInfo Info { get; }

        // @property (readonly) ACSParticipantRole role;
        [Export("role")]
        ACSParticipantRole Role { get; }

        // @property (readonly) BOOL isMuted __attribute__((deprecated("Deprecated use isOutgoingAudioMuted instead")));
	    [Export("isMuted")]
		[Obsolete("Deprecated use IsOutgoingAudioMuted instead")]
        bool IsMuted { get; }

        // @property (readonly) BOOL isOutgoingAudioMuted;
        [Export("isOutgoingAudioMuted")]
        bool IsOutgoingAudioMuted { get; }

        // @property (readonly) BOOL isIncomingAudioMuted;
        [Export("isIncomingAudioMuted")]
        bool IsIncomingAudioMuted { get; }

        // @property (readonly, retain) ACSCallerInfo * _Nonnull callerInfo;
        [Export("callerInfo", ArgumentSemantic.Retain)]
		ACSCallerInfo CallerInfo { get; }

		// @property (readonly, copy) NSArray<ACSLocalVideoStream *> * _Nonnull localVideoStreams;
		[Export("localVideoStreams", ArgumentSemantic.Copy)]
		ACSLocalVideoStream[] LocalVideoStreams { get; }

        // @property (readonly) int totalParticipantCount;
        [Export("totalParticipantCount")]
        int TotalParticipantCount { get; }

        [Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSCallDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSCallDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSCallEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSCallEvents Events { get; }

		// -(void)startAudio:(ACSAudioStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("startAudio(stream:completionHandler:)")));
		[Export ("startAudio:withCompletionHandler:")]
		void StartAudio (ACSAudioStream stream, Action<NSError> completionHandler);

		// -(void)stopAudio:(ACSMediaStreamDirection)direction withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("stopAudio(direction:completionHandler:)")));
		[Export ("stopAudio:withCompletionHandler:")]
		void StopAudio (ACSMediaStreamDirection direction, Action<NSError> completionHandler);

		// -(void)muteWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("mute(completionHandler:)")));
		[Export("muteWithCompletionHandler:")]
		void MuteWithCompletionHandler(Action<NSError> completionHandler);

        // -(void)updateIncomingAudio:(BOOL)mute withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("updateIncomingAudio(mute:completionHandler:)")));
        [Export("updateIncomingAudio:withCompletionHandler:")]
        void UpdateIncomingAudio(bool mute, Action<NSError> completionHandler);

        // -(void)updateOutgoingAudio:(BOOL)mute withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("updateOutgoingAudio(mute:completionHandler:)")));
        [Export("updateOutgoingAudio:withCompletionHandler:")]
        void UpdateOutgoingAudio(bool mute, Action<NSError> completionHandler);

        // -(void)unmuteWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("unmute(completionHandler:)"))) __attribute__((deprecated("Deprecated use updateOutgoingAudio(mute:) instead")));
        [Export("unmuteWithCompletionHandler:")]
		[Obsolete("Deprecated use updateOutgoingAudio(bool mute) instead")]
		void UnmuteWithCompletionHandler(Action<NSError> completionHandler);

		// -(void)sendDtmf:(ACSDtmfTone)tone withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("sendDtmf(tone:completionHandler:)")));
		[Export("sendDtmf:withCompletionHandler:")]
		void SendDtmf(ACSDtmfTone tone, Action<NSError> completionHandler);

		// -(void)startVideo:(ACSOutgoingVideoStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("startVideo(stream:completionHandler:)")));
		[Export("startVideo:withCompletionHandler:")]
		void StartVideo (ACSOutgoingVideoStream stream, Action<NSError> completionHandler);

		// -(void)stopVideo:(ACSLocalVideoStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("stopVideo(stream:completionHandler:)")));// -(void)stopVideo:(ACSOutgoingVideoStream * _Nonnull)stream withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("stopVideo(stream:completionHandler:)")));
		[Export("stopVideo:withCompletionHandler:")]
		void StopVideo (ACSOutgoingVideoStream stream, Action<NSError> completionHandler);

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

        // @property (readonly) ACSParticipantRole role;
        [Export("role")]
        ACSParticipantRole Role { get; }

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

    // @interface ACSCallInfo : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSCallInfo
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // -(void)getServerCallIdWithCompletionHandler:(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("getServerCallId(completionHandler:)")));
        [Export("getServerCallIdWithCompletionHandler:")]
        void GetServerCallIdWithCompletionHandler(Action<NSString, NSError> completionHandler);
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
    // Trying out transient to see if this solves some strange cleanup behaviour
    [Transient]
    interface ACSCallClient
	{
		// -(instancetype _Nonnull)init:(ACSCallClientOptions * _Nonnull)options __attribute__((swift_name("init(options:)")));
		[Export ("init:")]
        IntPtr Constructor(ACSCallClientOptions options);

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

        // +(void)reportIncomingCallFromKillState:(ACSPushNotificationInfo * _Nonnull)payload callKitOptions:(ACSCallKitOptions * _Nonnull)callKitOptions withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("reportIncomingCallFromKillState(with:callKitOptions:completionHandler:)")));
        [Static]
        [Export("reportIncomingCallFromKillState:callKitOptions:withCompletionHandler:")]
        void ReportIncomingCallFromKillState(ACSPushNotificationInfo payload, ACSCallKitOptions callKitOptions, Action<NSError> completionHandler);

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

    // @interface ACSTeamsCaptionsCallFeature : ACSCallFeature
    [BaseType(typeof(ACSCallFeature))]
    [DisableDefaultCtor]
    interface ACSTeamsCaptionsCallFeature
    {
        // @property (readonly, copy) NSArray<NSString *> * _Nonnull supportedSpokenLanguages;
        [Export("supportedSpokenLanguages", ArgumentSemantic.Copy)]
        string[] SupportedSpokenLanguages { get; }

        // @property (readonly, copy) NSArray<NSString *> * _Nonnull supportedCaptionLanguages;
        [Export("supportedCaptionLanguages", ArgumentSemantic.Copy)]
        string[] SupportedCaptionLanguages { get; }

        // @property (readonly) BOOL isCaptionsFeatureActive;
        [Export("isCaptionsFeatureActive")]
        bool IsCaptionsFeatureActive { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        ACSTeamsCaptionsCallFeatureDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ACSTeamsCaptionsCallFeatureDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) ACSTeamsCaptionsCallFeatureEvents * _Nonnull events;
        [Export("events", ArgumentSemantic.Strong)]
        ACSTeamsCaptionsCallFeatureEvents Events { get; }

        // -(void)startCaptions:(ACSStartCaptionsOptions * _Nullable)options withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("startCaptions(options:completionHandler:)")));
        [Export("startCaptions:withCompletionHandler:")]
        void StartCaptions([NullAllowed] ACSStartCaptionsOptions options, Action<NSError> completionHandler);

        // -(void)stopCaptionsWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("stopCaptions(completionHandler:)")));
        [Export("stopCaptionsWithCompletionHandler:")]
        void StopCaptionsWithCompletionHandler(Action<NSError> completionHandler);

        // -(void)setSpokenLanguage:(NSString * _Nonnull)language withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("set(spokenLanguage:completionHandler:)")));
        [Export("setSpokenLanguage:withCompletionHandler:")]
        void SetSpokenLanguage(string language, Action<NSError> completionHandler);

        // -(void)setCaptionLanguage:(NSString * _Nonnull)language withCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("set(captionLanguage:completionHandler:)")));
        [Export("setCaptionLanguage:withCompletionHandler:")]
        void SetCaptionLanguage(string language, Action<NSError> completionHandler);
    }

    // @interface ACSStartCaptionsOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSStartCaptionsOptions
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (retain) NSString * _Nonnull spokenLanguage;
        [Export("spokenLanguage", ArgumentSemantic.Retain)]
        string SpokenLanguage { get; set; }
    }

    // @interface ACSTeamsCaptionsInfo : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSTeamsCaptionsInfo
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) ACSCallerInfo * _Nonnull speaker;
        [Export("speaker", ArgumentSemantic.Retain)]
        ACSCallerInfo Speaker { get; }

        // @property (readonly, retain) NSString * _Nonnull spokenText;
        [Export("spokenText", ArgumentSemantic.Retain)]
        string SpokenText { get; }

        // @property (readonly, retain) NSString * _Nonnull spokenLanguage;
        [Export("spokenLanguage", ArgumentSemantic.Retain)]
        string SpokenLanguage { get; }

        // @property (readonly, retain) NSString * _Nonnull captionText;
        [Export("captionText", ArgumentSemantic.Retain)]
        string CaptionText { get; }

        // @property (readonly, retain) NSString * _Nonnull captionLanguage;
        [Export("captionLanguage", ArgumentSemantic.Retain)]
        string CaptionLanguage { get; }

        // @property (readonly) ACSCaptionsResultType resultType;
        [Export("resultType")]
        ACSCaptionsResultType ResultType { get; }

        // @property (readonly, retain) NSDate * _Nonnull timestamp;
        [Export("timestamp", ArgumentSemantic.Retain)]
        NSDate Timestamp { get; }
    }

    // @interface ACSDominantSpeakersCallFeature : ACSCallFeature
    [BaseType(typeof(ACSCallFeature))]
    [DisableDefaultCtor]
    interface ACSDominantSpeakersCallFeature
    {
        // @property (readonly, retain) ACSDominantSpeakersInfo * _Nonnull dominantSpeakersInfo;
        [Export("dominantSpeakersInfo", ArgumentSemantic.Retain)]
        ACSDominantSpeakersInfo DominantSpeakersInfo { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        ACSDominantSpeakersCallFeatureDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ACSDominantSpeakersCallFeatureDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) ACSDominantSpeakersCallFeatureEvents * _Nonnull events;
        [Export("events", ArgumentSemantic.Strong)]
        ACSDominantSpeakersCallFeatureEvents Events { get; }
    }

    // @interface ACSDominantSpeakersInfo : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSDominantSpeakersInfo
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) NS_SWIFT_NAME(lastUpdated) NSDate * lastUpdatedAt __attribute__((swift_name("lastUpdated")));
        [Export("lastUpdatedAt", ArgumentSemantic.Retain)]
        NSDate LastUpdatedAt { get; }

        // @property (readonly, nonatomic) NSArray<id<CommunicationIdentifier>> * _Nonnull speakers;
        [Export("speakers")]
        CommunicationIdentifier[] Speakers { get; }
    }

    // @interface ACSRaiseHandCallFeature : ACSCallFeature
    [BaseType(typeof(ACSCallFeature))]
    [DisableDefaultCtor]
    interface ACSRaiseHandCallFeature
    {
        // @property (readonly, copy) NSArray<ACSRaisedHand *> * _Nonnull raisedHands;
        [Export("raisedHands", ArgumentSemantic.Copy)]
        ACSRaisedHand[] RaisedHands { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        ACSRaiseHandCallFeatureDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ACSRaiseHandCallFeatureDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) ACSRaiseHandCallFeatureEvents * _Nonnull events;
        [Export("events", ArgumentSemantic.Strong)]
        ACSRaiseHandCallFeatureEvents Events { get; }

        // -(void)raiseHandWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("raiseHand(completionHandler:)")));
        [Export("raiseHandWithCompletionHandler:")]
        void RaiseHandWithCompletionHandler(Action<NSError> completionHandler);

        // -(void)lowerHandWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("lowerHand(completionHandler:)")));
        [Export("lowerHandWithCompletionHandler:")]
        void LowerHandWithCompletionHandler(Action<NSError> completionHandler);

        // -(void)lowerAllHandsWithCompletionHandler:(void (^ _Nonnull)(NSError * _Nullable))completionHandler __attribute__((swift_name("lowerAllHands(completionHandler:)")));
        [Export("lowerAllHandsWithCompletionHandler:")]
        void LowerAllHandsWithCompletionHandler(Action<NSError> completionHandler);

        // -(void)lowerHands:(NSArray<id<CommunicationIdentifier>> * _Nonnull)participants withCompletionHandler:(void (^ _Nonnull)(NSError *))completionHandler __attribute__((swift_name("lowerHands(participants:completionHandler:)")));
        [Export("lowerHands:withCompletionHandler:")]
        void LowerHands(CommunicationIdentifier[] participants, Action<NSError> completionHandler);
    }

    // @interface ACSRaisedHand : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSRaisedHand
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly) int order;
        [Export("order")]
        int Order { get; }

        // @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
        [Export("identifier")]
        CommunicationIdentifier Identifier { get; }
    }

	// @interface ACSRaisedHandChangedEventArgs : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSRaisedHandChangedEventArgs
	{
		// -(void)dealloc;
		[Export("dealloc")]
		void Dealloc();

		// @property (readonly, nonatomic) id<CommunicationIdentifier> _Nonnull identifier;
		[Export("identifier")]
		CommunicationIdentifier Identifier { get; }
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

		// @interface ACSVideoFormat : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSVideoFormat
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

		// @property ACSPixelFormat pixelFormat;
		[Export ("pixelFormat", ArgumentSemantic.Assign)]
		ACSPixelFormat PixelFormat { get; set; }

		// @property ACSVideoFrameKind videoFrameKind;
		[Export ("videoFrameKind", ArgumentSemantic.Assign)]
		ACSVideoFrameKind VideoFrameKind { get; set; }

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

	// @interface ACSVideoFrameSenderChangedEventArgs : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoFrameSenderChangedEventArgs
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly, retain) ACSVideoFrameSender * _Nonnull videoFrameSender;
		[Export ("videoFrameSender", ArgumentSemantic.Retain)]
		ACSVideoFrameSender VideoFrameSender { get; }
	}

	// @interface ACSVideoFrameSender : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSVideoFrameSender
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) int64_t timestampInTicks;
		[Export ("timestampInTicks")]
		long TimestampInTicks { get; }

		// @property (readonly, retain) ACSVideoFormat * _Nonnull videoFormat;
		[Export ("videoFormat", ArgumentSemantic.Retain)]
		ACSVideoFormat VideoFormat { get; }

		// @property (readonly) ACSVideoFrameKind videoFrameKind;
		[Export ("videoFrameKind")]
		ACSVideoFrameKind VideoFrameKind { get; }
	}

	// @interface ACSRawOutgoingVideoStreamOptions : NSObject
	[BaseType (typeof(NSObject))]
	interface ACSRawOutgoingVideoStreamOptions
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (copy) NSArray<ACSVideoFormat *> * _Nonnull videoFormats;
		[Export ("videoFormats", ArgumentSemantic.Copy)]
		ACSVideoFormat[] VideoFormats { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSRawOutgoingVideoStreamOptionsDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSRawOutgoingVideoStreamOptionsDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSRawOutgoingVideoStreamOptionsEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSRawOutgoingVideoStreamOptionsEvents Events { get; }
	}

	// @interface ACSFrameConfirmation : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface ACSFrameConfirmation
	{
		// -(void)dealloc;
		[Export ("dealloc")]
		void Dealloc ();

		// @property (readonly) int64_t timestampInTicks;
		[Export ("timestampInTicks")]
		long TimestampInTicks { get; }

		// @property (readonly) int status;
		[Export ("status")]
		int Status { get; }
	}

	// @interface ACSSoftwareBasedVideoFrameSender : ACSVideoFrameSender
	[BaseType (typeof(ACSVideoFrameSender))]
	[DisableDefaultCtor]
	interface ACSSoftwareBasedVideoFrameSender
	{
		// -(void)sendFrame:(CVImageBufferRef _Nonnull)frame timestampInTicks:(long long)timestamp withCompletionHandler:(void (^ _Nonnull)(ACSFrameConfirmation * _Nullable, NSError * _Nullable))completionHandler __attribute__((swift_name("send(frame:timestampInTicks:completion:)")));
		[Export ("sendFrame:timestampInTicks:withCompletionHandler:")]
		void SendFrame (CVImageBuffer frame, long timestamp, Action<ACSFrameConfirmation, NSError> completionHandler);
	}

	// @interface ACSRawOutgoingVideoStream : ACSOutgoingVideoStream
	[BaseType (typeof(ACSOutgoingVideoStream))]
	[DisableDefaultCtor]
	interface ACSRawOutgoingVideoStream
	{
		// @property (readonly) int64_t timestampInTicks;
		[Export ("timestampInTicks")]
		long TimestampInTicks { get; }
	}

	// @interface ACSScreenShareRawOutgoingVideoStream : ACSRawOutgoingVideoStream
	[BaseType (typeof(ACSRawOutgoingVideoStream))]
	[DisableDefaultCtor]
	interface ACSScreenShareRawOutgoingVideoStream
	{
		// -(instancetype _Nonnull)init:(ACSRawOutgoingVideoStreamOptions * _Nonnull)videoStreamOptions __attribute__((swift_name("init(videoStreamOptions:)")));
		[Export ("init:")]
		IntPtr Constructor (ACSRawOutgoingVideoStreamOptions videoStreamOptions);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSScreenShareRawOutgoingVideoStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSScreenShareRawOutgoingVideoStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSScreenShareRawOutgoingVideoStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSScreenShareRawOutgoingVideoStreamEvents Events { get; }
	}

	// @interface ACSVirtualRawOutgoingVideoStream : ACSRawOutgoingVideoStream
	[BaseType (typeof(ACSRawOutgoingVideoStream))]
	[DisableDefaultCtor]
	interface ACSVirtualRawOutgoingVideoStream
	{
		// -(instancetype _Nonnull)init:(ACSRawOutgoingVideoStreamOptions * _Nonnull)videoStreamOptions __attribute__((swift_name("init(videoStreamOptions:)")));
		[Export ("init:")]
		IntPtr Constructor (ACSRawOutgoingVideoStreamOptions videoStreamOptions);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		ACSVirtualRawOutgoingVideoStreamDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<ACSVirtualRawOutgoingVideoStreamDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) ACSVirtualRawOutgoingVideoStreamEvents * _Nonnull events;
		[Export ("events", ArgumentSemantic.Strong)]
		ACSVirtualRawOutgoingVideoStreamEvents Events { get; }
	}

	// @interface ACSRoomCallLocator : ACSJoinMeetingLocator
    [BaseType(typeof(ACSJoinMeetingLocator))]
    [DisableDefaultCtor]
    interface ACSRoomCallLocator
    {
        // -(instancetype _Nonnull)init:(NSString * _Nonnull)roomId __attribute__((swift_name("init(roomId:)")));
        [Export("init:")]
        IntPtr Constructor(string roomId);

        // @property (readonly, retain) NSString * _Nonnull roomId;
        [Export("roomId", ArgumentSemantic.Retain)]
        string RoomId { get; }
    }

    // @interface ACSLocalAudioStream : ACSOutgoingAudioStream
    [BaseType (typeof(ACSOutgoingAudioStream))]
    interface ACSLocalAudioStream
    {
    }

    // @interface ACSRemoteAudioStream : ACSIncomingAudioStream
    [BaseType (typeof(ACSIncomingAudioStream))]
    interface ACSRemoteAudioStream
    {
    }

    // @interface ACSDiagnosticsCallFeature : ACSCallFeature
    [BaseType(typeof(ACSCallFeature))]
    [DisableDefaultCtor]
    interface ACSDiagnosticsCallFeature
    {
        // @property (readonly, retain) ACSNetworkDiagnostics * _Nonnull networkDiagnostics;
        [Export("networkDiagnostics", ArgumentSemantic.Retain)]
        ACSNetworkDiagnostics NetworkDiagnostics { get; }

        // @property (readonly, retain) ACSMediaDiagnostics * _Nonnull mediaDiagnostics;
        [Export("mediaDiagnostics", ArgumentSemantic.Retain)]
        ACSMediaDiagnostics MediaDiagnostics { get; }
    }

    // @interface ACSNetworkDiagnostics : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSNetworkDiagnostics
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) ACSNetworkDiagnosticValues * _Nonnull latest;
        [Export("latest", ArgumentSemantic.Retain)]
        ACSNetworkDiagnosticValues Latest { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        ACSNetworkDiagnosticsDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ACSNetworkDiagnosticsDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) ACSNetworkDiagnosticsEvents * _Nonnull events;
        [Export("events", ArgumentSemantic.Strong)]
        ACSNetworkDiagnosticsEvents Events { get; }
    }

    // @interface ACSNetworkDiagnosticValues : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSNetworkDiagnosticValues
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // -(BOOL)valueForNoNetwork:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForNoNetwork:")]
        bool ValueForNoNetwork([NullAllowed] out NSError error);

        // -(BOOL)valueForNetworkRelaysNotReachable:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForNetworkRelaysNotReachable:")]
        bool ValueForNetworkRelaysNotReachable([NullAllowed] out NSError error);

        // -(ACSDiagnosticQuality)valueForNetworkReconnect __attribute__((swift_private));
        [Export("valueForNetworkReconnect")]
        ACSDiagnosticQuality ValueForNetworkReconnect { get; }

        // -(ACSDiagnosticQuality)valueForNetworkReceiveQuality __attribute__((swift_private));
        [Export("valueForNetworkReceiveQuality")]
        ACSDiagnosticQuality ValueForNetworkReceiveQuality { get; }

        // -(ACSDiagnosticQuality)valueForNetworkSendQuality __attribute__((swift_private));
        [Export("valueForNetworkSendQuality")]
        ACSDiagnosticQuality ValueForNetworkSendQuality { get; }
    }

    // @interface ACSFlagDiagnosticChangedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSFlagDiagnosticChangedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly) BOOL value;
        [Export("value")]
        bool Value { get; }
    }

    // @interface ACSQualityDiagnosticChangedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSQualityDiagnosticChangedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly) ACSDiagnosticQuality value;
        [Export("value")]
        ACSDiagnosticQuality Value { get; }
    }

    // @interface ACSMediaDiagnostics : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSMediaDiagnostics
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) ACSMediaDiagnosticValues * _Nonnull latest;
        [Export("latest", ArgumentSemantic.Retain)]
        ACSMediaDiagnosticValues Latest { get; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        ACSMediaDiagnosticsDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<ACSMediaDiagnosticsDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }

        // @property (readonly, nonatomic, strong) ACSMediaDiagnosticsEvents * _Nonnull events;
        [Export("events", ArgumentSemantic.Strong)]
        ACSMediaDiagnosticsEvents Events { get; }
    }

    // @interface ACSMediaDiagnosticValues : NSObject
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface ACSMediaDiagnosticValues
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // -(BOOL)valueForSpeakerNotFunctioning:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForSpeakerNotFunctioning:")]
        bool ValueForSpeakerNotFunctioning([NullAllowed] out NSError error);

        // -(BOOL)valueForSpeakerNotFunctioningDeviceInUse:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForSpeakerNotFunctioningDeviceInUse:")]
        bool ValueForSpeakerNotFunctioningDeviceInUse([NullAllowed] out NSError error);

        // -(BOOL)valueForSpeakerMuted:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForSpeakerMuted:")]
        bool ValueForSpeakerMuted([NullAllowed] out NSError error);

        // -(BOOL)valueForSpeakerVolumeIsZero:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForSpeakerVolumeIsZero:")]
        bool ValueForSpeakerVolumeIsZero([NullAllowed] out NSError error);

        // -(BOOL)valueForNoSpeakerDevicesEnumerated:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForNoSpeakerDevicesEnumerated:")]
        bool ValueForNoSpeakerDevicesEnumerated([NullAllowed] out NSError error);

        // -(BOOL)valueForSpeakingWhileMicrophoneIsMuted:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForSpeakingWhileMicrophoneIsMuted:")]
        bool ValueForSpeakingWhileMicrophoneIsMuted([NullAllowed] out NSError error);

        // -(BOOL)valueForNoMicrophoneDevicesEnumerated:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForNoMicrophoneDevicesEnumerated:")]
        bool ValueForNoMicrophoneDevicesEnumerated([NullAllowed] out NSError error);

        // -(BOOL)valueForMicrophoneNotFunctioningDeviceInUse:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForMicrophoneNotFunctioningDeviceInUse:")]
        bool ValueForMicrophoneNotFunctioningDeviceInUse([NullAllowed] out NSError error);

        // -(BOOL)valueForCameraFreeze:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForCameraFreeze:")]
        bool ValueForCameraFreeze([NullAllowed] out NSError error);

        // -(BOOL)valueForCameraStartFailed:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForCameraStartFailed:")]
        bool ValueForCameraStartFailed([NullAllowed] out NSError error);

        // -(BOOL)valueForCameraStartTimedOut:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForCameraStartTimedOut:")]
        bool ValueForCameraStartTimedOut([NullAllowed] out NSError error);

        // -(BOOL)valueForMicrophoneNotFunctioning:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForMicrophoneNotFunctioning:")]
        bool ValueForMicrophoneNotFunctioning([NullAllowed] out NSError error);

        // -(BOOL)valueForMicrophoneMuteUnexpectedly:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForMicrophoneMuteUnexpectedly:")]
        bool ValueForMicrophoneMuteUnexpectedly([NullAllowed] out NSError error);

        // -(BOOL)valueForCameraPermissionDenied:(NSError * _Nullable * _Nullable)error __attribute__((swift_error("nonnull_error"))) __attribute__((swift_private));
        [Export("valueForCameraPermissionDenied:")]
        bool ValueForCameraPermissionDenied([NullAllowed] out NSError error);
    }
}
