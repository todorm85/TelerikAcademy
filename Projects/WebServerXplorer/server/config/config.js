var path = require('path');

var rootPath = path.normalize(__dirname + '/../../');

module.exports = {
    development: {
        rootPath: rootPath,
        db: 'mongodb://localhost:27017/WebServerXplorer',
        port: process.env.PORT || 3000
    }
};