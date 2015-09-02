var arr = [5,3,77,-34,65.78,343,-45345,435345];
// var arr = [1,2,3,4,5];
// var arr = [5,4,3,2,1];

var sortedArr = new Array(0),
	i1,
	i2,
	arrLength = arr.length,
	minIndex;

while (arrLength>0) {
	minIndex = findMin(arr);
	sortedArr.push(arr[minIndex]);
	arr.splice(minIndex, 1);
	arrLength-=1;
}

console.log(sortedArr.join(', '));

function findMin (arr) {
	var min = arr[0],
		i,
		arrLength = arr.length,
		minIndex = 0;

	if (arr.length === 1) {return 0;}

	for (i = 1; i < arrLength; i+=1) {
		if (arr[i]<min) {
			min = arr[i];
			minIndex = i;
		}
	}

	return minIndex;
}