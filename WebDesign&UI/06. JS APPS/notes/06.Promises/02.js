function async(success) {
    setTimeout(function() {
        success("CALLBACK at " + new Date());
    }, 1000);
}

function success(result) {
    console.log(result);
    async();
}

async(success);

async(function(result) {l
    console.log(result);

    async(function(result) {
        console.log(result);

        async(function(result) {
            console.log(result);
        });
    });
});

// function asyncPromised() {
    var promise = new Promise(
        function(resolve, reject, pending) {
            setTimeout(
                function() {
                    resolve("PROMISE at " + new Date());
                },
                1000
            );
        }
    );

//     return promise;
// }
function success(result) {
        console.log(result);
        return promise;
    }// asyncPromised()
promise
    .then(success)
    .then(function(result) {
        console.log(result);
        return asyncPromised();
    })
    .then(function(result) {
        console.log(result);
        return asyncPromised();
    })
    .then(function(result) {
        console.log(result);
        // return asyncPromised();
    });