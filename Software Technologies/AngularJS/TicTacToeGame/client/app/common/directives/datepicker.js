(function () {
    angular
        .module('TicTacToeApp.directives')
        .directive('datepicker', function () {
            return {
                restrict: 'AE',
                link: function (scope, element, att) {
                    element.datepicker();
                }
            };
        });

})();
