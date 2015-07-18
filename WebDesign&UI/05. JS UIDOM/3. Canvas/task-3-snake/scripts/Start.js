(function() {
    var pause = true;
    var renderer = Object.create(RenderEngine.CanvasRenderer).init(640, 480);
    var inputProvider = Object.create(InputProvider.Keyboard);
    document.onkeydown = function(e) {
                
                if (e.keyCode === 37) {
                    pause = !pause;
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
    // var engine = Object.create(GameEngine);
    var ui = Object.create(UI);

    // engine.init(renderer, inputProvider);
    ui.init(renderer, inputProvider);
    var gameOver = false;
    // do {
    ui.start();
    while (pause) {1+1;}
    renderer.clearScreen(0, 0, 640, 480);
    // engine.start();
    // } while (!gameOver);

}());