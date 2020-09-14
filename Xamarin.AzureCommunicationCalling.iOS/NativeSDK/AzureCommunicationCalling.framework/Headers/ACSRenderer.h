//+-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Module name : ACSRenderer.h
//
//------------------------------------------------------------------------------

#import "ACSRendererView.h"
#import "ACSStreamSize.h"

@class ACSLocalVideoStream;
@class ACSRenderingOptions;
@class ACSRemoteVideoStream;

@protocol ACSRendererDelegate <NSObject>
@optional
- (void)onFirstFrameRendered;
@end

@interface ACSRenderer : NSObject
-(instancetype)initWithLocalVideoStream:(ACSLocalVideoStream*) localVideoStream;
-(instancetype)initWithRemoteVideoStream:(ACSRemoteVideoStream*) remoteVideoStream;
-(ACSRendererView*)createView:(ACSRenderingOptions*) options;
-(void)dispose;

@property(readonly, nonnull) ACSStreamSize* size;
@property(nonatomic, assign) id<ACSRendererDelegate> delegate;

@end
