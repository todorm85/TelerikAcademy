var mongoose = require('mongoose'),
    MessageModel = require('./models/message'),
    UserModel = require('./models/user');

module.exports.init = function() {
    mongoose.connect('mongodb://localhost:27017/chatHW');
    var db = mongoose.connection;

    db.once('open', function(err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }

        console.log('Database up and running...');
    });

    db.on('error', function(err){
        console.log('Database error: ' + err);
    });

    UserModel.init();
    MessageModel.init();
};