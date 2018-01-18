var dialogsModule = require("ui/dialogs");
var frameModule = require("ui/frame");
var EditTrainingViewModel = require("../../shared/view-models/edit-training-view-model");
var viewModel = new EditTrainingViewModel();
var TrainingDetailsViewModel = require("../../shared/view-models/training-details-view-model");

exports.loaded = function(args) {
    var page = args.object;
    var training = new TrainingDetailsViewModel(page.navigationContext.id);
    training.load().then(function() {
        viewModel.set("training", training);
        page.bindingContext = viewModel;
    });
};

exports.edit = function() {
    viewModel.edit()
        .then(function() {
            dialogsModule
                .alert("Your training was successfully update.")
                .then(function() {
                    var navigationEntry = {
                        moduleName: "views/list/list",
                        // clearHistory: true
                    };

                    frameModule.topmost().navigate(navigationEntry);
                });
        }).catch(function(error) {
            dialogsModule
                .alert({
                    message: "Unfortunately we were unable to updates your training. \n",
                    okButtonText: "OK"
                });
        });
}
