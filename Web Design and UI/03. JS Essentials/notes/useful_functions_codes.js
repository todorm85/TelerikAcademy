function binarySearch(key, startIndex, endIndex, arr) {
	if (startIndex > endIndex) {
		return -1;
	}
	var middleIndex = (startIndex + (endIndex - startIndex) / 2 + 0.5) | 0;
	if (key === arr[middleIndex]) {
		return middleIndex;
	}
	if (key < arr[middleIndex]) {
		return binarySearch(key, startIndex, middleIndex - 1, arr);
	}
	if (key > arr[middleIndex]) {
		return binarySearch(key, middleIndex + 1, endIndex, arr);
	}
	return 'error';
}

function stringFormat() {
	var argCount = arguments.length;
	if (argCount === 0) {
		return undefined;
	}
	var i;
	var str = arguments[0];
	console.log('string to process = ' + str);

	for (i = 1; i < argCount; i += 1) {
		var placeHolderPatter = new RegExp('\\{' + (i-1) + '+?\\}', 'g');
		// console.log('Patter to search for argument ' + i + ': ' + placeHolderPatter);
		// console.log('Argument ' + i + ' = ' + arguments[i]);
		str = str.replace(placeHolderPatter, arguments[i]);
	}

	return str;
}

function deepCopy(oldObject) {
	return JSON.parse(JSON.stringify(oldObject));
}

function toPower(base, pow) {
	var result = 1,
		i;
	for (i = 0; i< pow; i+= 1) {
		result *= base;
	}
	return result;
}

function isNumber (num) {
	return !isNaN(parseFloat(num)) && Number.isFinite(num);
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
		pplArr.push(getPerson(fname,lname,age,gender));
	}

	return pplArr;
}