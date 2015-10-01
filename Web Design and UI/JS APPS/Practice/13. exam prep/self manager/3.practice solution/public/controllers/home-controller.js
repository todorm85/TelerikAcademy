import toastr from 'toastr';
import templates from 'db/templates.js';
import data from 'db/data.js';

function show(context) {
    templates.get('home')
        .then(function (template) {
            context.$element().html(template());
        });
}

export default {
    show
};
