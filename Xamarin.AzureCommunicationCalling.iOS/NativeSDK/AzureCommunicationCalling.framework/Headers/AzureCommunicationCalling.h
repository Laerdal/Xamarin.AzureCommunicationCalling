// SpoolCommonModule
// This file was auto-generated from SpoolApiModel.cs.

#import <Foundation/Foundation.h>

#import <AzureCommunication/AzureCommunication-Swift.h>
#import <AzureCore/AzureCore-Swift.h>
#import "ACSRenderer.h"
#import "ACSRendererView.h"
#import "ACSStreamSize.h"

// Enumerations.
/// Additional failed states for ACS
typedef NS_OPTIONS(NSInteger, ACSCommunicationErrors)
{
    /// No errors
    ACSCommunicationErrorsNone = 0,
    /// No Audio permissions available.
    ACSCommunicationErrorsNoAudioPermission = 1,
    /// No Video permissions available.
    ACSCommunicationErrorsNoVideoPermission = 2,
    /// No Video and Audio permissions available.
    ACSCommunicationErrorsNoAudioAndVideoPermission = 3,
    /// Failed to process push notification payload.
    ACSCommunicationErrorsReceivedInvalidPNPayload = 4,
    /// Recieved empty/invalid notification payload.
    ACSCommunicationErrorsFailedToProcessPNPayload = 8
};

/// Direction of the camera
typedef NS_ENUM(NSInteger, ACSCameraFacing)
{
    /// Unknown
    ACSCameraFacingUnknown = 0,
    /// External device
    ACSCameraFacingExternal = 1,
    /// Front camera
    ACSCameraFacingFront = 2,
    /// Back camera
    ACSCameraFacingBack = 3,
    /// Panoramic camera
    ACSCameraFacingPanoramic = 4,
    /// Left front camera
    ACSCameraFacingLeftFront = 5,
    /// Right front camera
    ACSCameraFacingRightFront = 6
};

/// Describes the video device type
typedef NS_ENUM(NSInteger, ACSVideoDeviceType)
{
    /// Unknown type of video device
    ACSVideoDeviceTypeUnknown = 0,
    /// USB Camera Video Device
    ACSVideoDeviceTypeUsbCamera = 1,
    /// Capture Adapter Video Device
    ACSVideoDeviceTypeCaptureAdapter = 2,
    /// Virtual Video Device
    ACSVideoDeviceTypeVirtual = 3,
    /// Augmented Video Device
    ACSVideoDeviceTypeSRAugmented = 4
};

typedef NS_ENUM(NSInteger, ACSMediaStreamType)
{
    ACSMediaStreamTypeVideo = 0,
    ACSMediaStreamTypeScreenSharing = 1
};

/// State of a participant in the call
typedef NS_ENUM(NSInteger, ACSParticipantState)
{
    /// Idle
    ACSParticipantStateIdle = 0,
    /// Early Media
    ACSParticipantStateEarlyMedia = 1,
    /// Connecting
    ACSParticipantStateConnecting = 2,
    /// Connected
    ACSParticipantStateConnected = 3,
    /// On Hold
    ACSParticipantStateOnHold = 4,
    /// In Lobby
    ACSParticipantStateInLobby = 5,
    /// Disconnected
    ACSParticipantStateDisconnected = 6
};

/// State of a call
typedef NS_ENUM(NSInteger, ACSCallState)
{
    /// None - disposed or applicable very early in lifetime of a call
    ACSCallStateNone = 0,
    /// Early Media
    ACSCallStateEarlyMedia = 1,
    /// Call is incoming state. Local participant should be ringing
    ACSCallStateIncoming = 2,
    /// Call is being connected
    ACSCallStateConnecting = 3,
    /// Call is ringing the remote participant
    ACSCallStateRinging = 4,
    /// Call is connected
    ACSCallStateConnected = 5,
    /// On Hold
    ACSCallStateHold = 6,
    /// Call is being disconnected
    ACSCallStateDisconnecting = 7,
    /// Call is disconnected
    ACSCallStateDisconnected = 8
};

