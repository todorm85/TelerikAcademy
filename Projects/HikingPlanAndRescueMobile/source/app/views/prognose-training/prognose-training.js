var dialogsModule = require("ui/dialogs");
var frameModule = require('ui/frame');
var TrainingViewModel = require("~/views/prognose-training/training-view-model");
var Observable = require("data/observable")
    .Observable;

var trainingViewModel = new TrainingViewModel({
    startDate: "1/15/16 10:00",
        track: {
            length: "78",
            ascent: "2500",
            ascentLength: "36",
        }
});

var pageViewModel = new Observable({
    trainingViewModel,
    isLoading: false,
    prognosis: {
        EndDate: "",
        Water: "",
        Calories: "",
    }
});

exports.pageLoaded = function(args) {
    var page = args.object;
    page.bindingContext = pageViewModel;
};

exports.predict = function() {
    pageViewModel.isLoading = true;
    trainingViewModel.predict()
        .catch(function(error) {
            dialogsModule.alert({
                message: "Unfortunately we could not predict your training.",
                okButtonText: "OK"
            });
            pageViewModel.isLoading = false;
            return Promise.reject();
        })
        .then(function(data) {
            pageViewModel.set('prognosis', data);
            pageViewModel.isLoading = false;
        });

};
