var config = require("../../shared/config");
var fetchModule = require("fetch");
var Observable = require("data/observable").Observable;
var trainingsApi = 'api/trainings/';

function EditTrainingViewModel() {
	var viewModel = new Observable({});
	viewModel.edit = function(info) {
		return fetchModule.fetch(config.apiUrl + trainingsApi, {
				method: "PUT",
				body: JSON.stringify({
					Id: viewModel.training.id,
					StartDate: viewModel.training.startDate,
					EndDate: viewModel.training.endDate,
					PredictedEndDate: null,
					Title: viewModel.training.title,
					Water: viewModel.training.water,
					Calories: viewModel.training.calories,
					Track: {
						Title: viewModel.training.track.Title,
						Length: viewModel.training.track.Length,
						Ascent: viewModel.training.track.Ascent,
						AscentLength: viewModel.training.track.AscentLength
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

module.exports = EditTrainingViewModel;