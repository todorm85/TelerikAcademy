function Solve() {
    var validator = {
        validateNonEmptyString: function(value, callerID) {
            callerID = callerID || '';
            if (!(typeof value === 'string' && value.length > 0)) {
                throw 'Argument must be nonemptu string at ' + callerID;
            }
        },
        validateIfConvertibleToNumber: function(num, callerID) {
            if (isNaN(+num) || num === null || num === '') {
                throw 'Argument must be convertible to number at ' + callerID;
            }
        },
        validateIfNumber: function(num, callerID) {
            callerID = callerID || '';
            if (!(typeof num === 'number')) {
                throw 'Argument must be a number at ' + callerID;
            }
        },
        validateIfString: function(value, callerID) {
            callerID = callerID || '';
            if (!(typeof value === 'string')) {
                throw 'Argument must be a string at ' + callerID;
            }
        },
        validateIfObject: function(value, callerID) {
            callerID = callerID || '';
            if (!(typeof value === 'object')) {
                throw 'Argument must be an object at ' + callerID;
            }
        },
        validateIfUndefined: function(value, callerID) {
            callerID = callerID || '';
            if (typeof value === 'undefined') {
                throw 'Argument must not be undefined at ' + callerID;
            }
        },
        validateIfMatchRegex: function(value, pattern, errMsg) {
            errMsg = errMsg || '';
            if (!(pattern.test(value))) {
                throw 'String does not match the pattern. ' + errMsg;
            }
        },
        validateIfMatchLength: function(arg, minLength, maxLength, callerID) {
            callerID = callerID || '';
            if (arg.length < minLength || maxLength < arg.length) {
                throw 'Argument length must be between ' + minLength + ' and ' + maxLength + ' at ' + callerID;
            }
        },
        validateISBN: function(isbn) {
            if (isbn === undefined || !(isbn.length === 10 || isbn.length === 13)) {
                throw 'Invalid book isbn';
            }

            // check if only digits
            if (isbn.replace(/\d*/, '') !== '') {
                throw 'Invalid isbn';
            }
        },
        validateNumberInRange: function(num, min, max, callerID) {
            callerID = callerID || '';
            if (num < min || max < num) {
                throw 'Number must be between ' + min + ' and ' + max + ' at ' + callerID;
            }
        }
    };

    var common = {
        indexOfElementByPropertyName: function(array, propName) {
            var foundIndex = -1;
            array.forEach(function(element, index) {
                if (element[propName] !== undefined) {
                    foundIndex = index;
                }
            });
            return foundIndex;
        },
        indexOfElementByPropertyValue: function(array, propName, propValue) {
            var i, len, answer = -1;
            for (i = 0, len = array.length; i < len; i++) {
                if (array[i][propName] === propValue) {
                    answer = i;
                    break;
                }
            }

            return answer;
        },
        processArguments: function(args) {
            var items;
            if (args.length === 0) {
                throw 'No items added';
            }
            if (Array.isArray(args[0])) {
                items = args[0];
            } else {
                // possible problem here!
                items = Array.prototype.slice.call(args);
            }
            return items;
        },
        getSortingFunction: function(firstParameter, secondParameter) {
            return function(first, second) {
                if (first[firstParameter] > second[firstParameter]) {
                    return -1;
                } else if (first[firstParameter] < second[firstParameter]) {
                    return 1;
                }

                if (first[secondParameter] < second[secondParameter]) {
                    return -1;
                } else if (first[secondParameter] > second[secondParameter]) {
                    return 1;
                } else {
                    return 0;
                }
            }
        }
    }

    var Item = function() {
        var _lastId = 0;
        var Item = Object.defineProperties({}, {
            init: {
                value: function(name, description) {
                    this.description = description;
                    this.name = name;
                    this._id = ++_lastId;
                    return this;
                }
            },
            id: {
                get: function() {
                    return this._id;
                }
            },
            description: {
                get: function() {
                    return this._description;
                },
                set: function(description) {
                    validator.validateNonEmptyString(description, 'Item.description.set');
                    this._description = description;
                }
            },
            name: {
                get: function() {
                    return this._name;
                },
                set: function(name) {
                    validator.validateIfString(name, 'item.name');
                    validator.validateIfMatchLength(name, 2, 40, 'items.name')
                    this._name = name;
                }
            }
        });
        return Item;
    }();

    var Book = function(parent) {
        var Book = Object.create(parent);
        Object.defineProperties(Book, {
            init: {
                value: function(name, description, isbn, genre) {
                    parent.init.call(this, name, description)
                    this.isbn = isbn;
                    this.genre = genre;
                    return this;
                }
            },
            isbn: {
                get: function() {
                    return this._isbn;
                },
                set: function(isbn) {
                    validator.validateNonEmptyString(isbn, 'book.isbn.set');
                    validator.validateISBN(isbn);
                    this._isbn = isbn;
                },
            },
            genre: {
                get: function() {
                    return this._genre;
                },
                set: function(genre) {
                    validator.validateIfString(genre, 'book.genre.set');
                    validator.validateIfMatchLength(genre, 2, 20, 'book.genre.set');
                    this._genre = genre;
                }
            }
        });
        return Book;
    }(Item);

    var Media = function(parent) {
        var Media = Object.create(parent);
        Object.defineProperties(Media, {
            init: {
                value: function(name, description, duration, rating) {
                    parent.init.call(this, name, description);
                    this.duration = duration;
                    this.rating = rating;
                    return this;
                }
            },
            duration: {
                get: function() {
                    return this._duration;
                },
                set: function(duration) {
                    // possible problem
                    validator.validateIfNumber(duration, 'Media.duration');
                    if (duration <= 0) {
                        throw 'Number must be bigger than 0';
                    }

                    this._duration = duration;
                },
            },
            rating: {
                get: function() {
                    return this._rating;
                },
                set: function(rating) {
                    validator.validateIfNumber(rating, 'Media.rating');
                    validator.validateNumberInRange(rating, 1, 5, 'Media.rating')

                    this._rating = rating;
                }
            }
        });
        return Media;
    }(Item);

    var Catalog = function() {
        var _lastCatalogId = 0;
        var Catalog = Object.defineProperties({}, {
            init: {
                value: function(name, items) {
                    this.name = name;
                    this._items = [];
                    this._id = ++_lastCatalogId;
                    return this;
                }
            },
            name: {
                get: function() {
                    return this._name;
                },
                set: function(name) {
                    validator.validateIfString(name, 'Catalog.name');
                    validator.validateIfMatchLength(name, 2, 40, 'Catalog.name');
                    this._name = name;
                }
            },
            items: {
                get: function() {
                    return this._items;
                },
                set: function(items) { // maybe unneccessary
                    this._items = items;
                }
            },
            id: {
                get: function() {
                    return this._id;
                }
            },
            add: {
                value: function() {
                    var args = arguments;
                    var items = common.processArguments(args);

                    items.forEach(function(currentItem) {
                        if (!Item.isPrototypeOf(currentItem)) {
                            throw 'Items must be of type Item';
                        }
                    });

                    items.forEach(function(currentItem) {
                        this._items.push(currentItem);
                    }, this);
                }
            },
            find: {
                value: function(argument) {
                    var id,
                        options,
                        result,
                        foundIndex,
                        foundItems = [];
                    if (typeof argument === 'number') {
                        id = argument;
                        // console.log(this._items);
                        foundIndex = common.indexOfElementByPropertyValue(this._items, 'id', id);
                        // console.log(foundIndex);
                        if (foundIndex >= 0) {
                            return this._items[foundIndex];
                        } else {
                            return null;
                        }
                    } else if (typeof argument === 'object') {
                        options = argument;
                        foundItems = this._items;
                        var searchId = options.id;
                        var searchName = options.name;
                        if (argument.id) {
                            foundItems = foundItems.filter(function(item) {
                                return item.id === argument.id;
                            });
                        }
                        if (argument.name) {
                            foundItems = foundItems.filter(function(item) {
                                return item.name === argument.name;
                            });
                        }
                        return foundItems;
                    } else {
                        throw 'Invalid argument at Catalog.find';
                    }
                }
            },
            search: {
                value: function(pattern) {
                    validator.validateNonEmptyString(pattern);

                    var result = [];
                    var searchPattern = pattern.toLowerCase();
                    result = this._items.filter(function(item) {
                        var itemName = item.name.toLowerCase();
                        var itemDescription = item.description.toLowerCase();

                        if (itemName.indexOf(searchPattern) >= 0 ||
                            itemDescription.indexOf(searchPattern) >= 0) {
                            return true;
                        } else {
                            return false;
                        }
                    });
                    return result;
                }
            },
        });
        return Catalog;
    }();

    var BookCatalog = function(parent) {
        var BookCatalog = Object.create(parent);
        Object.defineProperties(BookCatalog, {
            init: {
                value: function(name) {
                    parent.init.call(this, name);
                    return this;
                }
            },
            add: {
                value: function() {
                    var args = arguments;
                    var items = common.processArguments(args);

                    items.forEach(function(currentItem) {
                        if (!Book.isPrototypeOf(currentItem)) {
                            throw 'Items must be of type Book';
                        }
                    });

                    parent.add.call(this, items);
                }
            },
            getGenres: {
                value: function() {
                    var results = [];
                    this._items.forEach(function(item) {
                        var isDuplicate = results.some(function(result) {
                            return result === item.genre.toLowerCase();
                        });

                        if (!isDuplicate) {
                            results.push(item.genre.toLowerCase());
                        }
                    });
                    return results;
                }
            },
            find: {
                value: function(argument) {
                    var results = parent.find.call(this, argument);
                    if (Array.isArray(results) && argument.genre) {
                        results = results.filter(function(item) {
                            return item.genre === argument.genre;
                        });
                    }
                    return results;
                }
            }
        });
        return BookCatalog;
    }(Catalog);

    var MediaCatalog = function(parent) {
        var MediaCatalog = Object.create(parent);
        Object.defineProperties(MediaCatalog, {
            init: {
                value: function(name) {
                    parent.init.call(this, name);
                    return this;
                }
            },
            add: {
                value: function() {
                    var args = arguments;
                    var items = common.processArguments(args);

                    items.forEach(function(currentItem) {
                        if (!Media.isPrototypeOf(currentItem)) {
                            throw 'Items must be of type Book';
                        }
                    });

                    parent.add.call(this, items);
                }
            },
            getTop: {
                value: function(count) {
                    var results = [];
                    this._items.sort(function(item1, item2) {
                        return item2.rating - item1.rating;
                    });

                    results = this._items.map(function(item) {
                        return {
                            id: item.id,
                            name: item.name
                        };
                    }).slice(0, count);
                    return results
                }
            },
            getSortedByDuration: {
                value: function() {
                    var results = this._items.sort(common.getSortingFunction('duration', 'id'));
                    return results;
                }
            }
        });
        return MediaCatalog;
    }(Catalog);

    return {
        getBook: function(name, isbn, genre, description) {
            //return a book instance
            return Object.create(Book).init(name, description, isbn, genre);
        },
        getMedia: function(name, rating, duration, description) {
            //return a media instance
            return Object.create(Media).init(name, description, duration, rating);
        },
        getBookCatalog: function(name) {
            //return a book catalog instance
            return Object.create(BookCatalog).init(name);
        },
        getMediaCatalog: function(name) {
            //return a media catalog instance
            return Object.create(MediaCatalog).init(name);
        }
    };
}