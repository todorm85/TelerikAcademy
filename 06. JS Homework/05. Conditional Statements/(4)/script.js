var num1 = prompt('Enter first num: ') * 1,
	num2 = prompt('Enter second num: ') * 1,
	num3 = prompt('Enter third num: ') * 1;

if (num1>num2) {
	if (num2>num3) {
		console.log(num1 + ' ' + num2 + ' ' + num3);
	}
	else {
		if (num1>num3) {
			console.log(num1 + ' ' + num3 + ' ' + num2);
		}
		else {
			console.log(num3 + ' ' + num1 + ' ' + num2);
		}
	}
}
else if (num1>num3) {
	console.log(num2 + ' ' + num1 + ' ' + num3);
}
else if (num2>num3) {
	console.log(num2 + ' ' + num3 + ' ' + num1);
}
else {
	console.log(num3 + ' ' + num2 + ' ' + num1);
}