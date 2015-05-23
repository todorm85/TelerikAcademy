var text = ('Lorem ipsum dolor sit amet lorem, consectetur adipisicing loremelit. Nesciunt, atque lorem.');
var key = 'lorem';
wordCountInsense = countWords(key, text, true),
	wordCountSense = countWords(key, text);

console.log('wordCountInsense = ' + wordCountInsense);
console.log('wordCountSense = ' + wordCountSense);

function countWords(key, text, caseFlag) {
	var index = -1,
		count = 0,
		keyLength = key.length;

	if (caseFlag) {	// this if creates the overloading for Case Sensitivity
		text = text.toLowerCase();
		key = key.toLowerCase();
	}

	key = ' ' + key + ' '; // prevents counting complex words that contain the word
	text = ' ' + text + ' '; // prevents index out of range when searching for the key with leading and trailing whitespaces
	text = removePunctuation(text); // substitute punctuation with spaces, in cases where the searched word is at the end of a sentence or is followed by comma ect.

	while (true) {	// this is the counting algorithm
		index = text.indexOf(key, index + 1);
		if (index !== -1) {
			count += 1;
		} else {
			break;
		}
	}
	return count;

	function removePunctuation(text) {
		var punc = ['.', '!', ':', '"', '\'', '(', '[', '{', '}', '?', ','], // this is all the punctuation signs that we want to substitue with whitespaces
			i,
			i2;			

		for (i in punc) {
			for (i2 in text) {
				if (punc[i] === text.charAt(i2)) {
					text = text.replace(punc[i], ' '); // this replaces the first occurance of the punct sign, so we need to repeat it as many times as there are occurances of the current sign. It might be done through the use of regex, but there are problems when serching for '.' or ''' in regex, you need to know what you are doing and it is not faster for computation.
				}	
			}
		}
		return text;
	}
}
