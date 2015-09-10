import 'jquery';
import Sammy from 'sammy';
import toastr from 'toastr';

import data from 'db/data.js';
// import homeController from 'controllers/home-controller.js';
import usersController from 'controllers/users-controller.js';
// import myCookieController from 'controllers/my-cookie-controller.js';
import cookiesController from 'controllers/cookies-controller.js';




var sammyApp = Sammy('#content', function () {

    this.get('#/', function (context) {
        context.redirect('#/home');
    });

    this.get('#/home', cookiesController.all);
    this.get('#/my-cookie', cookiesController.my);
    this.get('#/cookies/share', cookiesController.share);
    // this.get('#/cookies/:id', cookiesController.like);


    this.get('#/users', usersController.showAll);
    this.get('#/users/register', usersController.showRegisterForm);



});

$(function () {
    $('#loading-message').hide();
    $('#root').toggleClass('hidden');
    $('#container-sign-in').hide();
    $('#container-sign-out').hide();

    if (data.users.hasUser()) {
        $('#container-sign-out').show();

        var loggedUserUsername = localStorage.getItem(data.constants.LOCAL_STORAGE_USERNAME_KEY);
        var message = `Welcome, ${loggedUserUsername}`;
        $('#welcome-message').html(message);

        $('#btn-sign-out').on('click', function (e) {
            e.preventDefault();
            data.users.signOut()
                .then(function () {
                    document.location = '#/';
                    document.location.reload(true);
                }, function (error) {
                    toastr.error(error.responseText + ' Clear local storage if you restarted the server and refresh page!!!');
                });
        });
    } else {
        $('#container-sign-in').show();
        $('#welcome-message').html('');

        $('#btn-sign-in').on('click', function (e) {
            e.preventDefault();
            var user = {
                username: $('#tb-username').val(),
                password: $('#tb-password').val()
            };
            console.log('clicked sign in');
            data.users.signIn(user)
                .then(function (user) {
                    console.log('success');
                    document.location = '#/';
                    document.location.reload(true);
                }, function (error) {
                    toastr.error(error.responseText);
                });
        });
    }

    sammyApp.run('#/');
});
