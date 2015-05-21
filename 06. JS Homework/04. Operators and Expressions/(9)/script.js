var pX = prompt('Enter pointX') * 1;
var pY = prompt('Enter pointY') * 1;
var circleOX = 1;
var circleOY = 1;
var radius = 3;
var dX = pX - circleOX;
var dY = pY - circleOY;
var rectangleTop = 1;
var rectangleLeft = -1;
var rectangleWidth = 6;
var rectangleHeight = 2;
var isIn = true;

if ((dX * dX + dY * dY) > radius * radius) {
	isIn = false;
}

if (pX >= rectangleLeft && pX <= rectangleLeft + rectangleWidth && pY <= rectangleTop && pY >= rectangleTop - rectangleHeight) {
	isIn = false;
}

console.log(isIn);