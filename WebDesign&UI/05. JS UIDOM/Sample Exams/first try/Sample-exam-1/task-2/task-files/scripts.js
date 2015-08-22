$.fn.tabs = function () {
    var tabsContainer = this;
    tabsContainer.addClass('tabs-container');
    var tabItems = $('.tab-item');
    $(tabItems[0]).addClass('current');
    var tabItemsContent = $('.tab-item-content');
    tabItemsContent.css('display', 'none');
    $(tabItemsContent[0]).css('display', '');

    tabsContainer.on('click', '.tab-item-title', function () {
        var clickedTitle = $(this);
        var previousClickedTabItem = $('.current', tabsContainer);
        var previousClickedTabContent = $('.tab-item-content', previousClickedTabItem);
        previousClickedTabItem.removeClass('current');
        previousClickedTabContent.css('display', 'none');
        var clickedTab = clickedTitle.parent();
        clickedTab.addClass('current');
        var clickedTabContent = $('.tab-item-content', clickedTab);
        clickedTabContent.css('display', '');
    });
};