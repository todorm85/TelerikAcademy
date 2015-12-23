(function () {

    function baseDataSvc($http, $q, baseUrl) {

        function get(url, params) {
            var deffered = $q.defer();

            return $http.post(baseUrl + url, {
                params: params
            }).then(function (response) {
                deffered.resolve(response.data);
            }, function (err) {
                deffered.reject(err);
            });

            return deffered.promise;
        }

        function post(url, data, params) {
            var deffered = $q.defer();

            return $http.post(baseUrl + url, data, {
                params: params
            }).then(function (response) {
                deffered.resolve(response.data);
            }, function (err) {
                deffered.reject(err);
            });

            return deffered.promise;
        }

        function http (argument) {
            // body...
        }

        return {
            get,
            post,
            put,
            del
        };
    }

    angular
        .module('TicTacToeApp.services')
        .service('baseDataSvc', ['$http', '$q', 'baseUrl', baseDataSvc]);

})();
