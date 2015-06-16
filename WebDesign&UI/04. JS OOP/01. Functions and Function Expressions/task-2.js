/* Task description */
/*
	Write a function a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `string`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(start, end) {
	function checkPrime(num) {
		var i = 5;
		var isPrime = true;

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
			return isPrime;
		}
	}

	var primesFound = [],
		i;

	if (arguments.length !== 2) {
		throw 'MESSAGE: Please supply start and end number!';
	}

	// check that arguments are numbers
	if (!(Number(start) && Number(end))) {
		throw 'Please supply numbers as start and end'
	}

	start |= 0;
	end |= 0;

	for (i = start; i <= end; i+=1) {
		if (checkPrime(i)) {
			primesFound.push(i);
		}
	}			

	return primesFound;
}

module.exports = findPrimes;