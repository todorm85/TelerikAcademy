# SimpleExpenseTracker
IOS App minimalistic expense tracker

## Demo

[![SEE VIDEO](http://img.youtube.com/vi/zNvj2wPLBus/0.jpg)](http://www.youtube.com/watch?v=zNvj2wPLBus)

## Software description

Simple app for tracking daily expenses, nothing more, nothing less. Just add your products with price and save them. Later you can view statistics for a time period and location. You can track your expenses for the day, week or month or what you`ve spent while on vacation :). Location is automatically populated using GPS coordinates and Apple`s service for resolving them to human readable address.
There are two options for adding new items - right after the app starts on the main screen or in a form of a list. When adding items to list you can track the total cost. This is useful in situations where you want to check a bill with multiple entries. When finished you can save all the items in the list or discard it. When adding items on the main screen you also have the option to remove any of the last 10 added. In case you`ve made a mistake.
Statistics allow you to filter by start and end dates and location (location includes a search in the whole address - street, town, country). Statistics are presented 10 items per page for convinience and performance considerations (in case there are thousands of records in the database).
The UX and design concept follow a simplictic philosophy - only what is needed without overwhelming the user with buttons, excessive functionality and UI fireworks. The main objective is ease of use, fast and to the point interface.
The development process will be flexible and probably some of the features and scope of the app will change or not be implemented as work progresses. The general plan and end goals are laid out below.

## Software requirements

### Phase 1 - Basic Functionality
- AddItemsList for adding products and every added item displayed in a list
    - (DONE) Each item has name and cost (Cost cannot be floating-point type, must be some decimal)
    - (DONE) Items also have date in the db (used to filter them for statistics)
    - (DONE) On save list items are added to local db (date is automatically added when saving to db)
- ViewStatistics for displaying expenses statistics based on filters
    - (DONE) by default only daily expenses are displayed with total cost
    - (DONE) filter by date range

### Phase 2 - Improved functionality
- AddItemsList
    - (DONE) Add location service - remember the location where the item was added
    - (DONE) When displaying location use web service endpoint to get name
- ViewStatistics
    - (DONE) items can be filtered by location
    - (DONE) add total sum
- (DONE) Remove item functionality
- (DONE) Notifications!
- (DONE) items can be removed with left swipe
- (DONE) Paging the table view - if too many items in db


### Phase 3 - UX and design
- (DONE) Improve UX and design (create an ascetic, minimal design, focus on user productivity)
- (DONE) On slow connection display message while adding item(resolving the gps coordinates to human readable format)
- Add help

### Phase 4 - Advanced Features
- Autocomplete for previously added items
- Voice commands
- Login user to remote server and backup/restore data.
- Cache GPS data and request geolocation service only when significantly changed position.