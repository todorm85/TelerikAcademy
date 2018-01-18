var dialogsModule = require("ui/dialogs");
var frameModule = require("ui/frame");

var UserViewModel = require("../../shared/view-models/user-view-model");
var user = new UserViewModel({ email: 'u1@site.com', password: 'u1' });

exports.loaded = function(args) {
    var page = args.object;
    page.bindingContext = user;
};

function completeRegistration() {
    user.isLoading = true;
    user.register()
        .then(function() {
            dialogsModule
                .alert("Your account was successfully created.")
                .then(function() {
                    frameModule.topmost().navigate("views/login/login");
                    user.isLoading = false;
                });
        }).catch(function(error) {
            console.log(error);
            user.isLoading = false;

            // var errorsString;
            // if (error && error.ModelState) {
            //     var modelState = error.ModelState;
            //     //THE CODE BLOCK below IS IMPORTANT WHEN EXTRACTING MODEL STATE IN JQUERY/JAVASCRIPT
            //     for (var key in modelState) {
            //         if (modelState.hasOwnProperty(key)) {
            //             errorsString = (errorsString === "" ? "" : errorsString + ", ") + modelState[
            //                 key];
            //         }
            //     }
            // }

            dialogsModule
                .alert({
                    message: "Unfortunately we were unable to create your account. \n",
                    okButtonText: "OK"
                });
        });
}

exports.register = function() {
    if (user.isValidEmail()) {
        completeRegistration();
    } else {
        dialogsModule.alert({
            message: "Enter a valid email address.",
            okButtonText: "OK"
        });
    }
};
