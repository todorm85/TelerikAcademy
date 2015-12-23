(function () {

    'use strict';

    function pageController(author, identity, auth, $location, gameDataSvc) {
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

        pc.createGame = function () {
            gameDataSvc.createGame()
                .then(function (response) {
                    toastr.success('Created');
                   $location.path(`game/${response.data}`) 
                });
        }
    }

    angular
        .module('TicTacToeApp.controllers')
        .controller('PageController', ['author', 'identity','auth','$location','gameDataSvc', pageController]);

})();