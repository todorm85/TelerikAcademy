//
//  StatisticsViewController.m
//  ExpenseTracker
//
//  Created by todorm85 on 2/1/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "StatisticsViewController.h"
#import "Item.h"
#import "DBManager.h"
#import "ItemsService.h"
#import "ItemsTableDataSource.h"

@interface StatisticsViewController ()

@end

@implementation StatisticsViewController {
    NSMutableArray* items;
    ItemsService* itemsService;
    ItemsTableDataSource* tableDataSource;
    int page;
    int totalItemsCount;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    itemsService = [[ItemsService alloc] init];
    page = 0;
    tableDataSource = [[ItemsTableDataSource alloc] initWithItems:items
                       andTableView:self.table];
    
    NSTimeInterval secondsPerDay = 24 * 60 * 60;
    NSDate *yesterday = [[NSDate alloc]
                         initWithTimeIntervalSinceNow:-secondsPerDay];
    
    [self.dpFrom setDate:yesterday];
    self.tbLocation.delegate = self;
    [self.tbLocation becomeFirstResponder];
    [self getItems];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
}

-(void) getItems {

    NSDate* from = self.dpFrom.date;
    NSDate* to = self.dpTo.date;
    NSString* location = self.tbLocation.text;
    
    totalItemsCount = [itemsService getItemsCountFrom: (NSDate*) from
                                                andTo:(NSDate*) to
                                          andLocation: (NSString*) location];
    if (page*10 >= totalItemsCount) {
        page = 0;
        self.lbPageNumber.text = [NSString stringWithFormat:@"%d", page];
    }
    
    items = [itemsService getFrom:from andTo:to andLocation:location andPage:page];
    self.tbSum.text = [itemsService getItemsCostFrom:from
                                               andTo:to
                                         andLocation:location];
    
    tableDataSource.items = items;
    [self.table reloadData];
}

- (IBAction)dpFromValueChanged:(id)sender {
    [self getItems];
}
- (IBAction)dpToValueChanged:(id)sender {
    [self getItems];
}

- (BOOL)textField:(UITextField *)textField
shouldChangeCharactersInRange:(NSRange)range
replacementString:(NSString *)string {
    textField.text = [textField.text stringByReplacingCharactersInRange:range withString:string];
    [self getItems];
    return NO;
}

- (IBAction)btnNextPageTap:(id)sender {
    if ((page+1)*10 < totalItemsCount) {
        page++;
    }
    
    self.lbPageNumber.text = [NSString stringWithFormat:@"%d", page];
    [self getItems];
}

- (IBAction)btnPrevPageTap:(id)sender {
    if (page>0) {
        page--;
    }
    
    self.lbPageNumber.text = [NSString stringWithFormat:@"%d", page];
    [self getItems];
}

@end
