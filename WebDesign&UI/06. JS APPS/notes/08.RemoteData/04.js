console.log('entered');

var xhr = new XMLHttpRequest();
xhr.open('GET', 'partial/part1.html', true);

xhr.onreadystatechange = function() {
    // console.log(xhr.readyState);
    if (xhr.readyState === 4) {
        console.log('Request received.');
        switch (xhr.status / 100 | 0) {
            case 2:
                console.log('Success!');
                document.getElementById("loaded")
                    .innerHTML = xhr.responseText;
                break;
            case 4:
            case 5:
                console.log('Error!');
                break;
            default:
        }
    }
};

xhr.send(null);
