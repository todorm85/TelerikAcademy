var http = require('http'),
    path = require('path'),
    url = require('url'),
    qs = require('querystring'),
    fs = require('fs');

var viewEngine = require('./viewEngine');
var db = require('./fakeDb');

http.createServer(function (req, res) {
    var parsedUrl = url.parse(req.url, true);
    var pathname = parsedUrl.pathname;
    var query = parsedUrl.query;
    var method = req.method;
    var model;

    // return all static files (css, js, jpeg etc.)
    if (pathname.indexOf('/public') === 0) {
        var extension = pathname.split('.').pop();
        var contentType;
        switch (extension) {
            case 'css':
                contentType = 'text/css; charset=UTF-8';
                break;
            case 'js':
                contentType = 'text/javascript; charset=UTF-8';
                break;
        }

        res.writeHead(200, {
            'Content-Type': contentType
        });

        fs.readFile('.' + pathname, 'utf-8', function (err, content) {
            if (err) {
                console.log(err);
            }

            res.end(content);
        });
        return;
    }

    if (pathname === '/' || pathname === '/home') {
        res.writeHead(200, {
            'Content-Type': 'text/html'
        });

        viewEngine.render('home/home.jade', null, function (view) {
            res.end(view);
        });

        return;
    }

    if (pathname === '/phones') {
        res.writeHead(200, {
            'Content-Type': 'text/html'
        });

        model = {
            productType: 'phones',
            items: db.phones
        };

        viewEngine.render('products/products-list.jade', model, function (view) {
            res.end(view);
        });

        return;
    }

    if (pathname === '/tablets') {
        res.writeHead(200, {
            'Content-Type': 'text/html'
        });

        model = {
            productType: 'tablets',
            items: db.tablets
        };

        viewEngine.render('products/products-list.jade', model, function (view) {
            res.end(view);
        });

        return;
    }

    if (pathname === '/wearables') {
        res.writeHead(200, {
            'Content-Type': 'text/html'
        });

        model = {
            productType: 'Wearables',
            items: db.wearables
        };

        viewEngine.render('products/products-list.jade', model, function (view) {
            res.end(view);
        });

        return;
    }

    res.writeHead(404);
    res.end();

}).listen(8080, function () {
    console.log('Listening for requests');
});
