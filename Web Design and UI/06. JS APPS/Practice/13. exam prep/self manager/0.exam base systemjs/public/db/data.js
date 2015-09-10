import jsonRequester from 'db/json-requester.js';
import CryptoJS from 'sha1';

const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
    LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

/* Users */

function register(user) {
    var reqUser = {
        username: user.username,
        passHash: CryptoJS.SHA1(user.username + user.password).toString()
    };

    var options =  {
                data: reqUser
            };

    var url = 'api/users';

    return new Promise(function (resolve, reject) {
        jsonRequester.post(url, options)
            .then(function (resp) {
                var user = resp.result;
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
                resolve({
                    username: resp.result.username
                });
            }, function (errorMessage) {
                reject(errorMessage);
            });
    });
}

function signIn(user) {
    var reqUser = {
        username: user.username,
        passHash: CryptoJS.SHA1(user.username + user.password).toString()
    };

    var options = {
        data: reqUser
    };

    return new Promise(function (resolve, reject) {
        jsonRequester.put('api/users/auth', options)
        .then(function (resp) {
            var user = resp.result;
            localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
            localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);

            resolve(user);
        }, function (errorMessage) {
            console.log('error');
            reject(errorMessage);
        });
    });
}

function signOut() {
    var promise = new Promise(function (resolve, reject) {
        localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
        localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
        resolve();
    });
    return promise;
}

function hasUser() {
    return !!localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY) &&
        !!localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY);
}

function usersGet() {
    return jsonRequester.get('api/users')
        .then(function (res) {
            return res.result;
        });
}

export default {
    users: {
        signIn,
        signOut,
        register,
        hasUser,
        get: usersGet,
    },
    constants: {
        LOCAL_STORAGE_USERNAME_KEY
    }
};
