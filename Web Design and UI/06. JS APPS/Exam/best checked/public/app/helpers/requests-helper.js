function send(method, url, options) {
    options = options || {};

    var headers = options.headers || {},
        data = options.data || undefined;

    var promise = new Promise(function(resolve, reject) {
        $.ajax({
            url: url,
            method: method,
            contentType: 'application/json',
            headers: headers,
            data: JSON.stringify(data),
            success: function(res) {
                resolve(res);
            },
            error: function(err) {
                reject(err);
            }
        });
    });

    return promise;
}

export default {
    get: function(url, options) {
        return send('GET', url, options);
    },

    post: function(url, options) {
        return send('POST', url, options);
    },

    put: function(url, options) {
        return send('PUT', url, options);
    },

    del: function(url, options) {
        return send('DEL', url, options);
    }
};