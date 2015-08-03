function solve() {
    return function() {
        $.fn.listview = function(data) {
            var template = $('#' + this.attr('data-template')).html();
            template = '{{#each this}}' + template + '{{/each}}';
            var compiledTemplate = handlebars.compile(template);
            this.append(compiledTemplate(data));
        };
    };
}

// solve()();

// var books = [{
//     id: 1,
//     title: 'JS1'
// }, {
//     id: 2,
//     title: 'JS2'
// }, {
//     id: 3,
//     title: 'JS3'
// }, ];

// $('#books-list').listview(books);
module.exports = solve;