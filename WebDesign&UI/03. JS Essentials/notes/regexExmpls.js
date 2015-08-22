// Creating a regular expression

// You construct a regular expression in one of two ways:

// Using a regular expression literal, as follows:
// var re = /ab+c/;


// Regular expression literals provide compilation of the regular expression when the script is loaded. When the regular expression will remain constant, use this for better performance.

// Or calling the constructor function of the RegExp object, as follows:
// var re = new RegExp("ab+c");


// Using the constructor function provides runtime compilation of the regular expression. Use the constructor function when you know the regular expression pattern will be changing, or you don't know the pattern and are getting it from another source, such as user input.






// Working with regular expressions

// Regular expressions are used with the RegExp methods test and exec and with the String methods match, replace, search, and split. These methods are explained in detail in the JavaScript reference.

// Methods that use regular expressions


// Method

// Description


// exec A RegExp method that executes a search for a match in a string. It returns an array of information. 
// test A RegExp method that tests for a match in a string. It returns true or false. 
// match A String method that executes a search for a match in a string. It returns an array of information or null on a mismatch. 
// search A String method that tests for a match in a string. It returns the index of the match, or -1 if the search fails. 
// replace A String method that executes a search for a match in a string, and replaces the matched substring with a replacement substring. 
// split A String method that uses a regular expression or a fixed string to break a string into an array of substrings. 

// When you want to know whether a pattern is found in a string, use the test or search method; for more information (but slower execution) use the exec or match methods. If you use exec or match and if the match succeeds, these methods return an array and update properties of the associated regular expression object and also of the predefined regular expression object, RegExp. If the match fails, the exec method returns null (which coerces to false).

// In the following example, the script uses the exec method to find a match in a string.
var myRe = /d(b+)d/g;
var myArray = myRe.exec("cdbbdbsbz");


// If you do not need to access the properties of the regular expression, an alternative way of creating myArray is with this script:
// var myArray = /d(b+)d/g.exec("cdbbdbsbz");1


// If you want to construct the regular expression from a string, yet another alternative is this script:
var myRe = new RegExp("d(b+)d", "g");
var myArray = myRe.exec("cdbbdbsbz");

// With these scripts, the match succeeds and returns the array and updates the properties shown in the following table.

// Results of regular expression execution.


// Object

// Property or index

// Description

// In this example


// myArray   The matched string and all remembered substrings. ["dbbd", "bb"] 
// index The 0-based index of the match in the input string. 1 
// input The original string. "cdbbdbsbz" 
// [0] The last matched characters. "dbbd" 
// myRe lastIndex The index at which to start the next match. (This property is set only if the regular expression uses the g option, described in Advanced Searching With Flags.) 5 
// source The text of the pattern. Updated at the time that the regular expression is created, not executed. "d(b+)d" 

// As shown in the second form of this example, you can use a regular expression created with an object initializer without assigning it to a variable. If you do, however, every occurrence is a new regular expression. For this reason, if you use this form without assigning it to a variable, you cannot subsequently access the properties of that regular expression. For example, assume you have this script:
// var myRe = /d(b+)d/g;
// var myArray = myRe.exec("cdbbdbsbz");
// console.log("The value of lastIndex is " + myRe.lastIndex);

// // "The value of lastIndex is 5"1
// 2
// 3
// 4
// 5


// However, if you have this script:
var myArray = /d(b+)d/g.exec("cdbbdbsbz");
console.log("The value of lastIndex is " + /d(b+)d/g.lastIndex);

// // "The value of lastIndex is 0"1
// 2
// 3
// 4


// The occurrences of /d(b+)d/g in the two statements are different regular expression objects and hence have different values for their lastIndex property. If you need to access the properties of a regular expression created with an object initializer, you should first assign it to a variable.

// Using parenthesized substring matches

// Including parentheses in a regular expression pattern causes the corresponding submatch to be remembered. For example, /a(b)c/ matches the characters 'abc' and remembers 'b'. To recall these parenthesized substring matches, use the Array elements [1], ..., [n].

// The number of possible parenthesized substrings is unlimited. The returned array holds all that were found. The following examples illustrate how to use parenthesized substring matches.

