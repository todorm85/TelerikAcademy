//
//  ItemsService.m
//  ExpenseTracker
//
//  Created by todorm85 on 2/1/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "ItemsService.h"
#import "Item.h"
#import "DBManager.h"

@interface ItemsService()

@property (nonatomic, strong) DBManager *dbManager;

@end

@implementation ItemsService

-(instancetype) init {
    self = [super init];
    if (self) {
        self.dbManager = [[DBManager alloc] initWithDatabaseFilename:@"items.sqlite"];
    }
    
    return self;
}

-(NSMutableArray*) loadItems:(NSString*) query {
    NSMutableArray* items = [NSMutableArray arrayWithArray:@[]];
    NSArray *results = [[NSArray alloc] initWithArray:[self.dbManager loadDataFromDB:query]];
    for (NSArray* row in results) {
        Item* item = [[Item alloc] init];
        item.id = [row objectAtIndex:[self.dbManager.arrColumnNames indexOfObject:@"itemID"]];
        item.name = [row objectAtIndex:[self.dbManager.arrColumnNames indexOfObject:@"name"]];
        item.cost = [NSDecimalNumber decimalNumberWithString: [row objectAtIndex:[self.dbManager.arrColumnNames indexOfObject:@"cost"]]];
        item.location = [row objectAtIndex:[self.dbManager.arrColumnNames indexOfObject:@"location"]];
        item.date = [row objectAtIndex:[self.dbManager.arrColumnNames indexOfObject:@"date"]];
        [items addObject:item];
    }
    return items;
}

-(NSMutableArray*) getAll {
    NSString *query = [NSString stringWithFormat:@"select * from items"];
    return [self loadItems:query];
}

-(NSMutableArray*) getFrom: (NSDate*) from
                     andTo:(NSDate*) to
               andLocation: (NSString*) location
                   andPage: (int) page{
    // LIMIT <skip>, <count>
    NSString *query =
    [NSString stringWithFormat:@"select * from items WHERE date BETWEEN '%@' AND '%@' AND location LIKE '%%%@%%' ORDER BY date LIMIT %d,%d",
     from, to, location, page*10, 10];
    return [self loadItems:query];
}

-(int) getItemsCountFrom: (NSDate*) from
                         andTo:(NSDate*) to
                   andLocation: (NSString*) location{
    NSString *query =
    [NSString stringWithFormat:@"select COUNT(*) from items WHERE date BETWEEN '%@' AND '%@' AND location LIKE '%%%@%%'",
     from, to, location];
    NSString* result = [[[self.dbManager loadDataFromDB:query] firstObject] firstObject];
    int count = [result intValue];
    return count;
}

-(NSString*) getItemsCostFrom: (NSDate*) from
                   andTo:(NSDate*) to
             andLocation: (NSString*) location{
    NSString *query =
    [NSString stringWithFormat:@"select SUM(cost) from items WHERE date BETWEEN '%@' AND '%@' AND location LIKE '%%%@%%'",
     from, to, location];
    NSString* result = [[[self.dbManager loadDataFromDB:query] firstObject] firstObject];
    return result;
}

-(NSMutableArray*) getLastTen {
    NSString *query =
    [NSString stringWithFormat:@"select * from items ORDER BY date DESC LIMIT 10"];
    return [self loadItems:query];
}


-(BOOL) insertItem:(Item *)item {
    
    BOOL operationResult = YES;
    NSString* name = item.name;
    NSString* cost = [item.cost stringValue];
    NSString* location = item.location;
    
    name = [name stringByReplacingOccurrencesOfString:@"'"
                                         withString:@" "];
    cost = [cost stringByReplacingOccurrencesOfString:@"'"
                                           withString:@" "];
    location = [location stringByReplacingOccurrencesOfString:@"'"
                                           withString:@" "];
    
    NSString *query = [NSString stringWithFormat:@"insert into items values(null, '%@', '%@', datetime(), '%@')", name, cost, location];
    
    [self.dbManager executeQuery:query];
    
    if (self.dbManager.affectedRows != 0) {
        NSLog(@"Query was executed successfully. Affected rows = %d", self.dbManager.affectedRows);
    }
    else{
        operationResult = NO;
    }
    
    return operationResult;
}

-(BOOL) insertManyItems: (NSMutableArray*) items {
    
    BOOL operationResult = YES;
    
    for (Item* i in items) {
        if (![self insertItem:i]) {
            operationResult = NO;
            NSLog(@"Could not execute the query.");
            break;
        }
    }
    
    return operationResult;
}

-(NSDecimalNumber*) getTotalCost:(NSMutableArray*) items {
    NSDecimalNumber* sum = [NSDecimalNumber decimalNumberWithString:@"0.0"];
    for (Item* i in items) {
        sum = [sum decimalNumberByAdding:i.cost];
    }
    return sum;
}

-(BOOL) removeItem: (Item*) item {
    BOOL operationResult = YES;
    
    NSString *query = [NSString stringWithFormat:@"DELETE from items WHERE itemID = %@", item.id];
    
    [self.dbManager executeQuery:query];
    
    if (self.dbManager.affectedRows != 0) {
        NSLog(@"Query was executed successfully. Affected rows = %d", self.dbManager.affectedRows);
    }
    else{
        operationResult = NO;
    }
    
    return operationResult;
}


@end

// NSDateFormatter *dateFormat = [[NSDateFormatter alloc] init];
// [dateFormat setDateFormat:@"yyyy-MM-dd HH:mm:ss"];
// NSString* dateString=[dateFormat stringFromDate:[NSDate date]];

// to convert it back
// NSDateFormatter *dateFormat = [[NSDateFormatter alloc] init];
// [dateFormat setDateFormat:@"yyyy-MM-dd HH:mm:ss"];
// NSDate *myDate =[dateFormat dateFromString: string];