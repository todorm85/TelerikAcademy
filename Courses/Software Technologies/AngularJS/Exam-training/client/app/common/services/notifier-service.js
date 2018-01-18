(function () {
    'use strict';

    function notifier (toastr) {
        
        return {
            success: function (msg) {
                toastr.success(msg);
            },
            error: function (msg) {
                toastr.error(msg);
            }
        }
    }

    angular
        .module('MyApp.services')
        .service('notifier', ['toastr', notifier]);
}());