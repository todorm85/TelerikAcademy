//
//  Notifications.m
//  ExpenseTracker
//
//  Created by todorm85 on 2/3/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "Notifications.h"

@implementation Notifications
+(void) showAlertNotificationForView: (UIViewController*) view
                            andTitle: (NSString*) title
                          andMessage: (NSString*) msg{
    
    UIAlertController *alertController =
    [UIAlertController alertControllerWithTitle: title
                                        message: msg
                                 preferredStyle: UIAlertControllerStyleAlert];
    UIAlertAction *action = [UIAlertAction actionWithTitle:@"OK" style:UIAlertActionStyleDefault handler:nil];
    [alertController addAction:action];
    [view presentViewController:alertController animated:YES completion: nil];
}
@end
