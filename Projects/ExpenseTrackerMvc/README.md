# Expense Tracker

## General functionality

- start by typing item name
- while typing autocomplete suggestions of previously added items with same name appear
- if a suggestion is selected its relevant information is automatically added (price, category)
- if no suggestion is found you can manually enter details
- in either cases date is automatically added as current, but can be modified later
- all item information can be modified (for current item or for all items with same name, you are asked on change)
- automatically added date for items can be changed to other than current
- when enter is pressed item is added to database, input fields are cleared and focus is moved to item name input field
- item input fields should be validated (for empty input and valid numbers)
- item categories are hierarchical, tree structures
- when category is deleted all items are moved to parent, or to 'other' if no parent
- stats for time period, categories and item name (each category as separate graph)

## Site structure

- main nav
    - categories
    - items
    - stats
    - login/logout

- items page
    - shows input for new item and items for last 30 days by default
    - items can be sorted by date, name and price
    - items can be filtered by date and price

- categories page
    - shows categories as hierarchical tree structure
    - can add, modify or delete existing categories
    - 