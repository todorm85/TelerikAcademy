(function () {

    'use strict';

    function pageController(author, identity, auth, $location) {
        var pc = this;

        pc.author = author;
        pc.year = 2015;

        waitForLogin();

        pc.logout = function logout() {
            auth.logout();
            pc.globallyLoggedInUser = undefined;
            waitForLogin();
            $location.path('/');
        };

        function waitForLogin() {
            identity.getUser().then(function (user) {
                pc.globallyLoggedInUser = user;
            });
        }
    }

    angular
        .module('musicApp.controllers')
        .controller('PageController', ['author', 'identity','auth','$location', pageController]);

})();