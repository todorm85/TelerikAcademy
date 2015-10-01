import Sammy from 'sammy';

import header from './helpers/header-helper.js';
import templates from './helpers/templates-helper.js';

import homeController from './controllers/home-controller.js';
import usersController from './controllers/users-controller.js';
import cookiesController from './controllers/cookies-controller.js';

var container = '#content';
var sammyApp = Sammy(container, function() {
    this.before({}, function() {
        header.load();
    });

    this.get('#/', function() {
        this.redirect('#/home');
    });

    this.get('#/home', homeController.index);
    this.get('#/share-cookie', cookiesController.share);
    this.get('#/my-cookie', cookiesController.myCookie);

    this.get('#/login', usersController.login);
    this.get('#/register', usersController.register);
    this.get('#/logout', usersController.logout);


    //this.get(/.*/, function () {
    //    templates.load('404').then(function(template){
    //        $(container).html(template());
    //    });
    //});
});

sammyApp.run('#/');
