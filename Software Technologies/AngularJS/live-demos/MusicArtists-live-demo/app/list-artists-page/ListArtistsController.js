(function () {

    function listArtistsController(artistDataSvc) {

        var vm = this;
        vm.search = 'pesho';

        artistDataSvc.getAll()
            .then(function (data) {
                vm.artists = data;
            });
    }

    angular
        .module('musicApp.controllers')
        .controller('ListArtistsController', ['artistDataSvc', listArtistsController]);

})();
