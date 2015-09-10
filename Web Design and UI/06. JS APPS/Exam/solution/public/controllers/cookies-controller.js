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

function all(context) {
    var cookies;
    var category = context.params.category;
    var sortBy = context.params.sortBy || currentSortProp;

    data.cookies.get()
        .then(function (response) {
            cookies = response.result;

            if (category) {
                cookies = cookies.filter(function (cookie) {
                    return cookie.category === category;
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
            context.$element().html(template(cookies));

            $('.like').on('click', function () {
                var clickedCookie = this;
                data.cookies.like(this.id)
                    .then(function () {
                        var selector = ('p#'+clickedCookie.id) + ' span.likes';
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
                        var selector = ('p#'+clickedCookie.id) + ' span.dislikes';
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
