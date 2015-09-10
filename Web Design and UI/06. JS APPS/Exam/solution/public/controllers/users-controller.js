import data from 'db/data.js';
import templates from 'db/templates.js';
import toastr from 'toastr';

function showAll(context) {
    var users;

    data.users.get()
        .then(function (response) {
            users = response;
            return templates.get('users-list-all');
        })
        .then(function (template) {
            context.$element().html(template(users));
        });
}

function showRegisterForm(context) {
    templates.get('users-register')
        .then(function (template) {
            context.$element().html(template());

            $('#btn-register').on('click', function () {
                var user = {
                    username: $('#tb-reg-username').val(),
                    password: $('#tb-reg-pass').val()
                };

                data.users.register(user)
                    .then(function () {
                        toastr.success('User registered!');
                        context.redirect('#/');
                        // document.location.reload(true);
                    }, function (error) {
                        toastr.error(error.responseText);
                    });
            });
        });
}

export default {
    showAll,
    showRegisterForm
};