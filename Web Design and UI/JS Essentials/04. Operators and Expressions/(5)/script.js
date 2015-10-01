var a = prompt('Enter integer: ');
if (a - (a | 0)) {
	console.log('Number is not an integer!');

} else {

	a = a >> 3;
	console.log('Bit #3 is: ' + (a & 1));
}