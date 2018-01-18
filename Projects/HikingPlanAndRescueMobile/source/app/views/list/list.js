var dialogsModule = require("ui/dialogs");
var Observable = require("data/observable").Observable;
var ObservableArray = require("data/observable-array").ObservableArray;
var viewModule = require("ui/core/view");
var TrainingsListViewModel = require("../../shared/view-models/trainings-list-view-model");
var frameModule = require('ui/frame');

var page;
var trainingsList = new TrainingsListViewModel([]);
var pageData = new Observable({
    trainingsList,
    trainingTitle: ""
});

exports.loaded = function(args) {
    page = args.object;
    var listView = page.getViewById("trainingsList");
    page.bindingContext = pageData;

    trainingsList.empty();
    pageData.set("isLoading", true);
    trainingsList.load()
        .then(function() {
            pageData.set("isLoading", false);
            listView.animate({
                opacity: 1,
                duration: 1000
            });
        });
};

exports.delete = function(args) {
    var item = args.view.bindingContext;
    var index = trainingsList.indexOf(item);

    pageData.set("isLoading", true);
    trainingsList.delete(index)
        .catch(function(err) {
            // console.log('error:');
            // console.log(JSON.stringify(err));
            pageData.set("isLoading", false);
            return Promise.reject();
        })
        .then(function() {
            pageData.set("isLoading", false);
        });
};

exports.showDetails = function(args) {
    pageData.set('isLoading', true);
    var id = args.view.bindingContext.id;
    var topmost = frameModule.topmost();
    topmost.navigate({
        moduleName: 'views/training/training',
        context: {
            id: id
        },
        // backstackVisible: false,
    });
};

exports.addTraining = function(args) {
    var topmost = frameModule.topmost();
    topmost.navigate('views/add-training/add-training');
};

exports.mainMenu = function(args) {
    frameModule.topmost()
        .navigate("views/main-menu/main-menu");
};
