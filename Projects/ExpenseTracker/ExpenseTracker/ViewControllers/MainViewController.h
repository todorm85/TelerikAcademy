//
//  MainViewController.h
//  ExpenseTracker
//
//  Created by todorm85 on 1/31/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface MainViewController : UIViewController<UITextFieldDelegate>

@property (weak, nonatomic) IBOutlet UITextField *tbItemName;
@property (weak, nonatomic) IBOutlet UITextField *tbItemCost;
@property (weak, nonatomic) IBOutlet UIButton *btnAdd;
@property (nonatomic, strong) IBOutlet UITableView *table;
@property (weak, nonatomic) IBOutlet UILabel *lbTableTitle;

@end
