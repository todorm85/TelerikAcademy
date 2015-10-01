var canvas = document.getElementById('CanvasRegion');
var ctx = canvas.getContext('2d');

function applyStyles(fillColor, strokeColor, width) {
    ctx.fillStyle = fillColor;
    ctx.strokeStyle = strokeColor;
    ctx.lineWidth = width;
}

// first square
ctx.fillStyle = 'rgb(155,135,125)';
ctx.fillRect(5, 5, 40, 40);

// second square
applyStyles('orange', 'black', 3);
ctx.strokeRect(50, 5, 40, 40);
ctx.fillRect(50, 5, 40, 40);

// triangle
ctx.fillStyle = 'brown';
ctx.beginPath();
ctx.moveTo(100, 100);
ctx.lineTo(200, 200);
ctx.lineTo(200, 100);
ctx.closePath();
ctx.stroke();
ctx.fill();

// circle
ctx.beginPath();
// ctx.moveTo(400, 350);
ctx.arc(350, 350, 50, Math.PI / 2, 2 * Math.PI, false);
ctx.stroke();
ctx.fill();

// draw sector
function drawSector(x, y, r, from, to, isCounterClockwise) {
    ctx.beginPath();
    ctx.arc(x, y, r, from, to, isCounterClockwise);
    ctx.lineTo(x, y);
    ctx.closePath();
}

drawSector(300, 200, 50, 0, Math.PI / 2, false);
applyStyles('purple', 'orange', 3);
ctx.stroke();
ctx.fill();

// curves
ctx.beginPath();
ctx.moveTo(300, 200);
ctx.quadraticCurveTo(400, 200, 400, 100);
ctx.stroke();

// bezier
ctx.strokeStyle = 'black';
ctx.beginPath();
ctx.moveTo(300, 200);
ctx.bezierCurveTo(350, 200, 400, 150, 400, 100);
ctx.stroke();

// Drawing Text
ctx.font = "30px Arial";
ctx.fillStyle = "orange";

ctx.fillText("SOME Text", 150, 50);
ctx.lineWidth = 1;
ctx.strokeStyle = "green";
ctx.strokeText("stroked Text", 150, 80);

ctx.clearRect(0, 0, 640, 480);
ctx.fillStyle = "green";
ctx.strokeStyle = "black";
var minFontSize = 28;
var currentFontSize = 48;
var x = 200;
var y = currentFontSize;
while (minFontSize <= currentFontSize) {
    ctx.font = currentFontSize + "px " + "Arial";
    ctx.fillText("Telerik Academy", x, y);
    ctx.strokeText("Telerik Academy", x, y);

    y += currentFontSize;
    currentFontSize -= 3;
}

// Transformations
ctx.save();
ctx.rotate(20 * Math.PI / 180);
ctx.strokeRect(50, 0, 100, 100);
ctx.restore();
ctx.strokeRect(50, 0, 100, 100);
ctx.fillRect(50, 0, 100, 100);

// Per Pixel
function invertColors() {
    var ctx = document.getElementsByTagName("canvas")[0].getContext("2d");
    var imageData = ctx.getImageData(0, 0, ctx.canvas.width, ctx.canvas.height);
    for (var i = 0; i < imageData.data.length; i += 4) {
        imageData.data[i] = 255 - imageData.data[i];
        imageData.data[i + 1] = 255 - imageData.data[i + 1];
        imageData.data[i + 2] = 255 - imageData.data[i + 2];
    }
    ctx.putImageData(imageData, 0, 0);
}

invertColors();