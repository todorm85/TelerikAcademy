(function () {
    'use strict';

    var CONTROLLER_VIEW_MODEL_NAME = 'vm';

    var routeUserChecks = {
        authenticated: {
            authenticate: ['auth', '$q', function (auth, $q) {
                if (auth.isAuthenticated()) {
                    return true;
                }

                return $q.reject('not authorized');
            }]
        }
    };

    function config($routeProvider) {
        $routeProvider
            .when('/home', {
                templateUrl: 'app/home-page/home.html',
                controller: 'HomePageController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/register-user', {
                templateUrl: 'app/register-user-page/register-user.html',
                controller: 'RegisterUserController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/login-user', {
                templateUrl: 'app/login-user-page/login-user.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/game/list-games', {
                templateUrl: 'app/list-games-page/list-games.html',
                controller: 'ListGamesController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeUserChecks.authenticated
            })
            .when('/game/my-games', {
                templateUrl: 'app/my-games-page/my-games.html',
                controller: 'MyGamesController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeUserChecks.authenticated
            })
            .when('/game/:id', {
                templateUrl: 'app/game-page/game.html',
                controller: 'GamePageController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeUserChecks.authenticated
            })
            .otherwise({
                redirectTo: '/home'
            })
    }

    var startup = function startup(auth, $cookies, $rootScope, $location) {

        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
            if (rejection === 'not authorized') {
                $location.path('/');
            }
        });

        if (auth.isAuthenticated()) {
            auth.getIdentity().then(function (username) {
                toastr.success('Welcome back, ' + username + '!');
            });
        }
    }

    angular
        .module('TicTacToeApp.services', []);

    angular
        .module('TicTacToeApp.data', []);

    angular
        .module('TicTacToeApp.controllers', ['TicTacToeApp.services', 'TicTacToeApp.data']);

    angular
        .module('TicTacToeApp.filters', []);

    angular
        .module('TicTacToeApp.directives', []);

    angular
        .module('TicTacToeApp', [
            'TicTacToeApp.controllers',
            'TicTacToeApp.filters',
            'TicTacToeApp.directives',
            'ngResource',
            'ngCookies',
            'ngRoute'
        ])
        .config(['$routeProvider', config])
        .run(['auth', '$cookies', '$rootScope','$location', startup])
        .constant('author', 'Todor')
        .constant('baseUrl', 'http://localhost:33257/');
})();
