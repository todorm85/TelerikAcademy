var sammyApp = Sammy('#content', function () {
    var content = $('#content');

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
                        passHash: $('#tb-pass').val()
                    };
                    data.users.login(user)
                        .then(function (response) {
                            console.log(response);
                            $('#btn-go-to-login').hide();
                            $('#btn-logout').show();
                            context.redirect('#/');
                        });
                });
                
                content.on('click', '#btn-register', function () {
                    var user = {
                        username: $('#tb-user').val(),
                        passHash: $('#tb-pass').val()
                    };
                    data.users.register(user)
                        .then(function (response) {
                            console.log(response);
                            $('#btn-go-to-login').hide();
                            $('#btn-logout').show();
                            context.redirect('#/');
                        });
                });
            });
    });

    this.get('#/logout', function (context) {
        data.users.logout()
            .then(function () {
                $('#btn-logout').hide();
                $('#btn-go-to-login').show();
                context.redirect('#/');
            });

    });

    this.get('#/', function (context) {
        content.html('This is home.');
    });
});

$(function () {
    sammyApp.run('#/');
    if (data.users.getCurrent()) {
        $('#btn-go-to-login').hide();
    } else {
        $('#btn-logout').hide();
    }
})
