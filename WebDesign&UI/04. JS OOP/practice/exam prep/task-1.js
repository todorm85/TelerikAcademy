function solve() {
    function generateID() {
        if (typeof this._lastID === 'undefined') {
            this._lastID = 0;
        }

        return this._lastID += 1;
    }

    function isString(value) {
        return typeof value === 'string';
    }

    function isNumber(num) {
        return !isNaN(parseFloat(num)) && Number.isFinite(num);
    }

    function validateString(str, minLength, maxLength) {
        if (!isString(str)) {
            return false;
        }

        if (str.length < minLength && maxLength < str.length) {
            return false;
        }

        return true;
    }

    function isPlaylist(playlist) {
        if (Playlist.isPrototypeOf(playlist)) {
            return true;
        } else {
            return false;
        }
    }

    var Player = function() {
        var MIN_NAME_LENGTH = 3;
        var MAX_NAME_LENGTH = 25;

        function containsPlaylistWithId(id) {
            var isValid = this._playlists.some(function(playlist) {
                return playlist.id === id;
            });
            return isValid;
        }

        function removePlaylistById(id) {
            this._playlists = this._playlists.filter(function(playlist) {
                return playlist.id !== id;
            });
        }

        function sortByNameThenId(currentPlaylist, nextPlaylist) {
            if (currentPlaylist.name === nextPlaylist.name) {
                return currentPlaylist.id - nextPlaylist.id;
            }

            if (currentPlaylist.name > nextPlaylist.name) {
                return -1;
            }

            return 0;
        }

        function validatePageAndSize(page, size) {
            var playlistsCount = this.getPlaylistsCount;

            if (!isNumber(page) || !isNumber(size)) {
                throw new Error('Page and size must be numbers');
            }

            if (page * size > playlistsCount ||
                page < 0 ||
                size <= 0) {

                throw new Error('Invalid page and size arguments in listPlaylists!');
            }
        }

        var Player = Object.defineProperties({}, {
            init: {
                value: function(name) {
                    this.name = name;
                    this._playlists = [];
                    return this;
                }
            },
            name: {
                get: function() {
                    return this._name;
                },
                set: function(name) {
                    if (!validateString(name, MIN_NAME_LENGTH, MAX_NAME_LENGTH)) {
                        throw new Error('Invalid Player name!');
                    }

                    this._name = name;
                }
            }
            addPlaylist: {
                value: function(value) {
                    if (!isPlaylist(value)) {
                        throw new Error('Invalid playlist to add in player! Must be of type Playlist');
                    }

                    this._playlists.push(value);
                    return this;
                }
            },
            getPlaylistById: {
                value: function(searchID) {
                    var foundPlaylist = null;
                    this._playlists.forEach(function(playlist) {
                        if (playlist.id === searchID) {
                            foundPlaylist = playlist;
                        }
                    });
                    return foundPlaylist;
                }
            },
            removePlaylist: {
                value: function(key) {
                    var id;
                    if (typeof key === 'number') {
                        id = key;
                    } else {
                        id = key.id;
                    }

                    if (!containsPlaylistWithId(id)) {
                        throw new Error('Invalid playlist ID to remove!');
                    }

                    removePlaylistById.call(this, id);

                    return this;
                }
            },
            listPlaylists: {
                value: function(page, size) {
                    var startIndex,
                        endIndex,
                        playlists;

                    validatePageAndSize.call(this, page, size);

                    this._playlists.sort(sortByNameThenId);
                    startIndex = page * size;
                    endIndex = (page + 1) * size - 1;
                    playlists = this._playlists.slice(startIndex, endIndex);
                    return playlists;
                }
            },
            getPlaylistsCount: {
                get: function() {
                    return this._playlists.length;
                }
            },
            contains: {
                value: function(playable, playlist) {
                    // TODO ?? compare playables how?
                }
            }
        });
        return Player;
    }();

    var Playlist = function() {
        var Playlist = Object.defineProperties({}, {
            init: {
                value: function(name) {
                    this.name = name;
                    this.id = generateID();
                }
            },
            addPlayable: {
                value: function() {

                }
            },
            getPlayableById: {
                value: function() {

                }
            },
            removePlayable: {
                value: function() {

                }
            },
            listPlaylables: {
                value: function() {

                }
            }
        });
        return Playlist;
    }();

    var Playable = function() {
        var MIN_TITLE_LENGTH = 3,
            MAX_TITLE_LENGTH = 25,
            MIN_TITLE_LENGTH = 3,
            MAX_TITLE_LENGTH = 25;
        var Playable = Object.defineProperties({}, {
            init: {
                value: function(title, author) {
                    this.id = generateID.call(this);
                    this.title = title;
                    this.author = author;
                }
            },
            title: {
                get: function() {
                    return this._title;
                },
                set: function(value) {
                    if (validateString(title, MIN_TITLE_LENGTH, MAX_TITLE_LENGTH)) {
                        throw new Error('Invlid title length to set for playable!');
                    }
                    this._title = title;
                }
            },
            author: {
                get: function() {
                    return this._author;
                },
                set: function(value) {
                    if (validateString(author, MIN_AUTHOR_LENGTH, MAX_AUTHOR_LENGTH)) {
                        throw new Error('Invlid title length to set for playable!');
                    }

                    this._title = title;
                }
            },
            play: {
                get: function() {
                    return this.id + '. ' + this.title + ' - ' + this.author;
                }
            }
        });
        return Playable;
    }();

    var Audio = function(parent) {
        function validateLength(length) {
            if (!isNumber(length)) {
                return false;
            }

            length = +length;
            if (length < 0) {
                return false;
            }

            return true;
        }

        var Audio = Object.create(parent);
        Object.defineProperties(Audio, {
            init: {
                value: function(title, author, length) {
                    parent.init.call(this, title, author);
                    this.length = length;
                }
            },
            length: {
                get: function() {
                    return this._length;
                },
                set: function(value) {
                    if (!validateLength(value)) {
                        throw 'Invalid length of audio!';
                    }

                    this._length = length;
                },
            }
            play: {
                value: function() {
                    var result = parent.play.call(this);
                    result += ' - ' + this.length;
                    return result;
                }
            }
        });
        return Audio;
    }(Playable);

    var Video = function(parent) {
        function validateImdbRating(imdbRating) {
            if (!isNumber(imdbRating)) {
                throw 'imdbRating must be number!';
            }

            if (imdbRating < 1 || 5 < imdbRating) {
                throw 'imdbRating must be between 1 and 5!';
            }
        }
        var Video = Object.create(parent);
        Object.defineProperties(Video, {
            init: {
                value: function(title, author, imdbRating) {
                    parent.init.call(this, title, author);
                    this.imdbRating = imdbRating;
                }
            },
            imdbRating: {
                get: function() {
                    return this._imdbRating;
                },
                set: function(value) {
                    validateImdbRating.call(this, imdbRating);
                    this._imdbRating = imdbRating;
                }
            },
            play: {
                value: function() {
                    var result = parent.play.call(this);
                    result += ' - ' + this.imdbRating;
                    return result;
                }
            }
        });
        return Video;
    }(Playable);

    var module = {
        getPlayer: function(name) {
            // returns a new player instance with the provided name
            return Object.create(Player).init(name);
        },
        getPlaylist: function(name) {
            //returns a new playlist instance with the provided name
            return Object.create(Playlist).init(name);
        },
        getAudio: function(title, author, length) {
            //returns a new audio instance with the provided title, author and length
            return Object.create(Audio).init(title, author, length);
        },
        getVideo: function(title, author, imdbRating) {
            //returns a new video instance with the provided title, author and imdbRating
            return Object.create(Video).init(title, author, imdbRating);
        }
    };

    return module;
}();

