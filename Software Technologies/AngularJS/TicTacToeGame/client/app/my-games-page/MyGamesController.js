(function () {

    function myGamesController(gameDataSvc, $location, $route, identity, $scope) {
        var vm = this;

        gameDataSvc
            .getUserGames()
            .then(function (response) {
                vm.games = response.data;
            });

        vm.delete = function deleteGame(game) {

            var currentUser = $scope.pc.globallyLoggedInUser;

            if (currentUser && game.FirstPlayer != currentUser) {
                toastr.error('Cannot delete game you have not created.');
            } else {
                gameDataSvc.deleteGame(game.Id)
                    .then(function (response) {
                        toastr.success('Deleted');
                        $route.reload();
                    }, function (err) {
                        toastr.error(err.data);
                    });
            }

        }

        vm.enter = function (game) {
            $location.path(`game/${game.Id}`);
        }
    }

    angular
        .module('TicTacToeApp.controllers')
        .controller('MyGamesController', ['gameDataSvc', '$location', '$route', 'identity','$scope', myGamesController]);
})();
