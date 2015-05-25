// ### Problem 4. Parse tags
// *	You are given a text. Write a function that changes the text in all regions:

/* 	1. start search for closing tag from the end
	2. get tag name
	3. search from the end for first opening tag with same name
	4. format the text between these two tags, without the other tags, according to tag name
	5. Remove the tag and start from 1

	this algo ensures that the innermost nested tags have the hightest precedence*/

var txt = "We are `<mixcase>living</mixcase>` in a `<upcase>yellow submarine</upcase>`. We `<mixcase>don't</mixcase>` have `<lowcase>ANYTHING</lowcase>` else.";
// var txt = "We are `<lowcase>LIVING` in a `<upcase>yellow submarine</upcase>`. We `DON't</lowcase>` have `<lowcase>ANYTHING</lowcase>` else."; // testa nested tags
var txt = "<upcase>We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>ANYTHING</lowcase> </upcase> else.";

console.log(parseTags(txt));

function parseTags(txt) {
	while (true) {
		var closeTagStartIndex = txt.lastIndexOf('</');
		if (closeTagStartIndex === -1) {
			break;
		}
		var closeTagEndIndex = txt.indexOf('>', closeTagStartIndex);
		var tagName = txt.substring(closeTagStartIndex + 2, closeTagEndIndex);
		var openTagStartIndex = txt.lastIndexOf('<' + tagName + '>');
		var openTagEndIndex = openTagStartIndex + tagName.length + 1;

		var leftTxt = txt.substring(0, openTagEndIndex + 1);
		var midTxt = txt.substring(openTagEndIndex + 1, closeTagStartIndex);
		var rightTxt = txt.substring(closeTagStartIndex);
		// if (leftTxt===undefined) {leftTxt='';}
		leftTxt = leftTxt.substring(0, leftTxt.lastIndexOf('<'));
		// if (rightTxt===undefined) {rightTxt='';}
		rightTxt = rightTxt.substring(rightTxt.indexOf('>') + 1);

		txt = leftTxt + formatText(midTxt, tagName) + rightTxt; // format text in tag
	}

	return txt;

	function formatText(txt, tagName) {
		if (txt === '') {
			return txt;
		}

		var firstTagStart = txt.indexOf('<');
		var firstTagEnd = txt.indexOf('>');

		if (firstTagStart === -1) {
			if (tagName === 'upcase') {
				return txt.toUpperCase();
			} else if (tagName === 'lowcase') {
				return txt.toLowerCase();
			} else if (tagName === 'mixcase') {
				return formatMixCase(txt);
			} else {
				return 'error in tag name';
			}
		} else {
			var leftTxt = txt.substring(0, firstTagStart);
			var tagTxt = txt.substring(firstTagStart, firstTagEnd + 1);
			var rightTxt = txt.substring(firstTagEnd + 1);
			// if (leftTxt===undefined) {leftTxt='';}
			// if (rightTxt===undefined) {rightTxt='';}
			return formatText(leftTxt, tagName) + tagTxt + formatText(rightTxt, tagName);
		}
	}

	function formatMixCase(txt) {
		var ch,
			i,
			len = txt.length,
			num;
		for (i = 0; i < len; i += 1) {
			ch = txt[i];
			var num = getRandomArbitrary(0, 4) | 0;
			if (num >= 2) {
				ch = ch.toLowerCase();
			} else {
				ch = ch.toUpperCase();
			}
			txt = txt.substring(0, i) + ch + txt.substring(i + 1);
		}
		return txt;
	}

	function getRandomArbitrary(min, max) {
		return Math.random() * (max - min) + min;
	}
}