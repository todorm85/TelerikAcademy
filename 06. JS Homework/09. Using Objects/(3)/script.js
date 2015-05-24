// var oldObject = 5;
// var oldObject = 'test';
var oldObject = {
	x: {
		z: 7
	},
	y: 7
};

function deepCopy(oldObject) {
	return JSON.parse(JSON.stringify(oldObject));
}

var newObject = deepCopy(oldObject);

newObject.x.z = 0;

console.log(oldObject);
console.log(newObject);