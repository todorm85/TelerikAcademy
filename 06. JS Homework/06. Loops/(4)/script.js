var lexSmallest = '',
	lexLargest = '',
	prop;

for (prop in document) {
	if (lexLargest==='') {lexLargest=prop;}
	if (lexSmallest==='') {lexSmallest=prop; continue;}

	if (lexSmallest > prop) {
		lexSmallest = prop;
	}
	if (lexLargest < prop) {
		lexLargest = prop;
	}
}

console.log('Largest: ' + lexLargest + ', Smllest: ' + lexSmallest);

lexSmallest = '';
lexLargest = '';

for (prop in window) {
	if (lexLargest==='') {lexLargest=prop;}
	if (lexSmallest==='') {lexSmallest=prop; continue;}

	if (lexSmallest > prop) {
		lexSmallest = prop;
	}
	if (lexLargest < prop) {
		lexLargest = prop;
	}
}

console.log('Largest: ' + lexLargest + ', Smllest: ' + lexSmallest);

lexSmallest = '';
lexLargest = '';

for (prop in navigator) {
	if (lexLargest==='') {lexLargest=prop;}
	if (lexSmallest==='') {lexSmallest=prop; continue;}
	
	if (lexSmallest > prop) {
		lexSmallest = prop;
	}
	if (lexLargest < prop) {
		lexLargest = prop;
	}
}

console.log('Largest: ' + lexLargest + ', Smllest: ' + lexSmallest);