/// DTMF tone for PSTN calls
typedef NS_ENUM(NSInteger, ACSDtmfTone)
{
    /// Zero
    ACSDtmfToneZero = 0,
    /// One
    ACSDtmfToneOne = 1,
    /// Two
    ACSDtmfToneTwo = 2,
    /// Three
    ACSDtmfToneThree = 3,
    /// Four
    ACSDtmfToneFour = 4,
    /// Five
    ACSDtmfToneFive = 5,
    /// Six
    ACSDtmfToneSix = 6,
    /// Seven
    ACSDtmfToneSeven = 7,
    /// Eight
    ACSDtmfToneEight = 8,
    /// Nine
    ACSDtmfToneNine = 9,
    /// Star
    ACSDtmfToneStar = 10,
    /// Pound
    ACSDtmfTonePound = 11,
    /// A
    ACSDtmfToneA = 12,
    /// B
    ACSDtmfToneB = 13,
    /// C
    ACSDtmfToneC = 14,
    /// D
    ACSDtmfToneD = 15,
    /// Flash
    ACSDtmfToneFlash = 16
};

/// Type of audio device
typedef NS_ENUM(NSInteger, ACSAudioDeviceType)
{
    /// Audio device is a microphone
    ACSAudioDeviceTypeMicrophone = 0,
    /// Audio device is a speaker
    ACSAudioDeviceTypeSpeaker = 1
};

typedef NS_ENUM(NSInteger, ACSScalingMode)
{
    ACSScalingModeCrop = 1,
    ACSScalingModeFit = 2
};

typedef NS_ENUM(NSInteger, ACSCompositeAudioDeviceType)
{
    ACSCompositeAudioDeviceTypeSpeakers = 0,
    ACSCompositeAudioDeviceTypeHeadphones = 1,
    ACSCompositeAudioDeviceTypeHeadset = 2,
    ACSCompositeAudioDeviceTypeHandset = 3,
    ACSCompositeAudioDeviceTypeSpeakerphone = 4
};

// MARK: Forward declarations.
@class ACSVideoOptions;
@class ACSLocalVideoStream;
@class ACSVideoDeviceInfo;
@class ACSInternalTokenProvider;
@class ACSAudioOptions;
@class ACSJoinCallOptions;
@class ACSAcceptCallOptions;
@class ACSStartCallOptions;
@class ACSAddPhoneNumberOptions;
@class ACSGroupCallContext;
@class ACSSourceInfo;
@class ACSCallAgent;
@class ACSCall;
@class ACSRemoteParticipant;
@class ACSAcsError;
@class ACSRemoteVideoStream;
@class ACSPropertyChangedEventArgs;
@class ACSRemoteVideoStreamsEventArgs;
@class ACSParticipantsUpdatedEventArgs;
@class ACSLocalVideoStreamsUpdatedEventArgs;
@class ACSHangupOptions;
@class ACSCallsUpdatedEventArgs;
@class ACSInitializationOptions;
@class ACSCallClient;
@class ACSDeviceManager;
@class ACSAudioDeviceInfo;
@class ACSAudioDevicesUpdatedEventArgs;
@class ACSVideoDevicesUpdatedEventArgs;
@class ACSRenderingOptions;
@class ACSCompositeAudioDeviceInfo;
@protocol ACSInternalTokenProviderDelegate;
@protocol ACSCallAgentDelegate;
@protocol ACSCallDelegate;
@protocol ACSRemoteParticipantDelegate;
@protocol ACSDeviceManagerDelegate;

/**
 * A set of methods that are called by ACSInternalTokenProvider in response to important events.
 */
@protocol ACSInternalTokenProviderDelegate <NSObject>
@optional
- (void)onTokenRequested:(ACSInternalTokenProvider *)internalTokenProvider :(ACSInternalTokenProvider *)sender;
@end

/**
 * A set of methods that are called by ACSCallAgent in response to important events.
 */
@protocol ACSCallAgentDelegate <NSObject>
@optional
- (void)onCallsUpdated:(ACSCallAgent *)callAgent :(ACSCallsUpdatedEventArgs *)args;
@end

/**
 * A set of methods that are called by ACSCall in response to important events.
 */
@protocol ACSCallDelegate <NSObject>
@optional
- (void)onCallStateChanged:(ACSCall *)call :(ACSPropertyChangedEventArgs *)args;
- (void)onRemoteParticipantsUpdated:(ACSCall *)call :(ACSParticipantsUpdatedEventArgs *)args;
- (void)onLocalVideoStreamsChanged:(ACSCall *)call :(ACSLocalVideoStreamsUpdatedEventArgs *)args;
@end

/**
 * A set of methods that are called by ACSRemoteParticipant in response to important events.
 */
@protocol ACSRemoteParticipantDelegate <NSObject>
@optional
- (void)onParticipantStateChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args;
- (void)onVideoStreamsUpdated:(ACSRemoteParticipant *)remoteParticipant :(ACSRemoteVideoStreamsEventArgs *)args;
- (void)onScreenSharingStreamsUpdated:(ACSRemoteParticipant *)remoteParticipant :(ACSRemoteVideoStreamsEventArgs *)args;
@end

