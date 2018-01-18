//
//  AddItemsViewController.h
//  ExpenseTracker
//
//  Created by todorm85 on 1/31/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface AddItemsViewController : UIViewController<UITextFieldDelegate>

@property (weak, nonatomic) IBOutlet UITableView *table;
@property (weak, nonatomic) IBOutlet UITextField *tbCost;
@property (weak, nonatomic) IBOutlet UITextField *tbItemName;
@property (weak, nonatomic) IBOutlet UILabel *tbSum;

@end
