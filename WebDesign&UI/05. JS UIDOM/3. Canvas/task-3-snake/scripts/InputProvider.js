var InputProvider = function() {
    var Keyboard = function() {
        function init() {

            document.onkeydown = function(e) {
                pause = !pause;
                if (e.keyCode === 37) {
                    // dir = 'left';
                } else if (e.keyCode === 38) {
                    // dir = 'up';
                } else if (e.keyCode === 39) {
                    // dir = 'right';
                } else if (e.keyCode === 40) {
                    // dir = 'down';
                } else {
                }
            };
        }
        return {
            init: init
        }
    }();

    return {
        Keyboard: Keyboard
    }
}();