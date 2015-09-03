import Sammy from 'sammy';
import 'jquery';
import db from 'app/db.js';

var sammyApp = Sammy('#content', function() {
   this.get('#/', function() {
      this.redirect('#/home');
   });

   this.get('#/home', function() {
      console.log('home');
   });


   this.get('#/items', function() {
      db.get().then(showItemsLinks);
   });

   function showItemsLinks(items) {
      $('#content').html('');

      items.forEach(function(item) {
         $('<a />')
            .css('display', 'block')
            .attr('href', '#/items/' + item.id)
            .html('item ' + item.name)
            .appendTo('#content');
      });
   }


   this.get('#/items/:id', function() {
      var id = this.params.id;
      $('#content')
         .html('item' + id);
   });
});

$(function() {
   sammyApp.run('#/');
});