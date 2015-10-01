# BlackRussian

This is the teamwork project of "Black Russian" team for the course JavaScript Applications at Telerik Academy from 2015. It contains the famous Scrabble game as described [here](https://en.wikipedia.org/wiki/Scrabble). The game is written in Java Script, using [jQuery](https://jquery.com) and [SystemJS](https://github.com/systemjs/systemjs).

## How to load the dependencies
* Either Node.js or IO.js is needed to be installed on the system, as well as git in order to load all the dependencies.
* Install bower:
`npm install -g bower`
* Install bower dependencies (bower.json)
Navigate to the project root dir in the console and write:
`bower install`
* Install node.js dependencies (package.json)
Navigate to the project root dir in the console and write:
`npm install`

## How to run the app
* The app must be started from a local web server. To do so navigate in the console to the root dir of the project and enter: `node node-modules/http-server/bin/http-server`
* Don`t close the console, minimize it
* Open a browser and enter in the address: `localhost:8080`
* IMPORTANT: after each change to a .js file you MUST clear the browser cache or the changes won`t be displayed (because of asynchronous module loading with SystemJS)

## How to play
The game starts with 10 tiles with letters. Put tiles on the board with mouse click. Click on tile will select it. Clicking on an empty square on the board will put the tile there. Or if the same tile is clicked again it will be deselected. To submit the word written ob the board, click on submit button. To skip a turn simply click submit without writing anything on the board.
Only the current player`s name and tiles should be shown per turn.
All of the players` scores should be shown always.
