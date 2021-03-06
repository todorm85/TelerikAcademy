// ### Problem 3. Underage people 
// *	Write a function that prints all underaged persons of an array of person
// 	*	Use **Array#filter** and **Array#forEach**
// 	*	Use **only array methods** and no regular loops (for, while)

var pplArr = generatePeople(20);
console.log(pplArr);

var underagedPplArr = pplArr.filter(function (person) {
	return person.age < 18;
});

underagedPplArr.forEach(function (person) {
	console.log(person.fname + ' ' + person.lname + ' ' + person.age);
})

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