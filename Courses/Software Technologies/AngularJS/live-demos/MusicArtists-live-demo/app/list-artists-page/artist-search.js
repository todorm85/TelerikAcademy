(function () {

    angular
        .module('musicApp.directives')
        .directive('artistSearch', function () {
            return {
                restrict: 'AE',
                templateUrl: 'app/list-artists-page/artist-search.html',
                replace: true,
                scope: {
                    search: '='
                }
            };
        });

}());
