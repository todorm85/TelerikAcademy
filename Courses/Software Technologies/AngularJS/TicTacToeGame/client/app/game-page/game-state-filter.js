(function () {
    angular
        .module('TicTacToeApp.filters')
        .filter('gameState', function () {
            return function (input) {
                var modifiedInput;
                switch (input) {
                    case 0:
                        modifiedInput = 'WaitingForSecondPlayer';
                        break;
                    case 1:
                        modifiedInput = 'First player turn';
                        break;
                    case 2:
                        modifiedInput = 'Second player turn';
                        break;
                    case 3:
                        modifiedInput = 'First player won.';
                        break;
                    case 4:
                        modifiedInput = 'Second player won';
                        break;
                    case 5:
                        modifiedInput = 'Game ended in draw';
                        break;
                }

                return modifiedInput;
            }
        });

})();
