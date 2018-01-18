import request from '../helpers/requests-helper.js';
import 'sha1';

const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username';
const LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

/* ## User ## */

function userLogin(user) {
    var requestUser = {
        username: user.username,
        passHash: CryptoJS.SHA1(user.username + user.password).toString()
    };

    var options = {
        data: requestUser
    };

    return request.put('api/auth', options)
        .then(function(response) {
            sessionStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, response.result.username);
            sessionStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, response.result.authKey);
            return response;
        });
}

function userRegister(user) {
    var requestUser = {
        username: user.username,
        passHash: CryptoJS.SHA1(user.username + user.password).toString()
    };

    var options = {
        data: requestUser
    };

    return request.post('api/users', options);
}

function userLogout() {
    return new Promise(function (resolve) {
        sessionStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
        sessionStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
        resolve('Success');
    });
}

function userIsLoggedIn() {
    return !!sessionStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) && !!sessionStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
}

function userGetUsername() {
    return sessionStorage.getItem(LOCAL_STORAGE_USERNAME_KEY);
}

function userGetAuthKey() {
    return sessionStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
}

function userGetAll() {
    var options = {
        headers: {
            "x-auth-key": userGetAuthKey()
        }
    };

    return request.get('api/users', options)
        .then(function(response) {
            return response.result;
        });
}

/* ## End User ## */

/* ## Cookies ## */

function cookiesGet() {
    return request.get('api/cookies').then(function(cookies) {
        return cookies.result;
    })
}

function cookiesSet(cookie) {
    var options = {
        data: cookie,
        headers: {
            "x-auth-key": userGetAuthKey()
        }
    };

    return request.post('api/cookies', options);
}

function cookiesUpdate(cookie, id) {
    var options = {
        data: cookie,
        headers: {
            "x-auth-key": userGetAuthKey()
        }
    };

    return request.put('api/cookies/' + id, options)
}

function cookiesGetCategories() {
    return request.get('api/categories').then(function(response) {
        return response.result;
    })
}

function getHourlyCookie() {
    var options = {
        headers: {
            "x-auth-key": userGetAuthKey()
        }
    };

    return request.get('api/my-cookie', options).then(function(cookie) {
        return cookie.result;
    })
}

export default {
    user: {
        login: userLogin,
        register: userRegister,
        logout: userLogout,
        getAll: userGetAll,
        isLoggedIn: userIsLoggedIn,
        getUsername: userGetUsername,
        getAuthKey: userGetAuthKey
    },
    cookies: {
        get: cookiesGet,
        set: cookiesSet,
        update: cookiesUpdate,
        getCategories: cookiesGetCategories,
        getMyCookie: getHourlyCookie
    }
}