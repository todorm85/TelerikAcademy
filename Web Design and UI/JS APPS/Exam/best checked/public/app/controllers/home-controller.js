import baseController from './base-controller.js';
import templates from '../helpers/templates-helper.js';
import underscore from 'underscore';
import moment from 'moment';
import toastr from 'toastr';
import data from '../data/data.js';

function loadCookies(template, cookies, sammy) {
    var currentCategory = sammy.params['category'] || 'All';
    var currentOrder = sammy.params['order'] || 'likes';
    var cookiesContainer = $('#cookies-container');
    cookiesContainer.html(template(cookies));

    var categorySelect = $('#cookies-category');
    var sortSelect = $('#cookies-sort');

    data.cookies.getCategories().then(function(categories) {
        _.each(categories, function(category) {
            var option = $('<option/>')
                .text(category)
                .val(category);
            $('#cookies-category').append(option);
        });

        categorySelect.val(currentCategory);
        sortSelect.val(currentOrder);
    });

    categorySelect.on('click', function() {
        var optionSelected = $(this).find(':selected');
        var category = optionSelected.attr('value');

        sammy.redirect('#/home?category=' + category + '&order=' + currentOrder);
    });

    sortSelect.on('click', function() {
        var optionSelected = $(this).find(':selected');
        var order = optionSelected.attr('value');

        sammy.redirect('#/home?category=' + currentCategory + '&order=' + order);
    });

    cookiesContainer.on('click', '#cookie-like', baseController.likeCookie);
    cookiesContainer.on('click', '#cookie-dislike', baseController.dislikeCookie);
    cookiesContainer.on('click', '#cookie-reshare', baseController.shareCookie);
}

export default {
    index: function(sammy) {
        var category = sammy.params.category || '';
        var order = sammy.params.order || 'likes';

        var homeTemplate = templates.load('home');
        var cookiesTemplate = templates.load('home-cookies');
        var cookiesData = data.cookies.get();

        Promise.all([homeTemplate, cookiesTemplate, cookiesData]).then(function(results) {
            var homeTemplate = results[0];
            var cookiesTemplate = results[1];
            var cookies = results[2];

            sammy.$element().html(homeTemplate());

            if (category.length > 0 && category !== 'All') {
                cookies = _.filter(cookies, function(cookie){
                    return cookie.category === category;
                })
            }

            if (order === 'likes') {
                cookies = _.sortBy(cookies, function(cookie) {
                    return cookie.likes;
                }).reverse();
            } else {
                cookies = _.sortBy(cookies, function(cookie) {
                    return cookie.shareDate;
                }).reverse();
            }

            _.map(cookies, function(cookie) {
                cookie.shareDate = moment(cookie.shareDate).fromNow();
                return cookie;
            });

            // This is because I cannot access the users without being logged in :(
            data.user.getAll().then(function(users) {
                _.map(cookies, function(cookie) {
                    var user = _.filter(users, function(user) {
                        return user.id === cookie.userId
                    })[0];

                    cookie.userId = user.username;
                    return cookie;
                });

                loadCookies(cookiesTemplate, cookies, sammy);
            }, function() {
                _.map(cookies, function (cookie) {
                    cookie.userId = "Login to see the author";
                    return cookie;
                });

                loadCookies(cookiesTemplate, cookies, sammy);
            });
        })
    }
}