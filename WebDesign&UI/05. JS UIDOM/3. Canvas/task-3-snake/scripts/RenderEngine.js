var RenderEngine = (function() {

    var CanvasRenderer = function() {

        function init(width, height) {
            this.canvas = document.getElementById('canvas-region');
            this.ctx = this.canvas.getContext('2d');
            this.canvas.width = width;
            this.canvas.height = height;
            return this;
        }

        function renderText(x, y, size, color, text) {
            var ctx = this.ctx;
            ctx.font = size + "px Arial";
            ctx.fillStyle = "black";
            ctx.save();
            ctx.beginPath();
            ctx.fillText(text, x, y);
        }

        function clearScreen (x, y, width, height) {
            var ctx = this.ctx;
            ctx.clearRect(x, y, width, height);
        }

        return {
            init: init,
            renderText: renderText,
            clearScreen: clearScreen
        }
    }();

    return {
        CanvasRenderer: CanvasRenderer
    }

}());