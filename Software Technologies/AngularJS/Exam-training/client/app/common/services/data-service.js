(function () {

    // Data Access Layer object
    function dataService($http, baseUrl) {

        function get(url, params) {
            return $http.get(baseUrl + '/'  + url, {
                params: params
            }).then(function (response) {
                return response.data;
            });
        }

        function post(url, data, params) {
            return $http.post(baseUrl + '/' + url, data, {
                params: params
            }).then(function (response) {
                return response.data;
            });
        }

        return {
            get,
            post,
        };
    }

    angular
        .module('MyApp.services')
        .service('data', ['$http', 'baseUrl', dataService]);

})();
