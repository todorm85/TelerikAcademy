Dear Sir/Madam,

I am very sorry to hear that you have certain difficulties using our jQuery library. As I understand you have difficulties with the selection of DOM elements.

The short and general answer to your question is that you can use the following syntax structure after jQuery has been loaded to select all the dom elements that fulfill the selector condition:
``` JavaScript
$("selector");
```
This function accepts a string containing a CSS selector which is then used to match a set of elements.
More about this function can be found at the following [--LINK--](http://api.jquery.com/jQuery/)
 You can find all the possible selectors that can be used at the following [--LINK--](https://api.jquery.com/category/selectors/)

To answer your specific question I will provide the following example that I hope would be useful to you. 
**Firstly**, we`ll start by making html document with the following **body** structure:
```
<body>
    <div id="main-content">
        <div id="home-page-content">
            Home content
        </div>
        <div id="courses-page-content">
            Courses content
        </div>
        <div id="about-page-content">
            About content
        </div>
        <div id="contact-page-content">
            Contact content
        </div>
    </div>
</body>
```
If we open the document we can see that the content of all four divs is displayed.
**Secondly**, we`ll load the jQuery library and create the function that will hide all the divs.
```
<body>
    <div id="main-content">
        <div id="home-page-content">
            Home content
        </div>
        <div id="courses-page-content">
            Courses content
        </div>
        <div id="about-page-content">
            About content
        </div>
        <div id="contact-page-content">
            Contact content
        </div>
    </div>

    <script src="jquery.min.js"></script>
    <script>
        function hideAllContent() {
            $('#home-page-content').hide();
            $('#courses-page-content').hide();
            $('#about-page-content').hide();
            $('#contact-page-content').hide();
        }
    </script>
</body>
```
Here we use the jQuery function ```$()``` and a standart CSS selector by id to select the DOM elements and then call hide() to hide them. More about hide [--HERE--](http://api.jquery.com/hide/). If you open the document you`ll notice that the elements **aren`t hidden**. The reason for this is because we **still haven`t called the function** anywhere, so it is never executed.
**Finally**, we need to call the function we just created:
```
<body>
    <div id="main-content">
        <div id="home-page-content">
            Home content
        </div>
        <div id="courses-page-content">
            Courses content
        </div>
        <div id="about-page-content">
            About content
        </div>
        <div id="contact-page-content">
            Contact content
        </div>
    </div>

    <script src="jquery.min.js"></script>
    <script>
        function hideAllContent() {
            $('#home-page-content').hide();
            $('#courses-page-content').hide();
            $('#about-page-content').hide();
            $('#contact-page-content').hide();
        }
        
        hideAllContent();
    </script>
</body>
```
And that`s it. If we open the html document we can see that nothing is displayed anymore.

I hope this reply was helpful to you. Don`t hesitate to contact us if you have further questions.