/**
 * A set of methods that are called by ACSDeviceManager in response to important events.
 */
@protocol ACSDeviceManagerDelegate <NSObject>
@optional
- (void)onAudioDevicesUpdated:(ACSDeviceManager *)deviceManager :(ACSAudioDevicesUpdatedEventArgs *)args;
- (void)onVideoDevicesUpdated:(ACSDeviceManager *)deviceManager :(ACSVideoDevicesUpdatedEventArgs *)args;
@end

/// Video options in CallOptions
@interface ACSVideoOptions : NSObject
-(instancetype)init:(ACSLocalVideoStream *)localVideoStream;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Video device info which can be fetched from DeviceManager
@property (retain) ACSLocalVideoStream * localVideoStream;

@end

/// Local video stream information
@interface ACSLocalVideoStream : NSObject
-(instancetype)init:(ACSVideoDeviceInfo *)camera;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (retain, readonly) ACSVideoDeviceInfo * source;

@property (readonly) BOOL isSending;

@property (readonly) ACSMediaStreamType mediaStreamType;

// Class extension begins for LocalVideoStream.
-(void)switchSource:(ACSVideoDeviceInfo *)camera withCompletionHandler:(void (^)(NSError *error))completionHandler;
// Class extension ends for LocalVideoStream.

@end

/// Information about a video device
@interface ACSVideoDeviceInfo : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Get the name of this video device.
@property (retain, readonly) NSString * name;

/// Get Name of this audio device.
@property (retain, readonly) NSString * id;

/// Direction of the camera
@property (readonly) ACSCameraFacing cameraFacing;

/// Get the Device Type of this video device.
@property (readonly) ACSVideoDeviceType deviceType;

@end

@interface ACSInternalTokenProvider : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/**
 * The delegate that will handle events from the ACSInternalTokenProvider.
 */
@property(nonatomic, assign) id<ACSInternalTokenProviderDelegate> delegate;

-(void)setTokenWithToken:(NSString *)token accountIdentity:(NSString *)accountIdentity displayName:(NSString *)displayName;

-(void)setError:(NSString *)error;

@end

/// Audio options provided when accepting an incoming call or making an outgoing call
@interface ACSAudioOptions : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Start an outgoing or accept incoming call muted (true) or un-muted(false)
@property BOOL muted;

@end

/// Options to be passed when joining a call
@interface ACSJoinCallOptions : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Video options when placing a call
@property (retain) ACSVideoOptions * videoOptions;

/// Audio options when placing a call
@property (retain) ACSAudioOptions * audioOptions;

@end

/// Options to be passed when accepting a call
@interface ACSAcceptCallOptions : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Video options when accepting a call
@property (retain) ACSVideoOptions * videoOptions;

@end

/// Options to be passed when starting a call
@interface ACSStartCallOptions : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (retain) ACSVideoOptions * videoOptions;

@property (retain) ACSAudioOptions * audioOptions;

// Class extension begins for StartCallOptions.
@property(nonatomic, nonnull) PhoneNumber* alternateCallerID;
// Class extension ends for StartCallOptions.

@end

/// Options when making an outgoing PSTN call
@interface ACSAddPhoneNumberOptions : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

// Class extension begins for AddPhoneNumberOptions.
@property(nonatomic, nonnull) PhoneNumber* alternateCallerID;
// Class extension ends for AddPhoneNumberOptions.

@end

/// Options for joining a group call
@interface ACSGroupCallContext : NSObject
-(instancetype)init:(NSString *)groupId;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (retain, readonly) NSString * groupId;

@end

@interface ACSSourceInfo : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

@end

/// Call client created by the create factory method
@interface ACSCallAgent : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Get all the active calls.
@property (copy, readonly) NSArray<ACSCall *> * calls;

/**
 * The delegate that will handle events from the ACSCallAgent.
 */
@property(nonatomic, assign) id<ACSCallAgentDelegate> delegate;

/// Join an call using GroupCallContext
-(ACSCall *)joinWithGroupCallContext:(ACSGroupCallContext *)groupCallContext joinCallOptions:(ACSJoinCallOptions *)joinCallOptions;

-(void)unRegisterPushNotificationsWithCompletionHandler:(void (^)(NSError *error))completionHandler;

// Class extension begins for CallAgent.
-(ACSCall *)call:(NSArray<id<CommunicationIdentifier>> *)participants
         options:(ACSStartCallOptions *)options;
