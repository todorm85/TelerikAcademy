var config = require("../../shared/config");
var fetchModule = require("fetch");
var Observable = require("data/observable").Observable;
var trainingsApi = 'api/trainings/';

function AddTrainingViewModel(info) {
	var viewModel = new Observable({
		track: {}
	});
	viewModel.add = function(info) {
		return fetchModule.fetch(config.apiUrl + trainingsApi, {
				method: "POST",
				body: JSON.stringify({
					StartDate: viewModel.startDate,
					EndDate: viewModel.endDate,
					PredictedEndDate: null,
					Title: viewModel.title,
					Water: viewModel.water,
					Calories: viewModel.calories,
					Track: {
						Title: viewModel.track.trackTitle,
						Length: viewModel.track.length,
						Ascent: viewModel.track.ascent,
						AscentLength: viewModel.track.ascentLength
					}
				}),
				headers: {
					"Content-Type": "application/json",
					"Authorization": "Bearer " + config.token
				}
			})
			.then(handleErrors, function(err) {
				console.log(JSON.stringify(err));
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

module.exports = AddTrainingViewModel;