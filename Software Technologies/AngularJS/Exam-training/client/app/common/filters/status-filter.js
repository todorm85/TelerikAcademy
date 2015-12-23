(function () {
    angular
        .module('MyApp.filters')
        .filter('status', function () {
            return function (input) {
                var modifiedInput;
                switch (input) {
                    case 1:
                        modifiedInput = 'released';
                        break;
                    case 2:
                        modifiedInput = 'pending';
                        break;
                    case 3:
                        modifiedInput = 'unreleased';
                        break;
                }

                return modifiedInput;
            }
        });

})();
