var arr1 = [3, 5, 2, 55, 123, 567, -435, 344.6, 43.6, 5],
	key1 = 7,
	expected1 = 0,
	arr2 = [3, 5, 2, 55, 123, 567, -435, 344.6, 43.6, 5],
	key2 = 2,
	expected2 = 1,
	arr3 = [3, 5, 2, 55, 123, 567, -435, 344.6, 43.6, 5],
	key3 = 5,
	expected3 = 2;

console.log(countNumTest(key1, arr1, expected1) ? 'test success' : 'test fail');
console.log(countNumTest(key2, arr2, expected2) ? 'test success' : 'test fail');
console.log(countNumTest(key3, arr3, expected3) ? 'test success' : 'test fail');

function countNum(key, arr) {
	var count = 0,
		i;
	for (i in arr) {
		if (arr[i] === key) {
			count += 1;
		}
	}
	return count;
}

function countNumTest(key, arr, expected) {
	return countNum(key, arr) === expected;
}