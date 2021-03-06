import 'underscore';
import templates from 'db/templates.js';
import data from 'db/data.js';

function all(context) {
    var notifications;
    data.notifications.get()
        .then(function (resNotifications) {
            notifications = resNotifications;

            return templates.get('notifications');
        })
        .then(function (template) {
            context.$element().html(template(notifications));

            $('.btn-confirm').on('click', function () {
                var senderId = $(this).parents('.notification-box').attr('data-sender-id');
                data.friends.confirm(senderId)
                    .then(function (msg) {
                        toastr.success(msg.message);
                    });
            });
        })
        .catch(function (err) {
            console.log(err);
        });
}

export default {
    all
};
