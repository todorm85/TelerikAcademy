//
//  Item.h
//  ExpenseTracker
//
//  Created by todorm85 on 1/31/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Item : NSObject

@property (strong, nonatomic) NSString* id;
@property (strong, nonatomic) NSString* name;
@property (strong, nonatomic) NSString* location;
@property (strong, nonatomic) NSDecimalNumber* cost;
@property (strong, nonatomic) NSString* date;

-(instancetype)initWithName:(NSString *)name
                    andCost:(NSDecimalNumber*)cost
                andLocation:(NSString*)location;

@end
