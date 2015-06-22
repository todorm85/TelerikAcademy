/* Task Description */
/* 
	Create a function constructor for Person. Each Person must have:
	*	properties `firstname`, `lastname` and `age`
		*	firstname and lastname must always be strings between 3 and 20 characters, containing only Latin letters
		*	age must always be a number in the range 0 150
			*	the setter of age can receive a convertible-to-number value
		*	if any of the above is not met, throw Error 		
	*	property `fullname`
		*	the getter returns a string in the format 'FIRST_NAME LAST_NAME'
		*	the setter receives a string is the format 'FIRST_NAME LAST_NAME'
			*	it must parse it and set `firstname` and `lastname`
	*	method `introduce()` that returns a string in the format 'Hello! My name is FULL_NAME and I am AGE-years-old'
	*	all methods and properties must be attached to the prototype of the Person
	*	all methods and property setters must return this, if they are not supposed to return other value
		*	enables method-chaining
*/
function solve() {

	var Person = (function() {

		function Person(firstname, lastname, age) {
			this.firstname = firstname;
			this.lastname = lastname;
			this.age = age;
		}

		function validateName(name) {
			var isValid = true;
			if (typeof name !== 'string') {
				isValid = false;
			}

			if (name.length > 20 || name.length < 3) {
				isValid = false;
			}

			if (name.replace(/[a-zA-Z]*/, '') !== '') {
				isValid = false;
			}

			if (!isValid) {
				throw new Error;
			}
		}

		function isNumber(num) {
			return !isNaN(parseFloat(num)) && isFinite(num);
		}

		function validateAge(age) {
			var isValid = true;
			if (!isNumber(age)) {
				isValid = false;
			}

			if (age > 150 || age < 0) {
				isValid = false;
			}

			if (!isValid) {
				throw new Error;
			}
		}

		function parseNames(value) {
			var namesArr = value.trim().split(' ');
			return namesArr;
		}

		Object.defineProperties(Person.prototype, {
			'firstname': {
				get: function() {
					return this._firstname;
				},
				set: function(value) {
					validateName(value);
					this._firstname = value;
				}
			},
			'lastname': {
				get: function() {
					return this._lastname;
				},
				set: function(value) {
					validateName(value);
					this._lastname = value;
				}
			},
			'age': {
				get: function() {
					return this._age;
				},
				set: function(value) {
					validateAge(value);
					this._age = value;
				}
			},
			'fullname': {
				get: function() {
					return this.firstname + ' ' + this.lastname;
				},
				set: function(value) {
					var firstname;
					var lastname;

					if (typeof value !== 'string') {
						isValid = false;
					}

					firstname = parseNames(value)[0];
					lastname = parseNames(value)[1];

					this.firstname = firstname;
					this.lastname = lastname;
				}
			}
		});

		Person.prototype.introduce = function () {
			return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
		}

		return Person;
	}());

	// Testing

	// var ivan = new Person('Ivan', 'Mavrodiev', 5);
	// console.log(ivan.introduce());

	// End Testing

	return Person;
}
module.exports = solve;

// solve();