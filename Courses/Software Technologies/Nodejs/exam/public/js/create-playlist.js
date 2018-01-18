$(document).ready(function () {

    $('#add-input-url').on('click', function () {
        
    var videoUrls = $('#video-urls');
    var count = videoUrls.children('input[type="text"]').length;

    var inputTypeUrl = $('<input />');
    inputTypeUrl.attr('type', 'text');
    inputTypeUrl.attr('name', `video_${count}`);
    inputTypeUrl.attr('class', `form-control`);
    inputTypeUrl.attr('placeholder', `video`);

    videoUrls
        .prepend(inputTypeUrl);
    });
    
});