/* Task Description */
/* 
 * Create a module for a Telerik Academy course
 * The course has a title and presentations
 * Each presentation also has a title
 * There is a homework for each presentation
 * There is a set of students listed for the course
 * Each student has firstname, lastname and an ID
 * IDs must be unique integer numbers which are at least 1
 * Each student can submit a homework for each presentation in the course
 * Create method init
 * Accepts a string - course title
 * Accepts an array of strings - presentation titles
 * Throws if there is an invalid title
 * Titles do not start or end with spaces
 * Titles do not have consecutive spaces
 * Titles have at least one character
 * Throws if there are no presentations
 * Create method addStudent which lists a student for the course
 * Accepts a string in the format 'Firstname Lastname'
 * Throws if any of the names are not valid
 * Names start with an upper case letter
 * All other symbols in the name (if any) are lowercase letters
 * Generates a unique student ID and returns it
 * Create method getAllStudents that returns an array of students in the format:
 * {firstname: 'string', lastname: 'string', id: StudentID}
 * Create method submitHomework
 * Accepts studentID and homeworkID
 * homeworkID 1 is for the first presentation
 * homeworkID 2 is for the second one
 * ...
 * Throws if any of the IDs are invalid
 * Create method pushExamResults
 * Accepts an array of items in the format {StudentID: ..., Score: ...}
 * StudentIDs which are not listed get 0 points
 * Throw if there is an invalid StudentID
 * Throw if same StudentID is given more than once ( he tried to cheat (: )
 * Throw if Score is not a number
 * Create method getTopStudents which returns an array of the top 10 performing students
 * Array must be sorted from best to worst
 * If there are less than 10, return them all
 * The final score that is used to calculate the top performing students is done as follows:
 * 75% of the exam result
 * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
 */

function solve() {

    function isNumber(num) {
        return !isNaN(parseFloat(num)) && isFinite(num);
    }

    function isString(literal) {
        if (typeof literal === 'string') {
            return true;
        } else {
            return false;
        }
    }

    function validateStudentName(name) {
        if (!isString(name)) {
            throw 'Student name must be string!';
        }

        if (!/^[A-Z][a-z]* [A-Z][a-z]*$/.exec(name)) {
            throw 'Please enter exactly in the format "Firstname Lastname"';
        }

        return true;
    }

    function validateTitle(title) {
        if (!isString(title)) {
            throw 'Student name must be string!';
        }

        if (/^ | $/.exec(title)) {
            throw 'Titles must not start or end with spaces!'
        }

        if (/ {2,}/.exec(title)) {
            throw 'Titles must not have consecutive spaces!'
        }

        if (!/.+/.exec(title)) {
            throw 'Titles must have at least one character!'
        }

        return true;
    }

    function validatePresentationTitles(presentationTitles) {
        if (!presentationTitles || !Array.isArray(presentationTitles) || presentationTitles.length === 0) {
            throw 'Invalid presentationTitles array!';
        }

        presentationTitles.forEach(function(title) {
            if (!validateTitle(title)) {
                throw 'Invalid presentation title at init()!';
            }
        });

        return true;
    }

    function validateStudentID(studentID) {
        if (!isNumber(studentID)) {
            throw 'Student ID must be number at submitHomework';
        }

        if (studentID <= 0 || studentID > this._lastStudentCourseID) {
            throw 'No such studentID';
        }

        return true;
    }

    function validateHomeworkID(homeworkID, studentID) {
        if (!isNumber(homeworkID)) {
            throw 'Homework ID must be number!';
        }

        if (homeworkID < 1 || homeworkID > this._presentationTitles.length) {
            throw 'Invalid homework ID. No such presentation!';
        }

        if (this._homeworks[studentID].some(
                function(currentHomeworkID) {
                    return currentHomeworkID === homeworkID;
                })) {
            throw 'Cannot submit a homework twice!';
        }

        return true;
    }

    function validateResults(results) {
        if (!isArray(results)) {
            throw 'Results must be an array!';
        }

        results.forEach(function(resultEntry, index, results) {
            validateStudentID.call(this, resultEntry.StudentID);
            if (results.indexOf(resultEntry) !== index) {
                throw 'No duplicate entries allowed in exam results!';
            }
        });
    }

    function calculateStudentsScore(studentsWithScore) {
        studentsWithScore.map(function(student) {
            var examScore = 0,
                homeworkScore = 0;

            this._results.some(
                function(resultEntry, index, results) {
                    if (resultEntry.StudentID === student.id) {
                        examScore = results[index];
                        return true;
                    }

                    return false;
                });
            homeworkScore = this._homeworks[student.id].length / this._presentationTitles.length;
            student.score = (examScore * .75) + (homeworkScore * .25);
        }, this);
    }

    function deepCopy(oldObject) {
        return JSON.parse(JSON.stringify(oldObject));
    }

    function sortByProperty(arr, prop) {
        return arr.sort(function(memberA, memberB) {
            if (memberA[prop] > memberB[prop]) {
                return 1;
            }

            if (memberA[prop] < memberB[prop]) {
                return -1;
            }

            if (memberA[prop] === memberB[prop]) {
                return 0;
            }
        });
    }

    var Course = {
        init: function(title, presentationTitles) {
            validateTitle(title);
            validatePresentationTitles(presentationTitles);

            this._title = title;
            this._presentationTitles = presentationTitles;
            this._lastStudentCourseID = 0;
            this._homeworks = [null];
            this._students = [];
            return this;
        },
        addStudent: function(name) {
            validateStudentName(name);

            this._students.push({
                firstname: name.split(' ')[0],
                lastname: name.split(' ')[1],
                id: ++this._lastStudentCourseID
            });
            this._homeworks.push([]);
            return this._lastStudentCourseID;
        },
        getAllStudents: function() {
            return deepCopy(this._students);
        },
        submitHomework: function(studentID, homeworkID) {
            validateStudentID.call(this, studentID);
            validateHomeworkID.call(this, homeworkID, studentID);

            this._homeworks[studentID].push(homeworkID);
            return this;
        },
        pushExamResults: function(results) {
            validateResults(results);

            this._results = results;
        },
        getTopStudents: function() {
            var studentsWithScore = deepCopy(this._students);
            calculateStudentsScore(studentsWithScore);
            var topTen = studentsWithScore.sortByProperty(studentsWithScore, 'score').slice(0, 10);
            return topTen;
        }
    };

    return Course;
}

module.exports = solve;

var Course = solve();

var id,
    jsoop = Object.create(Course);

jsoop.init('testTitle', ['testTitle']);
id = jsoop.addStudent('Ivan' + ' ' + 'Georgiev');
jsoop.submitHomework(id, 1);
console.log(jsoop);