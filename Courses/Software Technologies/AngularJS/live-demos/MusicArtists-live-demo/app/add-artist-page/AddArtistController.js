(function () {
    'use strict';

    function editArtistController(artistDataSvc, $location) {

        var vm = this;

        vm.saveArtist = function saveArtistHandler(artist, artistForm) {
            if (artistForm.$valid) {
                artistDataSvc.saveArtist(artist)
                    .then(function (data) {
                        console.log(data);
                    }, function (err) {
                        console.log(err);
                    });
            } else {
                alert('invalid data');
            }
        }

        vm.cancel = function cancelHandler() {
            $location.path('#/home');
        }
    }

    angular
        .module('musicApp.controllers')
        .controller(
            'EditArtistController',
            ['artistDataSvc', '$location', editArtistController]);

})();
