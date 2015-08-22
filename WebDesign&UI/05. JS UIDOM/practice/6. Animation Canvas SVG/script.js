var stage = new Kinetic.Stage({
    container: 'canvas-div',
    width: 500,
    height: 350
});

var canvasWrapper = document.getElementById('canvas-div').firstChild;
canvasWrapper.style.border = '1px solid black';

var layer = new Kinetic.Layer();
var ballsCount = 13;
var balls = [];
var ballsProps = [];
for (var i = 0; i < ballsCount; i++) {
    var ball = new Kinetic.Circle({
        x: 16 + Math.random() * (stage.getWidth() - 16),
        y: 16 + Math.random() * (stage.getHeight() - 16),
        radius: 15,
        fill: 'yellow',
        stroke: 'purple'
    });
    balls.push(ball);

    ballsProps.push({
        dirX: 1,
        dirY: 1,
        speed: (Math.random() * 5)
    });

    layer.add(ball);
}

function checkBallsCollision(ball, index) {
    return balls.some(function(otherBall, otherIndex) {
        var firstX = ball.getX();
        var secondX = otherBall.getX();
        var firstY = ball.getY();
        var secondY = otherBall.getY();
        return (firstX - secondX) * (firstX - secondX) + (firstY - secondY) * (firstY - secondY) - ball.getRadius() * ball.getRadius() * 4 <= 0.000001 && otherIndex !== index;
    });
}

function animFrame() {
    balls.forEach(function(ball, index) {
        var x = ball.getX();
        var y = ball.getY();
        var deltaX = ballsProps[index].speed;
        var deltaY = ballsProps[index].speed;
        if (x > stage.getWidth() - ball.getRadius() ||
                x < 0 + ball.getRadius() ||
                checkBallsCollision(ball, index)) {
            ballsProps[index].dirX *= -1;
        }
        if (y > stage.getHeight() - ball.getRadius() ||
                y < 0 + ball.getRadius() ||
                checkBallsCollision(ball, index)) {
            ballsProps[index].dirY *= -1;
        }

        var directionX = ballsProps[index].dirX;
        var directionY = ballsProps[index].dirY;
        var newX = x + deltaX * directionX;
        var newY = y + deltaY * directionY;

        ball.setX(newX);
        ball.setY(newY);
    });
    layer.draw();
    setTimeout(animFrame, 10);
}

animFrame();

stage.add(layer);