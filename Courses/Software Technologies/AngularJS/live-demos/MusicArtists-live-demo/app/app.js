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
            .when('/list-artists', {
                templateUrl: 'app/list-artists-page/list-artists.html',
                controller: 'ListArtistsController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/add-artist', {
                templateUrl: 'app/add-artist-page/add-artist.html',
                controller: 'EditArtistController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME,
                resolve: routeUserChecks.authenticated
            })
            .when('/artist-details/:id', {
                templateUrl: 'app/artist-details-page/artist-details.html',
                controller: 'ArtistDetailsController',
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
        .module('musicApp.services', []);

    angular
        .module('musicApp.data', []);

    angular
        .module('musicApp.controllers', ['musicApp.services', 'musicApp.data']);

    angular
        .module('musicApp.filters', []);

    angular
        .module('musicApp.directives', []);

    angular
        .module('musicApp', [
            'musicApp.controllers',
            'musicApp.filters',
            'musicApp.directives',
            'ngResource',
            'ngCookies',
            'ngRoute'
        ])
        .config(['$routeProvider', config])
        .run(['auth', '$cookies', '$rootScope','$location', startup])
        .constant('author', 'Todor')
        .constant('baseUrl', 'http://localhost:55833');
})();
