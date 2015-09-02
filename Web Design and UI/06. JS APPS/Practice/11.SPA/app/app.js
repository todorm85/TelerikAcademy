var sammyApp = Sammy('#content', function () {

  this.get('#/', function () {
    console.log('home');
  });

  this.get('#/details', function () {
    console.log('details');
  });

});

$(function () {
  sammyApp.run();
});