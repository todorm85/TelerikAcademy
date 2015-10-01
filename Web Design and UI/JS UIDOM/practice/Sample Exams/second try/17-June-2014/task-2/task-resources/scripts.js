/* globals $ */
$.fn.gallery = function (cols) {
    cols = cols || 4;
    this.addClass('gallery');
    var selected = $('.selected', this);
    selected.css('display', 'none');
    var galleryList = $('.gallery-list', this);
    var imgContainers = $('.image-container', galleryList);
    imgContainers.each(function(index) {
        var clicked = $(this);
        if (index%cols===0) {
            clicked.addClass('clearfix');
        }
    });
    var preventGalleryClickDiv = $('<div />').addClass('disabled-background').css('display', 'none');
    this.append(preventGalleryClickDiv);
    var currentImage = $('#current-image', selected);
    var prevImage = $('#previous-image', selected);
    var nextImage = $('#next-image', selected);
    var allImages = $('img', galleryList);
    var currentImgIndex;
    var prevImgIndex;
    var nextImgIndex;
    galleryList.on('click', 'img', function () {
        var clicked = $(this);
        selected.css('display', '');
        galleryList.addClass('blurred');
        preventGalleryClickDiv.css('display', '');

        currentImgIndex = (clicked.attr('data-info') | 0) - 1;
        nextImgIndex = currentImgIndex+1;
        if (nextImgIndex > allImages.length-1) {
            nextImgIndex = 0;
        }
        prevImgIndex = currentImgIndex-1;
        if (prevImgIndex < 0) {
            prevImgIndex = allImages.length - 1;
        }
        prevImage.attr('src', $(allImages[prevImgIndex]).attr('src'));
        currentImage.attr('src', $(allImages[currentImgIndex]).attr('src'));
        nextImage.attr('src', $(allImages[nextImgIndex]).attr('src'));

    });
    currentImage.on('click', function () {
        var clicked = $(this);
        selected.css('display', 'none');
        galleryList.removeClass('blurred');
        preventGalleryClickDiv.css('display', 'none');
    });
    nextImage.on('click', function () {
        currentImgIndex += 1;
        if (currentImgIndex > allImages.length-1) {
            currentImgIndex = 0;
        } else if (currentImgIndex<0){
            currentImgIndex = allImages.length - 1;
        }
        nextImgIndex = currentImgIndex + 1;
        if (nextImgIndex > allImages.length-1) {
            nextImgIndex = 0;
        }
        prevImgIndex = currentImgIndex-1;
        if (prevImgIndex < 0) {
            prevImgIndex = allImages.length - 1;
        }
        prevImage.attr('src', $(allImages[prevImgIndex]).attr('src'));
        currentImage.attr('src', $(allImages[currentImgIndex]).attr('src'));
        nextImage.attr('src', $(allImages[nextImgIndex]).attr('src'));
    });
    prevImage.on('click', function () {
        currentImgIndex -= 1;
        if (currentImgIndex > allImages.length-1) {
            currentImgIndex = 0;
        } else if (currentImgIndex<0){
            currentImgIndex = allImages.length - 1;
        }
        nextImgIndex = currentImgIndex + 1;
        if (nextImgIndex > allImages.length-1) {
            nextImgIndex = 0;
        }
        prevImgIndex = currentImgIndex-1;
        if (prevImgIndex < 0) {
            prevImgIndex = allImages.length - 1;
        }
        prevImage.attr('src', $(allImages[prevImgIndex]).attr('src'));
        currentImage.attr('src', $(allImages[currentImgIndex]).attr('src'));
        nextImage.attr('src', $(allImages[nextImgIndex]).attr('src'));
    });
};