var arr = [3,4,6,1,3,5,7,9,4,5,7];

var	keyIndex = 2; // true
// var keyIndex = 0; // false
// var keyIndex = 10; //true

console.log(largerThanNeighbours(keyIndex,arr));

function largerThanNeighbours (index, arr) {
	var biggerThanLeft = true,
		biggerThanRight = true;

	if (arr[index] === undefined) { return undefined; }

	if (arr[index - 1]!==undefined) {
		(arr[index] > arr[index - 1]) ? biggerThanLeft = true : biggerThanLeft = false;
	}

	if (arr[index + 1]!==undefined) {
		(arr[index] > arr[index + 1]) ? biggerThanRight = true : biggerThanRight = false;
	}

	return biggerThanLeft && biggerThanRight;
}