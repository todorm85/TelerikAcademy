var path = require('path');

var rootPath = path.normalize(__dirname + '/../../');
var dbName = 'template';

module.exports = {
    development: {
        rootPath: rootPath,
        db: `mongodb://localhost:27017/${dbName}`,
        port: process.env.PORT || 3000
    }
};