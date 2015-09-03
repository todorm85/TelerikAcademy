import Sammy from 'sammy';
import 'jquery';
import db from 'app/db.js';

var sammyApp = Sammy('#content', function () {
   this.get('#/', function () {
      this.redirect('#/home');
   });

   this.get('#/home', function () {
      console.log('home');
   });

   this.get('#/items', function () {
      db.getItems().then(function (items) {
         $('#content').html('');

         items.forEach(function (item) {
            $('<a />')
               .css('display', 'block')
               .attr('href', '#/items/' + item.id)
               .html('item ' + item.name)
               .appendTo('#content');
         });
      });
   });

   this.get('#/items/:id', function () {
      var id = this.params.id;

      db.getItemById(id)
         .then(function (item) {
            $('#content')
               .html('Item name: ' + item.name + ', id: ' + item.id);
         });
   });

   this.get('#/addItem', function () {
      var sammyObj = this;
      var inputForm = $('<input />')
         .attr('id', 'input-name');
      var submitButton = $('<button />')
         .attr('id', 'button-submit')
         .html('Add')
         .on('click', function () {
            var name = inputForm.val() || '';
            if (!name.trim()) {
               alert('Please, enter name.');
            } else {
               sammyObj.redirect('#/addItem/' + name);
            }
         });

      $('#content')
         .html('')
         .append(inputForm)
         .append(submitButton);
   });

   this.get('#/addItem/:name', function () {
      db.saveItem(this.params.name)
         .then(function (item) {
            $('#content').html(item.name + ' added with id: ' + item.id);
         });
   });
});

$(function () {
   sammyApp.run('#/');
});
