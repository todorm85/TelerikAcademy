var num = 123.45;

var reversedNum = digitReverse(num);
console.log(reversedNum);

function digitReverse (num) {
	num = num + '';  // convert to string so we can use split() on it
	num = num.split(''); // convert to array so we can use reverse() on it
	num.reverse(); // finally reverse the array of chars(one letter strings)
	num = num.join(''); // last convert the array back to string
	return num * 1; // return the string as float by multiplying it by 1, so we can preserve floats
}