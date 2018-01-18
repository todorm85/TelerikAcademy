// ### Problem 11. String format
// *	Write a function that formats a string using placeholders.
// *	The function should work with up to 30 placeholders and all types.

var result = stringFormat('{0}a{1}{0}b{1}{2}', 0, '2', true);

console.log('\nFINAL RESULT = ' + result);

function stringFormat() {
	var argCount = arguments.length;
	if (argCount === 0) {
		return undefined;
	}
	var i;
	var str = arguments[0];
	console.log('string to process = ' + str);

	for (i = 1; i < argCount; i += 1) {
		var placeHolderPatter = new RegExp('\\{' + (i-1) + '+?\\}', 'g');
		console.log('Patter to search for argument ' + i + ': ' + placeHolderPatter);
		console.log('Argument ' + i + ' = ' + arguments[i]);
		str = str.replace(placeHolderPatter, arguments[i]);
	}

	return str;
}