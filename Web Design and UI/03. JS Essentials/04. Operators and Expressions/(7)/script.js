var i = 5;
var isPrime = true;
var num = prompt('enter integer: ');

if (num - (num | 0)) {
	console.log('Number is not an integer!');

} else {
	if (num <= 1) {
		isPrime = false;
	} else if (num > 3 && (num % 2 === 0 || num % 3 === 0)) {
		isPrime = false;
	} else {
		while (i * i <= num) {
			if (num % i === 0 || num % (i + 2) === 0) {
				isPrime = false;
			}
			i += 6;
		}
	}

	console.log(isPrime);
}