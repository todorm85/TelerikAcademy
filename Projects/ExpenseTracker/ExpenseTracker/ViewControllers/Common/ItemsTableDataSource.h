//
//  ItemsTableDataSource.h
//  ExpenseTracker
//
//  Created by todorm85 on 2/2/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface ItemsTableDataSource : NSObject<UITableViewDataSource>
    -(instancetype) initWithItems: (NSMutableArray*) itemsArg
                     andTableView: (UITableView*) tableView;

    @property NSMutableArray* items;
@end
