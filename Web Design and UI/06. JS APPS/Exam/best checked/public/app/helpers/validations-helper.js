export default {
    string: function(string) {
        var result = /^.{6,30}$/.test(string);
        return result;
    },

    username: function(username) {
        var result = /^[a-z0-9_.]{6,30}$/.test(username);
        return result;
    },
    url: function(url) {
        if (url.length === 0) {
            return true;
        }

        var result = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/.test(url);
        return result;
    }
}