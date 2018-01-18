//
//  locationUtils.m
//  ExpenseTracker
//
//  Created by todorm85 on 2/2/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "LocationService.h"


@implementation LocationService {

}

-(instancetype) init{
    self = [super init];
    if (self) {
        self.locationManager = [[CLLocationManager alloc] init];
        self.locationManager.delegate = self;
        self.locationManager.distanceFilter = kCLDistanceFilterNone;
        self.locationManager.desiredAccuracy = kCLLocationAccuracyBest;
        
        if ([[[UIDevice currentDevice] systemVersion] floatValue] >= 8.0)
            [self.locationManager requestAlwaysAuthorization];
        
        [self.locationManager startUpdatingLocation];
    }
    
    return self;
}

- (void)locationManager:(CLLocationManager *)manager didUpdateLocations:(NSArray *)locations {
    //NSLog(@"%@", [locations lastObject]);
}

-(void) getAddressStringWithCallback:(void (^)(NSString* success))callback{
    
    CLGeocoder *ceo = [[CLGeocoder alloc]init];
    CLLocation *loc = self.locationManager.location;
    
    [ceo reverseGeocodeLocation:loc
     
              completionHandler:^(NSArray *placemarks, NSError *error) {
                  
                  CLPlacemark *placemark = [placemarks objectAtIndex:0];
                  NSString *locatedAt = [[placemark.addressDictionary valueForKey:@"FormattedAddressLines"] componentsJoinedByString:@", "];
                  
                  callback(locatedAt);
                  
              }];
}

@end
