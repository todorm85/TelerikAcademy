var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    // HOME
    app.get('/', controllers.playlists.getHomePlaylists);

    // USERS
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);
    app.post('/login', auth.login);
    app.get('/login', controllers.users.getLogin);
    app.get('/logout', auth.isAuthenticated, auth.logout);
    app.get('/profile', auth.isAuthenticated, controllers.users.getProfile);
    app.post('/profile', auth.isAuthenticated, controllers.users.postProfile);

    
    // PLAYLISTS
    app.get('/create-playlist', auth.isAuthenticated, controllers.playlists.getCreatePlaylist);
    app.post('/create-playlist', auth.isAuthenticated, controllers.playlists.postCreatePlaylist);
    app.get('/list-playlists', controllers.playlists.getListPlaylists);
    app.get('/playlist/:id', controllers.playlists.getPlaylistDetails);
    app.get('/playlist/delete-video/:id/:index', controllers.playlists.getPlaylistDeleteVideo);
    app.get('/playlist/delete-playlist/:id', controllers.playlists.getDeletePlaylist);
    // playlist/add-comment/#{pl._id}
    app.post('/playlist/add-comment/:id', controllers.playlists.postAddComment);


    // DEFAULT
    app.get('*', function(req, res) {
        res.redirect('/');
    });


};