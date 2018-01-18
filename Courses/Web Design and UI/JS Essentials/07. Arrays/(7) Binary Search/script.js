var arr = [5,2,9,10,-24.1,-346,-4,4576,23,547,23,234,6],
	searchKey = -24.1;

// create shallow copy of the original array
var sortedArr = arr.slice(0);

// sort by numeric value, not lexicographically
sortedArr.sort(orderByAscending);
function orderByAscending (a,b) {
	return a-b;
}

// now we can begin our binary search on the sorted array. We will use recursion.
var foundIndex = binarySearch(searchKey,0,sortedArr.length-1,sortedArr);
console.log('Sorted Array: ' + sortedArr.join(', '));
console.log('Search key: ' + searchKey);
console.log('Found index: ' + foundIndex + ' (If -1 then number was not found!)');

function binarySearch (key,startIndex,endIndex,arr) {
	if (startIndex>endIndex) {return -1;}
	var middleIndex = (startIndex + (endIndex-startIndex)/2 + 0.5) | 0;
	if (key===arr[middleIndex]) {
		return middleIndex;
	}
	if (key<arr[middleIndex]) {
		return binarySearch(key, startIndex, middleIndex-1, arr);
	}
	if (key>arr[middleIndex]) {
		return binarySearch(key, middleIndex+1, endIndex, arr);
	}

	return 'error';
}