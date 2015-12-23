(function () {

    function homeController(stats, notifier) {
        var vm = this;

        vm.stats = stats.getStats()
            .then(function (stats) {
                vm.stats = stats;
            }, function (err) {
                console.log('Error in promise at home controller');
                console.log(err);
            })
    }

    angular
        .module('MyApp.controllers')
        .controller('HomePageController', ['stats', 'notifier',homeController]);
})();