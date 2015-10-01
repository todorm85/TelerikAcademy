import Sammy from 'sammy';
import db from 'app/db.js';
import templates from 'app/templates.js';
import handlebars from 'handlebars';
import 'jquery';

var sammyApp = Sammy('#content', function () {
   this.get('#/', function () {
      this.redirect('#/home');
   });

   this.get('#/home', function () {
      console.log('home');
   });

   this.get('#/items', function () {
      var items;
      db.getItems()
         .then(function (res) {
            items = res;
            return templates.get('items');
         })
         .then(function (htmlTemplate) {
               var compiledHtmlTemplate = handlebars.compile(htmlTemplate);
               $('#content').html(compiledHtmlTemplate(items));
            },
            function (errorMSG) {
               console.log('Items template error: ' + errorMSG.statusText);
            }
         );
   });

   this.get('#/items/:id', function () {
      var id = this.params.id;
      var item;

      db.getItemById(id)
         .then(function (res) {
            item = res;
            return templates.get('item');
         })
         .then(function (html) {
            var template = handlebars.compile(html);
            $('#content').html(template(item));
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
