 //=========================== // 02. JS Intro ===========================
// document object
// Provides some built-in arrays of specific objects on the currently loaded Web page
document.links[0].href = "yahoo.com";
document.write(
"This is some <b>bold text</b>");
document.location = "http://www.yahoo.com/";

for (i=1; i<=20; i++) {
var x = Math.random();
x = 10*x + 1;
x = Math.floor(x);
document.write(
"Random number (" +
i + ") in range " +
"1..10 --> " + x +
"<br/>");
}

var now = new Date();
var result = "It is now " + now;
document.getElementById("timeField")
.innerText = result;
...
<p id="timeField"></p>

var timer = setTimeout('bang()', 5000);
clearTimeout(timer);
var timer = setInterval('clock()', 1000);
clearInterval(timer);
function timerFunc() { var now = new Date();
var hour = now.getHours();
var min = now.getMinutes(); 
var sec = now.getSeconds();
document.getElementById("clock").value = "" + hour + ":" + min + ":" + sec; } setIntervaltimerFunc(), 1000);







 //=========================== // 03. Data Types and Variables ===========================

// NUMBERS CONVERSION
// anything to integer:
value = value | 0;
// this drops the fractional part and keeps only the whole
-8.75 | 0; // -8
8.75 | 0; // 8
'-8.75' * 1; // -8.75 
+'123.3' // 123.3 FASTEST
// ROUNDING
(8.75 + .5) | 0; // 9
(8.25 + .5) | 0; // 8

// In JS there is a special value undefinedIt means the variable has not been defined (no such variable in the current context)
// nullmeans that an object exists and is emptyvar

// Identifiers may consist of:Letters (Unicode) Digits [0-9]Underscore '_'Dollar '$'
// IdentifiersCan begin only with a letter or an underscoreCannot be a JavaScript keyword

// Names in JavaScript are case-sensitiveSmall letters are considered different than the capital letters

// Global variables
// Declared withoutthe keyword var
// Bad practices –never do this!
a = undefined;
a = 5; // the same as window.a = 5;









 //=========================== // 04. Operators and expressions ===========================
b++ // increments after the line
++b // increments before the line
var a = 5;
var b = 4;
console.log( a + b ); // 9
console.log( a + b++ ); // 9
console.log( a + b ); // 10
console.log( a + (++b) ); // 11
console.log( a + b ); // 11

console.log(11 % 3); // 2
console.log(11 % -3); // 2
console.log(-11 % 3); // -2


console.log(0 === ""); //False






 //=========================== // 05. Conditional Statements ===========================
var str = '1c23';
if(!(+str)){ // if str is not a number, +str is NaN
	throw new Error('str is not a Number!');}

var s = '123';
var number = +s;
if (number % 2){ console.log('This number is odd.');} 
еlse{console.log('This number is even.');}

if (+str) {console.log('The string is a Number');}
 else {console.log('The string is not a Number');}

These values are falsy
false, 0(zero), ""(empty string), null, undefined, NaN
All other values are truthy
All other values are truthy, including "0" (zero in quotes), "false" (false in quotes), empty functions, empty arrays, and empty objects.
The falsy values null and undefined are not equivalent to anything except themselves:
var f = (null == false); // false
var g = (null == null); // true
var h = (undefined == undefined); // true
var i = (undefined == null); // true

Finally, the falsy value NaN is not equivalent to anything — including NaN!
var j = (NaN == null); // false
var k = (NaN == NaN); // false
You should also be aware that typeof(NaN) returns "number". Fortunately, the core JavaScript function isNaN() can be used to evaluate whether a value is NaN or not.
If in doubt…
Use strict equal (===) and strict not equal (!==) in situations where truthy or falsy values could lead to logic errors. These operators ensure that the objects are compared by type and by value.
var l = (false == 0); // true
var m = (false === 0); // false

isNaN(NaN);       // true
isNaN(undefined); // true
isNaN({});        // true

isNaN(true);      // false
isNaN(null);      // false
isNaN(37);        // false

// strings
isNaN("37");      // false: "37" is converted to the number 37 which is not NaN
isNaN("37.37");   // false: "37.37" is converted to the number 37.37 which is not NaN
isNaN("");        // false: the empty string is converted to 0 which is not NaN
isNaN(" ");       // false: a string with spaces is converted to 0 which is not NaN

// dates
isNaN(new Date());                // false
isNaN(new Date().toString());     // true








 //=========================== // 06. Loops ===========================

// for-in loopiterates over the properties of an object
// When the object is array, nodeListor liveNodeListfor-in iterates over their elementsWhen the objectis not an array, for-in iterates over its properties

