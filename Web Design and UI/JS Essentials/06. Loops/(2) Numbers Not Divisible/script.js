var number = prompt('Enter number') * 1,
	i,
	result = '';

for (var i = 1; i <= number; i++) {
	if (checkDivisionBy35(i)) {continue;}
	result += i + ' ';
}

console.log(result);

function checkDivisionBy35 (number) {
	if (number%35==0) {return true;}
	else {return false;}
}