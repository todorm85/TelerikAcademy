var arr = [3, 4, 6, 1, 3, 5, 7, 9, 4, 5, 7];  // 2
// var arr = [1,2,3,4,4];  // -1

console.log(firstLargerThanNeighbours(arr));

function firstLargerThanNeighbours(arr) {
	var i,
		arrLen = arr.length;

	for (i = 0; i < arrLen; i += 1) {
		if (largerThanNeighbours(i, arr)) {
			return i;
		}
	}
	return -1;
}

function largerThanNeighbours(index, arr) {
	var biggerThanLeft = true,
		biggerThanRight = true;

	// first check to seee if index is out of range
	if (arr[index] === undefined) {
		return undefined;
	}
	// check if left exist
	if (arr[index - 1] !== undefined) {
		(arr[index] > arr[index - 1]) ? biggerThanLeft = true: biggerThanLeft = false;
	}
	// check if right exists
	if (arr[index + 1] !== undefined) {
		(arr[index] > arr[index + 1]) ? biggerThanRight = true: biggerThanRight = false;
	}

	return biggerThanLeft && biggerThanRight;
}