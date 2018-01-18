//
//  AddItemsViewController.m
//  ExpenseTracker
//
//  Created by todorm85 on 1/31/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "AddItemsViewController.h"
#import "Item.h"
#import "NSDecimalNumber+DecimalNumberExtensions.h"
#import "ItemsService.h"
#import "MainViewController.h"
#import "LocationService.h"
#import "ItemsTableDataSource.h"
#import "Validator.h"

@interface AddItemsViewController ()

@end

@implementation AddItemsViewController {
    NSMutableArray* items;
    ItemsService* itemsService;
    LocationService* locationService;
    ItemsTableDataSource* tableDataSource;
    NSString* location;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    itemsService = [[ItemsService alloc] init];
    locationService = [[LocationService alloc] init];
    
    items = [[NSMutableArray alloc] initWithArray:@[]];
    tableDataSource = [[ItemsTableDataSource alloc] initWithItems:items
                       andTableView:self.table];
    
    [self.tbItemName becomeFirstResponder];
    self.tbItemName.delegate = self;
    self.tbCost.delegate = self;
    
    __weak AddItemsViewController* weakSelf = self;
    [locationService getAddressStringWithCallback:^(NSString *locatedAt) {
        location = locatedAt;
        for (Item* item in items) {
            item.location = location;
        }
        
        [weakSelf.table reloadData];
    }];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

- (IBAction)btnAddItemToListTap:(id)sender {
    [self textFieldShouldReturn:self.tbItemName];
}

-(BOOL)textFieldShouldReturn:(UITextField *)textField{
    NSString* name = self.tbItemName.text;
    NSDecimalNumber* cost = [NSDecimalNumber decimalFromString:self.tbCost.text];
    
    if(![Validator validateItemName:name andCost:cost inViewController:self]) {
        return NO;
    }
    
    Item* item = [[Item alloc] initWithName: name
                                    andCost: cost
                                andLocation: location];
    [self addItemToList:item];
    
    return YES;
}

-(void) addItemToList:(Item*) item{
    [items addObject: item];
    self.tbItemName.text = @"";
    self.tbCost.text = @"";
    [self.table reloadData];
    self.tbSum.text = [NSString stringWithFormat:@"%@",[itemsService getTotalCost:items] ];
    [self.tbItemName becomeFirstResponder];
}

-(void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    if ([segue.identifier isEqualToString:@"saveBtnSegue"]) {
        BOOL operationResult = [itemsService insertManyItems:items];
        if (operationResult) {
            [items removeAllObjects];
            [self.table reloadData];
            // MainViewController* targetVC = [segue destinationViewController];
        } else {
            return;
        }
    }
}

@end
