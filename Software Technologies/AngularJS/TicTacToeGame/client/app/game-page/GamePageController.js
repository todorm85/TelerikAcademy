(function () {

    function gamePageController($routeParams, gameDataSvc, $q, $route, $timeout) {
        var vm = this;
        var deferred = $q.defer();

        vm.sessionStatus = "checking";

        vm.play = function playGame(r, c) {

            var data = {
                gameId: $routeParams.id,
                row: r,
                col: c
            };

            gameDataSvc.playGame(data)
                .then(function (response) {
                    $route.reload();
                }, function (error) {
                    console.log(error);
                    toastr.error(error.data.Message);
                });
        }

        updateGameStats();

        function updateGameStats() {
            gameDataSvc.getGameStatus($routeParams.id)
                .then(function (gameStatus) {
                    vm.sessionStatus = "online";
                    vm.gameStatus = gameStatus.data;
                    vm.board = gameStatus.data.Board;
                    $timeout(updateGameStats, 2000);
                }, function (error) {
                    vm.sessionStatus = "unavailable";
                    $timeout(updateGameStats, 2000);
                });
        }

    }

    angular
        .module('TicTacToeApp.controllers')
        .controller('GamePageController', [
            '$routeParams',
            'gameDataSvc',
            '$q',
            '$route',
            '$timeout',
            gamePageController
        ]);
})();
