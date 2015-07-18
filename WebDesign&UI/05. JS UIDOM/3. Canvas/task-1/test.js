(function() {

    var canvas = document.getElementById('CanvasRegion'),
        ctx = canvas.getContext('2d');

    // canvas.width = Width;
    // canvas.height = Height;

    function drawHat() {
        ctx.beginPath();
        ctx.save();
        ctx.scale(1, .2);
        ctx.arc(50, 300, 45, 0, 2 * Math.PI);
        ctx.restore();
        ctx.stroke();
        ctx.fill();

        ctx.beginPath();
        ctx.save();
        ctx.scale(1, .2);
        ctx.arc(50, 290, 25, 0, Math.PI);
        ctx.lineTo(25, 60);
        ctx.lineTo(75, 60);
        ctx.closePath();
        ctx.restore();
        ctx.stroke();
        ctx.fill();

        ctx.beginPath();
        ctx.save();
        ctx.scale(1, .15);
        ctx.arc(50, 60, 25, 0, 2 * Math.PI);
        ctx.restore();
        ctx.stroke();
        ctx.fill();
    }

    function drawFace() {
        ctx.beginPath();
        ctx.arc(100, 100, 50, 0, 2 * Math.PI);
        ctx.stroke();
        ctx.fill();

        ctx.beginPath();
        ctx.save();
        ctx.translate(90, 125);
        ctx.rotate(10 * Math.PI / 180);
        ctx.scale(1, .35);
        ctx.arc(0, 0, 20, 0, 2 * Math.PI);
        ctx.restore();
        ctx.lineWidth = "2";
        ctx.stroke();

        ctx.beginPath();
        ctx.save();
        ctx.translate(0, 15);
        ctx.moveTo(90, 90);
        ctx.lineTo(80, 90);
        ctx.lineTo(90, 65);
        ctx.restore();
        ctx.lineWidth = "2";
        ctx.stroke();

        ctx.save();
        ctx.translate(70, 80);
        ctx.save();
        ctx.scale(.85, .85);
        drawEye();
        ctx.translate(45, 0);
        drawEye();
        ctx.restore();
        ctx.restore();

        function drawEye() {
            ctx.save();

            ctx.beginPath();
            ctx.save();
            ctx.scale(1, .65);
            ctx.arc(0, 0, 10, 0, 2 * Math.PI);
            ctx.restore();
            ctx.lineWidth = "2";
            ctx.stroke();

            ctx.beginPath();
            ctx.save();
            ctx.translate(-4, 0);
            ctx.scale(.5, 1);
            ctx.arc(0, 0, 5, 0, 2 * Math.PI);
            ctx.restore();
            ctx.lineWidth = "2";
            ctx.fillStyle = "darkblue";
            ctx.fill();

            ctx.restore();
        }
    }

    // face
    ctx.fillStyle = "lightblue";
    ctx.strokeStyle = "darkblue";
    ctx.lineWidth = "5";
    ctx.save();
    ctx.translate(-10, 20);
    ctx.scale(.9, .85);
    drawFace();
    ctx.restore();

    // hat    
    ctx.fillStyle = "#0088AA";
    ctx.strokeStyle = "black";
    ctx.lineWidth = "5";
    ctx.save();
    ctx.translate(23, 5);
    ctx.scale(1.1, 1);
    drawHat();
    ctx.restore();

    // bike
    ctx.save();
    // wheel 1
    ctx.fillStyle = "lightblue";
    ctx.strokeStyle = "darkblue";
    ctx.lineWidth = "3";
    ctx.translate(50, 250);
    ctx.beginPath();
    ctx.arc(50, 50, 40, 0, 2*Math.PI);
    ctx.stroke();
    ctx.fill();
    // wheel 2
    ctx.beginPath();
    ctx.translate(150, 0);
    ctx.arc(50, 50, 40, 0, 2*Math.PI);
    ctx.stroke();
    ctx.fill();
    // bbracket
    ctx.beginPath();
    ctx.lineWidth = "2";
    ctx.translate(-75, 0);
    ctx.arc(50, 50, 10, 0, 2*Math.PI);
    ctx.stroke();

    // chainstay
    ctx.beginPath();
    ctx.moveTo(50, 50);
    ctx.lineTo(-25, 50);
    ctx.moveTo(50, 50);
    ctx.lineTo(15, -15);
    ctx.lineTo(110, -15);
    ctx.lineTo(105, -35);

    ctx.stroke();

    ctx.restore();
}());