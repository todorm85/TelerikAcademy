import 'jquery';

var _items = [{
  id: 1,
  name: 'first'
}, {
  id: 2,
  name: 'second'
}, {
  id: 3,
  name: 'third'
}, ];

function get() {
  return new Promise(function(resolve, reject) {
    resolve(_items);
  });
}

function getById() {

}

function save() {

}

export default {
  get, getById, save
};