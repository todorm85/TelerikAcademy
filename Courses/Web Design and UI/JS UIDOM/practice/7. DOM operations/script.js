var div = document.getElementsByTagName('div')[0];
// div.innerHTML = 'changed';
div.style.background = '#17d';
var ul = document.getElementsByTagName('ul')[0];
var ulChildren = ul.childNodes;
for (var el in ulChildren) {
    console.log(ulChildren[el]);
}
var newLiEl = document.createElement('li');
// var text = document.createElement('text');
newLiEl.innerHTML = 'Dynamically created.';
// ul.appendChild(newLiEl);
ul.insertBefore(newLiEl, ul.firstChild);
// ul.insertBefore(text, newLiEl.nextSibling);


console.log('-----------------------------');
var list = document.getElementById('list');
var parenList = list.parentNode;
console.log(parenList.nodeName);
console.log(parenList.id);
var children = list.childNodes;
console.log(children.length);
newUlEl = document.createElement('ul');

for (var i = 0, len = children.length, indexer = 1; i < len; i++) {
    if (children[i].nodeName !== '#text') {
        children[i].innerHTML += ' Traversed Item ' + (indexer);
        indexer++;
    } else {
        // for (var item in children[i]) {
        //    // console.log(item);
        // }
        newLiEl = document.createElement('li');
        newLiEl.innerHTML = children[i].nodeValue;
        newUlEl.appendChild(newLiEl);
    }
}

div.appendChild(newUlEl);
// document.body.removeChild(div);
var firstLi = ul.firstChild;
ul.appendChild(firstLi);

document.body.innerHTML = '';
var div3 = document.createElement('div');
div3.id = 'div3';
document.body.appendChild(div3);
var ul3 = document.createElement('ul');
ul3.id = 'div3';
document.body.appendChild(ul3);
var selectedEl = document.querySelectorAll('#div3');
div3.innerHTML = 'dynamic';
console.log(selectedEl[0].innerHTML);
