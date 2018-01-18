(function () {

    function listGamesController(gameDataSvc, $location) {
        var vm = this;

        gameDataSvc.getAllGames()
            .then(function (response) {
                vm.games = response.data;
            });

        vm.join = function joinGame (id) {
            gameDataSvc.joinGame(id)
                .then(function (response) {
                    $location.path(`game/${response.data}`);
                }, function (err) {
                    toastr.error(err);
                })
        }
    }

    angular
        .module('TicTacToeApp.controllers')
        .controller('ListGamesController', ['gameDataSvc','$location',listGamesController]);
})();