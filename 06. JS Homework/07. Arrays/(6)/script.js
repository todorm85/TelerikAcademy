var arr = [4,1,1,4,2,3,4,4,1,2,4,9,3];
// var arr = [1,1,1,5,3,2,2,5,2,2];
// var arr = [4,1,1,4,2,3,4,4,1,2,4,9,3,4];

var i,
	freqNum,
	currentNum,
	count,
	maxCount,
	arrLength = arr.length;

maxCount = 0;

while (arrLength>0) {
	currentNum = arr[0];
	count = 0;
	for (i = 0; i < arrLength; i+=1) {
		if (currentNum===arr[i]) {
			count+=1;
			arr.splice(i,1);
			i-=1;
			arrLength-=1;
		}
	}
	if (count > maxCount) {
		maxCount = count;
		freqNum = currentNum;
	}
}

console.log(freqNum + '(' + maxCount + ' times)');