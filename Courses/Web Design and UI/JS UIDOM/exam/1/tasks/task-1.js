function solve() {
    return function(selector, isCaseSensitive) {
        var root = document.querySelector(selector);
        root.className += ' items-control';
        var docFrag = document.createDocumentFragment();

        var addControls = document.createElement("div");
        addControls.className = 'add-controls';
        var addTextLabel = document.createElement("label");
        addTextLabel.innerHTML = 'Enter text';
        var textId = 'addTextLabel' + Math.random();
        addTextLabel.setAttribute('for', textId);
        addControls.appendChild(addTextLabel);
        var input = document.createElement("input");
        input.id = textId;
        addControls.appendChild(input);
        var addButton = document.createElement("div");
        addButton.className = 'button';
        addButton.innerHTML = 'Add';
        addControls.appendChild(addButton);

        var searchControls = document.createElement("div");
        searchControls.className = 'search-controls';
        var searchLabel = document.createElement("label");
        searchLabel.innerHTML = 'Search';
        var searchId = 'searchLabel' + Math.random();
        searchLabel.setAttribute('for', searchId);
        searchControls.appendChild(searchLabel)
        var searchInput = document.createElement("input");
        searchInput.id = searchId;
        searchControls.appendChild(searchInput);

        var resultControls = document.createElement("div");
        resultControls.className = 'result-controls';
        var itemsList = document.createElement("div");
        itemsList.className = 'items-list';
        resultControls.appendChild(itemsList);

        var listItem = document.createElement("div");
        listItem.className = 'list-item';
        var closeButton = document.createElement("div");
        closeButton.className = 'button';
        closeButton.innerHTML = 'X';
        var listItemText = document.createElement("span");


        addButton.addEventListener('click', function() {
            var itemToAdd = listItem.cloneNode(true);
            itemToAdd.appendChild(closeButton.cloneNode(true));
            itemToAddText = listItemText.cloneNode(true);
            itemToAddText.innerHTML = input.value;
            itemToAdd.appendChild(itemToAddText);
            if (searchInput.value && itemToAddText.innerHTML.indexOf(searchInput.value) <= 0) {
                itemToAdd.style.display = 'none';
            }
            itemsList.appendChild(itemToAdd);
        }, false);

        itemsList.addEventListener('click', function(ev) {
            var clicked = ev.target;
            if (clicked.className.indexOf('button') >= 0) {
                clicked.parentNode.parentNode.removeChild(clicked.parentNode);
            }
        }, false);

        var allItems = itemsList.getElementsByClassName("list-item");
        searchInput.addEventListener('input', function() {
            var pattern = this.value;

            for (var i=0, len = allItems.length; i<len; i+=1) {
                var item = allItems[i].getElementsByTagName("span")[0];
                item.parentNode.style.display = 'none';
                if (isCaseSensitive) {
                    if (item.innerHTML.indexOf(pattern) >= 0) {
                        item.parentNode.style.display = '';
                    }
                } else {
                    if (item.innerHTML.toLowerCase().indexOf(pattern.toLowerCase()) >= 0) {
                        item.parentNode.style.display = '';
                    }
                }
            }

        }, false);

        docFrag.appendChild(addControls);
        docFrag.appendChild(searchControls);
        docFrag.appendChild(resultControls);
        root.appendChild(docFrag);
    };
}

module.exports = solve;