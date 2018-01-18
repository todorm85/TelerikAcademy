window.onload = function() {
    var x = 0,
        y = 0,
        width = 50,
        height = 25;
    var svgNS = 'http://www.w3.org/2000/svg';
    var rect = document.createElementNS(svgNS, 'rect');
    rect.setAttribute('x', x);
    rect.setAttribute('y', y);
    rect.setAttribute('width', width);
    rect.setAttribute('height', height);
    rect.setAttribute('id', 'the-rect');

    document.getElementById('the-svg').appendChild(rect);
};