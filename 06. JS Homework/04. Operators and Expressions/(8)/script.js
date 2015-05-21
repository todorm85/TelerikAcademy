var sideA = prompt('Enter side a') * 1,
	sideB = prompt('Enter side b') * 1,
	h = prompt('Enter side h') * 1;

if (sideB<=0 || sideA<=0 || h<=0) {
	console.log('Sides cannot be negative!');
}

console.log('Area is: ' + (((sideA + sideB) / 2) * h));