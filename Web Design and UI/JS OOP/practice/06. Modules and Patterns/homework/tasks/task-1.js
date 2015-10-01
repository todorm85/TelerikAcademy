// function solve() {
var Course = function() {
    var validator = {
        validateTitle: function(title, errMsg) {
            var titlePattern = /^(?!.+\s\s|\s|.+\s$).+$/;
            errMsg = errMsg || '';
            if (!(titlePattern.test(title))) {
                throw 'String does not match the pattern. ' + errMsg;
            }
        },
    }
    var Course = Object.defineProperties({}, {
        init: {
            value: function(title) {
                this.title = title;
                this._presentations = presentations;
                this._students = [];
                this._homeworks = [];
            }
        },
        title: {
            get: function() {
                return this._title;
            },
            set: function(title) {
                validator.validateTitle(title, 'at set Course.title');
                this._title = title;
            },
        },
        addStudent: {
            value: function(fullname) {

            }
        },
        getAllStudents: {
            value: function() {

            }
        },
        submitHomework: {
            value: function(studentID, homeworkID) {

            }
        },
        pushExamResults: {
            value: function(results) {

            }
        },
        getTopStudents: {
            value: function() {

            }
        }
    });
    return Course;
}();
// return Course; }