// The following script uses the replace() method to switch the words in the string. For the replacement text, the script uses the $1 and $2 in the replacement to denote the first and second parenthesized substring matches.
// var re = /(\w+)\s(\w+)/;
// var str = "John Smith";
// var newstr = str.replace(re, "$2, $1");
// console.log(newstr);1
// 2
// 3
// 4


// This prints "Smith, John".

// Advanced searching with flags

// Regular expressions have four optional flags that allow for global and case insensitive searching. These flags can be used separately or together in any order, and are included as part of the regular expression.

// Regular expression flags


// Flag

// Description


// g Global search. 
// i Case-insensitive search. 
// m Multi-line search. 
// y Perform a "sticky" search that matches starting at the current position in the target string. 

// To include a flag with the regular expression, use this syntax:
// var re = /pattern/flags;1


// or
// var re = new RegExp("pattern", "flags");1


// Note that the flags are an integral part of a regular expression. They cannot be added or removed later.

// For example, re = /\w+\s/g creates a regular expression that looks for one or more characters followed by a space, and it looks for this combination throughout the string.
// var re = /\w+\s/g;
// var str = "fee fi fo fum";
// var myArray = str.match(re);
// console.log(myArray);1
// 2
// 3
// 4


// This displays ["fee ", "fi ", "fo "]. In this example, you could replace the line:
// var re = /\w+\s/g;1


// with:
// var re = new RegExp("\\w+\\s", "g");1


// and get the same result.

// The m flag is used to specify that a multiline input string should be treated as multiple lines. If the m flag is used, ^ and $ match at the start or end of any line within the input string instead of the start or end of the entire string.







// Special characters in regular expressions.


// \
// Matches according to the following rules:
//  A backslash that precedes a non-special character indicates that the next character is special and is not to be interpreted literally. For example, a 'b' without a preceding '\' generally matches lowercase 'b's wherever they occur. But a '\b' by itself doesn't match any character; it forms the special word boundary character.
//  A backslash that precedes a special character indicates that the next character is not special and should be interpreted literally. For example, the pattern /a*/ relies on the special character '*' to match 0 or more a's. By contrast, the pattern /a\*/ removes the specialness of the '*' to enable matches with strings like 'a*'.
//  Do not forget to escape \ itself while using the RegExp("pattern") notation because \ is also an escape character in strings.


// ^
// Matches beginning of input. If the multiline flag is set to true, also matches immediately after a line break character.
//  For example, /^A/ does not match the 'A' in "an A", but does match the 'A' in "An E".
//  The '^' has a different meaning when it appears as the first character in a character set pattern. See complemented character sets for details and an example.


// $
// Matches end of input. If the multiline flag is set to true, also matches immediately before a line break character.
// For example, /t$/ does not match the 't' in "eater", but does match it in "eat".


// *
// Matches the preceding character 0 or more times. Equivalent to {0,}.
// For example, /bo*/ matches 'boooo' in "A ghost booooed" and 'b' in "A bird warbled", but nothing in "A goat grunted".


// + 
// Matches the preceding character 1 or more times. Equivalent to {1,}.
// For example, /a+/ matches the 'a' in "candy" and all the a's in "caaaaaaandy", but nothing in "cndy".
 
// ? 
// Matches the preceding character 0 or 1 time. Equivalent to {0,1}.
//  For example, /e?le?/ matches the 'el' in "angel" and the 'le' in "angle" and also the 'l' in "oslo".
//  If used immediately after any of the quantifiers *, +, ?, or {}, makes the quantifier non-greedy (matching the fewest possible characters), as opposed to the default, which is greedy (matching as many characters as possible). For example, applying /\d+/ to "123abc" matches "123". But applying /\d+?/ to that same string matches only the "1".
//  Also used in lookahead assertions, as described in the x(?=y) and x(?!y) entries of this table.
   
// . 
// (The decimal point) matches any single character except the newline character.
// For example, /.n/ matches 'an' and 'on' in "nay, an apple is on the tree", but not 'nay'.

// (x) 
// Matches 'x' and remembers the match, as the following example shows. The parentheses are called capturing parentheses.
//  The '(foo)' and '(bar)' in the pattern /(foo) (bar) \1 \2/ match and remember the first two words in the string "foo bar foo bar". The \1 and \2 in the pattern match the string's last two words. Note that \1, \2, \n are used in the matching part of the regex. In the replacement part of a regex the syntax $1, $2, $n must be used, e.g.: 'bar foo'.replace( /(...) (...)/, '$2 $1' ).
 
