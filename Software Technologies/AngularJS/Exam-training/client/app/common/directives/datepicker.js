(function () {
    angular
        .module('MyApp.directives')
        .directive('datepicker', function () {
            return {
                restrict: 'AE',
                link: function (scope, element, att) {
                    element.datepicker();
                }
            };
        });

})();
