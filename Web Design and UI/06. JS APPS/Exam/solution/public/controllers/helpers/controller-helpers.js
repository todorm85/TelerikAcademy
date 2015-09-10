import moment from 'moment';

function groupByCategory(item) {
    return item.category;
}

function parseGroups(items, category) {
    return {
        category,
        items
    };
}

function filterByCategory(category) {
    return function (group) {
        return group.category.toLowerCase() === category.toLowerCase();
    };
}

function fixDate(item) {
    var newItem = Object.create(item);
    newItem.date = moment(item.date).format('MMM Do YYYY, hh:mm');
    newItem.timeRemaining = moment(item.date).fromNow();
    return newItem;
}

export default {
    groupByCategory, parseGroups, filterByCategory, fixDate
};
