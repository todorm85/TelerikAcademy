(function () {

    function registerUserController($location, auth) {
        var vm = this;

        vm.cancel = function cancelHandler() {
            $location.path('#/home');
        }

        vm.registerUser = function registerUserHandler(user, userForm) {
            if (userForm.$valid) {
                auth.register(user)
                    .then(function (data) {
                        toastr.success('Successful registration.');
                        $location.path('login-user');
                    }, function (response) {
                        toastr.error('Invalid request, probably password too short.');
                        console.log(response);
                    });
            } else {
                toastr.error('Invalid data');
            }
        }
    }

    angular
        .module('MyApp.controllers')
        .controller('RegisterUserController', ['$location', 'auth', registerUserController])
})();
