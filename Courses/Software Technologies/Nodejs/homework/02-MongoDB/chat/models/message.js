var mongoose = require('mongoose');

module.exports.init = function () {
    var userSchema = mongoose.Schema({
        from: {
            type: String,
            require: '{PATH} is required',
        },
        to: {
            type: String,
            require: '{PATH} is required',
        },
        text: {
            type: String
        },
    });

    mongoose.model('message', userSchema);
};
