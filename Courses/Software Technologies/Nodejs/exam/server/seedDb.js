var mongoose = require('mongoose');
var encryption = require('./services/encryption');
var categories = require('./common/constants').categories;

var User = mongoose.model('user');
User.count().exec(function (err, usersCount) {
    if (err || usersCount !== 0) {
        return;
    }

    for (var i = 0, len = 5; i < len; i += 1) {
        var newSalt = encryption.generateSalt();
        User.create({
            username: 'user_' + i,
            salt: newSalt,
            hashPass: encryption.generateHashedPassword(newSalt, 'user_' + i),
            firstName: 'user' + i + 'FN',
            lastName: 'user' + i + 'LN',
            email: `user_${i}@admin.bg`,
        });
    }
});

var Playlist = mongoose.model('playlist');
Playlist.count().exec(function (err, plCount) {
    if (err || plCount !== 0) {
        return;
    }

    for (var i = 0, len = 15; i < len; i += 1) {
        var pl = {
            title: 'pl' + i,
            description: `pl${i}_descr`,
            videoUrls: [],
            category: categories[i%(categories.length)],
            creator: `user_${i%5}`,
            date: new Date(),
            isPrivate: i%2,
            rating: (i+1)%5,
            ratedCount: 1
        };

        pl.videoUrls.push('https://www.youtube.com/watch?v=tPFz04LSa2U');
        pl.videoUrls.push('https://www.youtube.com/watch?v=bSghnrBtvKM');

        Playlist.create(pl);
    }
});
