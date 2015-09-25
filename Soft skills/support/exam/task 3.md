Dear Sir/Madam,

I am really sorry to hear about your inconviniences with jQuery and specifically, as I understand it, having trouble with attaching function handlers to events.

I reviewed the code sample that you provided and am happy to write that I found the solution to your problem. The function attachEventListener that was used in the sample is nonexistent in jQuery. The recommended function  that attaches handlers to events in jQuery is .on('event', callback). You can find more info about it [--HERE--](http://api.jquery.com/on/)

I have provided the slightly modified version of your sample here. All you need to do is replace attachEventListener() with on() and everything will work as expected:
``` JavaScript
<script>
        function hideAllContent() {
            $('#home-page-content').hide();
            $('#courses-page-content').hide();
            $('#about-page-content').hide();
            $('#contact-page-content').hide();
        }

        $('#home-page').on('click', function () {
            hideAllContent();
            $('#home-page-content').show();
        });

        $('#courses-page').on('click', function () {
            hideAllContent();
            $('#courses-page-content').show();
        });

        $('#about-page').on('click', function () {
            hideAllContent();
            $('#about-page-content').show();
        });

        $('#contact-page').on('click', function () {
            hideAllContent();
            $('#contact-page-content').show();
        });
    </script>
```
I hope this reply was useful to you. Please, don`t hesitate to contact us for further questions.