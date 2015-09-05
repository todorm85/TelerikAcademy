/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
  return function(selector) {

    function onButtonClick () {
      var clickedButton = $(this);
      var firstContent = clickedButton.nextAll('.content:first');      

      if (firstContent.length < 1) {
        return;
      }

      if (firstContent.css('display') === 'block' || firstContent.css('display') === '') {
        firstContent.css('display', 'none');
        clickedButton.html('show');
      } else {
        firstContent.css('display', '');
        clickedButton.html('hide');
      }
    }

    var matchedElements = $(selector);
    if (matchedElements.length < 1) {
      throw new Error('No matched elements found.');
    }

    $('.button', matchedElements).html('hide');
    matchedElements.on('click', '.button', onButtonClick);
  };
}
module.exports = solve;