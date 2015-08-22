function Person(name) {
    this.name = name;
    this.getName = function getPersonName() {
        return this.name;
    }
}

var p = new Person('Peter');
// console.log(p.getPersonName());
// console.log(p.name);
console.log(p.name);
console.log(p.getName());
var p2 = Person('Peter2');
console.log(name);
console.log(getName());