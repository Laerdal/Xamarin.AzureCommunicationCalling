// ACSCallingShared
// This file was auto-generated from ACSCallingModel.cs.

#import <Foundation/Foundation.h>

#import "../../AzureCommunication.framework/Headers/AzureCommunication-Swift.h"
#import "../../AzureCore.framework/Headers/AzureCore-Swift.h"
#import "ACSRenderer.h"
#import "ACSRendererView.h"
#import "ACSStreamSize.h"

// Enumerations.
/// Additional failed states for Azure Communication Services
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
    ACSCommunicationErrorsFailedToProcessPNPayload = 8,
    /// Recieved invalid group Id.
    ACSCommunicationErrorsInvalidGuidGroupId = 16,
    /// Push notification device registration token is invalid.
    ACSCommunicationErrorsInvalidPNDeviceRegistrationToken = 32
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

/// Local and Remote Video Stream types
typedef NS_ENUM(NSInteger, ACSMediaStreamType)
{
    /// Video
    ACSMediaStreamTypeVideo = 0,
    /// Screen share
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

/// DTMF (Dual-Tone Multi-Frequency) tone for PSTN calls
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

/// Local and Remote Video scaling mode
typedef NS_ENUM(NSInteger, ACSScalingMode)
{
    /// Cropped
    ACSScalingModeCrop = 1,
    /// Fitted
    ACSScalingModeFit = 2
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
@class ACSCallAgent;
@class ACSCall;
@class ACSRemoteParticipant;
@class ACSCallEndReason;
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
- (void)onIsMutedChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args;
- (void)onIsSpeakingChanged:(ACSRemoteParticipant *)remoteParticipant :(ACSPropertyChangedEventArgs *)args;
- (void)onVideoStreamsUpdated:(ACSRemoteParticipant *)remoteParticipant :(ACSRemoteVideoStreamsEventArgs *)args;
@end

/**
 * A set of methods that are called by ACSDeviceManager in response to important events.
 */
@protocol ACSDeviceManagerDelegate <NSObject>
@optional
- (void)onAudioDevicesUpdated:(ACSDeviceManager *)deviceManager :(ACSAudioDevicesUpdatedEventArgs *)args;
- (void)onVideoDevicesUpdated:(ACSDeviceManager *)deviceManager :(ACSVideoDevicesUpdatedEventArgs *)args;
@end

/// Property bag class for Video Options. Use this class to set video options required during a call (start/accept/join)
@interface ACSVideoOptions : NSObject
-(instancetype)init:(ACSLocalVideoStream *)localVideoStream;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// The video stream that is used to render the video on the UI surface
@property (retain) ACSLocalVideoStream * localVideoStream;

@end

/// Local video stream information
@interface ACSLocalVideoStream : NSObject
-(instancetype)init:(ACSVideoDeviceInfo *)camera;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Video device to use as source for local video.
@property (retain, readonly) ACSVideoDeviceInfo * source;

/// Sets to True when the local video stream is being sent on a call.
@property (readonly) BOOL isSending;

/// Video stream type being used for the current stream.
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

/// Internal Use Only. Should not be used publicly. Will be removed in the future.
@interface ACSInternalTokenProvider : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/**
 * The delegate that will handle events from the ACSInternalTokenProvider.
 */
@property(nonatomic, assign) id<ACSInternalTokenProviderDelegate> delegate;

/// Exclusively for Internal. Do not use publicly. Will be removed in the future.
-(void)setTokenWithToken:(NSString *)token accountIdentity:(NSString *)accountIdentity displayName:(NSString *)displayName resourceId:(NSString *)resourceId;

/// Exclusively for Internal. Do not use publicly. Will be removed in the future.
-(void)setError:(NSString *)error;

@end

/// Property bag class for Audio Options. Use this class to set audio settings required during a call (start/join)
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

/// Video options when starting a call
@property (retain) ACSVideoOptions * videoOptions;

/// Audio options when starting a call
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
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

// Class extension begins for GroupCallContext.
@property(nonatomic, nonnull) NSUUID* groupId;
// Class extension ends for GroupCallContext.

@end

/// Call agent created by the CallClient factory method createCallAgent It bears the responsibility of managing calls on behalf of the authenticated user
@interface ACSCallAgent : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Returns the list of all active calls.
@property (copy, readonly) NSArray<ACSCall *> * calls;

/**
 * The delegate that will handle events from the ACSCallAgent.
 */
@property(nonatomic, assign) id<ACSCallAgentDelegate> delegate;

/// Join a call using GroupCallContext
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

/// Get a list of remote participants in the current call.
@property (copy, readonly) NSArray<ACSRemoteParticipant *> * remoteParticipants;

/// Id of the call
@property (retain, readonly) NSString * callId;

/// Current state of the call
@property (readonly) ACSCallState state;

/// Containing code/subcode indicating how a call has ended
@property (retain, readonly) ACSCallEndReason * callEndReason;

/// True if the call is an incoming call
@property (readonly) BOOL isIncoming;

/// Whether the local microphone is muted or not.
@property (readonly) BOOL isMicrophoneMuted;

/// Get a list of local video streams in the current call.
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

/// Hangup a call
-(void)hangup:(ACSHangupOptions *)options withCompletionHandler:(void (^)(NSError *error))completionHandler;

/// Remove a participant from a call
-(void)removeParticipant:(ACSRemoteParticipant *)participant withCompletionHandler:(void (^)(NSError *error))completionHandler;

/// Accept an incoming call
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

/// Describes a remote participant on a call
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
@property (retain, readonly) ACSCallEndReason * callEndReason;

/// Current state of the remote participant
@property (readonly) ACSParticipantState state;

/// Remote Video streams part of the current call
@property (copy, readonly) NSArray<ACSRemoteVideoStream *> * videoStreams;

/**
 * The delegate that will handle events from the ACSRemoteParticipant.
 */
@property(nonatomic, assign) id<ACSRemoteParticipantDelegate> delegate;

// Class extension begins for RemoteParticipant.
@property(nonatomic, nonnull) id<CommunicationIdentifier> identity;
// Class extension ends for RemoteParticipant.

@end

/// Describes the reason for a call to end
@interface ACSCallEndReason : NSObject
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

/// True when remote video stream is available.
@property (readonly) BOOL isAvailable;

/// MediaStream type of the current remote video stream (Video or ScreenShare).
@property (readonly) ACSMediaStreamType type;

/// Unique Identifier of the current remote video stream.
@property (readonly) int id;


@end

/// Describes a PropertyChanged event data
@interface ACSPropertyChangedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

@end

/// Information about remote video streams added or removed (NOT SUPPORTED)
@interface ACSRemoteVideoStreamsEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Remote video streams that have been added to the current call
@property (copy, readonly) NSArray<ACSRemoteVideoStream *> * addedRemoteVideoStreams;

/// Remote video streams that are no longer part of the current call
@property (copy, readonly) NSArray<ACSRemoteVideoStream *> * removedRemoteVideoStreams;

@end

/// Describes a ParticipantsUpdated event data
@interface ACSParticipantsUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// List of Participants that were added
@property (copy, readonly) NSArray<ACSRemoteParticipant *> * addedParticipants;

/// List of Participants that were removed
@property (copy, readonly) NSArray<ACSRemoteParticipant *> * removedParticipants;

@end

/// Describes a LocalVideoStreamsUpdated event data
@interface ACSLocalVideoStreamsUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// List of LocalVideoStream that were added
@property (copy, readonly) NSArray<ACSLocalVideoStream *> * addedStreams;

/// List of LocalVideoStream that were removed
@property (copy, readonly) NSArray<ACSLocalVideoStream *> * removedStreams;

@end

/// Property bag class for hanging up a call
@interface ACSHangupOptions : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Use to determine whether the current call should be terminated for all participant on the call or not
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

/// Property bag class as container for SDK initialization options.
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

/// Private Preview Only: Enable STDOUT logging. Disabled by default.
@property BOOL stdoutLogging;

@end

/// This is the main class representing the entrypoint for the Calling SDK.
@interface ACSCallClient : NSObject
-(instancetype)init;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Gets a device manager object that can be used to enumerates audio and video devices available for calls.
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
-(void)setSpeaker:(ACSAudioDeviceInfo *)speakerDevice;

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

/// Describes a AudioDevicesUpdated event data
@interface ACSAudioDevicesUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// List of AudioDevices that were added
@property (copy, readonly) NSArray<ACSAudioDeviceInfo *> * addedAudioDevices;

/// List of AudioDevices that were removed
@property (copy, readonly) NSArray<ACSAudioDeviceInfo *> * removedAudioDevices;

@end

/// Describes a VideoDevicesUpdated event data
@interface ACSVideoDevicesUpdatedEventArgs : NSObject
/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Video devicesRemote video streams that have been added to the current call
@property (copy, readonly) NSArray<ACSVideoDeviceInfo *> * addedVideoDevices;

/// Remote video streams that have been added to the current call
@property (copy, readonly) NSArray<ACSVideoDeviceInfo *> * removedVideoDevices;

@end

/// Options to be passed when rendering a Video
@interface ACSRenderingOptions : NSObject
-(instancetype)init:(ACSScalingMode)scalingMode;

/// Deallocates the memory occupied by this object.
-(void)dealloc;

/// Scaling mode for rendering the video.
@property ACSScalingMode scalingMode;

@end

