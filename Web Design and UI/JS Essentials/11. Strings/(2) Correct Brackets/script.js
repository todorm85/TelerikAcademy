// ### Problem 2. Correct brackets
// *	Write a JavaScript function to check if in a given expression the brackets are put correctly.

var text = 'Lorem ipsum (dolor sit[ amet, consectetur] adipisicing) elit. Saepe, aspernatur.'; // true
// var text = 'Lorem ipsum )dolor sit[ amet, consectetur] adipisicing) elit. Saepe, aspernatur.'; // false
// var text = 'Lorem ipsum (dolor sit[ amet, ) consectetur] adipisicing) elit. Saepe, aspernatur.'; // false
// var text = 'Lorem ipsum (dolor (sit[ amet, consectetur] adipisicing) elit.) Saepe, aspernatur.'; // true
// var text = '((a+b)/5-d)'; // true
// var text = ')(a+b))'; // false

console.log(checkBrackets(text));

function checkBrackets(text) {
	var len = text.length;		
	var open = {
		'[': {count: 0, opposite: ']'},
		'(': {count: 0, opposite: ')'},
		'{': {count: 0, opposite: '}'},
		'<': {count: 0, opposite: '>'}
	};
	var close = {
		']': {opposite: '['},
		')': {opposite: '('},
		'}': {opposite: '{'},
		'>': {opposite: '<'}
	};

	var expectedArr = [];
	var expectedCh;
	var oppositeCh;
	var ch;
	var i;

	for (i = 0; i < len; i += 1) {
		ch = text[i];

		if (open.hasOwnProperty(ch)) {
			open[ch]['count'] += 1;
			expectedArr.push(open[ch]['opposite']);
			continue;
		}

		if (close.hasOwnProperty(ch)) {
			if (expectedArr.length === 0) {return false;}
			expectedCh = expectedArr[expectedArr.length - 1];
			oppositeCh = close[ch]['opposite'];
			if (open[oppositeCh]['count'] === 0 || ch !== expectedCh) {
				return false;
			} else {
				open[oppositeCh]['count'] -= 1;
				expectedArr.pop();
			}
		}
	}

	var prop;
	for (prop in open) {
		if (open[prop]['count'] !== 0) {
			return false;
		}
	}

	return true;
}