//
//  MainViewController.m
//  ExpenseTracker
//
//  Created by todorm85 on 1/31/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "MainViewController.h"
#import "Item.h"
#import "NSDecimalNumber+DecimalNumberExtensions.h"
#import "ItemsService.h"
#import "LocationService.h"
#import "ItemsTableDataSource.h"
#import "Notifications.h"
#import "Validator.h"

@interface MainViewController ()
@end

@implementation MainViewController {
    NSMutableArray* items;
    ItemsService* itemsService;
    LocationService* locationService;
    ItemsTableDataSource* tableDataSource;
    int addItemsQueue;
    
}

- (void)viewDidLoad {
    [super viewDidLoad];
    
    locationService = [[LocationService alloc] init];
    itemsService = [[ItemsService alloc] init];
    addItemsQueue = 0;
    tableDataSource = [[ItemsTableDataSource alloc] initWithItems:items
                       andTableView:self.table];

    self.tbItemName.delegate = self;
    self.tbItemCost.delegate = self;
    
    [self.tbItemName becomeFirstResponder];
    
    [self getItems];

}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

- (IBAction)btnAddTouch:(id)sender {
    [self textFieldShouldReturn:self.tbItemName];
}

// user presses enter on any text field
-(BOOL)textFieldShouldReturn:(UITextField *)textField{
    
    NSString* name = self.tbItemName.text;
    NSDecimalNumber* cost = [NSDecimalNumber decimalFromString:self.tbItemCost.text];
    
    if(![Validator validateItemName:name andCost:cost inViewController:self]) {
        return NO;
    }
    
    __weak MainViewController* weakSelf = self;
    [locationService getAddressStringWithCallback:^(NSString *locatedAt) {
        Item* item = [[Item alloc] initWithName: name
                                        andCost: cost
                                    andLocation: locatedAt];
        [weakSelf saveItem:item];
    }];
    addItemsQueue++;
    self.lbTableTitle.text = @"Adding item...";
    self.tbItemName.text = @"";
    self.tbItemCost.text = @"";
    
    return YES;
}

-(void) saveItem: (Item*) item{
    addItemsQueue--;
    if (addItemsQueue == 0) {
        self.lbTableTitle.text = @"Last 10 items:";
    }
    
    if(![itemsService insertItem:item]) {
        return;
    }
    
    
    [self.tbItemName becomeFirstResponder];
    [self getItems];
}

-(void) getItems {
    tableDataSource.items = [itemsService getLastTen];
    [self.table reloadData];
}

@end
