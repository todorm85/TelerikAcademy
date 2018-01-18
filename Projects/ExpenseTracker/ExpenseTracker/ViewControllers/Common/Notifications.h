//
//  Notifications.h
//  ExpenseTracker
//
//  Created by todorm85 on 2/3/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface Notifications : NSObject
    +(void) showAlertNotificationForView: (UIViewController*) view
                                andTitle: (NSString*) title
                              andMessage: (NSString*) msg;
@end
