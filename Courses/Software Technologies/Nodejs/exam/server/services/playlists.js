var Playlist = require('mongoose').model('playlist');

var cache = {
    expires: undefined,
    data: undefined
};

module.exports = {
    create: function (playlist) {
        return new Promise(function (resolve, reject) {
            Playlist.create(playlist, function (err, playlist) {
                if (err) {
                    reject(err);
                }

                resolve(playlist);
            });
        });
    },
    getAll: function (creator) {
        return Playlist.find()
            .or([{
                creator: creator
            }, {
                isPrivate: false
            }]);
    },
    getById: function (id) {
        return Playlist.findOne({
            _id: id
        });
    },
    getTopEight: function () {

        if (cache.data && cache.expires > new Date()) {
            return new Promise(cache.data);
        }

        return Playlist.find({
                isPrivate: false
            })
            .sort({
                rating: 'desc'
            })
            .limit(8)
            .then(function (foundPlaylists) {
                cache.data = foundPlaylists;
                cache.expires = new Date() + 10;
                return foundPlaylists;
            });
    },
    deleteVideo: function (id, index) {
        return Playlist.findOne({
                "_id": id
            })
            .then(function (pl) {
                if (pl.videoUrls.length > index &&
                    index >= 0) {
                    pl.videoUrls.splice(index, 1);
                }

                return pl.save();
            });
    },
    deletePlaylist: function (id, index) {
        return Playlist.remove({
                "_id": id
            });
    },
    addComment: function (id, comment, username) {
        return Playlist.findOne({
                "_id": id
            })
            .then(function (pl) {
                pl.comments.push({
                    username,
                    content: comment
                });

                return pl.save();
            });
    },
};
