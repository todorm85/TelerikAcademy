function solve() {
    return function() {
        /* globals $ */
        $.fn.gallery = function(cols) {
            this.addClass('gallery');
            var cols = cols || 4;
            var imageContainers = this.find('.image-container');
            imageContainers.each(function(index) {
                if (!(index % cols)) {
                    $(this).addClass('clearfix');
                }
            });
            var selectedContainer = this.children('.selected');
            selectedContainer.css('display', 'none');

            var galleryList = this.children('.gallery-list');
            var allImages = $('img', galleryList);
            var prevImage = $('.previous-image img', selectedContainer);
            var currentImage = $('.current-image img', selectedContainer);
            var nextImage = $('.next-image img', selectedContainer);
            var disableBackgroundDiv = $('<div />');
            this.append(disableBackgroundDiv);
            var currentImageIndex;
            var prevImageIndex;
            var nextImageIndex;

            galleryList.on('click', 'img', function() {
                var clickedImage = $(this);
                selectedContainer.css('display', '');

                currentImageIndex = clickedImage.attr('data-info') | 0;
                currentImageIndex -= 1;

                prevImageIndex = currentImageIndex - 1;
                if (prevImageIndex < 0) {
                    prevImageIndex = allImages.length - 1;
                }

                nextImageIndex = currentImageIndex + 1;
                if (nextImageIndex >= allImages.length) {
                    nextImageIndex = 0;
                }

                currentImage.attr('src', clickedImage.attr('src'));
                prevImage.attr('src', $(allImages[prevImageIndex]).attr('src'));
                nextImage.attr('src', $(allImages[nextImageIndex]).attr('src'));

                galleryList.addClass('blurred');
                disableBackgroundDiv.addClass('disabled-background');
            });

            currentImage.on('click', function() {
                selectedContainer.css('display', 'none');
                galleryList.removeClass('blurred');
                disableBackgroundDiv.removeClass('disabled-background');
            });

            nextImage.on('click', function() {
                currentImageIndex += 1;
                nextImageIndex += 1;
                prevImageIndex += 1;

                if (nextImageIndex >= allImages.length) {
                    nextImageIndex = 0;
                } else if (currentImageIndex >= allImages.length) {
                    currentImageIndex = 0;
                } else if (prevImageIndex >= allImages.length) {
                    prevImageIndex = 0;
                }

                currentImage.attr('src', $(allImages[currentImageIndex]).attr('src'));
                prevImage.attr('src', $(allImages[prevImageIndex]).attr('src'));
                nextImage.attr('src', $(allImages[nextImageIndex]).attr('src'));
            });

            prevImage.on('click', function() {
                currentImageIndex -= 1;
                nextImageIndex -= 1;
                prevImageIndex -= 1;

                if (prevImageIndex < 0) {
                    prevImageIndex = allImages.length - 1;
                } else if (currentImageIndex < 0) {
                    currentImageIndex = allImages.length - 1;
                } else if (nextImageIndex < 0) {
                    nextImageIndex = allImages.length - 1;
                }

                currentImage.attr('src', $(allImages[currentImageIndex]).attr('src'));
                prevImage.attr('src', $(allImages[prevImageIndex]).attr('src'));
                nextImage.attr('src', $(allImages[nextImageIndex]).attr('src'));
            });
        };
    };
}

module.exports = solve;