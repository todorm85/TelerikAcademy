(function () {

    'use strict';

    function pageController(identity, auth, $location, metaInfo) {
        var pc = this;

        pc.author = metaInfo.author;
        pc.year = metaInfo.year;
        pc.appName = metaInfo.appName;

        waitForLogin();

        pc.logout = function logout() {
            auth.logout()
                .then(function (response) {
                    pc.globallyLoggedInUser = undefined;
                    waitForLogin();
                    $location.path('/');
                }, function (err) {
                    console.log('Promise err at pageController');
                    console.log(err);
                });
        };

        function waitForLogin() {
            identity.getUser().then(function (user) {
                pc.globallyLoggedInUser = user.email;
            });
        }
    }

    angular
        .module('MyApp.controllers')
        .controller('PageController', ['identity', 'auth', '$location', 'metaInfo', pageController]);

})();
