var a = prompt('Enter an integer: ');

if (a - (a | 0) !== 0) {
	console.log('Number is not an integer!');

} else {

	if ((a % 7 === 0) && (a % 5 === 0)) {
		console.log('Number CAN be divided by 7 and 5');
	} else {
		console.log('Number CANNOT be divided by 7 and 5');
	}
}