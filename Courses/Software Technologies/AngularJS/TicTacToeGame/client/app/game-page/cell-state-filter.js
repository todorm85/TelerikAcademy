(function () {
    angular
        .module('TicTacToeApp.filters')
        .filter('cellState', function () {
            return function (input) {
                var modifiedInput = input;
                switch (input) {
                    case '-':
                        modifiedInput = '';
                        break;
                }

                return modifiedInput;
            }
        });

})();
