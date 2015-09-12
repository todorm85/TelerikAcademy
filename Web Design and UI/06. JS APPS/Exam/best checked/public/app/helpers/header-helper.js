import data from '../data/data.js';

export default {
    load: function() {
        if (data.user.isLoggedIn()) {
            $('#header-logged-out').addClass('hidden');
            $('#header-logged-in').removeClass('hidden');
            $('.logged-in-only').removeClass('hidden');
            $('#header-username').html(data.user.getUsername());
        } else {
            $('#header-logged-out').removeClass('hidden');
            $('#header-logged-in').addClass('hidden');
            $('.logged-in-only').addClass('hidden');
            $('#header-username').html('');
        }
    }
}