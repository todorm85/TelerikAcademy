/* globals $ */

function solve() {
    return function(selector) {
        var buttons,
            contents,
            i,
            len;

        function onButtonClick(ev) {
            var clickedButton = ev.target;
            var firstContent = clickedButton.nextSibling;
                
            while (firstContent && (!firstContent.className || firstContent.className.indexOf('content') === -1)) {
                firstContent = firstContent.nextSibling;
            }

            if (!firstContent) {
                return
            }

            if (firstContent.style.display === 'none') {
                firstContent.style.display = '';
                clickedButton.innerHTML = 'hide';
            } else {
                firstContent.style.display = 'none';
                clickedButton.innerHTML = 'show';
            }
        }

        if (!(selector instanceof HTMLElement)) {
            selector = document.getElementById(selector);
        }

        if (!selector) {
            throw new Error('Nonexistent element.');
        }

        buttons = selector.getElementsByClassName("button");

        for (i = 0, len = buttons.length; i < len; i++) {
            buttons[i].innerHTML = 'hide';
            buttons[i].addEventListener('click', onButtonClick, false);
        }
    };
}

module.exports = solve;