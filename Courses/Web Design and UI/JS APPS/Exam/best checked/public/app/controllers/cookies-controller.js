import baseController from './base-controller.js';
import templates from '../helpers/templates-helper.js';
import validate from '../helpers/validations-helper.js';
import moment from 'moment';
import toastr from 'toastr';
import data from '../data/data.js';
import 'jqueryui';

function validateInput(text, category, img) {
    var invalidText = !validate.string(text);
    var invalidCategory = !validate.string(category);
    var invalidImg = !validate.url(img);

    toastr.clear();

    if (invalidText) {
        toastr.error('Title must be between 6 and 30 characters long', 'Invalid form data!');
    }

    if (invalidCategory) {
        toastr.error('Category must be between 6 and 30 characters long', 'Invalid form data!');
    }

    if (invalidImg) {
        toastr.error('Image URL must be valid or empty', 'Invalid form data!');
    }

    return !(invalidText || invalidCategory || invalidImg);
}

export default {
    myCookie: function(sammy) {
        if (!data.user.isLoggedIn()) {
            toastr.error('You must be logged in to view this page!', 'Unauthorized!');
            sammy.redirect('#/home');
        } else {
            var template = templates.load('my-cookie');
            var cookie = data.cookies.getMyCookie();
            var users = data.user.getAll();

            Promise.all([template, cookie, users]).then(function(result) {
                var template = result[0];
                var cookie = result[1];
                var users = result[2];

                var user = _.filter(users, function(user) {
                    return user.id === cookie.userId
                })[0];

                cookie.userId = user.username;
                cookie.shareDate = moment(cookie.shareDate).fromNow();

                sammy.$element().html(template(cookie));

                $('#cookie-like').on('click', baseController.likeCookie);
                $('#cookie-dislike').on('click', baseController.dislikeCookie);
                $('#cookie-reshare').on('click',  baseController.shareCookie);
            })
        }
    },

    share: function(sammy) {
        var template = templates.load('share');
        var categories = data.cookies.getCategories();

        Promise.all([template, categories]).then(function(result) {
            var template = result[0];
            var categories = result[1];

            sammy.$element().html(template());

            $('#cookie-category').autocomplete({
                source: categories
            });

            $('#share-cookie').on('click', function() {
                var text = $('#cookie-title').val();
                var category = $('#cookie-category').val();
                var img = $('#cookie-img').val();

                if (validateInput(text, category, img)) {
                    var cookie = {
                        text: text,
                        category: category,
                        img: img
                    };

                    data.cookies.set(cookie).then(function() {
                        toastr.clear();
                        toastr.success('Cookie published!', '');
                        sammy.redirect('#/home');
                    });
                }
            })
        })
    }
}