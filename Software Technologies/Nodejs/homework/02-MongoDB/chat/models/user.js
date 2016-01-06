var mongoose = require('mongoose');

module.exports.init = function () {
    var userSchema = mongoose.Schema({
        user: {
            type: String,
            require: '{PATH} is required',
            unique: true
        },
        pass: {
            type: String
        }
    });

    mongoose.model('user', userSchema);
};
