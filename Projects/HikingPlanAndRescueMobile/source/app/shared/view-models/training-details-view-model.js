var config = require("../../shared/config");
var fetchModule = require("fetch");
var Observable = require("data/observable").Observable;
var trainingsApi = 'api/trainings/';

function TrainingDetailsViewModel(id) {
	var viewModel = new Observable({
		track: {}
	});

	viewModel.load = function() {
		return fetch(config.apiUrl + trainingsApi + id, {
				headers: {
					"Authorization": "Bearer " + config.token
				}
			})
			.then(handleErrors)
			.then(function(response) {
				return response.json();
			})
			.then(function(data) {
				console.log(JSON.stringify(data));
				viewModel.set('title', data.Title);
				viewModel.set('id', data.Id);
				viewModel.set('startDate', data.StartDate);
				viewModel.set('endDate', data.EndDate);
				viewModel.set('predictedEndDate', data.PredictedEndDate);
				viewModel.set('water', data.Water);
				viewModel.set('calories', data.Calories);
				viewModel.set('track', data.Track);
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

module.exports = TrainingDetailsViewModel;