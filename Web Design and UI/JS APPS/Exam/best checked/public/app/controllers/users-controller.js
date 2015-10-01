import templates from '../helpers/templates-helper.js';
import validate from '../helpers/validations-helper.js';
import toastr from 'toastr';
import data from '../data/data.js';

export default {
    login: function(sammy) {
        if (data.user.isLoggedIn()) {
            toastr.error('You are already logged in!', 'Oops!');
            sammy.redirect('#/home');
        } else {
            templates.load('login').then(function (template) {
                sammy.$element().html(template());

                $('#login-submit').on('click', function () {
                    var username = $('#login-name').val();
                    var password = $('#login-pass').val();

                    data.user.login({
                        username: username,
                        password: password
                    }).then(function (response) {
                        toastr.success('You successfully logged in!');
                        sammy.redirect('#/home');
                    }).catch(function (error) {
                        toastr.error(JSON.parse(error.responseText));
                    })
                })
            })
        }
    },

    register: function(sammy) {
        if (data.user.isLoggedIn()) {
            toastr.error('You cannot register while logged in!', 'Oops!');
            sammy.redirect('#/home');
        } else {
            templates.load('register').then(function(template) {
                sammy.$element().html(template());

                $('#signup-submit').on('click', function() {
                    var username = $('#register-name').val();
                    var password = $('#register-pass').val();

                    if (!validate.username(username)) {
                        toastr.error('Username must between 6 and 30 characters and contain only Latin letters, digits and the characters "_" and "."', 'Invalid form data!')
                    } else {
                        data.user.register({
                            username: username,
                            password: password
                        }).then(function(response){
                            toastr.success('You successfully registered!');
                            sammy.redirect('#/home');
                        }).catch(function(error){
                            toastr.error(JSON.parse(error.responseText));
                        })
                    }
                })
            })
        }
    },

    logout: function(sammy) {
        if (!data.user.isLoggedIn()) {
            toastr.error('You are already logged out!');
        } else {
            data.user.logout().then(function (response) {
                toastr.success('You successfully logged out!');
                sammy.redirect('#/home');
            });
        }
    }
}
