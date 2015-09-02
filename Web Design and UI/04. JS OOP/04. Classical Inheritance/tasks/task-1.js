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
    var Person = function(firstname, lastname, age) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.age = age;
    }

    Object.defineProperties(Person.prototype, {
        firstname: {
            get: function() {
                return this._firstname;
            },
            set: function(value) {
                validateName(value);
                this._firstname = value;
            }
        },
        lastname: {
            get: function() {
                return this._lastname;
            },
            set: function(value) {
                validateName(value);
                this._lastname = value;
            }
        },
        age: {
            get: function() {
                return this._age;
            },
            set: function(value) {
                validateAge(value);
                this._age = value;
            }
        },
        fullname: {
            get: function() {
                return this.firstname + ' ' + this.lastname;
            },
            set: function(value) {
                validateFullname(value);
                this.firstname = value.split(' ')[0];
                this.lastname = value.split(' ')[1] || '';
            }
        },
        introduce: {
            value: function() {
                return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old';
            }
        }
    });

    function isString(value) {
        return typeof value === 'string';
    }

    function isNumber(num) {
        return !isNaN(parseFloat(num)) && Number.isFinite(num);
    }

    function validateName(name) {
        var namePattern = new RegExp('^[A-Za-z]{3,20}$');

        if (!isString(name)) {
            throw new Error('Name must be string!');
        }

        if (!namePattern.test(name)) {
            throw new Error('Name must be between 3 and 20 characters, containing only Latin letters');
        }
    }

    function validateAge(value) {
        var minAge = 0;
        var maxAge = 150;

        if (!isNumber(value)) {
            throw new Error('Age must be a number!');
        }

        if (value < minAge || value > maxAge) {
            throw new Error('Age muse be in range 0 - 150');
        }
    }

    function validateFullname(value) {
        var fullnamePattern = new RegExp('^[A-Za-z]+$|^[A-Za-z]+ [A-Za-z]+$');

        if (!isString(value)) {
            throw new Error('Fullname must be string!');
        }

        if (!fullnamePattern.test(value)) {
            throw new Error('Fullname must be in format "Firstname Lastname"');
        }
    }

    return Person;
}
module.exports = solve;

var Person = solve();
var ivan = new Person('Ivan', 'Ivanov', 35);
console.log(ivan);