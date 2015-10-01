var InputProviders = function () {
    //game keys
    var ESC = 27;
    var SPACE = 32;
    var LEFT_ARROW = 37;
    var UP_ARROW = 38;
    var RIGHT_ARROW = 39;
    var DOWN_ARROW = 40;
    var Keyboard = function () {
        var currentInput = {
            p0: 'right',
            p1: 'right'
        };

        function init() {

            document.onkeydown = function (e) {
                currentInput.p0 = currentInput.p1;
                var input  = 'other';
                if (e.keyCode === LEFT_ARROW) {

                    input = 'left';
                } else if (e.keyCode === UP_ARROW) {

                    input = 'up';
                } else if (e.keyCode === RIGHT_ARROW) {

                    input = 'right';
                } else if (e.keyCode === DOWN_ARROW) {

                    input = 'down';
                } else if (e.keyCode === SPACE) {
                    window.location.reload();
                }
                else {
                    input = 'other';
                }

                currentInput.p1 = input;
            };

            return this;
        }

        function getInput() {
            return currentInput;
        }

        return {
            init: init,
            getInput: getInput
        };
    }();

    return {
        Keyboard: Keyboard
    };
}();