// (?:x) Matches 'x' but does not remember the match. The parentheses are called non-capturing parentheses, and let you define subexpressions for regular expression operators to work with. Consider the sample expression /(?:foo){1,2}/. If the expression was /foo{1,2}/, the {1,2} characters would apply only to the last 'o' in 'foo'. With the non-capturing parentheses, the {1,2} applies to the entire word 'foo'. 

// x(?=y) 
// Matches 'x' only if 'x' is followed by 'y'. This is called a lookahead.
// For example, /Jack(?=Sprat)/ matches 'Jack' only if it is followed by 'Sprat'. /Jack(?=Sprat|Frost)/ matches 'Jack' only if it is followed by 'Sprat' or 'Frost'. However, neither 'Sprat' nor 'Frost' is part of the match results.
 
// x(?!y) 
// Matches 'x' only if 'x' is not followed by 'y'. This is called a negated lookahead.
// For example, /\d+(?!\.)/ matches a number only if it is not followed by a decimal point. The regular expression /\d+(?!\.)/.exec("3.141") matches '141' but not '3.141'.
 
// x|y 
// Matches either 'x' or 'y'.
// For example, /green|red/ matches 'green' in "green apple" and 'red' in "red apple."
 
// {n} Matches exactly n occurrences of the preceding character. N must be a positive integer.
//  For example, /a{2}/ doesn't match the 'a' in "candy," but it does match all of the a's in "caandy," and the first two a's in "caaandy." 

// {n,m} 
// Where n and m are positive integers and n <= m. Matches at least n and at most m occurrences of the preceding character. When m is omitted, it's treated as ∞.
// For example, /a{1,3}/ matches nothing in "cndy", the 'a' in "candy," the first two a's in "caandy," and the first three a's in "caaaaaaandy". Notice that when matching "caaaaaaandy", the match is "aaa", even though the original string had more a's in it.
 
// [xyz] Character set. This pattern type matches any one of the characters in the brackets, including escape sequences. Special characters like the dot(.) and asterisk (*) are not special inside a character set, so they don't need to be escaped. You can specify a range of characters by using a hyphen, as the following examples illustrate.
//  The pattern [a-d], which performs the same match as [abcd], matches the 'b' in "brisket" and the 'c' in "city". The patterns /[a-z.]+/ and /[\w.]+/ match the entire string "test.i.ng". 

// [^xyz] 
// A negated or complemented character set. That is, it matches anything that is not enclosed in the brackets. You can specify a range of characters by using a hyphen. Everything that works in the normal character set also works here.
// For example, [^abc] is the same as [^a-c]. They initially match 'r' in "brisket" and 'h' in "chop."
 
// [\b]
// Matches a backspace (U+0008). You need to use square brackets if you want to match a literal backspace character. (Not to be confused with \b.)

// \b
// Matches a word boundary. A word boundary matches the position where a word character is not followed or preceeded by another word-character. Note that a matched word boundary is not included in the match. In other words, the length of a matched word boundary is zero. (Not to be confused with [\b].)
// Examples:
// /\bm/ matches the 'm' in "moon" ;
// /oo\b/ does not match the 'oo' in "moon", because 'oo' is followed by 'n' which is a word character;
// /oon\b/ matches the 'oon' in "moon", because 'oon' is the end of the string, thus not followed by a word character;
// /\w\b\w/ will never match anything, because a word character can never be followed by both a non-word and a word character.
// Note: JavaScript's regular expression engine defines a specific set of characters to be "word" characters. Any character not in that set is considered a word break. This set of characters is fairly limited: it consists solely of the Roman alphabet in both upper- and lower-case, decimal digits, and the underscore character. Accented characters, such as "é" or "ü" are, unfortunately, treated as word breaks.
 
// \B 
// Matches a non-word boundary. This matches a position where the previous and next character are of the same type: Either both must be words, or both must be non-words. The beginning and end of a string are considered non-words.
// For example, /\B../ matches 'oo' in "noonday", and /y\B./ matches 'ye' in "possibly yesterday."
 
