// function* async() {
//     yield setTimeout(function() {
//         console.log('first');
//     }, 5000);

//     yield setTimeout(function() {
//         console.log('second');
//     }, 1000);
// }

// var a = async();
// a.next();
// a.next();

// console.log('after next');
var first = {}, second = {};

setTimeout(function(first) {
    first.val = 'first';
}, 5000, first);

setTimeout(function(second) {
    second.val = 'second';
}, 1000, second);

console.log(first.val);
console.log(second.val);

setTimeout(function() {
    console.log(first.val);
    console.log(second.val);
}, 6000);

console.log('after next');