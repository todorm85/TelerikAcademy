var a = prompt('Enter integer: ');
if (a - (a | 0)) {
	console.log('Number is not an integer!');

} else {

	a = (a / 100) | 0;

	if (a % 10 === 7) {
		console.log('Yes, third digit is 7');

	} else {
		console.log('No, third digit is NOT 7');
	}
}