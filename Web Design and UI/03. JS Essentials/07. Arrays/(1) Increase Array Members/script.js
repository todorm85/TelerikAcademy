var count = 20,
	arr = new Array(count),
	i,
	factor = 5;

for (i = 1; i <= count; i+=1) {
	arr[i] = i * factor;
}

// for (i in arr) {
// 	console.log(arr[i] + ' ');
// }

var result = arr.join(' ');
console.log(result);