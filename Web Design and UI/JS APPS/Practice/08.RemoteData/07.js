var xhr = (function() {
    'use strict';

    function send(url, options) {
        return new Promise(function(resolve, reject) {
            let xhr = new XMLHttpRequest();
            options = options || {};
            options.verb = options.verb || 'GET';
            xhr.open(options.verb, url, true);

            xhr.onreadystatechange = function() {
                if (xhr.readyState === 4) {
                    var statusType = Math.floor(xhr.status / 100);
                    switch (statusType) {
                        case 2:
                            resolve(xhr.responseText);
                            break;
                        case 4:
                        case 5:
                            reject(xhr.responseText);
                            break;
                    }
                }
            }

            xhr.send(null);
        })
    };

    function getJSON(url, options) {
        return send(url, options)
            .then(function (resultData) {
                return JSON.parse(resultData);
            })
    }

    return {
        send, getJSON
    };
}());

var url = 'data.json';
var promise = xhr.send(url);

promise
    .then(function(data) {
        var dataObj = JSON.parse(data);
        console.log(dataObj.name);
        return xhr.getJSON('data.json');
    })
    .then(function(dataObj) {
        console.log(dataObj.name);
    });