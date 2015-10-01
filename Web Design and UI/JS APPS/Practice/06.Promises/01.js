console.log('Entered');
var xhr = new XMLHttpRequest();
xhr.open('GET', 'index.html', true);
// xhr.setRequestHeader('content-type', 'application/json');


xhr.onreadystatechange = function () {
    if (xhr.readyState === 4) {
        console.log(xhr.responseText);
    }
}

xhr.send(null);

console.log('After send!');