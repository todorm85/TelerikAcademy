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

    var options = {
        data: reqUser
    };

    var url = 'api/users';

    return new Promise(function (resolve, reject) {
        jsonRequester.post(url, options)
            .then(function (resp) {
                resolve();
            }, function (error) {
                reject(error);
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
        jsonRequester.put('api/auth', options)
            .then(function (resp) {
                console.log(resp);
                localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, resp.result.username);
                localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, resp.result.authKey);

                resolve(resp);
            }, function (error) {
                reject(error);
            });
    });
}

function signOut() {

    return new Promise(function (resolve, reject) {

        localStorage.removeItem(LOCAL_STORAGE_USERNAME_KEY);
        localStorage.removeItem(LOCAL_STORAGE_AUTHKEY_KEY);
        resolve();

    });
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

function getCurrentUser() {
    var username = localStorage.getItem(LOCAL_STORAGE_USERNAME_KEY);
    if (!username) {
        return null;
    } else {
        return {
            username
        }
    }
}

// POSTS

function getPosts(userFilter, patternFilter) {
    var url = 'post';
    url += `?user=${userFilter}&pattern=${patternFilter}`;

    return new Promise(function (resolve, reject) {
        $.get(url, resolve).error(reject);
    });
}

function addPost(post) {
    var options = {
        data: post,
        headers: {
            'X-SessionKey': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
        }
    };

    return new Promise(function (resolve, reject) {
        jsonRequester.post('post', options)
            .then(function (resp) {

                resolve(resp);
            }, function (error) {
                reject(error);
            });
    });
}

export default {
    users: {
        signIn,
        signOut,
        register,
        hasUser,
        get: usersGet,
            getCurrent: getCurrentUser
    },
    posts: {
        get: getPosts,
        add: addPost
    },
    constants: {
        LOCAL_STORAGE_USERNAME_KEY,
        LOCAL_STORAGE_AUTHKEY_KEY
    }
};
