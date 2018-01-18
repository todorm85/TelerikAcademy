var config = require("../../shared/config");
var fetchModule = require("fetch");
var Observable = require("data/observable")
    .Observable;
var CategoricalDataModel = require('~/shared/view-models/categorical-data-model');

var dummyData = [
    { Country: "Germany", Amount: Math.random() * 10 },
    { Country: "France", Amount: Math.random() * 10 },
    { Country: "Bulgaria", Amount: Math.random() * 10 },
    { Country: "Spain", Amount: Math.random() * 10 },
    { Country: "USA", Amount: Math.random() * 10 }
];

function CaloriesStatisticsViewModel(info) {
    info = info || {};

    var viewModel = new Observable({
        startDate: info.startDate || "",
        endDate: info.endDate || "",
        categoricalDataModel: new CategoricalDataModel()
    });

    viewModel.getStatData = function() {
        return fetchModule.fetch(config.apiUrl + "api/statistics/calories", {
                method: "POST",
                body: JSON.stringify({
                    startDate: viewModel.get('startDate'),
                    endDate: viewModel.get('endDate')
                }),
                headers: {
                    "Authorization": "bearer " + config.token,
                    "Content-Type": "application/json"
                }
            })
            .then(handleErrors, function(err) {
                console.log(JSON.stringify(err));
            })
            .then(function(response) {
                var body = JSON.parse(response._bodyInit);
                console.log(JSON.stringify(body.stats));
                if (body.stats.length === 0) { 
                    body.stats = [{}]; 
                }
                console.log(body.stats);

                viewModel.categoricalDataModel = new CategoricalDataModel(body.stats);
                // viewModel.categoricalDataModel = new CategoricalDataModel(body.stats);
            });
    };

    return viewModel;
}

function handleErrors(response) {
    if (!response.ok) {
        throw Error(response.statusText);
    }

    return response;
}

module.exports = {
    CaloriesStatisticsViewModel,
};
