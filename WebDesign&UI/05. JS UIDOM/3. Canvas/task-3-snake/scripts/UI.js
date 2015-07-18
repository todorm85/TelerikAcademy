

var UI = function() {
    var init = function(renderer, inputProvider) {
        this.renderer = renderer;
        this.inputProvider = inputProvider;
    }

    var start = function start() {
        var title = 'WELCOME\nPlease press space to continue...';
        this.renderer.renderText(120, 240, 20, 'black', title);
        
    }

    return {
        start: start,
        init: init
    }
}();