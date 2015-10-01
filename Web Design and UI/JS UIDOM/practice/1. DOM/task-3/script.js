var input = document.getElementsByTagName('input')[0];
input.addEventListener('input', changeColor);

function changeColor() {    
    document.body.style.backgroundColor = input.value;
}