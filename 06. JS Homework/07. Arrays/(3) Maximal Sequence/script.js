var arr = [ 1, 1, 2, 3, 3, 2, 2, 2, 1];
// var arr = [ 1, 1, 1, 1, 2, 3, 3, 2, 2, 2, 1];
// var arr = [ 1, 1, 2, 3, 3, 2, 2, 2, 1, 1, 1, 1];
var i,
	maxSeqNum = arr[0],
	maxSeqIter = 1,
	currentSeqNum = arr[0],
	currentSeqIter = 0,
	arrLength = arr.length,
	result = '';

for (i = 0; i < arrLength; i+=1) {
	if (currentSeqNum === arr[i]) {
		currentSeqIter+=1;
	}
	else {
		if (currentSeqIter>maxSeqIter) {
			maxSeqIter = currentSeqIter;
			maxSeqNum = currentSeqNum;
		}	
		currentSeqNum = arr[i];
		currentSeqIter = 1;
	}			
}

// this last check is needed if the max sequence is at the end of the array. It is faster to check it here than to add it to the for cycle, although we have code repetition.
if (currentSeqIter>maxSeqIter) {
	maxSeqIter = currentSeqIter;
	maxSeqNum = currentSeqNum;
}	

for (i = 0; i < maxSeqIter; i+=1) {
	result += maxSeqNum + ' ';
}

console.log('Max sequence: ' + result);