(function () {
    'use strict';

    function identityService($q) {
        var currentUser = {};
        var deferred = $q.defer();

        return {
            getUser: function () {
                if (this.isAuthenticated()) {
                    // returns a resolved promise with currentUser
                    return $q.resolve(currentUser);
                }
                // returns promise if no user, when user is set will be resolved at setUsr()
                return deferred.promise;
            },
            isAuthenticated: function () {
                return Object.getOwnPropertyNames(currentUser).length !== 0;
            },
            setUser: function (user) {
                currentUser = user;
                // resolves the promise for getUser
                deferred.resolve(user);
            },
            removeUser: function () {
                currentUser = {};
                // resets the promise for getUser
                deferred = $q.defer();
            }
        };
    };

    angular
        .module('MyApp.services')
        .factory('identity', ['$q', identityService]);
}());