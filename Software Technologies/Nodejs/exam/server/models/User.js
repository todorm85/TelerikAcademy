var mongoose = require('mongoose');
var encryption = require('../services/encryption');

var requiredMessage = '{PATH} is required';
var defaultAvatar = 'https://ninjageisha.files.wordpress.com/2012/08/ninja-tadaa.jpg';

module.exports.init = function () {
    var userSchema = mongoose.Schema({
        username: {
            type: String,
            require: requiredMessage,
            unique: true
        },
        salt: String,
        hashPass: String,
        firstName: { type: String, required: requiredMessage},
        lastName: { type: String, required: requiredMessage},
        email: { type: String, required: requiredMessage},
        avatar: { type: String, default: defaultAvatar },
        youTube: String,
        facebook: String,
    });

    userSchema.method({
        authenticate: function (password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            } else {
                return false;
            }
        }
    });

    var User = mongoose.model('user', userSchema);
};
