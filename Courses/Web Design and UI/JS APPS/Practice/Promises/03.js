function get(url) {
    var promise = new Promise(
        function(resolve) {
            $.ajax({
                url: url,
                contentType: 'application/json',
                success: function(data) {
                    resolve(data);
                }
            });
        }
    );

    return promise;
}

get('package.json')
    .then(function(data) {
        $('#output').append(data.name);
        return get('package.json');
    })
    .then(function(data) {
        $('#output').append(JSON.stringify(data));
        return 5;
    })
    .then(function(data) {
        $('#output').append(data);
    });