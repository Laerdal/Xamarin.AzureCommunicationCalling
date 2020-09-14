//+-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Module name : ACSRendererView.h
//
//------------------------------------------------------------------------------

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

// Forward declaration as importing here causes cyclic dependency
typedef NS_ENUM(NSInteger, ACSScalingMode);

@interface ACSRendererView : UIView
-(void)updateScalingMode:(ACSScalingMode) scalingMode;
-(void)dispose;
-(bool)isRendering;
@end
