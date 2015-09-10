import toastr from 'toastr';
import templates from 'db/templates.js';
import data from 'db/data.js';

function my(context) {
    var cookie;

    data.cookies.getMy()
        .then(function (response) {
            cookie = response.result;

            return templates.get('cookies-my')
        }, function (err) {
            toastr.error(JSON.parse(err.responseText));
        })
        .then(function (template) {
            context.$element().html(template(cookie));
        });
}

function all(context) {
    var cookies;
    var category = context.params.category;

    data.cookies.get()
        .then(function (response) {
            cookies = response.result;

            if (category) {
                cookies = cookies.filter(function (cookie) {
                    return cookie.category === category;
                });
            }

            return templates.get('cookies-all')
        })
        .then(function (template) {
            context.$element().html(template(cookies));
        });
}

function share(context) {
    if (!data.users.getCurrent()) {
        toastr.error('You must login!');
        return;
    }

    templates.get('cookies-share').
    then(function (template) {
        context.$element().html(template());

        $('#btn-add-cookie').on('click', function () {
            var cookie = {
                category: $('#tb-cookie-category').val(),
                text: $('#tb-cookie-text').val(),
                img: $('#tb-cookie-img').val(),
            };
            
            data.cookies.share(cookie)
                .then(function (response) {
                    context.redirect('#/home');
                }, function (err) {
                    toastr.error(JSON.parse(err.responseText));
                });
        });
    });
}

export default {
    my,
    all,
    share
};
