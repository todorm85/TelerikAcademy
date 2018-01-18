var dialogsModule = require("ui/dialogs");
var UserViewModel = require("~/shared/view-models/user-view-model");
var frameModule = require('ui/frame');
var userViewModel = new UserViewModel({ email: 'u1@site.com', password: 'u1' });

exports.pageLoaded = function(args) {
    var page = args.object;
    page.bindingContext = userViewModel;
};

exports.signIn = function() {
    userViewModel.isLoading = true;
    userViewModel.login()
        .catch(function(error) {
            dialogsModule.alert({
                message: "Unfortunately we could not find your account.",
                okButtonText: "OK"
            });
            userViewModel.isLoading = false;
            return Promise.reject();
        })
        .then(function() {
            var navigationEntry = {
                moduleName: "views/main-menu/main-menu",
                // clearHistory: true,
            };

            userViewModel.isLoading = false;
            frameModule.topmost().navigate(navigationEntry);
        });

};

exports.register = function() {
    var topmost = frameModule.topmost();
    topmost.navigate('views/register/register');
};
