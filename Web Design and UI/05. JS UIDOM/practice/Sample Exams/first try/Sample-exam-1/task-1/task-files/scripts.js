function createCalendar(selector, events) {
    var calendarContainer = document.querySelector(selector);

    var dayBox = document.createElement("div");
    dayBox.className = 'day-box';
    dayBox.style.width = '100px';
    dayBox.style.height = '100px';
    dayBox.style.border = '1px solid black';
    dayBox.style.float = 'left';

    var dayBoxTitle = document.createElement("div");
    dayBoxTitle.className = 'day-box-title';
    dayBoxTitle.style.borderBottom = '1px solid black';
    dayBoxTitle.style.backgroundColor = 'lightgrey';
    dayBoxTitle.style.fontSize = '12px';

    var dayBoxContent = document.createElement("div");
    dayBoxContent.className = 'day-box-content';
    dayBoxContent.style.fontSize = '12px';

    var weekdays = {
        0: 'Mon',
        1: 'Tue',
        2: 'Wed',
        3: 'Thi',
        4: 'Fri',
        5: 'Sat',
        6: 'Sun',
    };

    for (var i = 0; i < 30; i += 1) {
        var dayIndex = i + 1;
        var currentDayBox = dayBox.cloneNode(true);
        var currentDayBoxTitle = dayBoxTitle.cloneNode(true);
        var currentDayBoxContent = dayBoxContent.cloneNode(true);
        var currentDate = new Date(2014, 6, i);
        var weekday = currentDate.getDay();

        if (dayIndex % 7 === 1) {
            currentDayBox.style.clear = 'left';
        }

        currentDayBoxTitle.innerHTML = weekdays[weekday] + ' ' + dayIndex + ' June 2014';

        events.forEach(function(event) {
            if ((event.date | 0) === dayIndex) {
                currentDayBoxContent.innerHTML = event.hour + ' ' + event.date + ' ' + event.title;
            }
        });

        currentDayBox.appendChild(currentDayBoxTitle);
        currentDayBox.appendChild(currentDayBoxContent);
        calendarContainer.appendChild(currentDayBox);
    }

    calendarContainer.addEventListener('mouseover', function(e) {
        var clickedItem = e.target;
        if (clickedItem.className.indexOf('day-box-title') >= 0) {
            clickedItem.style.backgroundColor = 'darkgrey';
        }
    }, false);

    calendarContainer.addEventListener('mouseout', function(e) {
        var clickedItem = e.target;
        if (clickedItem.className.indexOf('day-box-title') >= 0) {
            clickedItem.style.backgroundColor = 'lightgrey';
        }
    }, false);

    calendarContainer.addEventListener('click', function(e) {
        var clickedItem = e.target;

        function resetPreviousSelectedItem() {
            var previousSelectedItem = calendarContainer.getElementsByClassName("selected");
            if (previousSelectedItem.length > 0) {
                previousSelectedItem[0].style.backgroundColor = '';
                previousSelectedItem[0].className = 'day-box';
            }
        }

        resetPreviousSelectedItem();

        if (clickedItem.className.indexOf('day-box') >= 0) {
            clickedItem.style.backgroundColor = 'lightgrey';
            clickedItem.className += ' selected';
        }
    }, false);
}