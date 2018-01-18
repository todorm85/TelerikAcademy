//
//  Validator.m
//  ExpenseTracker
//
//  Created by todorm85 on 2/3/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "Validator.h"
#import "Notifications.h"

@implementation Validator
+(BOOL) validateItemName: (NSString*) name
                 andCost: (NSDecimalNumber*) cost
        inViewController: (UIViewController*) vc{

    if ([name isEqualToString:@""] || name == nil ) {
        [Notifications showAlertNotificationForView:vc
                                           andTitle:@"Error"
                                         andMessage:@"Name cannot be empty"];
        return NO;
    }
    
    if (!cost) {
        [Notifications showAlertNotificationForView:vc
                                           andTitle:@"Error"
                                         andMessage:@"Cost must be a valid number: 5, 5.34, .34, 0.34 etc."];
        return NO;
    }
    
    if (cost < 0) {
        [Notifications showAlertNotificationForView:vc
                                           andTitle:@"Error"
                                         andMessage:@"Cost must be positive."];
        return NO;
    }
    
    return YES;
}
@end
