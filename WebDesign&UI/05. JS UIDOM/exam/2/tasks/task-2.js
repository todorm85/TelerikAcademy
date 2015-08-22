function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        // you are welcome :)
        var date = new Date();
        // console.log(date.getDayName());
        // console.log(date.getMonthName());
        var selectedDate = new Date();



        var wrapper = $('<div />').addClass('datepicker-wrapper');
        this.parent().append(wrapper);
        wrapper.append(this);
        var input = this;
        input.addClass('datepicker');

        var picker = $('<div />').addClass('picker');

        var controls = $('<div />').addClass('controls');
        picker.append(controls);

        var calendar = $('<table />').addClass('calendar');
        picker.append(calendar);

        var currentDate = $('<div />').addClass('current-date');
        picker.append(currentDate);

        var prevButton = $('<button />').addClass('btn').addClass('prevBtn').html('<');
        var nextButton = $('<button />').addClass('btn').addClass('nextBtn').html('>');
        var currentMonth = $('<div />').addClass('current-month');
        currentMonth.html(date.getMonthName() + ' ' + date.getFullYear());
        controls.append(prevButton).append(currentMonth).append(nextButton);

        function setCurrentMonth() {
            currentMonth.html(selectedDate.getMonthName() + ' ' + selectedDate.getFullYear());
            controls.append(prevButton).append(currentMonth).append(nextButton);            
        }

        var currentDateLink = $('<a />').addClass('current-date-link');
        currentDateLink.html(date.getDate() + ' ' + date.getMonthName() + ' ' + date.getFullYear());
        currentDate.append(currentDateLink);

        // TABLE
        var th = $('<th />');
        var thead = $('<thead />');
        var tr = $('<tr />');
        thead.append(tr);
        calendar.append(tr);
        for (var i = 0, len = 7; i < len; i+=1) {
            tr.append(th.clone().html(WEEK_DAY_NAMES[i]));
        }

        function populateMonth() {

        }

        controls.on('click', '.btn', function () {
            if ($(this).hasClass('prevBtn')) {
                var selectedMonth = selectedDate.getMonth();
                selectedDate.setMonth(selectedMonth - 1);
                setCurrentMonth();
            }

            if ($(this).hasClass('nextBtn')) {
                var selectedMonth = selectedDate.getMonth();
                selectedDate.setMonth(selectedMonth + 1);
                setCurrentMonth();
            }
        }); 

        wrapper.on('click', '.datepicker', function () {
            picker.addClass('picker-visible');
        });

        currentDate.on('click', 'a', function () {
            input.val(date.getDate() + '/' + date.getMonth() + '/' + date.getFullYear());
            picker.removeClass('picker-visible');
        });

        wrapper.append(picker);
        return wrapper;
    };
}

module.exports = solve;