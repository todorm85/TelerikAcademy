import writer from 'app/consoleWriter.js';

function write() {
    console.log('Private message from db.');
}

function add() {
    writer.write('add');
    write();
}

function get() {
    writer.write('get');
    write();
}

window.student = {
    name: 'Todor'
};

console.log('db loaded!');

export {
    add, get
};
export default {
    add, get
};