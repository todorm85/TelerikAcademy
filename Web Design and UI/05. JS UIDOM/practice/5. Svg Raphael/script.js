var paper = Raphael(10, 10, 500, 500);
paper.setStart();
var rect = paper.rect(50, 90, 180, 80);
rect.attr({
    'fill': 'purple',
    'stroke': 'blue',
    'stroke-width': '25'
}).rotate(45, 140, 130);
var circle = paper.circle(75, 85, 75);
paper.rect(160, 85, 75 ,45);
paper.text(10,200,'This is text!');
var testSet = paper.setFinish();

testSet.attr({
    fill: 'orange'
});