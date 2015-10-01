/* globals $ */

function solve() {
    var data = {
        animals: [{
            name: 'Lion',
            url: 'https://susanmcmovies.files.wordpress.com/2014/12/the-lion-king-wallpaper-the-lion-king-2-simbas-pride-4685023-1024-768.jpg'
        }, {
            name: 'Turtle',
            url: 'http://www.enkivillage.com/s/upload/images/a231e4349b9e3f28c740d802d4565eaf.jpg'
        }, {
            name: 'Dog'
        }, {
            name: 'Cat',
            url: 'http://i.imgur.com/Ruuef.jpg'
        }, {
            name: 'Dog Again'
        }]
    };

    return function (selector) {
        var htmlTemplate = $('#animals-list-template').html();
        var htmlRenderer = Handlebars.compile(htmlTemplate);
        var finalHtml = htmlRenderer(data);

        $(selector).html(finalHtml);
    };
}

solve()('#content');
// module.exports = solve;
