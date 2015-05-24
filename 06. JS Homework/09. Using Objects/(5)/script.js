function buildPerson(fname, lname, age) {
	return {
		fname: fname,
		lname: lname,
		age: age
	};
}

var gosho = buildPerson('gosho', 'georgiev', 25);
var ivan = buildPerson('ivan', 'ivanov', 23);
var misho = buildPerson('misho', 'mihailov', 26);

var people = [gosho, ivan, misho];
youngest(people);

function youngest(people) {
	var minAge = people[0].age;
	var minIndex = 0;
	for (i in people) {
		if (people[i].age < minAge) {
			minAge = people[i].age;
			minIndex = i;
		}
	}
	console.log(people[minIndex].fname + ' ' + people[minIndex].lname);
}