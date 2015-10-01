function solve() {
    return function() {
        $.fn.listview = function(data) {
            var htmlTemplateIdSelector = '#' + this.attr('data-template');
            var htmlTemplate = $(htmlTemplateIdSelector).html();
            var htmlRenderer = Handlebars.compile(htmlTemplate);
            var finalHtml = '';
            data.forEach(function (item) {
                finalHtml += htmlRenderer(item);
            });
            this.html(finalHtml);
        };
    };
}

solve()();

var books = [
    {title: 'title 1', id: 1},
    {title: 'title 2', id: 2},
    {title: 'title 3', id: 3},
    {title: 'title 4', id: 4},
    {title: 'title 5', id: 5},
];

$('#books-list').listview(books);
// module.exports = solve;