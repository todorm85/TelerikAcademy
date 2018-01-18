import Handlebars from 'handlebars';

export default {
    load: function(templateName) {
        return new Promise(function(resolve, reject) {
            var url = 'app/templates/' + templateName + '.handlebars';

            $.get(url).then(function(template) {
                var compiled = Handlebars.compile(template);
                resolve(compiled);
            }, function(error) {
                reject(error);
            });
        })
    }
}