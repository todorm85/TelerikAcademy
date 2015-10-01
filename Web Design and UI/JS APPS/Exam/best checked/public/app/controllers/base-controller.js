import toastr from 'toastr';
import data from '../data/data.js';

function likeCookie() {
    var $this = $(this);

    var id = $this.parent().attr('data-cookie-id');
    var likes = $this.parent().parent().find('.cookie-likes');

    var cookie = {
        type: "like"
    };

    data.cookies.update(cookie, id).then(function() {
        toastr.success('Cookie liked!');

        var likesCount = likes.html();
        likes.html((+likesCount + 1));
    }, function(error) {
        toastr.error("You must log in first!", 'Unauthorized!')
    });
}

function dislikeCookie() {
    var $this = $(this);

    var id = $this.parent().attr('data-cookie-id');
    var dislikes = $this.parent().parent().find('.cookie-dislikes');

    var cookie = {
        type: "dislike"
    };

    data.cookies.update(cookie, id).then(function() {
        toastr.warning('Cookie disliked! :(');

        var dislikesCount = dislikes.html();
        dislikes.html((+dislikesCount + 1));
    }, function(error) {
        toastr.error("You must log in first!", 'Unauthorized!')
    });
}

function shareCookie() {
    var $this = $(this);

    var text = $this.parent().parent().find('.cookie-title').text();
    var category = $this.parent().parent().find('.cookie-category').text();
    var img = $this.parent().parent().parent().find('img').attr('src');

    var cookie = {
        text: text,
        category: category,
        img: img
    };

    data.cookies.set(cookie).then(function() {
        toastr.info('Cookie re-shared! :)', 'Tumblr style!');
    })
}

export default {
    likeCookie: likeCookie,
    dislikeCookie: dislikeCookie,
    shareCookie: shareCookie
}