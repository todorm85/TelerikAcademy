import templates from 'db/templates.js';

function all(context) {
    templates.get('home')
        .then(function (template) {
            context.$element().html(template());
        });
}

export default {
    all
};
