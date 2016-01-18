var users = require('../services/users');

var CONTROLLER_NAME = 'users';

module.exports = {
    getLogin: function (req, res, next) {
        res.render(`${CONTROLLER_NAME}/login`);
    },
    getRegister: function (req, res, next) {
        res.render(`${CONTROLLER_NAME}/register`);
    },
    postRegister: function (req, res, next) {
        var newUserData = req.body;

        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Passwords do not match';
            return res.redirect('/register');
        }

        if (newUserData.username.length > 20 || newUserData.username.length < 6) {
            req.session.error = 'Username must be between 6 and 20 chars long';
            return res.redirect('/register');
        }

        if (newUserData.username.search(/[^A-z0-9_.]/) >=0) {
            req.session.error = 'Username can contain oly latin letters, digits and _ or .';
            return res.redirect('/register');
        }

        users.create(newUserData)
            .then(function (user) {
                req.logIn(user, function (err) {
                    if (err) {
                        res.status(400);
                        return res.send({
                            reason: err.toString()
                        });
                    } else {
                        res.redirect('/');
                    }
                });
            }, function (err) {
                req.session.error = 'Failed to register new user.' +
                    ' Perhaps already registered.' +
                    '<br />error: ' + err;
                return res.redirect('/');
            });
    },
    getProfile: function (req, res, next) {
        res.render(`${CONTROLLER_NAME}/profile`, req.user);
    },
    postProfile: function (req, res, next) {
        var newUserData = req.body;
        users.update(req.user, newUserData)
            .then(function (result) {
                req.session.success = 'Successful update.';
                res.redirect('/profile');
            }, function (err) {
                req.session.error = 'Failed to update user details.' +
                    '<br />error: ' + err;
                return res.redirect('/profile'); 
            });
    },
};
