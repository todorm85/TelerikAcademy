(function () {

    // Data Access Layer object
    function dataService(data, $q) {

        var STATS_API = 'api/stats';
        var stats;

        function getStats(url, params) {
            if (stats) {
                return $q.resolve(stats);
            }
            
            return data.get(STATS_API)
                .then(function (data) {
                    stats = data;
                    return data;
                });
        }

        return {
            getStats,
        };
    }

    angular
        .module('MyApp.services')
        .service('stats', ['data', '$q', dataService]);

})();
