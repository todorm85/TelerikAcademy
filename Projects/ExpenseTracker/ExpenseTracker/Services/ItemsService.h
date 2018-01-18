//
//  ItemsService.h
//  ExpenseTracker
//
//  Created by todorm85 on 2/1/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Item.h"

@interface ItemsService : NSObject
-(instancetype) init;
-(NSMutableArray*) getAll;
-(NSMutableArray*) getLastTen;
-(BOOL) insertItem: (Item*) item;
-(BOOL) insertManyItems: (NSMutableArray*) items;
-(NSMutableArray*) getFrom: (NSDate*) from
                        andTo:(NSDate*) to
               andLocation: (NSString*) location
                   andPage: (int) page;
-(int) getItemsCountFrom: (NSDate*) from
                         andTo:(NSDate*) to
             andLocation: (NSString*) location;
-(NSString*) getItemsCostFrom: (NSDate*) from
                        andTo:(NSDate*) to
                  andLocation: (NSString*) location;
-(NSDecimalNumber*) getTotalCost:(NSMutableArray*) items;
-(BOOL) removeItem: (Item*) item;
@end
