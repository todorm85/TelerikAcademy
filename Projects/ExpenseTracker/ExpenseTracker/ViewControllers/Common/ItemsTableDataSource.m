//
//  ItemsTableDataSource.m
//  ExpenseTracker
//
//  Created by todorm85 on 2/2/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import "ItemsTableDataSource.h"
#import "Item.h"
#import "ItemUITableViewCell.h"
#import "ItemsService.h"

@implementation ItemsTableDataSource{
    ItemsService* itemsService;
}

static NSString* cellId = @"ItemUITableViewCell";

-(instancetype) initWithItems: (NSMutableArray*) itemsArg
                 andTableView: (UITableView*) tableView {
    if (self = [super init]) {
        self.items = itemsArg;
        UINib* nib = [UINib nibWithNibName:cellId bundle:nil];
        [tableView registerNib:nib forCellReuseIdentifier:cellId];
        tableView.rowHeight = UITableViewAutomaticDimension;
        tableView.estimatedRowHeight = 160.0;
        tableView.dataSource = self;
        
        itemsService = [[ItemsService alloc] init];
    }
    
    return self;
}

- (NSInteger)tableView:(UITableView *)tableView
 numberOfRowsInSection:(NSInteger)section {
    return self.items.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView
         cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    ItemUITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:cellId];
    Item* item = self.items[indexPath.row];
    cell.tbItemAddress.text = item.location;
    cell.tbItemCost.text = [item.cost stringValue];
    cell.tbItemDate.text = item.date;
    cell.tbItemName.text = item.name;
    return cell;
}

- (BOOL)tableView:(UITableView *)tableView canEditRowAtIndexPath:(NSIndexPath *)indexPath {
    return YES;
}

- (void)tableView:(UITableView *)tableView commitEditingStyle:(UITableViewCellEditingStyle)editingStyle forRowAtIndexPath:(NSIndexPath *)indexPath {
    if (editingStyle == UITableViewCellEditingStyleDelete) {
        Item* item = [self.items objectAtIndex:indexPath.row];
        if (item.id) {
            if(![itemsService removeItem:item]) {
                NSLog(@"Could not remove item. DB error!");
                return;
            }
        }
        
        [self.items removeObjectAtIndex:indexPath.row];
        [tableView reloadData];
    }
}

@end