// \cX 
// Where X is a character ranging from A to Z. Matches a control character in a string.
// For example, /\cM/ matches control-M (U+000D) in a string.
 
// \d 
// Matches a digit character. Equivalent to [0-9].
// For example, /\d/ or /[0-9]/ matches '2' in "B2 is the suite number."
 
// \D 
// Matches any non-digit character. Equivalent to [^0-9].
// For example, /\D/ or /[^0-9]/ matches 'B' in "B2 is the suite number."
 
// \f Matches a form feed (U+000C). 
// \n Matches a line feed (U+000A). 
// \r Matches a carriage return (U+000D). 

// \s 
// Matches a single white space character, including space, tab, form feed, line feed. Equivalent to [ \f\n\r\t\v​\u00a0\u1680​\u180e\u2000​-\u200a​\u2028\u2029\u202f\u205f​\u3000].
// For example, /\s\w*/ matches ' bar' in "foo bar."
 
// \S 
// Matches a single character other than white space. Equivalent to [^ \f\n\r\t\v​\u00a0\u1680​\u180e\u2000-\u200a​\u2028\u2029​\u202f\u205f​\u3000].
// For example, /\S\w*/ matches 'foo' in "foo bar."
 
// \t Matches a tab (U+0009). 

// \v Matches a vertical tab (U+000B). 

// \w 
// Matches any alphanumeric character including the underscore. Equivalent to [A-Za-z0-9_].
// For example, /\w/ matches 'a' in "apple," '5' in "$5.28," and '3' in "3D."
 
// \W 
// Matches any non-word character. Equivalent to [^A-Za-z0-9_].
// For example, /\W/ or /[^A-Za-z0-9_]/ matches '%' in "50%."
 
// \n 
// Where n is a positive integer, a back reference to the last substring matching the n parenthetical in the regular expression (counting left parentheses).
// For example, /apple(,)\sorange\1/ matches 'apple, orange,' in "apple, orange, cherry, peach."
 
// \0 Matches a NULL (U+0000) character. Do not follow this with another digit, because \0<digits> is an octal escape sequence. 

// \xhh Matches the character with the code hh (two hexadecimal digits) 

// \uhhhh Matches the character with the code hhhh (four hexadecimal digits). 







// Escaping user input to be treated as a literal string within a regular expression can be accomplished by simple replacement:
function escapeRegExp(string) {
	return string.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
}





// Specifying a string as a parameter
// The replacement string can include the following special replacement patterns:
// Pattern Inserts 
// $$ Inserts a "$". 
// $& Inserts the matched substring. 
// $` Inserts the portion of the string that precedes the matched substring. 
// $' Inserts the portion of the string that follows the matched substring. 
// $n or $nn Where n or nn are decimal digits, inserts the nth parenthesized submatch string, provided the first argument was a RegExp object. 

// Specifying a function as a parameter
// Possible name 			Supplied value 
// match 					The matched substring. (Corresponds to $& above.) 
// p1, p2, ... 				The nth parenthesized submatch string, provided the first argument to replace() was a RegExp object. (Corresponds to $1, $2, etc. above.) For example, if /(\a+)(\b+)/, was given, p1 is the match for \a+, and p2 for \b+. 
// offset 					The offset of the matched substring within the total string being examined. (For example, if the total string was 'abcd', and the matched substring was 'bc', then this argument will be 1.) 
// string 					The total string being examined. 







// (match, p1, p2, p3, offset, string) - Това е поредицата, в която се подават параметрите при replace от регекса, няма значение как ще ги кръщаваш, но първия аргумент винаги ти е намерения стринг, последващите са колкото параметризирани събстрингове със скоби си сложил, а след като се изчерпат възможните такива, последните два параметъра, които се подават са offset и string. Стринг е целия стринг, в който търсиш, а офсета е индекса на намерения стринг от началото. 

// ------------------ 

//  конкретно в твоя случай първия параметър, който си кръстил tag всъщност ти приема стойноста на намерения(мачнатия от регекса) стринг, а вторият параметър реално ти е параметризираният събстринг в скобите от регекса, който ти си кръстил match. Един вид, не зависи от имената на подаваните променливи, а от техния ред на подаване. Голяма глупост, интересно, че не е написано ясно в документацията. Случайно се загледах в един пример, където подаваха повече от използваните параметри в MDN. 

