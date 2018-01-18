import toastr from 'toastr';
import templates from 'db/templates.js';
import data from 'db/data.js';

var currentUsernameFilter = '';
var currentPatternFilter = '';
var currentSortProp = '';

function show(context) {
    var posts;
    var usernameFilter = context.params.user || '';
    var patternFilter = context.params.pattern || '';
    var sortBy = context.params.sortBy;

    data.posts.get(usernameFilter, patternFilter)
        .then(function (res) {
            posts = res;
            return templates.get('posts');
        })
        .then(function (template) {
            if (sortBy) {
                posts.sort(function (a, b) {
                    return a[sortBy] > b[sortBy];
                });
            }

            context.$element().html(template(posts));
            $('#tb-filter-username').val(currentUsernameFilter);
            $('#tb-filter-pattern').val(currentPatternFilter);
            $(`#sort-selector option[value="${currentSortProp}"]`).attr('selected', '');

            $('#btn-refresh').on('click', function () {
                var user = $('#tb-filter-username').val();
                currentUsernameFilter = user;
                var pattern = $('#tb-filter-pattern').val();
                currentPatternFilter = pattern;
                var sortBy = $('#sort-selector option:selected').val();
                currentSortProp = sortBy;

                context.redirect(`#/posts?user=${user}&pattern=${pattern}&sortBy=${sortBy}`);
            });
        });
}

function add(context) {
    var currentUser = data.users.getCurrent();

    templates.get('posts-add')
        .then(function (template) {
            context.$element().html(template());

            $('#btn-add-post').on('click', function () {
                if (!data.users.getCurrent()) {
                    toastr.error('You must be logged in.');
                    return;
                }

                var post = {
                    title: $('#tb-post-title').val(),
                    body: $('#tb-post-text').val(),
                };

                data.posts.add(post)
                    .then(function (response) {
                        console.log(response);
                        context.redirect('#/posts');
                    }, function (err) {
                        toastr.error(JSON.parse(err.responseText).message);
                    });
            });
        });

}

export default {
    show,
    add
};