// FOR-OF
// Can be used only on arrays, or array-like objects
// 	i.e. the arguments object
var arr = ['One', 'Two', 'Three', 'Four'];for(var n of arr) { console.log(n); }//prints 'One', 'Two', 'Three' and 'Four'
// part of the ECMAScript 6 standard






 //=========================== // 07. Arrays ===========================

// Using new Array(elements):
// Using new Array(initialLength):
// Using array literal (recommended):
var arr = new Array(1, 2, 3, 4, 5);
var arr = new Array(10);
var arr = [1, 2, 3, 4, 5];

// Methods for array manipulation (cont.)
array.unshift(element)
// Inserts a new element at the head of the array
var arr1 = [1,2,3,4,5];
var res = arr1.unshift(0);
console.log(arr1);	// [ 0, 1, 2, 3, 4, 5 ]
console.log(res);	// 6  // gives the length

array.shift()
// Removes and returns the element at the head
var arr1 = [11,2,3,4,5];
var res = arr1.shift();
console.log(arr1);	// [ 2, 3, 4, 5 ]
console.log(res);	// 11

array.push(element)
// Inserts a new element at the tail of the array

array.pop()
// Removes the element at the tail
// Returns the removed element

array.sort(compareFunc)
// Keep in mind that array.sort uses the string representation of the elements!
// Sorts element using a compare function
// The compare function defines the sorting rules
// Return negative or 0 to leave the elements
// Return positive to swap them
function orderBy(a, b) {
	return (a == b) ? 0 : (a > b) ? 1 : -1;
}
var numbers = [5, 4, 23, 2];
numbers.sort(orderBy);
// console.log(numbers.join(', '));
// // returns 2, 4, 5, 23

array.reverse()
// Makes current array`s elements in reversed order
var arr1 = [11,2,3,4,5];
arr1.reverse();
console.log(arr1);	// [ 5, 4, 3, 2, 11 ]


array.splice(index, count, elements)
// Adds and / or removes elements from an array
var arr1 = [0,1,2,3,4,5,6];
var res = arr1.splice(2,3);
console.log(res); // [ 2, 3, 4 ]
console.log(arr1); // [ 0, 1, 5, 6 ]

arr.slice([begin[, end]])
// slice does not alter. It returns a shallow copy of elements from the original array. Elements of the original array are copied into the returned array as follows:
// https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/Global_Objects/Array/slice

array.concat(elements)
// Inserts the elements at the end of the array and returns a new array
// Joins two arrays
var arr1 = [0,1,2,3,4,5,6];
var arr2 = [7,8,9];
var res = arr1.concat(arr2);
console.log(arr1);	// [ 0, 1, 2, 3, 4, 5, 6 ]
console.log(arr2);	// [ 7, 8, 9 ]
console.log(res);	// [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ]

array.join(separator)
// Concatenates the elements of the array
var arr1 = new Array (5)
var res = arr1.join('a');
console.log(arr1);	// [ , , , ,  ]
console.log(res);	// aaaa

array.filter(condition)
// Returns a new array with the elements that satisfy condition
// filter() does not mutate the array on which it is called.
// Function to test each element of the array. Invoked with arguments (element, index, array). Return true to keep the element, false otherwise.
var arr1 = [11,2,3,4,5];
var res = arr1.filter(function (item) {
	if (item > 3) {return true;}
	return false;
});
console.log(arr1);	// [ 11, 2, 3, 4, 5 ]
console.log(res);	// [ 11, 4, 5 ]

array.forEach(function(item){})
// Iterates through the array and executes the function for each item

array.indexOf(element)
// Returns the index of the first match in the array
// Returns -1 is the element is not found

array.lastIndexOf(element)
// Returns the index of the first match in the array
// Returns -1 is the element is not found

// indexOf() and lastIndexOf() do not work in all browsers

// Checking for array
typeof([1, 2, 3])  object

Array.isArray([1, 2, 3])  true
// Supported on all modern browsers

// Arrays official documentation:
// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Array





// =========================== 08. Functions ===========================

// DEFINING FUNCTIONS
// to construct a function from string use function object constructor with passed string value
var print = new Function('console.log("Hello")');

// standart way to define a function is by declaration, which make the interpreteur move it to the top when compiling
function print() { console.log('Hello') };

