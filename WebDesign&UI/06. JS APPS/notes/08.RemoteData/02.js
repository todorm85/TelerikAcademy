console.log('entered');

var xhr = new XMLHttpRequest();
xhr.open('GET', 'data.json', true);

xhr.onreadystatechange = function() {
    // console.log(xhr.readyState);
    if (xhr.readyState === 4) {
        console.log('Request received.');
        switch (xhr.status / 100 | 0) {
            case 2:
                console.log('Success!');
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