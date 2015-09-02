/*var async = (function() {
    var iterator,
        run = function(generator) {
            iterator = generator();
            async.resume();
        },
        resume = function() {
            iterator.next();
        };

    return {
        run: run,
        resume: resume
    }
}());*/

console.log('Some other code executing BEFORE asynchronous functions were called.');

function asynchronousFunction(delay, name) {
    setTimeout(function() {
        console.log(name + ' asynchronous function finished after ' + delay + 'ms');
        // async.resume();  // this is called on success
        iterator.next();    // this is called on success
    }, delay);
}

function* main() {
    yield asynchronousFunction(2000, 'FIRST');
    console.log('Function after FIRST started and finsihed');
    yield asynchronousFunction(1000, 'SECOND');
    console.log('Function after SECOND started and finished');
}

// async.run(main);

var iterator = main();
iterator.next();    // start first asynchronousFunction, it will call the next on success

console.log('Some other code executing AFTER asynchronous functions were called.');