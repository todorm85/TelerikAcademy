var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    // HOME
    app.get('/', function (req, res) {
        res.render('index');
    });

    // USERS
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);
    app.post('/login', auth.login);
    app.get('/login', controllers.users.getLogin);
    app.get('/logout', auth.isAuthenticated, auth.logout);
 
    // DEFAULT
    app.get('*', function(req, res) {
        res.render('index');
    });


};