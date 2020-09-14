//+-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// Module name : ACSStreamSize.h
//
//------------------------------------------------------------------------------

#import <Foundation/Foundation.h>

@interface ACSStreamSize : NSObject
-(instancetype)initWithWidth:(int) width
                      height:(int) height;
@property(readonly) int width;
@property(readonly) int height;
@end
