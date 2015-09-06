var templates = (function() {

    function get(templateName) {
        return new Promise(function(resolve, reject) {
            var url = 'templates/' + templateName + '.handlebars';
            $.get(url, function (templateHtml) {
                var template = Handlebars.compile(templateHtml);
                resolve(template);
            }).error(reject);
        });
    }

    return {
        get: get
    }
}());