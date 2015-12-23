(function () {
    'use strict';

    var authService = function authService($http, $cookies, identity, baseUrl) {
        var TOKEN_KEY = 'authentication';

        function login(user) {
            toastr.info('logging in');
            var data = "grant_type=password&username=" + (user.username || '') + '&password=' + (user.password || '');

            var promise = $http.post(baseUrl + '/api/users/login', data, {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .then(function (response) {
                    var tokenValue = response.data.access_token;
                    var theBigDay = new Date();
                    theBigDay.setHours(theBigDay.getHours() + 72);
                    $cookies.put(TOKEN_KEY, tokenValue, {
                        expires: theBigDay
                    });

                    return getIdentity();
                });

            return promise;
        };

        // gets user-realted detailed information from server
        var getIdentity = function () {

            var tokenValue = $cookies.get(TOKEN_KEY);
            $http.defaults.headers.common.Authorization = 'Bearer ' + tokenValue;

            var promise = $http.get(baseUrl + '/api/users/UserInfo')
                .then(function (identityResponse) {
                    identity.setUser(identityResponse.data);
                    return identityResponse.data;
                });

            return promise;
        };

        function register(user) {
            var promise = $http.post(baseUrl + '/api/users/register', user);
            return promise;
        }

        function logout() {
            toastr.info('loggin out');
            var promise = $http.post(baseUrl + '/api/users/logout')
                .then(function (response) {
                    $cookies.remove(TOKEN_KEY);
                    $http.defaults.headers.common.Authorization = undefined;
                    identity.removeUser();
                    toastr.success('Logged out.');
                }, function (err) {
                    console.log(err);
                });

            return promise;
        }

        return {
            login,
            getIdentity,
            isAuthenticated: function () {
                    return !!$cookies.get(TOKEN_KEY);
                },
            logout,
            register
        };
    };

    angular
        .module('MyApp.services')
        .factory('auth', ['$http', '$cookies', 'identity', 'baseUrl', authService]);
}());
