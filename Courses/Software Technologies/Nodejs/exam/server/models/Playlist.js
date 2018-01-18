var mongoose = require('mongoose');

var requiredMessage = '{PATH} is required';

module.exports.init = function() {
    var playlistSchema = mongoose.Schema({
        title: { type: String, required: requiredMessage },
        description: { type: String, required: requiredMessage },
        videoUrls: [String],
        category: { type: String, required: requiredMessage },
        creator: { type: String, required: requiredMessage },
        date: { type: Date, required: requiredMessage },
        isPrivate: { type: Boolean, required: requiredMessage },
        comments: [{
            username: String,
            content: String
        }],
        rating: Number,
        ratedCount: Number
    });

    var Playlist = mongoose.model('playlist', playlistSchema);
};