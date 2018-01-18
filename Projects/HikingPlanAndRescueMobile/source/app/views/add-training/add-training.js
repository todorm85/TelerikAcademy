var dialogsModule = require("ui/dialogs");
var frameModule = require("ui/frame");

var AddTrainingViewModel = require("../../shared/view-models/add-training-view-model");
var viewModel = new AddTrainingViewModel();

exports.loaded = function(args) {
    var page = args.object;
    page.bindingContext = viewModel;
};

exports.add = function() {
    viewModel.add()
        .then(function() {
            dialogsModule
                .alert("Your training was successfully created.")
                .then(function() {
                    frameModule.topmost().navigate("views/list/list");
                });
        }).catch(function(error) {
            dialogsModule
                .alert({
                    message: "Unfortunately we were unable to create your training. \n",
                    okButtonText: "OK"
                });
        });
}