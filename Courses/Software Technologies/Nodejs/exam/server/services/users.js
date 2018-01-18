var User = require('mongoose').model('user');
var encryption = require('../services/encryption');

module.exports = {
    create: function (user) {
        user.salt = encryption.generateSalt();
        user.hashPass = encryption.generateHashedPassword(user.salt, user.password);

        if (!user.avatar) {
            delete user.avatar;
        }

        return new Promise(function (resolve, reject) {
            User.create(user, function (err, user) {
                if (err) {
                    reject(err);
                }

                resolve(user);
            });
        });
    },
    update: function (user, userData) {
        return User.findOne({"_id": user._id})
            .then(function (foundUser) {
                foundUser.firstName = userData.firstName;
                foundUser.lastName = userData.lastName;
                foundUser.email = userData.email;
                foundUser.avatar = userData.avatar;
                foundUser.youTube = userData.youTube;
                foundUser.facebook = userData.facebook;
                if (userData.newPassword) {
                    foundUser.password = userData.newPassword;
                }

                return foundUser.save();
            });
    }
};
