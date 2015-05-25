// ### Problem 3. Sub-string in text
// *	Write a JavaScript function that finds how many times a substring is contained in a given text (perform case insensitive search).

var text = 'Lorem ipsum dolor lorem sit amet.';
var str = 'lorem';
var result = countString(str,text);

console.log(result);
result = countString('',text);
console.log(result);
result = countString(str,'');
console.log(result);

function countString (str, text) {
	if (!str || !text) {
		return null;
	}

	str = str.toLowerCase();
	text = text.toLowerCase();

	var count = 0,
		index = -1,
		len = text.length;

	while (true) {
		index = text.indexOf(str, index+1);
		if (index === -1) { break;}
		count+=1;
	}

	return count;
}