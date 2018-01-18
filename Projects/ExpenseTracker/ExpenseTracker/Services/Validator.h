//
//  Validator.h
//  ExpenseTracker
//
//  Created by todorm85 on 2/3/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import "Item.h"

@interface Validator : NSObject
    +(BOOL) validateItemName: (NSString*) name
                     andCost: (NSDecimalNumber*) cost
            inViewController: (UIViewController*) vc;
@end
