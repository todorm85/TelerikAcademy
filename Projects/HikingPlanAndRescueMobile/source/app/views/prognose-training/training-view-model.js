var config = require("../../shared/config");
var fetchModule = require("fetch");
var Observable = require("data/observable")
    .Observable;

function TrainingViewModel(info) {
    info = info || {};
    info.track = info.track || {};

    var viewModel = new Observable({
        startDate: info.startDate || "",
        track: {
            length: info.track.length || "",
            ascent: info.track.ascent || "",
            ascentLength: info.track.ascentLength || "",
        }
    });

    viewModel.predict = function() {
        var startDate = viewModel.get('startDate');
        var track = viewModel.get('track');

        return fetchModule.fetch(config.apiUrl + "api/prognosis/training/", {
                method: "POST",
                body: JSON.stringify({
                    startDate,
                    track
                }),
                headers: {
                    "Content-Type": "application/json",
                    "Authorization" : "bearer " + config.token
                }
            })
            .then(handleErrors, function (err) {
                console.log(JSON.stringify(err));
            })
            .then(function(response) {
                return response.json();
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

module.exports = TrainingViewModel;
