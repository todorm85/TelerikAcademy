import toastr from 'toastr';
import templates from 'db/templates.js';
import data from 'db/data.js';
import moment from 'moment';

function my(context) {
    var cookie;

    data.cookies.getMy()
        .then(function (response) {
            cookie = response.result;

            return templates.get('cookies-my')
        }, function (err) {
            toastr.error(JSON.parse(err.responseText));
        })
        .then(function (template) {
            context.$element().html(template(cookie));
        });
}

var currentSortProp = '';
var currentFilterCategory = '';

function all(context) {
    var cookies;
    var filterCategory = context.params.category || currentFilterCategory;
    var sortBy = context.params.sortBy || currentSortProp;
    var categories;

    data.cookies.getCategories()
        .then(function (response) {
            categories = response.result;
            console.log(categories);
            return data.cookies.get()
        })
        .then(function (response) {
            cookies = response.result;

            if (filterCategory) {
                cookies = cookies.filter(function (cookie) {
                    return cookie.category === filterCategory;
                });
            }

            if (sortBy) {
                cookies.sort(function (a, b) {
                    return a[sortBy] < b[sortBy];
                });
            }

            cookies.forEach(function (cookie) {
                cookie.shareDate = moment(cookie.shareDate).fromNow();
            });

            return templates.get('cookies-all')
        })
        .then(function (template) {
            var templateData = {
                categories: categories,
                cookies: cookies,
            };

            context.$element().html(template(templateData));

            $('.like').on('click', function () {
                var clickedCookie = this;

                data.cookies.like(this.id)
                    .then(function () {
                        var selector = ('p#' + clickedCookie.id) + ' span.likes';
                        var likesConatiner = $(selector);
                        var likes = +likesConatiner.html();
                        likes++;
                        likesConatiner.html(likes);
                    }, function (error) {
                        toastr.error(JSON.parse(error.responseText) + ' Probably not logged in');
                    });
            });

            $('.dislike').on('click', function () {
                var clickedCookie = this;
                data.cookies.dislike(this.id)
                    .then(function () {
                        var selector = ('p#' + clickedCookie.id) + ' span.dislikes';
                        var dislikesConatiner = $(selector);
                        var dislikes = +dislikesConatiner.html();
                        dislikes++;
                        dislikesConatiner.html(dislikes);
                    }, function (error) {
                        toastr.error(JSON.parse(error.responseText) + ' Probably not logged in');
                    });
            });

            $(`#sort-selector option[value="${currentSortProp}"]`).attr('selected', '');
            $('#btn-sort').on('click', function () {
                var sortBy = $('#sort-selector option:selected').val();
                currentSortProp = sortBy;
                context.redirect(`#/home?sortBy=${sortBy}`);
            });

            $(`#category-selector option[value="${currentFilterCategory}"]`).attr('selected', '');
            $('#btn-filter-category').on('click', function () {
                var filterByCategory = $('#category-selector option:selected').val();
                currentFilterCategory = filterByCategory;
                context.redirect(`#/home?category=${filterByCategory}`);
            });

            $('.reshare').on('click', function () {
                var clickedCookie = $('div.cookie-container#' + this.id);

                var clickedCategory = clickedCookie.find('.cookie-category').html();
                var clickedImgUrl = clickedCookie.children('.cookie-img-url').attr('src');
                var clickedText = clickedCookie.children('.cookie-text').html();

                context.redirect(`#/cookies/share?category=${clickedCategory}&img=${clickedImgUrl}&cookieText=${clickedText}`);
            });
        });
}

function share(context) {
    if (!data.users.getCurrent()) {
        toastr.error('You must login!');
        return;
    }

    templates.get('cookies-share').
    then(function (template) {
        context.$element().html(template());

        var category = context.params.category;
        var imgUrl = context.params.img;
        var text = context.params.cookieText;

        $('#tb-cookie-category').val(category);
        $('#tb-cookie-text').html(text);
        $('#tb-cookie-img').val(imgUrl);

        $('#btn-add-cookie').on('click', function () {
            var cookie = {
                category: $('#tb-cookie-category').val(),
                text: $('#tb-cookie-text').val(),
                img: $('#tb-cookie-img').val(),
            };

            data.cookies.share(cookie)
                .then(function (response) {
                    context.redirect('#/home');
                }, function (err) {
                    toastr.error(JSON.parse(err.responseText));
                });
        });
    });
}

export default {
    my,
    all,
    share,
};
