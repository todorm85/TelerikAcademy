var common = {
    indexOfElementByPropertyName: function(array, propName) {
        var foundIndex = -1;
        array.forEach(function(element, index) {
            if (element[propName] !== undefined) {
                foundIndex = index;
            }
        });
        return foundIndex;
    },
    indexOfElementByPropertyValue: function(array, propName, propValue) {
        var i, len;
        for (i = 0, len = array.length; i < len; i++) {
            if (array[i][propName] === propValue) {
                return i;
            }
        }

        return -1;
    },
    processArguments: function(args) {
        var items;
        if (args.length === 0) {
            throw 'No items added';
        }
        if (Array.isArray(args[0])) {
            items = args[0];
        } else {
            // possible problem here!
            items = Array.prototype.slice.call(args);
        }
        return items;
    },
}

function test() {
    var args = arguments;
    var items = common.processArguments(args);

    return items;
}

var arrItems = test(1, 2, 3, 4);
console.log(arrItems);
var arrArr = test([5, 6, 7, 8]);
console.log(arrArr);