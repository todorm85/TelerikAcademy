// ### Problem 10. Find palindromes
// *	Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

/*

1. Start check for arr[i] 
2. if i-k>0 and arr[i] === arr[i-k] then set foundFlag, push and shift (arr[i]) in foundArrs[palindCount], k+=2, 
3. else if not foundFlag and i-k-1>0 and arr[i]==arr[i-k-1] then push arr[i-1], push arr[i], shift arr[i-k-1], k=+2+1, set foundFlag
3. else if foundFlag then palindCount++, reset foundFlag, k=1, foundArr[palindCount]+=[],

*/

var txt = 'Lorem aabbbbaa xcvcx ipsum dolor sit amet.';
var palindromes = extractPalind (txt);
console.log(palindromes);

function extractPalind (txt) {
	var i,
		foundArr = [],
		k = 1,
		palindCount = 0,
		foundFlag = false,
		len = txt.length;

	foundArr.push('');

	for (i = 0; i < len; i+=1) {
		if (i-k>0 && txt[i]===txt[i-k]) {
			foundArr[palindCount] += txt[i];
			foundArr[palindCount] = txt[i] + foundArr[palindCount];
			k+=2;
			foundFlag = true;
		}
		else if (!foundFlag && i-2>0 && txt[i]===txt[i-2]) {
			foundArr[palindCount] += txt[i-1];
			foundArr[palindCount] += txt[i];
			foundArr[palindCount] = txt[i] + foundArr[palindCount];
			k+=3;
			foundFlag = true;
		}
		else if (foundFlag) {
			foundFlag = false;
			k=1;
			palindCount+=1;
			foundArr.push('');
			i-=1;
		}
	}

	foundArr.pop();

	return foundArr;
}