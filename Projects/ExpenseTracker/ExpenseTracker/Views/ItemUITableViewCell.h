//
//  ItemUITableViewCell.h
//  ExpenseTracker
//
//  Created by todorm85 on 2/3/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface ItemUITableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UILabel *tbItemName;
@property (weak, nonatomic) IBOutlet UILabel *tbItemCost;
@property (weak, nonatomic) IBOutlet UILabel *tbItemAddress;
@property (weak, nonatomic) IBOutlet UILabel *tbItemDate;

@end