// by assigning the function to a variable with function expression, this DOES NOT move the function to the top of the scope when compiled
var print = function() { console.log('Hello') };
var print = function printFunc() { console.log('Hello')



// argumentsObject
// Every function have a special object called arguments
// It holds information about the function and all the parameters passed to the function
// No need to be explicitly declared. It exists in every function
function printArguments() {
	for(var i in arguments) {
 		console.log(arguments[i]);}
}
printArguments(1, 2, 3, 4); //1, 2, 3, 4


// FUNCTION OVERLOADING
// When we know types expected
argumentsfunction printText(number, text) {
	switch (arguments.length) {
		case 1:
			console.log('Number :' + number);
			break;
		case 2:
			console.log('Number :' + number);
			console.log('Text :' + text);
			break;
	}
}
printText(5); //logs 5printText (5,'Lorem Ipsum'); //logs 5 and Lorem Ipsum
// When we don`t know the type that is going to be given
function printValue(value) {
	var log = console.log;
	switch (typeof value) {
		case 'number':
			log('Number: ' + value);
			break;
		case 'string':
			log('String: ' + value);
			break;
		case 'object':
			log('Object: ' + value);
			break;
		case 'boolean':
			log('Number: ' + value);
			break;
	}
}
printValue(5);
printValue('Lorem Ipsum');
printValue([1, 2, 3, 4]);
printValue(true);


// CHECKING INPUT VALUES AND ASSIGNING DEFAULT VALUES TO THEM
function substring(str, start, end) {
	start = start || 0;
	str = str || 'default';
	end = end || str.length;
	// function code
	console.log(str);
}
substring();	// default



// Add a function to the Array object to remove all instances of element
if (!Array.hasOwnProperty('removeAll')) {
	Array.prototype.removeAll = function(item) {
		var i,
			length = this.length;

		for (i = 0; i < length; i += 1) {
			if (this[i] === item) {
				this.splice(i, 1);
				i -= 1;
				length -= 1;
			}
		}
	}
}
var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
arr.removeAll(1); //arr = [2,4,3,4,111,3,2,'1'];
console.log(arr);






// =========================== 09. Objects ===========================

obj.hasOwnProperty("prop")
// checks whether the object has property named prop. Returns true/false. Important function!

// Properties can be accessed with . or by indexer and string value
document.write === document['write']  // results in true

function buildPerson(fname, lname) {
	return {
		firstName: fname,
		lastName: lname,
		toString: function() {
			return this.firstName + ', ' + this.lastName;
		}
	}
}
var minkov = buildPerson('Doncho', 'Minkov');
console.log(minkov.toString());






// =========================== 10. Strings ===========================

return 'cat'.charAt(1); // returns "a"
return 'cat'[1]; // returns "a"
if (a < b) { // true

var s_prim = 'foo';
var s_obj = new String(s_prim);
console.log(typeof s_prim); // Logs "string"
console.log(typeof s_obj);  // Logs "object"

console.log(String.fromCharCode(97,98,99,120,121,122))
//output: abcxyz

indexOf(substr, [start]) 	
// Searches and (if found) returns the index number of the searched character or substring within the string. If not found, -1 is returned. “Start” is an optional argument specifying the position within string to begin the search. Default is 0.

lastIndexOf(substr, [start])
var myString = 'javascript rox';
console.log(myString.lastIndexOf('r'));
//output: 11

search(regexp) 
// Tests for a match in a string. It returns the index of the match, or -1 if not found.

split(delimiter, [limit]) 	
// Splits a string into many according to the specified delimiter, and returns an array containing each element. The optional “limit” is an integer that lets you specify the maximum number of elements to return.

substr(start, [length]) 	
// Returns the characters in a string beginning at “start” and through the specified number of characters, “length”. “Length” is optional, and if omitted, up to the end of the string is assumed.

substring(from, [to]) 	
// Returns the characters in a string between “from” and “to” indexes, NOT including “to” inself. “To” is optional, and if omitted, up to the end of the string is assumed.

toLowerCase() 	
// Returns the string with all of its characters converted to lowercase.

toUpperCase() 	
// Returns the string with all of its characters converted to uppercase.




// Methods that use regular expressions

str.split([separator[, limit]])

// separator
// Optional. Specifies the character(s) to use for separating the string. The separator is treated as a string or a regular expression. If separator is omitted, the array returned contains one element consisting of the entire string. If separator is an empty string, str is converted to an array of characters.

// limit
// Optional. Integer specifying a limit on the number of splits to be found. The split() method still splits on every match of separator, but it truncates the returned array to at most limit elements.

// The split() method returns the new array.

// Note: When the string is empty, split() returns an array containing one empty string, rather than an empty array.


str.replace(regexp|substr, newSubStr|function[, flags]);
// Note: The flags argument does not work in v8 Core (Chrome and Node.js). 
// This method does not change the String object it is called on. It simply returns a new string
https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String/replace

// To perform a global search and replace, either include the g switch in the regular expression or if the first parameter is a string, include g in the flags parameter.

// Specifying a string as a parameter

// The replacement string can include the following special replacement patterns:

// Pattern Inserts 
// $$ Inserts a "$". 
// $& Inserts the matched substring. 
// $` Inserts the portion of the string that precedes the matched substring. 
// $' Inserts the portion of the string that follows the matched substring. 
// $n or $nn Where n or nn are decimal digits, inserts the nth parenthesized submatch string, provided the first argument was a RegExp object. 

// Specifying a function as a parameter

// You can specify a function as the second parameter. In this case, the function will be invoked after the match has been performed. The function's result (return value) will be used as the replacement string. (Note: the above-mentioned special replacement patterns do not apply in this case.) Note that the function will be invoked multiple times for each full match to be replaced if the regular expression in the first parameter is global.

// The arguments to the function are as follows:

// Possible name Supplied value 
// match The matched substring. (Corresponds to $& above.) 
// p1, p2, ... The nth parenthesized submatch string, provided the first argument to replace() was a RegExp object. (Corresponds to $1, $2, etc. above.) For example, if /(\a+)(\b+)/, was given, p1 is the match for \a+, and p2 for \b+. 
// offset The offset of the matched substring within the total string being examined. (For example, if the total string was 'abcd', and the matched substring was 'bc', then this argument will be 1.) 
// string The total string being examined. 

// (The exact number of arguments will depend on whether the first argument was a RegExp object and, if so, how many parenthesized submatches it specifies.)

// the parameters are given always in the same sequence regardless of how they are named. Ex. match could be named custom, and it will still hold the matched string value, since it is given as the first parameter of the function
function replacer(match, p1, p2, p3, offset, string) {
  // p1 is nondigits, p2 digits, and p3 non-alphanumerics
  return [p1, p2, p3].join(' - ');
}
var newString = 'abc12345#$*%'.replace(/([^\d]*)(\d*)([^\w]*)/, replacer);


str.search(regexp)
// Parameters
// regexpA regular expression object. If a non-RegExp object obj is passed, it is implicitly converted to a RegExp by using new RegExp(obj).
// If successful, search() returns the index of the first match of the regular expression inside the string. Otherwise, it returns -1.


str.match(regexp)
// Parameters
// regexpA regular expression object. If a non-RegExp object obj is passed, it is implicitly converted to a RegExp by using new RegExp(obj).
// Returns
// array An Array containing the matched results or null if there were no matches.
// •If you only want the first match found, you might want to use RegExp.exec() instead.

var str = 'For more information, see Chapter 3.4.5.1';
var re = /(chapter \d+(\.\d)*)/i;
var found = str.match(re);

console.log(found);

// logs ['Chapter 3.4.5.1', 'Chapter 3.4.5.1', '.1']

// 'Chapter 3.4.5.1' is the first match and the first value 
// remembered from `(Chapter \d+(\.\d)*)`.

// '.1' is the last value remembered from `(\.\d)`.


regexObj.test(str)
// The test() method executes a search for a match between a regular expression and a specified string. Returns true or false.


regexObj.exec(str)
// The exec() method executes a search for a match in a specified string. Returns a result array, or null.
// If you are executing a match simply to find true or false, use the RegExp.prototype.test() method or the String.prototype.search() method.

// If the match succeeds, the exec() method returns an array and updates properties of the regular expression object. The returned array has the matched text as the first item, and then one item for each capturing parenthesis that matched containing the text that was captured.

// Match "quick brown" followed by "jumps", ignoring characters in between
// Remember "brown" and "jumps"
// Ignore case
var re = /quick\s(brown).+?(jumps)/ig;
var result = re.exec('The Quick Brown Fox Jumps Over The Lazy Dog');

result	
Property/Index 		Description 								Example 
[0] 				The full string of characters matched 		Quick Brown Fox Jumps 
[1], ...[ n ] 	The parenthesized substring matches, if any. The number of possible parenthesized substrings is unlimited. 		[1] = Brown [2] = Jumps 
index 				The 0-based index of the match in the string. 4 
input 				The original string. The Quick Brown Fox Jumps Over The Lazy Dog 

re 
lastIndex 		The index at which to start the next match. When "g" is absent, this will remain as 0. 	25 
ignoreCase 		Indicates if the "i" flag was used to ignore case. 		true 
global 			Indicates if the "g" flag was used for a global match. 		true 
multiline 		Indicates if the "m" flag was used to search in strings across multiple line. false 
source 			The text of the pattern. quick\s(brown).+?(jumps) 

// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/RegExp/exec