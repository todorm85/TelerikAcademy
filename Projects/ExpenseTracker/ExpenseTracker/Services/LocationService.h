//
//  locationUtils.h
//  ExpenseTracker
//
//  Created by todorm85 on 2/2/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <CoreLocation/CoreLocation.h>

@interface LocationService : NSObject<CLLocationManagerDelegate>

    -(instancetype) init;
    -(void) getAddressStringWithCallback:(void (^)(NSString* locatedAt))callback;

    @property CLLocationManager *locationManager;

@end
