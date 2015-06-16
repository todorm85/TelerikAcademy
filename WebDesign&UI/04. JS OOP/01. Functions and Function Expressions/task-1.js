/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(numsArr) {
	var numIndex;

	// check if argument was passed
	if (!numsArr) {
		throw 'MESSAGE: Please supply an argument';
	}

	// check if argument passed is array
	if (!(Object.prototype.toString.call( numsArr ) === '[object Array]')) {
		throw 'MESSAGE: Please supply an array of numbers';
	}

	// check arr length
	if (!numsArr.length) {
		return null;
	}

	// check that array contains only numbers
	if (!numsArr.every(function (num, currentIndex) {
		if (Number(num) || num === 0) {
			return true;
		} else {
			numIndex = currentIndex;
			return false;
		}
	})) {
		throw 'MESSAGE: Element ' + numIndex + ' not convertible to number!';
	}

	// return the result
	return numsArr.reduce(function (sum, num) {
		return sum += (num | 0);
	}, 0);
}

module.exports = sum;

console.log(sum([1,2,3]));