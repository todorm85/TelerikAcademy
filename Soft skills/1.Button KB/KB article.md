# Display the number of times a button in HTML page is clicked

*TAGS*: HTML, JavaScript, button, event

### **Article information**

***Article relates to***: HTML, JavaScript

***Prerequisites***: This article assumes the reader has a basic knolwedge of HTML markup language, document structure and how to add scripts to html page. A basic knowledge of JavaScript and DOM is also needed.

***Created by***: Todor Mitskovski on 16.09.2015

***Last modified by***: Todor Mitskovski on 16.09.2015


## Description
The article explains how to make a html button tag display the number of times it was clicked. JavaScript is used to handle the click event.

## Solution

**Create the button.**

Start with simple html page and create one button tag inside the body tag ([click here for more information about button tag](http://www.w3schools.com/tags/tag_button.asp)). The id of the button can be random, but must be unique for the html document. For the particular demo the id of the button that will display the clicks count is "btn-clicks-count". The starting text of the button is 0, because after the page loads it will not have been clicked yet. 

```HTML
<body>
    <button id="btn-clicks-count" style="width:50px; height:25px">0</button>
</body>
```

**Create the script and attach event to the button**

Java Script will be used to handle the click event on the button and modify its display text. First select the element that the click event will be attached to. In the provided example the native function document.getElementById() is used to select the button by its unique id ([click here for more information about this function](https://developer.mozilla.org/en-US/docs/Web/API/Document/getElementById)). The selected button is assigned to the clickedCounterBtn variable. Then the native function addEventListener() is used on the selected DOM element to attach the click event. (more on addEventListener [here](https://developer.mozilla.org/en-US/docs/Web/API/EventTarget/addEventListener)) The second passed parameter (onCounterBtnClick) is the name of the callback function that will be executed when the button is clicked.

```HTML
<body>
    <button id="btn-clicks-count" style="width:50px; height:25px">0</button>
    <script>
        var clicksCounterBtn = document.getElementById("btn-clicks-count");
        clicksCounterBtn.addEventListener('click', onCounterBtnClick, true);
    </script>
</body>
```

**Create the handler function**

The final step is to create the actual handler function that will modify the button text and display the current clicks count. This is achieved by creating a variable called clicksCount with initial value of '0' that will be incremented with 1 by the handler function onCounterBtnClick every time the button is clicked. Then its value will be displayed in the button text. To assign a new value to the button text the property innerHTML is used. ([click here for more information about innerHTML](https://developer.mozilla.org/en-US/docs/Web/API/Element/innerHTML)).

```HTML
<body>
    <button id="btn-clicks-count" style="width:50px; height:25px">0</button>
    <script>
        var clicksCounterBtn = document.getElementById("btn-clicks-count");
        clicksCounterBtn.addEventListener('click', onCounterBtnClick, true);
        var clicksCount = 0;
        function onCounterBtnClick() {
            clicksCount++;
            clicksCounterBtn.innerHTML = clicksCount;
        }
    </script>
</body>
```