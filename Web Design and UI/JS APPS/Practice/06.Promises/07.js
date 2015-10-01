var promiseCount = 0;

var getPromise = function(input) {
    return new Promise(
        function(resolve, reject) {
            console.log(input + ' started');
            setTimeout(
                function() {
                    console.log(input + ' finished');
                    resolve(input);
                },
                Math.random() * 2000 + 1000
            );
        }
    );
}

function onResolve(input) {
    console.log(input + ' resolved');
    return getPromise(input + 1);
}

function printFinalInputValue(input) {
    console.log('Final input value is: ' + input);
}

getPromise(1)
    .then(onResolve)
    .then(printFinalInputValue);


getPromise(100)
    .then(onResolve)
    .then(printFinalInputValue);


getPromise(10)
    .then(onResolve)
    .then(printFinalInputValue);