function printDOM(msg) {
    $('<div />')
        .html(msg)
        .appendTo('#output');
}

$.ajax({
    url: 'data.json',
    type: 'GET',
    timeout: 5000,
    contentType: 'application/json',
    success: function(response) {
        console.log(response);
        printDOM(JSON.stringify(response));
    }
});

$.getJSON('data.json', function(response) {
    console.log(response);
    printDOM(JSON.stringify(response));
});

$('#loaded').load('data.json');