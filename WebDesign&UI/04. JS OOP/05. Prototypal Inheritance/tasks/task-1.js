function solve() {
    var domElement = (function() {
        var ATTRIBUTE_NAME_PATTERN = /^[A-Za-z\d-]+$/;
        var TYPE_NAME_PATTERN = /^[A-Za-z\d]+$/;

        var domElement = {};

        Object.defineProperties(domElement, {
            init: {
                value: function(type) {
                    this.type = type;
                    this._attributes = [];
                    this._children = [];
                    this._content = '';
                    return this;
                }
            },
            innerHTML: {
                get: function() {
                    return parseDomElementToString.call(this);
                }
            },
            type: {
                set: function(typeName) {
                    validateString(typeName, TYPE_NAME_PATTERN, 'Invalid type format!');
                    this._type = typeName;
                    return this;
                }
            },
            content: {
                set: function(value) {
                    validateContent(value);
                    this._content = (hasChildren.call(this)) ? '' : value;
                    return this;
                }
            },
            parent: {
                get: function() {
                    return this._parent;
                },
                set: function(parent) {
                    validateParent(parent);
                    this._parent = parent;
                    return this;
                }
            },
            appendChild: {
                value: function(child) {
                    validateChild(child);
                    this._children.push(child);
                    this._content = '';

                    if (typeof child === 'object' && child.parent !== this) {
                        child.parent = this;
                    }

                    return this;
                }
            },
            addAttribute: {
                value: function(name, value) {
                    validateString(name, ATTRIBUTE_NAME_PATTERN, 'Invalid attribute name to add');

                    if (!checkAttributeExistance.call(this, name)) {
                        this._attributes.push({
                            name: name,
                            value: value
                        });
                    } else {
                        overwriteExistingAttributeValue.call(this, name, value);
                    }

                    return this;
                }
            },
            removeAttribute: {
                value: function(name) {
                    validateString(name, ATTRIBUTE_NAME_PATTERN, 'Invalid attribute name to remove');
                    if (!checkAttributeExistance.call(this, name)) {
                        throw new Error('No such attribute to remove!');
                    }

                    this._attributes = removeArrayElementByProperty(this._attributes, name);
                    return this;
                }
            }
        });

        // Validations

        function isNumber(num) {
            return !isNaN(parseFloat(num)) && Number.isFinite(num);
        }

        function isString(value) {
            return typeof value === 'string';
        }

        function validateContent(content) {
            if (!isString(content)) {
                throw new Error('Content must be string!');
            }
        }

        function hasChildren() {
            if (this._children.length !== 0) {
                return true;
            }

            return false;
        }

        function validateChild(child) {
            if (!isString(child) && !domElement.isPrototypeOf(child)) {
                throw new Error('Child must be string or domElement');
            }
        }

        function validateString(value, pattern, errorMessage) {
            pattern = pattern || /.*/g;
            if (!isString(value)) {
                throw new Error(errorMessage + 'Must be string.');
            }

            if (!pattern.test(value)) {
                throw new Error(errorMessage + 'Pattern mismatch for: ' + value);
            }
        }

        function checkAttributeExistance(name) {
            var isFound = this._attributes.some(
                function(existingAttribute) {
                    return existingAttribute.name === name;
                });
            return isFound;
        }

        function overwriteExistingAttributeValue(name, value) {
            this._attributes.map(
                function(attribute) {
                    if (attribute.name === name) {
                        attribute.value = value;
                    }
                });
        }

        function validateParent(parent) {
            if (!domElement.isPrototypeOf(parent)) {
                throw new Error('Parent must be dom element!');
            }
        }

        // Functionalities

        function removeArrayElementByProperty(array, propertyName) {
            array = array.filter(
                function(existingAttribute) {
                    return existingAttribute.name !== propertyName;
                });
            return array;
        }

        function parseAttributesToString() {
            var attributesAsString = '',
                name,
                value;

            this._attributes.sort(
                function(currentAttribute, nextAttribute) {
                    return currentAttribute.name > nextAttribute.name;
                });

            for (index in this._attributes) {
                name = this._attributes[index].name;
                value = this._attributes[index].value;

                attributesAsString += ' ' + name + '="' + value + '"';
            }

            return attributesAsString;
        }

        function parseChildrenToString() {
            var childrenAsString = '',
                index,
                child;

            if (hasChildren.call(this)) {
                for (index in this._children) {
                    child = this._children[index];

                    if (!isString(child)) {
                        childrenAsString += child.innerHTML;
                    } else {
                        childrenAsString += child;
                    }
                }
            } else {
                childrenAsString += this._content;
            }

            return childrenAsString;
        }

        function parseDomElementToString() {
            var domElementAsString,
                attributesAsString,
                childrenAsString;

            attributesAsString = parseAttributesToString.call(this);
            childrenAsString = parseChildrenToString.call(this);
            domElementAsString = '<' + this._type + attributesAsString + '>' +
                childrenAsString + '</' + this._type + '>';

            return domElementAsString;
        }

        return domElement;
    }());
    return domElement;
}

module.exports = solve;