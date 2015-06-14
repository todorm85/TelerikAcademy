function buildPoint(x, y) {
	return {
		x: x,
		y: y
	};
}

function buildLine(point1, point2) {
	return {
		p1: point1,
		p2: point2,
		length: pointDistance(point1, point2)
	};
}

function pointDistance(p1, p2) {
	var dx = p1.x - p2.x;
	var dy = p1.y - p2.y;
	return Math.sqrt(dx * dx + dy * dy);
}

function canBeTriangle(l1, l2, l3) {
	if (l1.length >= l2.length + l3.length || l2.length >= l1.length + l3.length || l3.length >= l2.length + l1.length) {
		return false;
	} else {
		return true;
	}
	return undefined;
}

var p1 = buildPoint(1, 1),
	p2 = buildPoint(4, 5),
	p3 = buildPoint(-10, -1),
	p4 = buildPoint(-5, 11),
	p5 = buildPoint(13, 10),
	p6 = buildPoint(7, 2);

var l1 = buildLine(p1, p2),
	l2 = buildLine(p3, p4),
	l3 = buildLine(p5, p6),
	l4 = buildLine(p1,p2);

console.log('l1 length (p1, p2 distance): ' + l1.length);
console.log('l2 length (p3, p4 distance): ' + l2.length);
console.log('l3 length (p5, p6 distance): ' + l3.length);

console.log('l1,l2,l3 can form triangle: ' + canBeTriangle(l1, l2, l3));
console.log('l1,l2,l1 can form triangle: ' + canBeTriangle(l1, l2, l1));