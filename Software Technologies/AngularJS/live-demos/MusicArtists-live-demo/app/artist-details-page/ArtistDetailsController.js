(function () {
    'use strict';

    function artistDetailsController(artistDataSvc, routeParams) {

        var vm = this;

        artistDataSvc.getArtist(routeParams.id)
            .then(function (artist) {
                vm.artist = artist;
            }, function (err) {
                console.log(err);
            });

        vm.hideInformation = true;
        vm.toggleHideMoreInfoBtn = 'show';
        vm.toggleHideMoreInfo = function () {
            vm.hideInformation = !vm.hideInformation;
            vm.toggleHideMoreInfoBtn = (vm.toggleHideMoreInfoBtn == 'show') ? 'hide' : 'show';
        }

        vm.bandInformationDisplay = true;
        vm.bandInformationDisplayBtn = 'show';
        vm.toggleBandInformationDisplay = function () {
            vm.bandInformationDisplay = !vm.bandInformationDisplay;
            vm.bandInformationDisplayBtn = (vm.bandInformationDisplayBtn == 'show') ? 'hide' : 'show';
        }

        vm.memberNameStyle = {
            fontWeight: 'bold',
            textDecoration: 'underline',
            align: 'center'
        };

        vm.oddMemberClass = 'dark-back';
        vm.memberNameLinkClass = 'dark-text';

        vm.albumsDisplay = true;
        vm.albumsDisplayBtn = 'show';
        vm.toggleAlbumsDisplay = function () {
            vm.albumsDisplay = !vm.albumsDisplay;
            vm.albumsDisplayBtn = (vm.albumsDisplayBtn == 'show') ? 'hide' : 'show';
        }

        vm.ratingUp = function ratingUpHandler(album) {
            album.rating += 1;
        }

        vm.ratingDown = function ratingDownHandler(album) {
            if (album.rating <= 0) {
                return;
            }

            album.rating -= 1;
        }

        vm.albumSortKey = 'rating';
    }

    angular
        .module('musicApp.controllers')
        .controller('ArtistDetailsController',
            ['artistDataSvc', '$routeParams', artistDetailsController]);
})();