function replacer(match, p1, p2, p3, offset, string) {
	// p1 is nondigits, p2 digits, and p3 non-alphanumerics
	return [p1, p2, p3].join(' - ');
}
var newString = 'abc12345#$*%'.replace(/([^\d]*)(\d*)([^\w]*)/, replacer);





// Example: Using global and ignore with replace()
// In the following example, the regular expression includes the global and ignore case flags which permits replace() to replace each occurrence of 'apples' in the string with 'oranges'.

var re = /apples/gi;
var str = 'Apples are round, and apples are juicy.';
var newstr = str.replace(re, 'oranges');
console.log(newstr); // oranges are round, and oranges are juicy.





// Example: Switching words in a string
// The following script switches the words in the string. For the replacement text, the script uses the $1 and $2 replacement patterns.
var re = /(\w+)\s(\w+)/;
var str = 'John Smith';
var newstr = str.replace(re, '$2, $1');
console.log(newstr); // Smith, John





// Example: Using an inline function that modifies the matched characters
function styleHyphenFormat(propertyName) {
		function upperToHyphenLower(match) {
			return '-' + match.toLowerCase();
		}
		return propertyName.replace(/[A-Z]/g, upperToHyphenLower);
	}
	// Given styleHyphenFormat('borderTop'), this returns 'border-top'.
	// Because we want to further transform the result of the match before the final substitution is made, we must use a function. This forces the evaluation of the match prior to the toLowerCase() method. If we had tried to do this using the match without a function, the toLowerCase() would have no effect.
var newString = propertyName.replace(/[A-Z]/g, '-' + '$&'.toLowerCase()); // won't work
// This is because '$&'.toLowerCase() would be evaluated first as a string literal (resulting in the same '$&') before using the characters as a pattern.





// An array of objects. An 'x' denotes an 'on' state, a '-' (hyphen) denotes an 'off' state and an '_' (underscore) denotes the length of an 'on' state.
var str = 'x-x_';
var retArr = [];
str.replace(/(x_*)|(-)/g, function(match, p1, p2) {
	if (p1) {
		retArr.push({
			on: true,
			length: p1.length
		});
	}
	if (p2) {
		retArr.push({
			on: false,
			length: 1
		});
	}
});
console.log(retArr);
// [
//   { on: true, length: 1 },
//   { on: false, length: 1 },
//   { on: true, length: 2 }
//   ...
// ]





// Using special characters to verify input

// In the following example, the user is expected to enter a phone number. When the user presses the "Check" button, the script checks the validity of the number. If the number is valid (matches the character sequence specified by the regular expression), the script shows a message thanking the user and confirming the number. If the number is invalid, the script informs the user that the phone number is not valid.

// Within non-capturing parentheses (?: , the regular expression looks for three numeric characters \d{3} OR | a left parenthesis \( followed by three digits \d{3}, followed by a close parenthesis \), (end non-capturing parenthesis )), followed by one dash, forward slash, or decimal point and when found, remember the character ([-\/\.]), followed by three digits \d{3}, followed by the remembered match of a dash, forward slash, or decimal point \1, followed by four digits \d{4}.
var re = /(?:\d{3}|\(\d{3}\))([-\/\.])\d{3}\1\d{4}/;

function testInfo(phoneInput) {
		var OK = re.exec(phoneInput.value);
		if (!OK)
			window.alert(OK.input + " isn't a phone number with area code!");
		else
			window.alert("Thanks, your phone number is " + OK[0]);
}





// Extract URL
function extractUrl(url) {
	var protocol;
	var server;
	var resource;

	url.replace(/([^:]*)\:\/\/(.*?)\/(.*)/, extractor);

	function extractor(match, p1, p2, p3, offset, string) {
		protocol = p1;
		server = p2;
		resource = p3;
	}

	return {protocol: protocol, server: server, resource: resource};
}



// Example: Using regular expression to split lines with different line endings/ends of line/line breaks
var text = 'Some text\nAnd some more\r\nAnd yet\rThis is the end';
var lines = text.split(/\r\n|\r|\n/);
console.log(lines); // prints [ 'Some text', 'And some more', 'And yet', 'This is the end' ]