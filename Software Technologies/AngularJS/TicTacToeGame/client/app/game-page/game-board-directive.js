(function () {
    angular
        .module('TicTacToeApp.directives')
        .directive('gameBoard', function () {
            return {
                restrict: 'AE',
                templateUrl: 'app/game-page/game-board.html',
            };
        });

})();
