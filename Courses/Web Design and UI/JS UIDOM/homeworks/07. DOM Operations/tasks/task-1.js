/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function() {

    function template(element, contents) {
        var div,
            dFrag;

        if (!(element instanceof HTMLElement)) {
            element = document.getElementById(element);
        }

        if (!element) {
            throw new Error('Must proide valid id or DOM element.' + element);
        }

        contents.forEach(function(content) {
            if (typeof content !== 'number' && typeof content !== 'string') {
                throw new Error('Invalid content type!');
            }
        });

        while (element.firstChild) {
            element.removeChild(element.firstChild);
        }

        div = document.createElement('div');
        dFrag = document.createDocumentFragment();
        contents.forEach(function(content) {
            var newDiv;
            newDiv = div.cloneNode(true);
            newDiv.innerHTML = content;
            dFrag.appendChild(newDiv);
        });

        element.appendChild(dFrag);
    };

    return template;
};