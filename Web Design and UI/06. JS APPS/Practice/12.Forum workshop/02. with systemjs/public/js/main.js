import Sammy from 'sammy';
import 'jquery';
import templates from 'js/templates.js';
import data from 'js/data.js';
import moment from 'moment';
import 'underscore';

var sammyApp = Sammy('#content', function () {
    var content = $('#content');

    // LOGIN FORM
    this.get('#/login', function (context) {

        if (data.users.getCurrent()) {
            context.redirect('#/');
            return;
        }

        templates.get('login')
            .then(function (compiledTemplate) {
                content.html(compiledTemplate());

                content.on('click', '#btn-login', function () {
                    var user = {
                        username: $('#tb-user').val(),
                        password: $('#tb-pass').val()
                    };
                    data.users.login(user)
                        .then(function (response) {
                            $('#btn-go-to-login').hide();
                            $('#btn-logout').show();
                            $('#user-greet').html('Welcome, ' + data.users.getCurrent().username);
                            context.redirect('#/');
                        });
                });

                content.on('click', '#btn-register', function () {
                    var user = {
                        username: $('#tb-user').val(),
                        password: $('#tb-pass').val()
                    };
                    data.users.register(user)
                        .then(function (response) {
                            $('#btn-go-to-login').hide();
                            $('#btn-logout').show();
                            context.redirect('#/');
                        });
                });
            });
    });
    
    // HOME
    this.get('#/', function (context) {
        templates.get('home')
            .then(function (template) {
                content.html(template());
            });
    });

    // SHOW ALL THREADS
    this.get('#/threads', function (context) {
        var threads;
        data.threads.get()
            .then(function (response) {
                _.each(response, function (thread) {
                    thread.postDate = moment(thread.postDate).fromNow();
                });
                threads = response;
                return templates.get('threads');
            })
            .then(function (template) {
                var html = template(threads);
                content.html(html);
            });
    });

    // ADD THREAD FORM
    this.get('#/threads/add', function (context) {
        var currentUser = data.users.getCurrent();

        if (!currentUser) {
            context.redirect('#/login');
            return;
        }

        templates.get('addThread')
            .then(function (compiledTemplate) {
                content.html(compiledTemplate());

                $('#btn-add').on('click', function () {
                    var thread = {
                        title: $('#tb-title').val(),
                    };
                    data.threads.add(thread)
                        .then(function (response) {
                            context.redirect('#/threads');
                        });
                });
            });
    });

    // SHOW ONE THREAD
    this.get('#/threads/:id', function (context) {
        var thread;
        var id = this.params.id;
        data.threads.getById(id)
            .then(function (response) {
                thread = response;
                return templates.get('thread');
            })
            .then(function (template) {
                var html = template(thread);
                content.html(html);
            });
    });

    // ADD MESSAGE TO THREAD FORM
    this.get('#/thread/:id/messages/add', function (context) {
        var threadId = this.params.id;
        var currentUser = data.users.getCurrent();

        if (!currentUser) {
            context.redirect('#/login');
            return;
        }

        templates.get('addMessageToThread')
            .then(function (compiledTemplate) {
                content.html(compiledTemplate());
                $('#btn-add-message').on('click', function () {
                    var message = {
                        text: $('#tb-message-text').val(),
                        author: currentUser.username,
                        date: new Date(),
                    };
                    data.threads.addMessage(message, threadId)
                        .then(function (response) {
                            console.log(response);
                            context.redirect('#/threads' + threadId);
                        });
                });
            });
    });

    // SHOW ALL USERS
    this.get('#/users', function (context) {
        var users;
        data.users.get()
            .then(function (response) {
                users = response;
                return templates.get('users');
            })
            .then(function (template) {
                var html = template(users);
                content.html(html);
            });
    });
});

$(function () {
    sammyApp.run('#/');
    
    // LOAD NAV AT START
    templates.get('nav')
        .then(function (template) {
            var html = template();
            $('header').html(html);
            var loggedUser = data.users.getCurrent();
            if (loggedUser) {
                $('#btn-go-to-login').hide();
                $('#user-greet').html('Welcome, ' + loggedUser.username);
            } else {
                $('#btn-logout').hide();
            }

            $('#btn-logout').on('click', function () {
                data.users.logout()
                    .then(function () {
                        $('#btn-logout').hide();
                        $('#btn-go-to-login').show();
                        $('#user-greet').html('');
                        document.location.hash = ('#/');
                    });
            });
        });
})
