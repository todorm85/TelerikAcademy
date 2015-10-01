function printDOM(msg) {
    $('<div />')
        .html(msg)
        .appendTo('#output');
}

printDOM('loaded!');
