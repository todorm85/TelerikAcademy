var validator = require("email-validator");
var config = require("../../shared/config");
var fetchModule = require("fetch");
var Observable = require("data/observable")
    .Observable;

function UserViewModel(info) {
    info = info || {};

    var viewModel = new Observable({
        email: info.email || "",
        password: info.password || "",
        isLoading: false
    });

    viewModel.register = function() {
        var email = viewModel.get("email");
        var password = viewModel.get("password");
        return fetchModule.fetch(config.apiUrl + "api/account/register/", {
                method: "POST",
                body: JSON.stringify({
                    Email: email,
                    Password: password,
                    ConfirmPassword: password
                }),
                headers: {
                    "Content-Type": "application/json"
                }
            })
            .then(handleErrors, function (err) {
                console.log(JSON.stringify(err));
            });
    };

    viewModel.login = function() {
        var requestUrl = config.apiUrl + "token";
        var username = viewModel.get("email");
        var password = viewModel.get("password");
        return fetchModule.fetch(requestUrl, {
                method: "POST",
                body: `grant_type=password&username=${username}&password=${password}`,
                headers: {
                    "Content-Type": "x-www-form-url-encoded"
                }
            })
            .then(handleErrors, function (err) {
                console.log('error: ' + JSON.stringify(err));
            })
            .then(function(response) {
                return response.json();
            })
            .then(function(data) {
                config.token = data.access_token;
            });
    };

    viewModel.isValidEmail = function() {
        var email = this.get("email");
        return validator.validate(email);
    };

    return viewModel;
}

function handleErrors(response) {
    if (!response.ok) {
        throw Error(response.statusText);
    }

    return response;
}

module.exports = UserViewModel;
