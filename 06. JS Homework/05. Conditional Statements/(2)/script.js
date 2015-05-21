var num1 = prompt('Enter first num: ') * 1,
	num2 = prompt('Enter second num: ') * 1,
	num3 = prompt('Enter third num: ') * 1;

if (num1===0 || num2 === 0 || num3 === 0) {
	console.log('0');
}
else {
	if (num1<0) {
		if ((num2<0&&num3<0) || (num2>0&&num3>0) ) {
			console.log('-');
		}
		else {
			console.log('+');
		}
	}
	if (num1>0) {
		if ((num2<0&&num3<0) || (num2>0&&num3>0) ) {
			console.log('+');
		}
		else {
			console.log('-');
		}
	}
}