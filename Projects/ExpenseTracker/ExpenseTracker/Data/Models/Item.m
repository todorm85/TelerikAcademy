//
//  Item.m
//  ExpenseTracker
//
//  Created by todorm85 on 1/31/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "Item.h"

@implementation Item {
    NSString* _name;
    NSDecimalNumber* _cost;
    NSString* _location;
}

-(NSString*) location{
    return _location;
}

-(void) setLocation:(NSString*) location{
    if (location == nil || [location  isEqual: @""]) {
        location = @"Unknown location";
    }
    _location = location;
}

-(NSString*) name{
    return _name;
}

-(void) setName:(NSString*) name{
    if (name == nil || [name  isEqual: @""]) {
        NSException *ex = [[NSException alloc] initWithName:@"Name out of range" reason:@"Name cannot be empty." userInfo:nil];
        
        [ex raise];
    }
    
    _name = name;
}

-(NSDecimalNumber*) cost{
    return _cost;
}

-(void) setCost:(NSDecimalNumber*) cost{
    if (cost < 0) {
        NSException *ex = [[NSException alloc] initWithName:@"Cost out of range" reason:@"Cost cannot be negative." userInfo:nil];
        
        [ex raise];
    }
    
    _cost = cost;
}

-(instancetype)initWithName:(NSString *)name
                    andCost:(NSDecimalNumber*)cost
                andLocation:(NSString*)location{
    if (self = [super init]) {
        self.name = name;
        self.cost = cost;
        self.location = location;
        return self;
    }
    
    return nil;
}

@end
