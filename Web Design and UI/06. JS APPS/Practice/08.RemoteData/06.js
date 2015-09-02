var xhr = (function() {
    'use strict';

    function send(url, options) {
        let xhr = new XMLHttpRequest();
        options = options || {};
        options.verb = options.verb || 'GET';
        xhr.open(options.verb, url, true);

        xhr.onreadystatechange = function() {
            if (xhr.readyState === 4) {
                var statusType = Math.floor(xhr.status / 100);
                switch (statusType) {
                    case 2:
                        if (typeof options.success === 'function') {
                            options.success(xhr.responseText);
                        }
                        break;
                    case 4:
                    case 5:
                        if (typeof options.success === 'function') {
                            options.error(xhr);
                        }
                        break;
                }
            }
        }

        xhr.send(null);
    }

    return {
        send
    };
}());

var url = 'data.json';

xhr.send(url, {
    verb: 'GET',
    headers: {
        'content-type': 'application/json',
        'accepts': 'application/json'
    },
    success: function(data) {
        console.log(data);
    },
    error: function(error) {
        console.log(error);
    }
});

url = 'remote.html';

xhr.send(url, {
    verb: 'GET',
    headers: {
        'content-type': 'application/json',
        'accepts': 'application/json'
    },
    success: function(data) {
        console.log(data);
    },
    error: function(error) {
        console.log(error);
    }
});