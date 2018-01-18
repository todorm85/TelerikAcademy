var http = require('http'),
    path = require('path'),
    url = require('url'),
    qs = require('querystring'),
    fs = require('fs');

var Busboy = require('busboy'),
    guid = require('guid');

var filenames = {};

http.createServer(function (req, res) {
    var parsedUrl = url.parse(req.url, true);
    var pathname = parsedUrl.pathname;
    var query = parsedUrl.query;

    if (req.method === 'POST') {
        var uploadedFileName;
        var originalFileName;
        var busboy = new Busboy({
            headers: req.headers
        });
        busboy.on('file', function (fieldname, file, filename, encoding, mimetype) {
            originalFileName = filename;
            uploadedFileName = guid.raw();
            file.pipe(fs.createWriteStream(uploadedFileName));
        });
        busboy.on('finish', function () {
            filenames[uploadedFileName] = originalFileName;
            res.writeHead(200, {
                'Connection': 'close'
            });
            res.end(`<html><head></head><body>
                Upload finished. Download link:
                <a href="download?fileGuid=${uploadedFileName}">${originalFileName}</a>
            </body></html>`);
        });
        return req.pipe(busboy);
    } else if (pathname === '/') {
        res.writeHead(200, {
            'Content-Type': 'text/html'
        });
        res.end(`<html><head></head><body>
               <form method="POST" enctype="multipart/form-data">
                <input type="file" name="file1"><br />
                <input type="submit">
              </form>
            </body></html>`);
    } else if (pathname === '/download') {
        var fileGuid = query.fileGuid;
        var fileName = filenames[query.fileGuid];

        var filePath = path.join(__dirname, query.fileGuid);
        var stat = fs.statSync(filePath);
        res.writeHead(200, {
            'Content-Length': stat.size,
            'Content-Disposition': `attachment; filename=${fileName}`
        });

        var readStream = fs.createReadStream(filePath);
        readStream.on('open', function () {
            readStream.pipe(res);
        });
    } else {
        res.writeHead(404);
        res.end();
    }

}).listen(8080, function () {
    console.log('Listening for requests');
});
