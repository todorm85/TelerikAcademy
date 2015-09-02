// http://www.sitepoint.com/understanding-es6-modules/


console.log('loaded!');

// this is without default export

// import {add, get} from 'app/db.js';
// add();
// get();

// this is usage with default export

import db from 'app/db.js';
db.add();
db.get();

// import 'app/db.js';
// console.log(student.name);