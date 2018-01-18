var dialogsModule = require("ui/dialogs");
var Observable = require("data/observable").Observable;
var viewModule = require("ui/core/view");
var TrainingDetailsViewModel = require("../../shared/view-models/training-details-view-model");
var frameModule = require('ui/frame');
var page, training, pageData;

exports.loaded = function(args) {
    page = args.object;
    var detailsView = page.getViewById("training");
    training = new TrainingDetailsViewModel(page.navigationContext.id);
    pageData = new Observable({
        training: training,
        isLoading: true
    });

    page.bindingContext = pageData;
    training.load()
        .then(function() {
            pageData.set("isLoading", false);
            detailsView.animate({
                opacity: 1,
                duration: 1000
            });
        });
};

exports.edit = function(args) {
    pageData.set('isLoading', true);
    var id = args.object.bindingContext.training.id;
    var topmost = frameModule.topmost();
    topmost.navigate({
        moduleName: 'views/edit-training/edit-training',
        context: {
            id: id
        },
        backstackVisible: false,
        // clearHistory: true
    });
};