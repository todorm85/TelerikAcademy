var stage = new Kinetic.Stage({
    container: 'canvas-container',
    width: 450,
    height: 350
});

var layer = new Kinetic.Layer();
var stageFrame = new Kinetic.Rect({
    // fill: 'green',
    stroke: '#000',
    strokeWidth: 3,
    x: 0,
    y: 0,
    width: 450,
    height: 350
});
var rect = new Kinetic.Rect({
    fill: 'green',
    stroke: '#fff',
    x: 100,
    y: 100,
    width: 50,
    height: 30
});
var circle = new Kinetic.Circle({
    radius: 45,
    fill: 'RGBA(200, 128, 128, .5)',
    stroke: 'darkblue',
    strokeWidth: 3,
    x: 100,
    y: 100
});
var straightLine = new Kinetic.Line({
    points: [0, 0, 50, 50],
    stroke: 'green',
    strokeWidth: 2,
    lineJoin: 'round'
});
var curvedLine = new Kinetic.Line({
    points: [100, 0, 50, 70, 150, 70],
    stroke: 'red',
    strokeWidth: 2,
    tension: -.5,
    closed: true
});

layer.add(stageFrame);
layer.add(rect);
layer.add(circle);
layer.add(straightLine);
layer.add(curvedLine);

stage.add(layer);