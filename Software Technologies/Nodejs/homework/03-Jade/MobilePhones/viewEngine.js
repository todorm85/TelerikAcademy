var jade = require('jade');
var fs = require('fs');
var path = require('path');

var VIEWS_PATH = './views/';

function render(templateFilePath, model, cb) {
    
    fs.readFile(VIEWS_PATH + templateFilePath, 'utf-8', function (err, content) {
        if (err) {
            return cb(err.toString());
        }

        var template = jade.compile(content, {
            // filename: './views/random'
            // filename: path.basename(templateFilePath)
            filename: VIEWS_PATH + templateFilePath
        });

        var output = template(model);

        return cb(output);
    });
}

module.exports = {
    render
};
