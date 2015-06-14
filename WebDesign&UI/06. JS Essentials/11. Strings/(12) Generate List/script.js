// ### Problem 12. Generate list
// *	Write a function that creates a HTML `<ul>` using a template for every HTML `<li>`.
// *	The source of the list should be an array of elements.
// *	Replace all placeholders marked with –{…}– with the value of the corresponding property of the object.

var ppl = [{
	name: 'Peter1',
	age: 14,
	'class': 'math1'
}, {
	name: 'Peter2',
	age: 25,
	'class': 'math2'
}];

// to make the .js .html independent, the pattern is written directly to the variable tmpl, since it has the same effect as getElementById, if you want to change the pattern, change it here!!!!!! There are three predefined test patterns for you to test with, simply leave the one to test uncommented.
var tmpl = '<li>' + '<strong>-{name}-</strong> <span>-{age}-</span>' + '</li>';  // test tempalte pattern 1
var tmpl = '<li>' + '<strong>-{name}-</strong>' + '</li>';  // test tempalte pattern 2
var tmpl = '<li>' + '<strong>-{name}-</strong> <span>-{age}-</span> <span>-{class}-</span>' + '</li>';  // test tempalte pattern 3

var pplList = generateList(ppl, tmpl);
console.log('\nFINAL RESULT: ' + pplList);

function generateList(ppl, tmpl) {
	// peopleList = '<ul><li><strong>Peter</strong> <span>14</span></li><li>…</li>…</ul>'
	var prop,
		i,
		i2,
		person,
		li;
	var pplList = '<ul>';

	for (i in ppl) {
		person = ppl[i];
		li = tmpl;
		console.log('\nCurrent person: ' + person['name']);
		for (prop in person) {
			var placeholderPattern = new RegExp('-{' + prop + '}-', 'g');
			console.log('pattern: ' + placeholderPattern);
			li = li.replace(placeholderPattern, person[prop]);
			console.log('current li: ' + li);
		}
		pplList += li;
		console.log('current pplList: ' + pplList);
	}

	return pplList + '</ul>';
}