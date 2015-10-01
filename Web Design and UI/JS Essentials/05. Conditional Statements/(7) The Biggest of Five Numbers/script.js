var num1 = prompt('Enter first num: ') * 1,
	num2 = prompt('Enter second num: ') * 1,
	num3 = prompt('Enter third num: ') * 1,
	num4 = prompt('Enter fourth num: ') * 1,
	num5 = prompt('Enter fifth num: ') * 1;
	max = Number.MAX_VALUE * -1;

if (num1>max) {max=num1;}
if (num2>max) {max=num2;}
if (num3>max) {max=num3;}
if (num4>max) {max=num4;}
if (num5>max) {max=num5;}
console.log('Max: ' + max);