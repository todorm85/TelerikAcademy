var data = (function () {

    const AUTH_KEY = 'authkey-key',
        AUTH_USER = 'username-key';

    function userLogin(user) {
        return new Promise(function (resolve, reject) {
            var requestUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            };

            $.ajax({
                url: 'api/auth',
                type: 'PUT',
                data: JSON.stringify(requestUser),
                contentType: 'application/json',
                success: function (response) {
                    localStorage.setItem(AUTH_KEY, response.authKey);
                    localStorage.setItem(AUTH_USER, response.username);
                    resolve(response);
                }
            });
        });
    }

    function userRegister(user) {
        return new Promise(function (resolve, reject) {
            var requestUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            };

            $.ajax({
                url: 'api/users',
                type: 'POST',
                data: JSON.stringify(requestUser),
                contentType: 'application/json',
                success: function (response) {
                    localStorage.setItem(AUTH_KEY, response.authKey);
                    localStorage.setItem(AUTH_USER, response.username);
                    resolve(response);
                }
            });
        });
    }

    function userLogout() {
        return new Promise(function (resolve, reject) {
            localStorage.removeItem(AUTH_KEY);
            localStorage.removeItem(AUTH_USER);
            resolve();
        });
    }

    function userFind() {}

    function getCurrentUser() {
        var username = localStorage.getItem(AUTH_USER);
        if (!username) {
            return null;
        } else {
            return {
                username
            }
        }
    }

    return {
        users: {
            login: userLogin,
            register: userRegister,
            logout: userLogout,
            find: userFind,
            getCurrent: getCurrentUser
        }
    };
})();
