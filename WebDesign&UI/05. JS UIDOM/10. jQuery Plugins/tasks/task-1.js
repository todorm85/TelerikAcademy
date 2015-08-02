function solve() {
    return function(selector) {
        var matchedSelect,
            containerDiv,
            matchedOptions,
            optionsContainer,
            itemsToAdd,
            firstOption,
            currentDiv,
            i,
            len;

        function onCurrentDivClick() {
            currentDiv.html('Select option').attr('data-value', '');
            if (optionsContainer.css('display') === 'none') {
                optionsContainer.css('display', 'block');
            } else {
                optionsContainer.css('display', 'none');
                $(this).html('Select option');
            }
        }

        function onDropdownItemClick() {
            matchedSelect.val($(this).attr('data-value'));
            currentDiv.html($(this).html()).attr('data-value', $(this).attr('data-value'));
            optionsContainer.css('display', 'none');
        }

        containerDiv = $('<div/>').addClass('dropdown-list');
        currentDiv = $('<div/>').addClass('current').attr('data-value', '');
        containerDiv.append(currentDiv);

        optionsContainer = $('<div />')
            .addClass('options-container')
            .css('position', 'absolute')
            .css('display', 'none');
        containerDiv.append(optionsContainer);

        itemsToAdd = [];
        matchedSelect = $(selector).css('display', 'none');
        matchedOptions = $('option', matchedSelect);
        for (i = 0, len = matchedOptions.length; i < len; i += 1) {
            itemsToAdd.push($('<div />')
                .addClass('dropdown-item')
                .attr('data-value', $(matchedOptions[i]).attr('value'))
                .attr('data-index', i)
                .html(matchedOptions[i].innerHTML));
        }

        optionsContainer.append(itemsToAdd);
        firstOption = $(matchedOptions[0]);
        currentDiv.html(firstOption.html())
            .attr('data-value', firstOption.attr('value'))
            .on('click', onCurrentDivClick);
        optionsContainer.on('click', '.dropdown-item', onDropdownItemClick);

        containerDiv.insertBefore(matchedSelect).prepend(matchedSelect);
    };
}

module.exports = solve;