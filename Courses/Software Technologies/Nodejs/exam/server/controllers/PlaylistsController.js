var users = require('../services/users');
var playlists = require('../services/playlists');
var categories = require('../common/constants').categories;

var CONTROLLER_NAME = 'playlists';

module.exports = {
    getCreatePlaylist: function (req, res, next) {
        res.render(`${CONTROLLER_NAME}/create-playlist`, { categories });
    },
    postCreatePlaylist: function (req, res, next) {
        var playlist = req.body;

        if (!playlist.title) {
            req.session.error = 'Title is required';
            return res.redirect('/create-playlist');
        }

        if (!playlist.description) {
            req.session.error = 'Description is required';
            return res.redirect('/create-playlist');
        }

        if (!playlist.video_0) {
            req.session.error = 'At least one video url is required';
            return res.redirect('/create-playlist');
        }

        if (!playlist.category) {
            req.session.error = 'Category is required';
            return res.redirect('/create-playlist');
        }

        var i = 0;
        playlist.videoUrls = [];
        while(true)
        {
            var video = playlist[`video_${i}`];
            if (!video) {
                break;
            }

            playlist.videoUrls.push(video);
            i++;
        }

        playlist.creator = req.user.username;
        playlist.date = new Date();
        playlist.isPrivate = (playlist.isPrivate) ? true : false;
        playlist.rating = 0;
        playlist.ratedCount = 0;

        playlists.create(playlist)
            .then(function (playlist) {
                req.session.success = 'Playlist created.'; 
                return res.redirect('/list-playlists');
            }, function (err) {
                req.session.error = 'Failed to create new playlist.' +
                    '<br />error: ' + err.errmsg;
                return res.redirect('/create-playlist');
            });
    },
    getListPlaylists: function (req, res, next) {
        var username;
        if (req.user) {
            username = req.user.username;
        }
        
        playlists.getAll(username)
            .then(function (foundPl) {
                res.render(`${CONTROLLER_NAME}/list-playlists`, { playlists: foundPl });
            }, function (err) {
                req.session.error = 'Failed to retrieve playlists.' +
                    '<br />error: ' + err.errmsg;
                return res.redirect('/');
            });
    },
    getPlaylistDetails: function (req, res, next) {
        var id = req.params.id;
        playlists.getById(id)
            .then(function (playlist) {

                if (!req.user && playlist.isPrivate) {
                    req.session.error = 'Not authorized!';
                    return res.redirect('/');
                }

                if (req.user && req.user.username !== playlist.creator && playlist.isPrivate === true) {
                    req.session.error = 'Not authorized!';
                    return res.redirect('/');
                }
                
                return res.render(`${CONTROLLER_NAME}/playlist-details`, { pl: playlist });
            }, function (err) {
                console.log(err);
                req.session.error = 'Failed to retrieve playlist details.' +
                    '<br />error: ' + err.errmsg;
                return res.redirect('/'); 
            });
    },
    getPlaylistDeleteVideo: function (req, res, next) {
        var id = req.params.id;
        var index = req.params.index;
        playlists.getById(id)
            .then(function (playlist) {

                if (!req.user || req.user.username !== playlist.creator) {
                    req.session.error = 'Not authorized! You can delete only videos from playlits you own.';
                    return res.redirect(`/playlist/${playlist._id}`);
                }
                
                return playlists.deleteVideo(id, index);
            })
            .then(function (playlist) {
                return res.render(`${CONTROLLER_NAME}/playlist-details`, { pl: playlist });
            }, function (err) {
                console.log(err);
                req.session.error = 'Failed to delete video.' +
                    '<br />error: ' + err;
                return res.redirect('/'); 
            });
    },
    getDeletePlaylist: function (req, res, next) {
        var id = req.params.id;
        playlists.getById(id)
            .then(function (playlist) {

                if (!req.user || req.user.username !== playlist.creator) {
                    req.session.error = 'Not authorized! You can delete only playlits you own.';
                    return res.redirect(`/playlist/${playlist._id}`);
                }
                
                return playlists.deletePlaylist(id);
            })
            .then(function () {
                req.session.success = 'Playlist deleted.';
                return res.redirect('/list-playlists');
            }, function (err) {
                console.log(err);
                req.session.error = 'Failed to delete playlist.' +
                    '<br />error: ' + err;
                return res.redirect('/'); 
            });
    },
    postAddComment: function (req, res, next) {
        var id = req.params.id;
        var comment = req.body.comment;
        var foundPlaylist;
        playlists.getById(id)
            .then(function (playlist) {
                foundPlaylist = playlist;
                if (!req.user) {
                    req.session.error = 'Not authorized! You can comment only if logged in.';
                    return res.redirect(`/playlist/${playlist._id}`);
                }

                var username = req.user.username;
                return playlists.addComment(id, comment, username);
            })
            .then(function () {
                req.session.success = 'Comment added';
                    return res.redirect(`/playlist/${foundPlaylist._id}`);
            }, function (err) {
                console.log(err);
                req.session.error = 'Failed to add comment.' +
                    '<br />error: ' + err;
                return res.redirect('/'); 
            });
    },
    getHomePlaylists: function (req, res, next) {
        playlists.getTopEight()
            .then(function (foundPl) {
                res.render('home', { playlists: foundPl });
            }, function (err) {
                req.session.error = 'Failed to retrieve playlist details.' +
                    '<br />error: ' + err.errmsg;
                return res.redirect('/'); 
            });
    }
    
};
