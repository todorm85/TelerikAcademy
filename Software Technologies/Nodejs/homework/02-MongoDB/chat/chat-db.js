var users = require('mongoose').model('user');
var messages = require('mongoose').model('message');

module.exports = {

    registerUser: function (user) {
        return users.create(user);
    },

    sendMessage: function (message) {
        return messages.create(message);
    },

    getMessages: function (query) {

        return messages.find()
            .or([{
                from: query.with,
                to: query.and
            }, {
                from: query.and,
                to: query.with
            }])
            .select('text');
    }
};
