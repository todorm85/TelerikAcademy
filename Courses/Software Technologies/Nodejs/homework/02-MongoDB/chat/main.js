require('./mongooseConfig').init();

var chatDb = require('./chat-db');

//inserts a new user records into the DB
chatDb.registerUser({
    user: 'DonchoMinkov',
    pass: '123456q'
});

//inserts a new message record into the DB
//the message has two references to users (from and to)
chatDb.sendMessage({
    from: 'DonchoMinkov',
    to: 'NikolayKostov',
    text: 'Hey, Niki!'
}).then(function () {
    return chatDb.sendMessage({
        from: 'NikolayKostov',
        to: 'DonchoMinkov',
        text: 'Hey, Doncho!'
    });
}).then(function () {
    return chatDb.getMessages({
        with: 'DonchoMinkov',
        and: 'NikolayKostov'
    });
}).then(function (res) {
    console.log(res);
}, function (err) {
    console.log(err);
});
