# Subscribe a JavaScript function to an event with jQuery library

*TAGS*: jQuery, events

### **Article information**

***Article relates to***: jQuery

***Prerequisites***: This article assumes the reader has a basic knolwedge of HTML markup language, document structure and how to add scripts to html page. A basic knowledge of JavaScript, DOM and CSS is also recommended.

***Created by***: Anonymous on 17.09.2015

***Last modified by***: Anonymous on 17.09.2015


## Description
The article explains how to attach handler functions to click events on DOM elements, using the jQuery library.

## Solution

**Create the html document structure**

We`ll start with the following HTML document. It is a simple page that contains navigation menu (div with id main-menu) and an area to display selected content (div with id main-content). Here`s the base structure

```HTML
<body>
    <ul id="main-menu">
        <li id="home-page">
            Home
        </li>
        <li id="courses-page">
            Courses
        </li>
        <li id="about-page">
            About
        </li>
        <li id="contact-page">
            Contact
        </li>
    </ul>
    <div id="main-content">
        <div id="home-page-content" style="display: none">
            Home content
        </div>
        <div id="courses-page-content" style="display: none">
            Courses content
        </div>
        <div id="about-page-content" style="display: none">
            About content
        </div>
        <div id="contact-page-content" style="display: none">
            Contact content
        </div>
    </div>
</body>
```

**Load the jQuery library and create the script that will handle the events**

```HTML
<body>
    <ul id="main-menu">
        <li id="home-page">
            Home
        </li>
        <li id="courses-page">
            Courses
        </li>
        <li id="about-page">
            About
        </li>
        <li id="contact-page">
            Contact
        </li>
    </ul>
    <div id="main-content">
        <div id="home-page-content" style="display: none">
            Home content
        </div>
        <div id="courses-page-content" style="display: none">
            Courses content
        </div>
        <div id="about-page-content" style="display: none">
            About content
        </div>
        <div id="contact-page-content" style="display: none">
            Contact content
        </div>
    </div>

    <script src="jquery.min.js"></script>
    <script>
        // UI logic here
    </script>
</body>
```

**Create a function to hide all the contents inside main-content div initially**

```HTML
<body>
    <ul id="main-menu">
        <li id="home-page">
            Home
        </li>
        <li id="courses-page">
            Courses
        </li>
        <li id="about-page">
            About
        </li>
        <li id="contact-page">
            Contact
        </li>
    </ul>
    <div id="main-content">
        <div id="home-page-content" style="display: none">
            Home content
        </div>
        <div id="courses-page-content" style="display: none">
            Courses content
        </div>
        <div id="about-page-content" style="display: none">
            About content
        </div>
        <div id="contact-page-content" style="display: none">
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

**Add events to the navigation menu items**

Add events that will hide all the content in #main-content and show only the desired one. You can use jQuery functions .show() and .hide(). More about show [--HERE--](http://api.jquery.com/show/) and hide [here](http://api.jquery.com/hide/)

```HTML
<body>
    <ul id="main-menu">
        <li id="home-page">
            Home
        </li>
        <li id="courses-page">
            Courses
        </li>
        <li id="about-page">
            About
        </li>
        <li id="contact-page">
            Contact
        </li>
    </ul>
    <div id="main-content">
        <div id="home-page-content" style="display: none">
            Home content
        </div>
        <div id="courses-page-content" style="display: none">
            Courses content
        </div>
        <div id="about-page-content" style="display: none">
            About content
        </div>
        <div id="contact-page-content" style="display: none">
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
</body>
```