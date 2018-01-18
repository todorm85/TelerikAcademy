var config = require("../../shared/config");
var fetchModule = require("fetch");
var ObservableArray = require("data/observable-array")
    .ObservableArray;

var trainingsApi = 'api/trainings/';

function TrainingsListViewModel(items) {
    var viewModel = new ObservableArray(items);

    viewModel.load = function() {
        return fetch(config.apiUrl + trainingsApi, {
                headers: {
                    "Authorization": "Bearer " + config.token
                }
            })
            .then(handleErrors)
            .then(function(response) {
                return response.json();
            })
            .then(function(data) {
                data.forEach(function(training) {
                    viewModel.push({
                        title: training.Title,
                        id: training.Id
                    });
                });
            });
    };

    viewModel.empty = function() {
        while (viewModel.length) {
            viewModel.pop();
        }
    };

    viewModel.delete = function(index) {
        var url = config.apiUrl + trainingsApi + viewModel.getItem(index).id;
        return fetch(url, {
                    method: "DELETE",
                    headers: {
                        "Authorization": "Bearer " + config.token
                    }
                })
            // for some reason the delete fetch is resolved to reject??? when successful WTF!!
            // found it -> promise is rejected if response body is empty, regardless of status code!
            .then(handleErrors, function (err) {
                console.log('error: ' + JSON.stringify(err));
            })
            .then(function() {
                console.log('splicing array');
                viewModel.splice(index, 1);
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

module.exports = TrainingsListViewModel;
