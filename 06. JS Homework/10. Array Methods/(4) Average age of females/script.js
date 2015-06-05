// ### Problem 4. Average age of females
// *	Write a function that calculates the average age of all females, extracted from an array of persons
// 	*	Use **Array#filter**
// 	*	Use **only array methods** and no regular loops (for, while)


var pplArr = generatePeople(5);
console.log(pplArr);

var femalesArr = pplArr.filter(function (person) {
	return person.gender === 'f';
})
console.log(femalesArr);

var avgFemaleAge = femalesArr.reduce(function (previousValue,currentValue) {
	return previousValue + currentValue.age;
},0) / femalesArr.length;

console.log(avgFemaleAge);

function generatePeople(count) {
	count = count || 20;
	var fnamesMen = ['Gosho', 'Pencho', 'Slavi', 'Niki', 'Atanas', 'Asen', 'Lyubozar'];
	var lnamesMen = ['Georgiev', 'Petrov', 'Ivanov', 'Kernadjiev', 'Perenski', 'Mahlenski'];
	var fnamesWomen = ['Penka', 'Gergana', 'Slava', 'Nikita', 'Atanaska', 'Lyubozara', 'Asena'];
	var lnamesWomen = ['Georgieva', 'Petrova', 'Ivanova', 'Kerandjieva', 'Perenska', 'Mahlenska'];

	function getPerson(fname, lname, age, gender) {
		return {
			fname: fname,
			lname: lname,
			age: age,
			gender: gender
		}
	}

	var pplArr = [];
	var fname,
		lname,
		age,
		gender;
	for (var i = 0; i < count; i += 1) {
		if (Math.round(Math.random())) {
			fname = fnamesMen[(Math.random() * fnamesMen.length) | 0];
			lname = lnamesMen[(Math.random() * lnamesMen.length) | 0];
			gender = 'm';
		} else {
			fname = fnamesWomen[(Math.random() * fnamesWomen.length) | 0];
			lname = lnamesWomen[(Math.random() * lnamesWomen.length) | 0];
			gender = 'f';
		}
		age = Math.random() * 100 | 0;
		pplArr.push(getPerson(fname,lname,age,gender));
	}

	return pplArr;
}