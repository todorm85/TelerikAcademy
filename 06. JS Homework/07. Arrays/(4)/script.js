var arr = [3,2,3,4,2,2,4];
// var arr = [1,2,3,4,2,2,4];
// var arr = [3,2,3,4,2,2,4,5,6];

var i,
	lastNum = arr[0],
	lastSeqArr = new Array(0),
	maxSeqArr = new Array(0),
	arrLength = arr.length;

for (i = 0; i < arrLength; i+=1) {
	if (lastNum <= arr[i]) {
		lastSeqArr.push(arr[i]);
		lastNum = arr[i];
	}
	else {
		if (lastSeqArr.length > maxSeqArr.length) {
			maxSeqArr = lastSeqArr;
		}
		lastSeqArr = new Array(0);
		lastSeqArr.push(arr[i]);
		lastNum = arr[i];
	}
}

// check again in case max increasing sequence is at the end of the array
if (lastSeqArr.length > maxSeqArr.length) {
	maxSeqArr = lastSeqArr;
}

var result = maxSeqArr.join(', ');
console.log(result);