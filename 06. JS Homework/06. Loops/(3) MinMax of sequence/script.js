var numSequence = [-1, 0, 1, 2, 3, 25, 4, 5, -15, 6, 7, 8, 9, 10],
	max = Number.MAX_VALUE * -1,
	min = Number.MAX_VALUE,
	i;

for (i in numSequence) {
	if (max < numSequence[i]) {max = numSequence[i];}
	if (min > numSequence[i]) {min = numSequence[i];}
}

console.log('MAX: ' + max);
console.log('MIN: ' + min);