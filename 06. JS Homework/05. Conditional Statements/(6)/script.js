var a = prompt('Enter coef. a') * 1,
	b = prompt('Enter coef. b') * 1,
	c = prompt('Enter coef. c') * 1,
	D = b * b - 4 * a * c;

if (D < 0) {
	console.log('No real roots!');
} else if (D === 0) {
	console.log('One real root: ' + (-b / (2 * a)));
} else {
	console.log('X1 = ' + ((-b + Math.sqrt(D)) / (2 * a)));
	console.log('X2 = ' + ((-b - Math.sqrt(D)) / (2 * a)));
}