var stage = new Kinetic.Stage({
    container: 'canvas-div',
    width: 500,
    height: 350
});

var canvasWrapper = document.getElementById('canvas-div').firstChild;
canvasWrapper.style.border = '1px solid black';

var layer = new Kinetic.Layer();

var player = new Kinetic.Rect({
    x: 100,
    y: 100,
    width: 30,
    height: 80,
    fill: 'yellowgreen',
    stroke: 'purple'
});

layer.add(player);
stage.add(layer);

var jumpHeight = 50;
var isJumping = false;

function jump(player) {
    // var x = player.getX();
    var initialY = player.getY();
    var deltaY = -1;
    var directionY = 1;

    function animateJump() {
        var currentY = player.getY();
        if (initialY - currentY >= jumpHeight) {
            directionY *= -1;
        }

        deltaY *= directionY;
        player.setY(currentY + deltaY);
        layer.draw();
        if (currentY < initialY + 1) {
            requestAnimationFrame(animateJump);
        } else {
            isJumping = false;
        }
    }
    animateJump();

}

function move(player, direction) {
    var currentX = player.getX();
    player.setX(currentX + direction);
    layer.draw();
}

// document.onkeydown = function(e) {
//     console.log(e.keyCode);

//     if (e.keyCode === 39) {
//         move(player, 1);
//     }
//     if (e.keyCode === 37) {
//         move(player, -1);
//     }

// };

// document.onkeyup = function(e) {
//     if (e.keyCode === 32) {
//         if (!isJumping) {
//             isJumping = true;
//             jump(player);
//         }
//     }
// }

// Keyboard input with customisable repeat (set to 0 for no key repeat)
//
function KeyboardController(keys, repeat) {
    // Lookup of key codes to timer ID, or null for no repeat
    //
    var timers = {};

    // When key is pressed and we don't already think it's pressed, call the
    // key action callback and set a timer to generate another one after a delay
    //
    document.onkeydown = function(event) {
        var key = (event || window.event).keyCode;
        if (!(key in keys))
            return;
        if (!(key in timers)) {
            timers[key] = null;
            keys[key]();
            if (repeat !== 0)
                timers[key] = setInterval(keys[key], repeat);
        }
        return;
    };

    // Cancel timeout and mark key as released on keyup
    //
    document.onkeyup = function(event) {
        var key = (event || window.event).keyCode;
        if (key in timers) {
            if (timers[key] !== null)
                clearInterval(timers[key]);
            delete timers[key];
        }
    };

    // When window is unfocused we may not get key events. To prevent this
    // causing a key to 'get stuck down', cancel all held keys
    //
    window.onblur = function() {
        for (key in timers)
            if (timers[key] !== null)
                clearInterval(timers[key]);
        timers = {};
    };
};

// Arrow key movement. Repeat key five times a second
//
KeyboardController({
    // right
    37: function() {
        move(player, -1);
    },
    // left
    39: function() {
        move(player, 1);
    },
    // space
    32: function() {
        if (!isJumping) {
            isJumping = true;
            jump(player);
        }
    },
}, 25);