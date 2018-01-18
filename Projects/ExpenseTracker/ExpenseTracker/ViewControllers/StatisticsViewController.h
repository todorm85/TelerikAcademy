//
//  StatisticsViewController.h
//  ExpenseTracker
//
//  Created by todorm85 on 2/1/16.
//  Copyright © 2016 todorm85. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface StatisticsViewController : UIViewController<UITextFieldDelegate>

@property (weak, nonatomic) IBOutlet UITableView *table;
@property (weak, nonatomic) IBOutlet UIDatePicker *dpFrom;
@property (weak, nonatomic) IBOutlet UIDatePicker *dpTo;
@property (weak, nonatomic) IBOutlet UILabel *tbSum;
@property (weak, nonatomic) IBOutlet UITextField *tbLocation;
@property (weak, nonatomic) IBOutlet UILabel *lbPageNumber;

@end
