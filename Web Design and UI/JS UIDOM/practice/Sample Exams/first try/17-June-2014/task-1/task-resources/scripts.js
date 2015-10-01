function createImagesPreviewer(selector, items) {
    var root = document.querySelector(selector);
    root.style['width'] = '700px';
    root.style['height'] = '400px';
    // root.style.overflow = 'hidden';

    var leftPane = document.createElement("div");
    leftPane.style.display = 'inline-block';
    leftPane.style.width = '60%';
    leftPane.style.height = '100%';
    leftPane.className += ' image-preview';
    // leftPane.innerHTML = '&nbsp';

    var selectedImage = document.createElement("img");
    selectedImage.src = items[0].url;
    selectedImage.title = items[0].title;
    selectedImage.style.width = '100%';

    var selectedImageTitle = document.createElement("h1");
    selectedImageTitle.innerHTML = items[0].title;
    selectedImageTitle.style['text-align'] = 'center';

    leftPane.appendChild(selectedImageTitle);
    leftPane.appendChild(selectedImage);

    var rightPane = document.createElement("div");
    rightPane.style.display = 'inline-block';
    rightPane.style['text-align'] = 'center';
    rightPane.style['width'] = '40%';
    rightPane.style['height'] = '100%';
    rightPane.style['overflow-y'] = 'scroll';

    var filterContainer = document.createElement("p");
    rightPane.appendChild(filterContainer);
    filterContainer.innerHTML = 'Filter';

    var inputBox = document.createElement("input");
    rightPane.appendChild(inputBox);

    var imgList = document.createElement("ul");
    rightPane.appendChild(imgList);
    imgList.style['list-style-type'] = 'none';

    var imageContainers = [];
    var i, len;
    for (i = 0, len = items.length; i < len; i += 1) {
      var imgContainer = document.createElement("li");
      imgContainer.className += 'image-container';
      imgContainer['data-title'] = items[i].title;
      var img = document.createElement("img");
      img.style.width = '100%';
      img.title = items[i].title;
      img.src = items[i].url;
      var imgTitle = document.createElement("p");
      imgTitle.innerHTML = items[i].title;

      imgContainer.appendChild(imgTitle);
      imgContainer.appendChild(img);
      imageContainers.push(imgContainer);
      imgList.appendChild(imgContainer);
    }

    // var clearingDiv = document.createElement("div");
    // clearingDiv.style.clear = 'both';

    imgList.addEventListener('click', function(ev) {
      var clickedImg = ev.target;
      if (clickedImg.nodeName !== 'IMG') {
        return;
      }

      selectedImage.src = clickedImg.src;
      selectedImageTitle.innerHTML = clickedImg.title;
    }, false);

    imgList.addEventListener('mouseover', function(ev) {
      var clickedItem = ev.target;

      if (clickedItem.nodeName !== 'IMG') {
        return;
      }

      clickedItem.parentNode.style['background-color'] = 'grey';
    }, false);

    imgList.addEventListener('mouseout', function(ev) {
      var clickedItem = ev.target;
      if (clickedItem.nodeName !== 'IMG') {
        return;
      }

      clickedItem.parentNode.style['background-color'] = '';
    }, false);

    inputBox.addEventListener('input', function(ev) {
      var filterKey = inputBox.value.toLowerCase();
      // console.log('entered');
      for (var i = 0, len = imageContainers.length; i < len; i += 1) {
        if (imageContainers[i]['data-title'].toLowerCase().indexOf(filterKey) < 0) {
          imageContainers[i].style.display = 'none';
        } else {
          imageContainers[i].style.display = '';
        }
      }

    }, false);

    root.appendChild(leftPane);
    root.appendChild(rightPane);
  }