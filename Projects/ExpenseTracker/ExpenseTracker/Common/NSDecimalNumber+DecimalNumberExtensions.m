//
//  NSDecimalNumber+DecimalNumberExtensions.m
//  ExpenseTracker
//
//  Created by todorm85 on 1/31/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "NSDecimalNumber+DecimalNumberExtensions.h"

@implementation NSDecimalNumber (DecimalNumberExtensions)

+(instancetype) decimalFromString: (NSString*) str
{
    // check if integer is present
    if (![str containsString:@"."]) {
        str = [str stringByAppendingString:@".0"];
    }
    
    
    NSError *error = NULL;
    NSRegularExpression *regex =
    [NSRegularExpression regularExpressionWithPattern: @"^(?:|0|[1-9]\\d*)\\.(?:\\d*)?$"
                                              options:0
                                                error:&error];
    
    NSUInteger numberOfMatches =
    [regex numberOfMatchesInString:str
                           options:0
                             range:NSMakeRange(0, [str length])]; // Check full string
    
    if (numberOfMatches > 0) {
        NSDecimalNumber* decimalNumber = [NSDecimalNumber decimalNumberWithString:str];
        return decimalNumber;
    }

    return nil;
}

@end
