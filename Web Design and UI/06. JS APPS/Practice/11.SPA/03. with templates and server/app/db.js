import 'jquery';

var _items = [];
var lastId = 0;

function getItems() {
   return new Promise(function (resolve) {
      resolve(_items);
   });
}

function getItemById(id) {
   return new Promise(function (resolve) {
      var item = _items[id-1];
      resolve(item);
   });
}

function saveItem(name) {
   return new Promise(function (resolve) {
      var item = {};
      item.id = lastId += 1;
      item.name = name;
      _items.push(item);
      resolve(item);
   });
}

export default {
   getItems, getItemById, saveItem
};
