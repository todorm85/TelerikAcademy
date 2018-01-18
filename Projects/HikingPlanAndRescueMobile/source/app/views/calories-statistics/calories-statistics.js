var CaloriesStatisticsViewModel = require("~/shared/view-models/statistics-view-model").CaloriesStatisticsViewModel;
var dialogsModule = require("ui/dialogs");
var Observable = require("data/observable").Observable;

var statsViewModel = new CaloriesStatisticsViewModel({
    startDate: '1/1/15',
    endDate: '1/1/17'
});

var pageViewModel = new Observable({
    statsViewModel,
    isLoading: true
});

function onPageLoaded(args) {
    var page = args.object;
    page.bindingContext = pageViewModel;

    redrawGraph();
}

function redrawGraph () {
    pageViewModel.set('isLoading', true);
    statsViewModel.getStatData()
        .catch(function (err) {
            dialogsModule.alert(err);
        })
        .then(function() {
            pageViewModel.set('isLoading', false);
        }, function (err) {
            dialogsModule.alert(err);
            pageViewModel.set('isLoading', false);
        });
}

function calculate() {
    redrawGraph();
}

exports.onPageLoaded = onPageLoaded;
exports.calculate = calculate;
