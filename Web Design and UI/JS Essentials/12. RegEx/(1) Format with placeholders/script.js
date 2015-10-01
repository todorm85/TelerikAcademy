// ### Problem 1. Format with placeholders
// *	Write a function that formats a string. The function should have placeholders, as shown in the example
// 	*	Add the function to the **String.prototype**

if (!String.hasOwnProperty('format')) {
	String.prototype.format = function(options) {
		for (var item in options) {
			var placeholdPattern = new RegExp('#{' + item + '}', 'g');
			return this.replace(placeholdPattern, options[item]);
		}
	}
}

var options = {
	name: 'John'
};
console.log('Hello, there! Are you #{name}?'.format(options));
var str = 'Hello, there! Are you #{name}?';
str = str.format(options);
console.log(str);