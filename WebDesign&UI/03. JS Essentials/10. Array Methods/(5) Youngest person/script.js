// ### Problem 5. Youngest person
// *	Write a function that finds the youngest male person in a given array of people and prints his full name
// 	*	Use **only array methods** and no regular loops (for, while)
// 	*	Use **Array#find**

if (!Array.prototype.find) {
	Array.prototype.find = function(callback) {
		var i, len = this.length;
		for (i = 0; i < len; i += 1) {
			if (callback(this[i], i, this)) {
				return this[i];
			}
		}
	}
}

var pplArr = generatePeople(5);
console.log(pplArr);
var youngest = findYoungest(pplArr, 'm');
console.log(youngest);

function findYoungest(pplArr, gender) {
	var minAge = pplArr.reduce(function(previousValue, currentValue) {
		if (gender === 'm' || gender === 'f') {
			if (previousValue > currentValue.age && currentValue.gender === gender) {
				return currentValue.age;
			} else {
				return previousValue;
			}
		} else {
			if (previousValue > currentValue.age) {
				return currentValue.age;
			} else {
				return previousValue;
			}
		}
	}, 200);
	var youngest = pplArr.find(function(person) {
		if (person.age === minAge) {
			return true;
		} else {
			return false;
		}

	});
	return youngest.fname + ' ' + youngest.lname;
}

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
		pplArr.push(getPerson(fname, lname, age, gender));
	}

	return pplArr;
}