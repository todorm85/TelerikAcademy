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
            .when('/', {
                templateUrl: 'app/home-page/home.html',
                controller: 'HomePageController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/register-user', {
                templateUrl: 'app/identity/register-user-page/register.html',
                controller: 'RegisterUserController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .when('/login-user', {
                templateUrl: 'app/identity/login-user-page/login.html',
                controller: 'LoginController',
                controllerAs: CONTROLLER_VIEW_MODEL_NAME
            })
            .otherwise({
                redirectTo: '/'
            })
    }

    var startup = function startup(auth, $cookies, $rootScope, $location) {

        $rootScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
            if (rejection === 'not authorized') {
                $location.path('/');
            }
        });

        if (auth.isAuthenticated()) {
            auth.getIdentity().then(function (user) {
                toastr.success('Welcome back, ' + user.email + '!');
            });
        }
    }

    angular
        .module('MyApp.services', []);

    angular
        .module('MyApp.controllers', ['MyApp.services']);

    angular
        .module('MyApp.filters', []);

    angular
        .module('MyApp.directives', []);

    angular
        .module('MyApp', [
            'MyApp.controllers',
            'MyApp.filters',
            'MyApp.directives',
            'ngResource',
            'ngCookies',
            'ngRoute',
            'kendo.directives'
        ])
        .config(['$routeProvider', config])
        .run(['auth', '$cookies', '$rootScope','$location', startup])
        .constant('metaInfo', {
            appName: 'myApp',
            author: 'Anonymous',
            year: 2030,
        })
        .constant('baseUrl', 'http://localhost:1337')
        .value('toastr', toastr);
})();
