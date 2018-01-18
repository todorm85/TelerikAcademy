function solve() {
    return function (selector) {
        var template = '<div class="events-calendar">' +
            '<h2 class="header">' +
                'Appointments for <span class="month">{{this.month}}</span> <span class="year">{{this.year}}</span>' +
            '</h2>' +
            '{{#each this.days}}' +
            '<div class="col-date">' +
                '<div class="date">{{day}}</div>' +
                '<div class="events">' +
                    '{{#each events}}' +
                    '<div class="event {{importance}}" title="{{#if comment}}{{comment}}{{else}}no comment{{/if}}">' +
                        '<div class="title">{{#if title}}{{title}}{{else}}Free slot{{/if}}</div>' +
                        '{{#if time}}' +
                        '<span class="time">at: {{time}}</span>' +
                        '{{/if}}' +
                    '</div>' +
                    '{{/each}}' +
                '</div>' +
            '</div>' +
            '{{/each}}' +
        '</div>';
        document.getElementById(selector).innerHTML = template;
    };
}

module.exports = solve;

