(function () {

    function gameDataSvc($http, $q, $resource, baseUrl) {

        var API_URL = baseUrl + 'api/games/';

        function createGame() {
            return $http.post(API_URL + 'create');
        }

        function joinGame(id) {
            return $http.post(API_URL + 'join/' + id);
        }

        function playGame(data) {
            return $http.post(API_URL + 'play', data);
        }

        function getGameStatus(gameId) {
            return $http.get(API_URL + 'status', {
                params: {
                    gameId: gameId
                }
            });
        }

        function getAllGames() {
            return $http.get(API_URL + 'list');
        }

        function getUserGames() {
            return $http.get(API_URL + 'listmy');
        }

        function deleteGame(id) {
            return $http.delete(API_URL + 'delete/' + id);
        }

        return {
            createGame,
            joinGame,
            getGameStatus,
            playGame,
            getAllGames,
            getUserGames,
            deleteGame
        };
    }

    angular
        .module('TicTacToeApp.services')
        .service('gameDataSvc', ['$http', '$q', '$resource', 'baseUrl', gameDataSvc]);

})();
