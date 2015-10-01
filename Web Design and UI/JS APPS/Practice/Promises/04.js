function* idFactory() {
    yield 1;
    yield 2;
    yield 3;
    yield 4;
    yield 5;
}

console.log(idFactory().next());
console.log(idFactory().next());
console.log(idFactory().next());
console.log(idFactory().next());
console.log(idFactory().next());

console.log('-----------------------------');
var factory1 = idFactory();
var factory2 = idFactory();

console.log(factory1.next());
console.log(factory2.next());
console.log(factory1.next());
console.log(factory2.next());
console.log(factory1.next());
console.log(factory2.next());
console.log(factory1.next());
console.log(factory2.next());
console.log(factory1.next());
console.log(factory2.next());
console.log(factory1.next());
console.log(factory2.next());
console.log(factory1.next());
console.log(factory2.next());