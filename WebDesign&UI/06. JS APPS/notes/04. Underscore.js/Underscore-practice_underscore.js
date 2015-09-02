if (typeof require !== 'undefined') {
    var _ = require('./underscore-min.js');
}

var Person = {
    init: function (fname, lname, age) {
        this.fname = fname;
        this.lname = lname;
        this.age = age;
        return this;
    },
    toString: function () {
        return this.fname + ' ' + this.lname;
    }
};

var people = [
    Object.create(Person).init('Georgi', 'Georgiev', 15),
    Object.create(Person).init('Ivan', 'Ivanov', 45),
    Object.create(Person).init('Maria', 'Marieva', 45),
    Object.create(Person).init('Konstantin', 'Konstantinov', 25),
];

// _.each(people[0], function (value, key) {
//     console.log(key + '-->' + value);
// });

// _.chain(people)
//     .each(function (person, index) {
//         console.log(index + ' ' + person.toString());
//     });

// function fullName() {
//     return this.fname + ' ' + this.lname;
// }
// _.chain(people)
//     .map(function (person, index, collection) {
//         person.fullName =  fullName;
//         return person;
//     })
//     .each(function (person, index, collection) {
//         console.log(person.fullName());
//     });;

// var nums = [1,2,3,4,5,6,7,8,9,10];
// function isEven (num, index, collection) {
//     return num % 2 === 0;
// }
// var evenNums = _.filter(nums, isEven);
// var oddNums = _.reject(nums, isEven);
// console.log(evenNums);
// console.log(oddNums);

// _.chain(people)
//     .where({age: 45})
//     .each(function (person, index, collection) {
//         console.log(person.fname);
//     });

// var sortedAscending = _.sortBy(people, function (person, index, collection) {
//     return person.age;
// });
// console.log(people);
// console.log(sortedAscending);
// var sortedDescending = sortedAscending.reverse();
// console.log(sortedDescending);

// var sortedAscending = _.sortBy(people, 'fname');
// console.log(people);
// console.log(sortedAscending);

// var groupedByAge = _.groupBy(people, 'age');
// console.log(people);
// console.log(groupedByAge);

// _.chain(people)
//     .sortBy('age')
//     .tap(
//         function (people) {
//             _.each(people, 
//                 function (person, index, collection) {
//                     console.log(person.age);
//                 }
//             );
//         }
//     )
//     .tap(
//         function (people) {
//             console.log(_.pluck(people, 'age'));
//         }
//     );

_.chain(people)
    .first(1)
    .each(function (person) {
        console.log(person.fname);
    });