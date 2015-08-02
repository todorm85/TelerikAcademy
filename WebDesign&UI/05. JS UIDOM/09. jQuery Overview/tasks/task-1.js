/* globals $ */

/* 

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/

function solve() {

  function isConvertibleToNumber(num, callerID) {
    if (isNaN(+num) || num === null || num === '') {
      return false;
    } else {
      return true;
    }
  }

  return function(selector, count) {
    var $ul,
      i,
      $matchedElements;

    if (typeof selector !== 'string') {
      throw new Error('Selector must be string');
    }

    if (!isConvertibleToNumber(count)) {
      throw new Error('Argument must be convertible to number');
    }

    if (count < 1) {
      throw new Error('Count must be greater than or equal to 1');
    }

    $ul = $('<ul />').addClass('items-list');
    count = parseInt(count);
    for (i = 0; i < count; i += 1) {
      $ul.append($('<li />').addClass('list-item').html('List item #' + i));
    }

    $matchedElements = $(selector);
    if ($matchedElements) {
      $matchedElements.append($ul);
    }
  };
};

module.exports = solve;