var a = prompt('Enter integer: ');
if (a - (a | 0) !== 0) {
	console.log('Number is not an integer!');
} else {

	if (a % 2 === 0) {
		console.log('Even');
	} else {
		console.log('Odd');
	}
}