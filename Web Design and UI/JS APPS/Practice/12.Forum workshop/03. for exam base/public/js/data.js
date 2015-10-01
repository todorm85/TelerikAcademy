import 'jquery';
import CryptoJS from 'sha1';

const AUTH_KEY_LOCAL_KEY = 'authkey-key',
    AUTH_USER_LOCAL_KEY = 'username-key';

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
                localStorage.setItem(AUTH_KEY_LOCAL_KEY, response.authKey);
                localStorage.setItem(AUTH_USER_LOCAL_KEY, response.username);
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
                localStorage.setItem(AUTH_KEY_LOCAL_KEY, response.authKey);
                localStorage.setItem(AUTH_USER_LOCAL_KEY, response.username);
                resolve(response);
            }
        });
    });
}

function userLogout() {
    return new Promise(function (resolve, reject) {
        localStorage.removeItem(AUTH_KEY_LOCAL_KEY);
        localStorage.removeItem(AUTH_USER_LOCAL_KEY);
        resolve();
    });
}

function getAllUsers() {
    return new Promise(function (resolve, reject) {
        $.getJSON('api/users', function (response) {
            resolve(response.result);
        });
    });
}

function getCurrentUser() {
    var username = localStorage.getItem(AUTH_USER_LOCAL_KEY);
    if (!username) {
        return null;
    } else {
        return {
            username
        }
    }
}

function getThreads() {
    return new Promise(function (resolve, reject) {
        $.getJSON('api/threads', function (response) {
            resolve(response.result);
        });
    });
}

function addThread(thread) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: 'api/threads',
            type: 'POST',
            data: JSON.stringify(thread),
            contentType: 'application/json',
            headers: {
                'x-authkey': localStorage.getItem(AUTH_KEY_LOCAL_KEY)
            },
            success: function (response) {
                resolve(response);
            }
        });
    });
}

function getThreadById(id) {
    return new Promise(function (resolve, reject) {
        $.getJSON('api/threads/' + id, function (response) {
            resolve(response.result);
        });
    });
}

function addMessage(message, threadId) {
    var url = 'api/threads/' + threadId + '/messages';
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: url,
            type: 'POST',
            data: JSON.stringify(message),
            contentType: 'application/json',
            headers: {
                'x-authkey': localStorage.getItem(AUTH_KEY_LOCAL_KEY)
            },
            success: function (response) {
                resolve(response);
            }
        });
    });
}

export default {
    users: {
        login: userLogin,
        register: userRegister,
        logout: userLogout,
        getCurrent: getCurrentUser,
        get: getAllUsers
    },
    threads: {
        get: getThreads,
        add: addThread,
        getById: getThreadById,
        addMessage: addMessage
    }
};
