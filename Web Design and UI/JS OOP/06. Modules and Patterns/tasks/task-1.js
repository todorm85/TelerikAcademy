function solve() {
    var TITLE_PATTERN = /^(?!.*\s{2}|.*\s$|^\s).+$/;
    var STUDENT_NAME_PATTERN = /^[A-Z][a-z]* [A-Z][a-z]*$/;
    var STUDENTS_MIN_COUNT = 1;
    var HOMEWORKS_MIN_COUNT = 1;

    var Course = {
        init: function(title, presentations) {
            validateTitle(title);
            validatePresentations(presentations);

            this._title = title;
            this._presentations = presentations;
            this._students = [];
            return this;
        },
        addStudent: function(name) {
            var id;
            validateStudentName(name);

            id = this._students.length + 1;
            this._students.push({
                firstname: name.split(' ')[0],
                lastname: name.split(' ')[1],
                ID: id,
                homeworks: [],
                examResult: 0,
                totalScore: 0
            });
            return id;
        },
        getAllStudents: function() {
            var students;
            students = this._students.map(
                function(student) {
                    var studentInfo = {
                        firstname: student.firstname,
                        lastname: student.lastname,
                        id: student.ID
                    };
                    return studentInfo;
                });
            return students;
        },
        submitHomework: function(studentID, homeworkID) {
            var student,
                course = this;
            validateHomeworkID(course, homeworkID);
            validateStudentID(course, studentID);

            student = this._students[studentID - 1];
            student['homeworks'].push(homeworkID);
            return this;
        },
        pushExamResults: function(results) {
            var students,
                course = this;

            validateExamResults(course, results);

            students = this._students;
            results.forEach(
                function(result) {
                    var student = students[(result.StudentID - 1)];
                    student.examResult = result.score;
                });
            return this;
        },
        getTopStudents: function() {
            var topStudents,
                course = this;

            calculateTotalScore(course);
            topStudents = this._students.slice().sort(
                function(currentStudent, nextStudent) {
                    return currentStudent.totalScore < nextStudent.totalScore;
                }).slice(0, 9);
            return topStudents;
        }
    };

    function isNumber(num) {
        return !isNaN(parseFloat(num)) && Number.isFinite(num);
    }

    function isInteger(num) {
        return !isNaN(parseFloat(num)) && num === parseInt(num);
    }

    function isString(value) {
        return typeof value === 'string';
    }

    function validateStringPattern(value, pattern, errorMsg) {
        errorMsg = errorMsg || 'Error.';
        if (!isString(value)) {
            throw new Error(errorMsg + ' Must be string!');
        }
        if (!pattern.test(value)) {
            throw new Error(errorMsg + ' Invalid format!');
        }
    }

    function validateTitle(title) {
        validateStringPattern(title, TITLE_PATTERN, 'Invalid title!');
    }

    function validatePresentations(presentations) {
        if (!Array.isArray(presentations)) {
            throw new Error('Presentations must be array.')
        }

        if (presentations.length === 0) {
            throw new Error('No presentations provided. Empty array.')
        }

        presentations.forEach(function(title) {
            validateTitle(title);
        })
    }

    function validateStudentName(name) {
        validateStringPattern(name, STUDENT_NAME_PATTERN, 'Invalid student name.');
    }

    function isInRangeID(ID, rangeMin, rangeMax) {
        if (!(isInteger(ID) && isInteger(rangeMax) && isInteger(rangeMin))) {
            return false;
        }

        if (ID < rangeMin || rangeMax < ID) {
            return false;
        }

        return true;
    }

    function validateHomeworkID(course, homeworkID) {
        if (!isInRangeID(homeworkID, HOMEWORKS_MIN_COUNT, course._presentations.length)) {
            throw new Error('Invalid homework ID. No such presentation. Out of possible id range.');
        }
    }

    function validateStudentID(course, studentID) {
        if (!isInRangeID(studentID, STUDENTS_MIN_COUNT, course._students.length)) {
            throw new Error('Invalid student ID. No such stuent. Out of possible id range.');
        }
    }

    function validateExamResults(course, results) {
        var processedIDs;

        if (!Array.isArray(results)) {
            throw new Error('Results must be array.');
        }

        processedIDs = [];
        results.forEach(function(result) {
            var isFoundDuplicateID;
            validateStudentID(course, result.StudentID);
            if (!isNumber(result.score)) {
                throw new Error('Score must be number!');
            }

            isFoundDuplicateID = processedIDs.some(
                function(id) {
                    return id === result.StudentID;
                });
            if (isFoundDuplicateID) {
                throw new Error('One student cannot submit exam results twice!')
            }

            processedIDs.push(result.StudentID);
        });
    }

    function calculateTotalScore(course) {
        var students = course._students,
            presentationsCount = course._presentations.length;

        students.forEach(function(student) {
            var homeworksResult = student.homeworks.length / presentationsCount;
            student.totalScore = (student.examResult * .75) + (homeworksResult * .25);
        });
    }

    return Course;
}

module.exports = solve;