using System;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Xamarin.AzureCommunicationCalling.iOS
{
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
    [Protocol(Name = "_TtP18AzureCommunication23CommunicationIdentifier_")]
    [BaseType(typeof(NSObject), Name = "_TtP18AzureCommunication23CommunicationIdentifier_")]
    interface CommunicationIdentifier
    {
        // @required -(NSString * _Nonnull)getId __attribute__((warn_unused_result("")));
        //[Abstract]
        [Export("getId")] string Id { get; }
    }

    // @interface CallingApplication : NSObject <CommunicationIdentifier>
    [BaseType(typeof(CommunicationIdentifier), Name = "_TtC18AzureCommunication18CallingApplication")]
    [DisableDefaultCtor]
    interface CallingApplication //: ICommunicationIdentifier
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Export("identifier")] string Identifier { get; }

        // -(NSString * _Nonnull)getId __attribute__((warn_unused_result("")));
        [Export("getId")] string Id { get; }

        // -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
        [Export("initWithIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(string identifier);
    }

    // @interface CommunicationUser : NSObject <CommunicationIdentifier>
    [BaseType(typeof(CommunicationIdentifier), Name = "_TtC18AzureCommunication17CommunicationUser")]
    [DisableDefaultCtor]
    interface CommunicationUser //: ICommunicationIdentifier
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Export("identifier")] string Identifier { get; }

        // -(NSString * _Nonnull)getId __attribute__((warn_unused_result("")));
        //[Export ("getId")]
        //[Verify (MethodToProperty)]
        //string Id { get; }

        // -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
        [Export("initWithIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(string identifier);
    }

    // @interface CommunicationUserCredential : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC18AzureCommunication27CommunicationUserCredential")]
    [DisableDefaultCtor]
    interface CommunicationUserCredential
    {
        // -(instancetype _Nullable)initWithToken:(NSString * _Nonnull)token error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
        [Export("initWithToken:error:")]
        [DesignatedInitializer]
        IntPtr Constructor(string token, [NullAllowed] out NSError error);

        // -(instancetype _Nullable)initWithInitialToken:(NSString * _Nullable)initialToken refreshProactively:(BOOL)refreshProactively error:(NSError * _Nullable * _Nullable)error tokenRefresher:(void (^ _Nonnull)(void (^ _Nonnull)(NSString * _Nullable, NSError * _Nullable)))tokenRefresher __attribute__((objc_designated_initializer));
        //[Export ("initWithInitialToken:refreshProactively:error:tokenRefresher:")]
        //[DesignatedInitializer]
        //IntPtr Constructor ([NullAllowed] string initialToken, bool refreshProactively, [NullAllowed] out NSError error, Action<Action<NSString, NSError>> tokenRefresher);

        // -(void)tokenWithCompletionHandler:(void (^ _Nonnull)(AccessToken * _Nullable, NSError * _Nullable))completionHandler;
        [Export("tokenWithCompletionHandler:")]
        void TokenWithCompletionHandler(Action<AccessToken, NSError> completionHandler);
    }

    // @interface PhoneNumber : NSObject <CommunicationIdentifier>
    [BaseType(typeof(CommunicationIdentifier), Name = "_TtC18AzureCommunication11PhoneNumber")]
    [DisableDefaultCtor]
    interface PhoneNumber
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull value;
        [Export("value")] string Value { get; }

        // -(NSString * _Nonnull)getId __attribute__((warn_unused_result("")));
        //[Export ("getId")]
        //[Verify (MethodToProperty)]
        //string Id { get; }

        // -(instancetype _Nonnull)initWithPhoneNumber:(NSString * _Nonnull)phoneNumber __attribute__((objc_designated_initializer));
        [Export("initWithPhoneNumber:")]
        [DesignatedInitializer]
        IntPtr Constructor(string phoneNumber);
    }

    // @interface UnknownIdentifier : NSObject <CommunicationIdentifier>
    [BaseType(typeof(CommunicationIdentifier), Name = "_TtC18AzureCommunication17UnknownIdentifier")]
    [DisableDefaultCtor]
    interface UnknownIdentifier
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
        [Export("identifier")] string Identifier { get; }

        // -(NSString * _Nonnull)getId __attribute__((warn_unused_result("")));
        //[Export ("getId")]
        //[Verify (MethodToProperty)]
        //string Id { get; }

        // -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier __attribute__((objc_designated_initializer));
        [Export("initWithIdentifier:")]
        [DesignatedInitializer]
        IntPtr Constructor(string identifier);
    }

    // @interface AccessToken : NSObject
    [BaseType(typeof(NSObject), Name = "_TtC9AzureCore11AccessToken")]
    [DisableDefaultCtor]
    interface AccessToken
    {
        // @property (readonly, copy, nonatomic) NSString * _Nonnull token;
        [Export("token")] string Token { get; }

        // @property (readonly, copy, nonatomic) NSDate * _Nonnull expiresOn;
        [Export("expiresOn", ArgumentSemantic.Copy)]
        NSDate ExpiresOn { get; }

        // -(instancetype _Nonnull)initWithToken:(NSString * _Nonnull)token expiresOn:(NSDate * _Nonnull)expiresOn __attribute__((objc_designated_initializer));
        [Export("initWithToken:expiresOn:")]
        [DesignatedInitializer]
        IntPtr Constructor(string token, NSDate expiresOn);
    }

    // @interface ACSRendererView : UIView
    [BaseType(typeof(UIView))]
    interface ACSRendererView
    {
        // -(void)updateScalingMode:(ACSScalingMode)scalingMode;
        [Export("updateScalingMode:")]
        void UpdateScalingMode(ACSScalingMode scalingMode);

        // -(void)dispose;
        [Export("dispose")]
        void Dispose();

        // -(_Bool)isRendering;
        [Export("isRendering")] bool IsRendering { get; }
    }

    // @interface ACSStreamSize : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSStreamSize
    {
        // -(instancetype)initWithWidth:(int)width height:(int)height;
        [Export("initWithWidth:height:")]
        IntPtr Constructor(int width, int height);

        // @property (readonly) int width;
        [Export("width")] int Width { get; }

        // @property (readonly) int height;
        [Export("height")] int Height { get; }
    }

    // @protocol ACSRendererDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface ACSRendererDelegate
    {
        // @optional -(void)onFirstFrameRendered;
        [Abstract]
        [Export("onFirstFrameRendered")]
        void OnFirstFrameRendered();
    }

    // @interface ACSRenderer : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSRenderer
    {
        // -(instancetype)initWithLocalVideoStream:(ACSLocalVideoStream *)localVideoStream;
        [Export("initWithLocalVideoStream:")]
        IntPtr Constructor(ACSLocalVideoStream localVideoStream);

        // -(instancetype)initWithRemoteVideoStream:(ACSRemoteVideoStream *)remoteVideoStream;
        [Export("initWithRemoteVideoStream:")]
        IntPtr Constructor(ACSRemoteVideoStream remoteVideoStream);

        // -(ACSRendererView *)createView:(ACSRenderingOptions *)options;
        [Export("createView:")]
        ACSRendererView CreateView(ACSRenderingOptions options);

        // -(void)dispose;
        [Export("dispose")]
        void Dispose();

        // @property (readonly) ACSStreamSize * _Nonnull size;
        [Export("size")] ACSStreamSize Size { get; }

        [Wrap("WeakDelegate")] ACSRendererDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<ACSRendererDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol ACSInternalTokenProviderDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface ACSInternalTokenProviderDelegate
    {
        // @optional -(void)onTokenRequested:(ACSInternalTokenProvider *)internalTokenProvider :(ACSInternalTokenProvider *)sender;
        [Abstract]
        [Export("onTokenRequested::")]
        void OnTokenRequested(ACSInternalTokenProvider internalTokenProvider, ACSInternalTokenProvider sender);
    }

    // @protocol ACSCallAgentDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface ACSCallAgentDelegate
    {
        // @optional -(void)onCallsUpdated:(ACSCallAgent *)callAgent :(ACSCallsUpdatedEventArgs *)args;
        [Abstract]
        [Export("onCallsUpdated::")]
        void OnCallsUpdated(ACSCallAgent callAgent, ACSCallsUpdatedEventArgs args);
    }

    // @protocol ACSCallDelegate <NSObject>    
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface ACSCallDelegate
    {
        // @optional -(void)onCallStateChanged:(ACSCall *)call :(ACSPropertyChangedEventArgs *)args;
        [Abstract]
        [Export("onCallStateChanged::")]
        void OnCallStateChanged(ACSCall call, ACSPropertyChangedEventArgs args);

        // @optional -(void)onRemoteParticipantsUpdated:(ACSCall *)call :(ACSParticipantsUpdatedEventArgs *)args;
        [Abstract]
        [Export("onRemoteParticipantsUpdated::")]
        void OnRemoteParticipantsUpdated(ACSCall call, ACSParticipantsUpdatedEventArgs args);

        // @optional -(void)onLocalVideoStreamsChanged:(ACSCall *)call :(ACSLocalVideoStreamsUpdatedEventArgs *)args;
        [Abstract]
        [Export("onLocalVideoStreamsChanged::")]
        void OnLocalVideoStreamsChanged(ACSCall call, ACSLocalVideoStreamsUpdatedEventArgs args);
    }

    // @protocol ACSRemoteParticipantDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface ACSRemoteParticipantDelegate
    {
        // @optional -(void)onParticipantStateChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args;
        [Abstract]
        [Export("onParticipantStateChanged::")]
        void OnParticipantStateChanged(ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsMutedChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args;
		[Export ("onIsMutedChanged::")]
		void OnIsMutedChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);

		// @optional -(void)onIsSpeakingChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args;
		[Export ("onIsSpeakingChanged::")]
		void OnIsSpeakingChanged (ACSRemoteParticipant remoteParticipant, ACSPropertyChangedEventArgs args);
        

        // @optional -(void)onVideoStreamsUpdated:(ACSRemoteParticipant *)remoteParticipant :(ACSRemoteVideoStreamsEventArgs *)args;
        [Abstract]
        [Export("onVideoStreamsUpdated::")]
        void OnVideoStreamsUpdated(ACSRemoteParticipant remoteParticipant, ACSRemoteVideoStreamsEventArgs args);
    }

    // @protocol ACSDeviceManagerDelegate <NSObject>
    [Protocol, Model(AutoGeneratedName = true)]
    [BaseType(typeof(NSObject))]
    interface ACSDeviceManagerDelegate
    {
        // @optional -(void)onAudioDevicesUpdated:(ACSDeviceManager *)deviceManager :(ACSAudioDevicesUpdatedEventArgs *)args;
        [Abstract]
        [Export("onAudioDevicesUpdated::")]
        void OnAudioDevicesUpdated(ACSDeviceManager deviceManager, ACSAudioDevicesUpdatedEventArgs args);

        // @optional -(void)onVideoDevicesUpdated:(ACSDeviceManager *)deviceManager :(ACSVideoDevicesUpdatedEventArgs *)args;
        [Abstract]
        [Export("onVideoDevicesUpdated::")]
        void OnVideoDevicesUpdated(ACSDeviceManager deviceManager, ACSVideoDevicesUpdatedEventArgs args);
    }

    // @interface ACSVideoOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSVideoOptions
    {
        // -(instancetype)init:(ACSLocalVideoStream *)localVideoStream;
        [Export("init:")]
        IntPtr Constructor(ACSLocalVideoStream localVideoStream);

        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (retain) ACSLocalVideoStream * localVideoStream;
        [Export("localVideoStream", ArgumentSemantic.Retain)]
        ACSLocalVideoStream LocalVideoStream { get; set; }
    }

    // @interface ACSLocalVideoStream : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSLocalVideoStream
    {
        // -(instancetype)init:(ACSVideoDeviceInfo *)camera;
        [Export("init:")]
        IntPtr Constructor(ACSVideoDeviceInfo camera);

        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) ACSVideoDeviceInfo * source;
        [Export("source", ArgumentSemantic.Retain)]
        ACSVideoDeviceInfo Source { get; }

        // @property (readonly) BOOL isSending;
        [Export("isSending")] bool IsSending { get; }

        // @property (readonly) ACSMediaStreamType mediaStreamType;
        [Export("mediaStreamType")] ACSMediaStreamType MediaStreamType { get; }

        // -(void)switchSource:(ACSVideoDeviceInfo *)camera withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("switchSource:withCompletionHandler:")]
        void SwitchSource(ACSVideoDeviceInfo camera, Action<NSError> completionHandler);
    }

    // @interface ACSVideoDeviceInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSVideoDeviceInfo
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) NSString * name;
        [Export("name", ArgumentSemantic.Retain)]
        string Name { get; }

        // @property (readonly, retain) NSString * id;
        [Export("id", ArgumentSemantic.Retain)]
        string Id { get; }

        // @property (readonly) ACSCameraFacing cameraFacing;
        [Export("cameraFacing")] ACSCameraFacing CameraFacing { get; }

        // @property (readonly) ACSVideoDeviceType deviceType;
        [Export("deviceType")] ACSVideoDeviceType DeviceType { get; }
    }

    // @interface ACSInternalTokenProvider : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSInternalTokenProvider
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        [Wrap("WeakDelegate")] ACSInternalTokenProviderDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<ACSInternalTokenProviderDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // -(void)setTokenWithToken:(NSString *)token accountIdentity:(NSString *)accountIdentity displayName:(NSString *)displayName resourceId:(NSString *)resourceId;
        [Export("setTokenWithToken:accountIdentity:displayName:resourceId:")]
        void SetTokenWithToken(string token, string accountIdentity, string displayName, string resourceId);

        // -(void)setError:(NSString *)error;
        [Export("setError:")]
        void SetError(string error);
    }

    // @interface ACSAudioOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSAudioOptions
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property BOOL muted;
        [Export("muted")] bool Muted { get; set; }
    }

    // @interface ACSJoinCallOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSJoinCallOptions
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (retain) ACSVideoOptions * videoOptions;
        [Export("videoOptions", ArgumentSemantic.Retain)]
        ACSVideoOptions VideoOptions { get; set; }

        // @property (retain) ACSAudioOptions * audioOptions;
        [Export("audioOptions", ArgumentSemantic.Retain)]
        ACSAudioOptions AudioOptions { get; set; }
    }

    // @interface ACSAcceptCallOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSAcceptCallOptions
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (retain) ACSVideoOptions * videoOptions;
        [Export("videoOptions", ArgumentSemantic.Retain)]
        ACSVideoOptions VideoOptions { get; set; }
    }

    // @interface ACSStartCallOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSStartCallOptions
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (retain) ACSVideoOptions * videoOptions;
        [Export("videoOptions", ArgumentSemantic.Retain)]
        ACSVideoOptions VideoOptions { get; set; }

        // @property (retain) ACSAudioOptions * audioOptions;
        [Export("audioOptions", ArgumentSemantic.Retain)]
        ACSAudioOptions AudioOptions { get; set; }

        // @property (nonatomic) PhoneNumber * _Nonnull alternateCallerID;
        [Export("alternateCallerID", ArgumentSemantic.Assign)]
        PhoneNumber AlternateCallerID { get; set; }
    }

    // @interface ACSAddPhoneNumberOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSAddPhoneNumberOptions
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (nonatomic) PhoneNumber * _Nonnull alternateCallerID;
        [Export("alternateCallerID", ArgumentSemantic.Assign)]
        PhoneNumber AlternateCallerID { get; set; }
    }

    // @interface ACSGroupCallContext : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSGroupCallContext
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (nonatomic) NSUUID * _Nonnull groupId;
        [Export("groupId", ArgumentSemantic.Assign)]
        NSUuid GroupId { get; set; }
    }

    // @interface ACSCallAgent : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSCallAgent
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, copy) NSArray<ACSCall *> * calls;
        [Export("calls", ArgumentSemantic.Copy)]
        ACSCall[] Calls { get; }

        [NullAllowed, Wrap("WeakDelegate")] ACSCallAgentDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<ACSCallAgentDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // -(ACSCall *)joinWithGroupCallContext:(ACSGroupCallContext *)groupCallContext joinCallOptions:(ACSJoinCallOptions *)joinCallOptions;
        [Export("joinWithGroupCallContext:joinCallOptions:")]
        ACSCall JoinWithGroupCallContext(ACSGroupCallContext groupCallContext, ACSJoinCallOptions joinCallOptions);

        // -(void)unRegisterPushNotificationsWithCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("unRegisterPushNotificationsWithCompletionHandler:")]
        void UnRegisterPushNotificationsWithCompletionHandler(Action<NSError> completionHandler);

        // -(ACSCall *)call:(NSArray<id<CommunicationIdentifier>> *)participants options:(ACSStartCallOptions *)options;
        [Export("call:options:")]
        ACSCall Call(CommunicationIdentifier[] participants, ACSStartCallOptions options);

        // -(void)registerPushNotifications:(NSData *)deviceToken withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("registerPushNotifications:withCompletionHandler:")]
        void RegisterPushNotifications(NSData deviceToken, Action<NSError> completionHandler);

        // -(void)handlePushNotification:(NSDictionary *)payload withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("handlePushNotification:withCompletionHandler:")]
        void HandlePushNotification(NSDictionary payload, Action<NSError> completionHandler);
    }

    // @interface ACSCall : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSCall
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, copy) NSArray<ACSRemoteParticipant *> * remoteParticipants;
        [Export("remoteParticipants", ArgumentSemantic.Copy)]
        ACSRemoteParticipant[] RemoteParticipants { get; }

        // @property (readonly, retain) NSString * callId;
        [Export("callId", ArgumentSemantic.Retain)]
        string CallId { get; }

        // @property (readonly) ACSCallState state;
        [Export("state")] ACSCallState State { get; }

        // @property (readonly, retain) ACSCallEndReason * callEndReason;
        [Export("callEndReason", ArgumentSemantic.Retain)]
        ACSCallEndReason CallEndReason { get; }

        // @property (readonly) BOOL isIncoming;
        [Export("isIncoming")] bool IsIncoming { get; }

        // @property (readonly) BOOL isMicrophoneMuted;
        [Export("isMicrophoneMuted")] bool IsMicrophoneMuted { get; }

        // @property (readonly, copy) NSArray<ACSLocalVideoStream *> * localVideoStreams;
        [Export("localVideoStreams", ArgumentSemantic.Copy)]
        ACSLocalVideoStream[] LocalVideoStreams { get; }

        [Wrap("WeakDelegate")] ACSCallDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<ACSCallDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // -(void)muteWithCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("muteWithCompletionHandler:")]
        void MuteWithCompletionHandler(Action<NSError> completionHandler);

        // -(void)unmuteWithCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("unmuteWithCompletionHandler:")]
        void UnmuteWithCompletionHandler(Action<NSError> completionHandler);

        // -(void)sendDtmf:(ACSDtmfTone)tone withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("sendDtmf:withCompletionHandler:")]
        void SendDtmf(ACSDtmfTone tone, Action<NSError> completionHandler);

        // -(void)startVideo:(ACSLocalVideoStream *)stream withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("startVideo:withCompletionHandler:")]
        void StartVideo(ACSLocalVideoStream stream, Action<NSError> completionHandler);

        // -(void)stopVideo:(ACSLocalVideoStream *)stream withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("stopVideo:withCompletionHandler:")]
        void StopVideo(ACSLocalVideoStream stream, Action<NSError> completionHandler);

        // -(void)hangup:(ACSHangupOptions *)options withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("hangup:withCompletionHandler:")]
        void Hangup(ACSHangupOptions options, Action<NSError> completionHandler);

        // -(void)removeParticipant:(ACSRemoteParticipant *)participant withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("removeParticipant:withCompletionHandler:")]
        void RemoveParticipant(ACSRemoteParticipant participant, Action<NSError> completionHandler);

        // -(void)accept:(ACSAcceptCallOptions *)options withCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("accept:withCompletionHandler:")]
        void Accept(ACSAcceptCallOptions options, Action<NSError> completionHandler);

        // -(void)rejectWithCompletionHandler:(void (^)(NSError *))completionHandler;
        [Export("rejectWithCompletionHandler:")]
        void RejectWithCompletionHandler(Action<NSError> completionHandler);

        // @property (nonatomic) id<CommunicationIdentifier> _Nonnull callerId;
        [Export("callerId", ArgumentSemantic.Assign)]
        CommunicationIdentifier CallerId { get; set; }

        // -(ACSRemoteParticipant *)addParticipant:(id<CommunicationIdentifier>)participant;
        [Export("addParticipant:")]
        ACSRemoteParticipant AddParticipant(CommunicationIdentifier participant);

        // -(ACSRemoteParticipant *)addParticipant:(PhoneNumber *)participant options:(ACSAddPhoneNumberOptions *)options;
        [Export("addParticipant:options:")]
        ACSRemoteParticipant AddParticipant(PhoneNumber participant, ACSAddPhoneNumberOptions options);
    }

    // @interface ACSRemoteParticipant : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSRemoteParticipant
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) NSString * displayName;
        [Export("displayName", ArgumentSemantic.Retain)]
        string DisplayName { get; }

        // @property (readonly) BOOL isMuted;
        [Export("isMuted")] bool IsMuted { get; }

        // @property (readonly) BOOL isSpeaking;
        [Export("isSpeaking")] bool IsSpeaking { get; }

        // @property (readonly, retain) ACSCallEndReason * callEndReason;
        [Export("callEndReason", ArgumentSemantic.Retain)]
        ACSCallEndReason CallEndReason { get; }

        // @property (readonly) ACSParticipantState state;
        [Export("state")] ACSParticipantState State { get; }

        // @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * videoStreams;
        [Export("videoStreams", ArgumentSemantic.Copy)]
        ACSRemoteVideoStream[] VideoStreams { get; }

        [Wrap("WeakDelegate")] ACSRemoteParticipantDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<ACSRemoteParticipantDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (nonatomic) id<CommunicationIdentifier> _Nonnull identity;
        [Export("identity", ArgumentSemantic.Assign)]
        CommunicationIdentifier Identity { get; set; }
    }

    // @interface ACSCallEndReason : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSCallEndReason
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly) int code;
        [Export("code")] int Code { get; }

        // @property (readonly) int subcode;
        [Export("subcode")] int Subcode { get; }
    }

    // @interface ACSRemoteVideoStream : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSRemoteVideoStream
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly) BOOL isAvailable;
        [Export("isAvailable")] bool IsAvailable { get; }

        // @property (readonly) ACSMediaStreamType type;
        [Export("type")] ACSMediaStreamType Type { get; }

        // @property (readonly) int id;
        [Export("id")] int Id { get; }
    }

    // @interface ACSPropertyChangedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSPropertyChangedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();
    }

    // @interface ACSRemoteVideoStreamsEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSRemoteVideoStreamsEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * addedRemoteVideoStreams;
        [Export("addedRemoteVideoStreams", ArgumentSemantic.Copy)]
        ACSRemoteVideoStream[] AddedRemoteVideoStreams { get; }

        // @property (readonly, copy) NSArray<ACSRemoteVideoStream *> * removedRemoteVideoStreams;
        [Export("removedRemoteVideoStreams", ArgumentSemantic.Copy)]
        ACSRemoteVideoStream[] RemovedRemoteVideoStreams { get; }
    }

    // @interface ACSParticipantsUpdatedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSParticipantsUpdatedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, copy) NSArray<ACSRemoteParticipant *> * addedParticipants;
        [Export("addedParticipants", ArgumentSemantic.Copy)]
        ACSRemoteParticipant[] AddedParticipants { get; }

        // @property (readonly, copy) NSArray<ACSRemoteParticipant *> * removedParticipants;
        [Export("removedParticipants", ArgumentSemantic.Copy)]
        ACSRemoteParticipant[] RemovedParticipants { get; }
    }

    // @interface ACSLocalVideoStreamsUpdatedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSLocalVideoStreamsUpdatedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, copy) NSArray<ACSLocalVideoStream *> * addedStreams;
        [Export("addedStreams", ArgumentSemantic.Copy)]
        ACSLocalVideoStream[] AddedStreams { get; }

        // @property (readonly, copy) NSArray<ACSLocalVideoStream *> * removedStreams;
        [Export("removedStreams", ArgumentSemantic.Copy)]
        ACSLocalVideoStream[] RemovedStreams { get; }
    }

    // @interface ACSHangupOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSHangupOptions
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property BOOL forEveryone;
        [Export("forEveryone")] bool ForEveryone { get; set; }
    }

    // @interface ACSCallsUpdatedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSCallsUpdatedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, copy) NSArray<ACSCall *> * addedCalls;
        [Export("addedCalls", ArgumentSemantic.Copy)]
        ACSCall[] AddedCalls { get; }

        // @property (readonly, copy) NSArray<ACSCall *> * removedCalls;
        [Export("removedCalls", ArgumentSemantic.Copy)]
        ACSCall[] RemovedCalls { get; }
    }

    // @interface ACSInitializationOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSInitializationOptions
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (retain) NSString * dataPath;
        [Export("dataPath", ArgumentSemantic.Retain)]
        string DataPath { get; set; }

        // @property (retain) NSString * logFileName;
        [Export("logFileName", ArgumentSemantic.Retain)]
        string LogFileName { get; set; }

        // @property BOOL isEncrypted;
        [Export("isEncrypted")] bool IsEncrypted { get; set; }

        // @property BOOL stdoutLogging;
        [Export("stdoutLogging")] bool StdoutLogging { get; set; }
    }

    // @interface ACSCallClient : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSCallClient
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // -(void)getDeviceManagerWithCompletionHandler:(void (^)(ACSDeviceManager *, NSError *))completionHandler;
        [Export("getDeviceManagerWithCompletionHandler:")]
        void GetDeviceManagerWithCompletionHandler(Action<ACSDeviceManager, NSError> completionHandler);

        // -(void)createCallAgent:(CommunicationUserCredential *)userCredential withCompletionHandler:(void (^)(ACSCallAgent *, NSError *))completionHandler;
        [Export("createCallAgent:withCompletionHandler:")]
        void CreateCallAgent(CommunicationUserCredential userCredential,
            Action<ACSCallAgent, NSError> completionHandler);

        // @property (retain) CommunicationUserCredential * _Nonnull communicationCredential;
        [Export("communicationCredential", ArgumentSemantic.Retain)]
        CommunicationUserCredential CommunicationCredential { get; set; }
    }

    // @interface ACSDeviceManager : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSDeviceManager
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) ACSAudioDeviceInfo * microphone;
        [Export("microphone", ArgumentSemantic.Retain)]
        ACSAudioDeviceInfo Microphone { get; }

        // @property (readonly, retain) ACSAudioDeviceInfo * speaker;
        [Export("speaker", ArgumentSemantic.Retain)]
        ACSAudioDeviceInfo Speaker { get; }

        [Wrap("WeakDelegate")] ACSDeviceManagerDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<ACSDeviceManagerDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // -(NSArray<ACSVideoDeviceInfo *> *)getCameraList;
        [Export("getCameraList")] ACSVideoDeviceInfo[] CameraList { get; }

        // -(NSArray<ACSAudioDeviceInfo *> *)getMicrophoneList;
        [Export("getMicrophoneList")] ACSAudioDeviceInfo[] MicrophoneList { get; }

        // -(NSArray<ACSAudioDeviceInfo *> *)getSpeakerList;
        [Export("getSpeakerList")] ACSAudioDeviceInfo[] SpeakerList { get; }

        // -(void)setMicrophone:(ACSAudioDeviceInfo *)microphoneDevice;
        [Export("setMicrophone:")]
        void SetMicrophone(ACSAudioDeviceInfo microphoneDevice);

        // -(void)setSpeaker:(ACSAudioDeviceInfo *)speakerDevice;
        [Export("setSpeaker:")]
        void SetSpeaker(ACSAudioDeviceInfo speakerDevice);
    }

    // @interface ACSAudioDeviceInfo : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSAudioDeviceInfo
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, retain) NSString * name;
        [Export("name", ArgumentSemantic.Retain)]
        string Name { get; }

        // @property (readonly, retain) NSString * id;
        [Export("id", ArgumentSemantic.Retain)]
        string Id { get; }

        // @property (readonly) BOOL isSystemDefault;
        [Export("isSystemDefault")] bool IsSystemDefault { get; }

        // @property (readonly) ACSAudioDeviceType deviceType;
        [Export("deviceType")] ACSAudioDeviceType DeviceType { get; }
    }

    // @interface ACSAudioDevicesUpdatedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSAudioDevicesUpdatedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, copy) NSArray<ACSAudioDeviceInfo *> * addedAudioDevices;
        [Export("addedAudioDevices", ArgumentSemantic.Copy)]
        ACSAudioDeviceInfo[] AddedAudioDevices { get; }

        // @property (readonly, copy) NSArray<ACSAudioDeviceInfo *> * removedAudioDevices;
        [Export("removedAudioDevices", ArgumentSemantic.Copy)]
        ACSAudioDeviceInfo[] RemovedAudioDevices { get; }
    }

    // @interface ACSVideoDevicesUpdatedEventArgs : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSVideoDevicesUpdatedEventArgs
    {
        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * addedVideoDevices;
        [Export("addedVideoDevices", ArgumentSemantic.Copy)]
        ACSVideoDeviceInfo[] AddedVideoDevices { get; }

        // @property (readonly, copy) NSArray<ACSVideoDeviceInfo *> * removedVideoDevices;
        [Export("removedVideoDevices", ArgumentSemantic.Copy)]
        ACSVideoDeviceInfo[] RemovedVideoDevices { get; }
    }

    // @interface ACSRenderingOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface ACSRenderingOptions
    {
        // -(instancetype)init:(ACSScalingMode)scalingMode;
        [Export("init:")]
        IntPtr Constructor(ACSScalingMode scalingMode);

        // -(void)dealloc;
        [Export("dealloc")]
        void Dealloc();

        // @property ACSScalingMode scalingMode;
        [Export("scalingMode", ArgumentSemantic.Assign)]
        ACSScalingMode ScalingMode { get; set; }
    }
}
