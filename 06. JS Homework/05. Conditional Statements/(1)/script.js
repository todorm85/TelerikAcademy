var a = prompt('Enter double a: ') * 1,
	b = prompt('Enter double b: ') * 1;
if (a>b) {
	a = a + b;
	b = a - b;
	a = a - b;
}

console.log(a+' '+b);