(function () {
    'use strict';

    var authService = function authService($http, $q, $cookies, identity, baseUrl) {
        var TOKEN_KEY = 'authentication';

        function login(user) {
            var deferred = $q.defer();

            var data = "grant_type=password&username=" + (user.username || '') + '&password=' + (user.password || '');

            $http.post(baseUrl + '/token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .then(function (response) {
                    var tokenValue = response.data.access_token;
                    var theBigDay = new Date();
                    theBigDay.setHours(theBigDay.getHours() + 72);

                    $cookies.put(TOKEN_KEY, tokenValue, { expires: theBigDay });

                    getIdentity().then(function () {
                        deferred.resolve(response);
                    });

                }, function (err) {
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        // gets user-realted detailed information from server
        var getIdentity = function () {
            var deferred = $q.defer();
            
            var tokenValue = $cookies.get(TOKEN_KEY);
            $http.defaults.headers.common.Authorization = 'Bearer ' + tokenValue;

            $http.get(baseUrl + '/api/Account/UserInfo')
                .then(function (identityResponse) {
                    console.log(identityResponse);
                    identity.setUser(identityResponse.data.Email);
                    deferred.resolve(identityResponse.data.Email);
                });

            return deferred.promise;
        };

        function register (user) {
            var deferred = $q.defer();

            $http.post(baseUrl + '/api/account/register', user)
                .then(function (response) {
                    deferred.resolve(response);
                }, function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        return {
            login,
            getIdentity,
            isAuthenticated: function () {
                return !!$cookies.get(TOKEN_KEY);
            },
            logout: function () {
                $cookies.remove(TOKEN_KEY);
                $http.defaults.headers.common.Authorization = null;
                identity.removeUser();
            },
            register
        };
    };

    angular
        .module('musicApp.services')
        .factory('auth', ['$http', '$q', '$cookies', 'identity', 'baseUrl', authService]);
}());