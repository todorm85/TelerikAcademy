(function () {

    function artistDataSvc ($http, $q, $resource) {

            var artistApi = $resource('data/artist/:id', {
                id: '@id'
            });

            function getArtist(id) {
                return artistApi
                    .get({
                        id: id
                    }).$promise;
            }

            function saveArtist(artist) {
                return artistApi
                    .query().$promise
                    .then(function (artists) {
                        artist.id = artists.length + 1;
                        return artistApi.save(artist).$promise;
                    });
            }

            function getAll() {
                return artistApi.query().$promise;
            }

            return {
                getArtist,
                saveArtist,
                getAll
            };
        }

    angular
        .module('musicApp.services')
        .service('artistDataSvc', ['$http', '$q', '$resource', artistDataSvc]);

})();
