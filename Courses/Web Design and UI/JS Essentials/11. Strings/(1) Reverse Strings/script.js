// ### Problem 1. Reverse string
// *	Write a JavaScript function that reverses a string and returns it.

function charReverse(str) {
	str = str + ''; // convert to string so we can use split() on it
	str = str.split(''); // convert to array so we can use reverse() on it
	str.reverse(); // finally reverse the array of chars(one letter strings)
	str = str.join(''); // last convert the array back to string
	return str;
}

var str = 'abcdef';
console.log(charReverse(str));