-(void)registerPushNotifications: (NSData *)deviceToken withCompletionHandler:(void (^)(NSError *error))completionHandler;
-(void)handlePushNotification: (NSDictionary *)payload withCompletionHandler:(void (^)(NSError *error))completionHandler;
// Class extension ends for CallAgent.

@end

/// Describes a call
@interface ACSCall : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Get a list of remote participants in this call.
@property (copy, readonly) NSArray<ACSRemoteParticipant *> * remoteParticipants;

/// Id of the call
@property (retain, readonly) NSString * callId;

/// Current state of the call
@property (readonly) ACSCallState state;

/// Containing code/subcode indicating how call ended
@property (retain, readonly) ACSAcsError * callEndReason;

/// True if the call is an incoming call
@property (readonly) BOOL isIncoming;

/// Whether this local microphone is muted.
@property (readonly) BOOL isMicrophoneMuted;

@property (copy, readonly) NSArray<ACSLocalVideoStream *> * localVideoStreams;

/**
 * The delegate that will handle events from the ACSCall.
 */
@property(nonatomic, assign) id<ACSCallDelegate> delegate;

/// Mute local microphone.
-(void)muteWithCompletionHandler:(void (^)(NSError *error))completionHandler;

/// Unmute local microphone.
-(void)unmuteWithCompletionHandler:(void (^)(NSError *error))completionHandler;

/// Send DTMF tone
-(void)sendDtmf:(ACSDtmfTone)tone withCompletionHandler:(void (^)(NSError *error))completionHandler;

/// Start sharing video stream to the call
-(void)startVideo:(ACSLocalVideoStream *)stream withCompletionHandler:(void (^)(NSError *error))completionHandler;

/// Stop sharing video stream to the call
-(void)stopVideo:(ACSLocalVideoStream *)stream withCompletionHandler:(void (^)(NSError *error))completionHandler;

/// Hangup
-(void)hangup:(ACSHangupOptions *)options withCompletionHandler:(void (^)(NSError *error))completionHandler;

-(void)removeParticipant:(ACSRemoteParticipant *)participant withCompletionHandler:(void (^)(NSError *error))completionHandler;

-(void)accept:(ACSAcceptCallOptions *)options withCompletionHandler:(void (^)(NSError *error))completionHandler;

/// Reject this incoming call
-(void)rejectWithCompletionHandler:(void (^)(NSError *error))completionHandler;

// Class extension begins for Call.
@property(nonatomic, nonnull) id<CommunicationIdentifier> callerId;
-(ACSRemoteParticipant *)addParticipant:(id<CommunicationIdentifier>)participant;
-(ACSRemoteParticipant *)addParticipant:(PhoneNumber*) participant
                                options:(ACSAddPhoneNumberOptions *)options;
// Class extension ends for Call.

@end

/// Describes a remote participant
@interface ACSRemoteParticipant : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Private Preview Only: Display Name of the remote participant
@property (retain, readonly) NSString * displayName;

/// True if the remote participant is muted
@property (readonly) BOOL isMuted;

/// True if the remote participant is speaking
@property (readonly) BOOL isSpeaking;

/// Reason why participant left the call, contains code/subcode.
@property (retain, readonly) ACSAcsError * callEndReason;

/// Current state of the remote participant
@property (readonly) ACSParticipantState state;

@property (copy, readonly) NSArray<ACSRemoteVideoStream *> * videoStreams;

@property (copy, readonly) NSArray<ACSRemoteVideoStream *> * screenSharingStreams;

/**
 * The delegate that will handle events from the ACSRemoteParticipant.
 */
@property(nonatomic, assign) id<ACSRemoteParticipantDelegate> delegate;

// Class extension begins for RemoteParticipant.
@property(nonatomic, nonnull) id<CommunicationIdentifier> identity;
// Class extension ends for RemoteParticipant.

@end

/// Describes the reason for a call end
@interface ACSAcsError : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// The code
@property (readonly) int code;

/// The subcode
@property (readonly) int subcode;

@end

/// Video stream on remote participant (NOT SUPPORTED)
@interface ACSRemoteVideoStream : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (readonly) BOOL isAvailable;

@property (readonly) ACSMediaStreamType type;

@property (readonly) int id;


@end

@interface ACSPropertyChangedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

@end

/// Information about remote video streams added or removed (NOT SUPPORTED)
@interface ACSRemoteVideoStreamsEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (copy, readonly) NSArray<ACSRemoteVideoStream *> * addedRemoteVideoStreams;

