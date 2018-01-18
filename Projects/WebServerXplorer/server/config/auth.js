var passport = require('passport');

module.exports = {
    login: function (req, res, next) {
        var auth = passport.authenticate('local', function (err, user) {
            if (err) {
                req.session.error = "wrong username or password";
                return res.redirect('/login');
            }

            if (!user) {
                req.session.error = "wrong username or password";
                return res.redirect('/login');
            }

            req.logIn(user, function (err) {
                if (err) {
                    req.session.error = "wrong username or password";
                    return res.redirect('/login');
                }

                return res.redirect('/');
            });
        });

        auth(req, res, next);
    },
    logout: function (req, res, next) {
        req.logout();
        res.redirect('/');
    },
    isAuthenticated: function (req, res, next) {
        if (!req.isAuthenticated()) {
            req.session.error = "You must login first.";
            res.status(403);
            res.redirect('/login');
        } else {
            next();
        }
    }
};
