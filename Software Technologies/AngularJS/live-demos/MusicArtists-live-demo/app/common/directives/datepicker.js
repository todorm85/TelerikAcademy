(function () {
    angular
        .module('musicApp.directives')
        .directive('datepicker', function () {
            return {
                restrict: 'AE',
                link: function (scope, element, att) {
                    element.datepicker();
                }
            };
        });

})();
