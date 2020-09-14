//
//  ACSIdentifiers.h
//  AzureCommunicationCalling
//
//  Created by Sanath Rao on 8/25/20.
//

#ifndef ACSIdentifiers_h
#define ACSIdentifiers_h

#import <Foundation/Foundation.h>
#import <AzureCommunication/AzureCommunication-Swift.h>

@interface ACSIdentifiers : NSObject

-(id<CommunicationIdentifier>) fromMri: (NSString*) identifier;
-(NSString*) toMRI: (id<CommunicationIdentifier>) communicationIdentifier;
-(NSArray<NSString *> *) toMRIs: (NSArray<id<CommunicationIdentifier>> *) identifiers;
@end


#endif /* ACSIdentifiers_h */
