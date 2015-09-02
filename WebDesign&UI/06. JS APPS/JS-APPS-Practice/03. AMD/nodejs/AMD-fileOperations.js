var fs = require('fs');
var files = fs.readdirSync('.');
files.forEach(function (file) {
    console.log(file);
});