@property (copy, readonly) NSArray<ACSRemoteVideoStream *> * removedRemoteVideoStreams;

@end

/// Describes a ParticipantsUpdated event
@interface ACSParticipantsUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Participants that were added
@property (copy, readonly) NSArray<ACSRemoteParticipant *> * addedParticipants;

/// Participants that were removed
@property (copy, readonly) NSArray<ACSRemoteParticipant *> * removedParticipants;

@end

@interface ACSLocalVideoStreamsUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (copy, readonly) NSArray<ACSLocalVideoStream *> * addedStreams;

@property (copy, readonly) NSArray<ACSLocalVideoStream *> * removedStreams;

@end

/// Hangup options
@interface ACSHangupOptions : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property BOOL forEveryone;

@end

/// Describes a CallsUpdated event
@interface ACSCallsUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// New calls being tracked by the library
@property (copy, readonly) NSArray<ACSCall *> * addedCalls;

/// Calls that are no longer tracked by the library
@property (copy, readonly) NSArray<ACSCall *> * removedCalls;

@end

@interface ACSInitializationOptions : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Path where logs should be saved on the disk
@property (retain) NSString * dataPath;

/// Name of the log file
@property (retain) NSString * logFileName;

/// Private Preview Only: Enable log encryption
@property BOOL isEncrypted;

/// Private Preview Only: Enable STDOUT logging
@property BOOL stdoutLogging;

@end

@interface ACSCallClient : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

-(void)getDeviceManagerWithCompletionHandler:(void (^)(ACSDeviceManager * value, NSError *error))completionHandler;

// Class extension begins for CallClient.
-(void)createCallAgent:(CommunicationUserCredential *) userCredential
                        withCompletionHandler:(void (^)(ACSCallAgent *clientAgent, NSError *error))completionHandler;
@property (retain, nonnull) CommunicationUserCredential* communicationCredential;
// Class extension ends for CallClient.

@end

/// Device manager
@interface ACSDeviceManager : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Gets the currently selected microphone
@property (retain, readonly) ACSAudioDeviceInfo * microphone;

/// Gets the currently selected speaker
@property (retain, readonly) ACSAudioDeviceInfo * speaker;

/**
 * The delegate that will handle events from the ACSDeviceManager.
 */
@property(nonatomic, assign) id<ACSDeviceManagerDelegate> delegate;

/// Get the list of currently connected video devices
-(NSArray<ACSVideoDeviceInfo *> *)getCameraList;

/// Get the list of currently connected microphones
-(NSArray<ACSAudioDeviceInfo *> *)getMicrophoneList;

/// Get the list of currently connected speakers
-(NSArray<ACSAudioDeviceInfo *> *)getSpeakerList;

/// Set the microphone to be used for all active calls
-(void)setMicrophone:(ACSAudioDeviceInfo *)microphoneDevice;

/// Set the speakers to be used for all active calls
-(void)setSpeakers:(ACSAudioDeviceInfo *)speakersDevice;

@end

/// Information about an audio device
@interface ACSAudioDeviceInfo : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Get the name of this audio device.
@property (retain, readonly) NSString * name;

/// Get Id of this audio device.
@property (retain, readonly) NSString * id;

/// True if device is a system default
@property (readonly) BOOL isSystemDefault;

/// Get the type of this audio device.
@property (readonly) ACSAudioDeviceType deviceType;

@end

/// Audio devices added or removed
@interface ACSAudioDevicesUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (copy, readonly) NSArray<ACSAudioDeviceInfo *> * addedAudioDevices;

@property (copy, readonly) NSArray<ACSAudioDeviceInfo *> * removedAudioDevices;

@end

/// Video devices added or removed
@interface ACSVideoDevicesUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (copy, readonly) NSArray<ACSVideoDeviceInfo *> * addedVideoDevices;

@property (copy, readonly) NSArray<ACSVideoDeviceInfo *> * removedVideoDevices;

@end

@interface ACSRenderingOptions : NSObject
-(instancetype)init:(ACSScalingMode)scalingMode;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property ACSScalingMode scalingMode;

@end

/// Composite audio device info (NOT_SUPPORTED)
@interface ACSCompositeAudioDeviceInfo : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

@property (retain, readonly) ACSAudioDeviceInfo * microphone;

@property (retain, readonly) ACSAudioDeviceInfo * speakers;

@property (readonly) BOOL isPcInternalDevice;

@property (readonly) ACSCompositeAudioDeviceType compositeAudioDeviceType;

@end

