var WorldObjects = function() {
    var worldObject = {
        init: function(x, y, sizeX, sizeY) {
            this.x = x;
            this.y = y;
            this.sizeX = sizeX;
            this.sizeY = sizeY;
        }
    };

    var snake = function(parent) {
        var snake = Object.create(parent);
        snake.init = function(length, radius, headX, headY, speed) {
            parent.init.call(this, headX, headY, radius * 2, radius * 2);
            this.radius = radius;
            this.length = length;
            this.tail = [{
                x: headX,
                y: headY
            }];
            this.direction = 'right';
            this.speed = speed;
            this.arrHeads = ['media/theHead.gif', 'media/theHeadUp.gif', 'media/theHeadLeft.gif', 'media/theHeadDown.gif'];
            this.currentDir = 1;
            return this;
        };

        return snake;
    }(worldObject);

    var wall = function(parent) {
        var wall = Object.create(parent);
        wall.init = function(x, y, sizeX,sizeY, currentImageInd) {
            parent.init.call(this, x, y, sizeX, sizeY);
            this.arrFaces = ['media/obstacle1.png','media/obstacle2.png','media/obstacle1.png','media/obstacle1.png'];
            this.currentImage = this.arrFaces[currentImageInd];
            return this;
        }

        return wall;
    }(worldObject);

    var food = function(parent) {
        var food = Object.create(parent);
        food.init = function(x, y, isEaten) {
            this.x = x;
            this.y = y;
            this.isEaten = isEaten;
            this.sizeX = 30;
            this.sizeY = 28;
            return this;
        }

        return food;
    }(worldObject);

    var bonus = function(parent) {
        var bonus = Object.create(parent);
        bonus.init = function(x, y, isTaken) {
            this.x = x;
            this.y = y;
            this.isTaken = isTaken;
            this.sizeX = 30;
            this.sizeY = 34;
            this.upDateX= 1;
            this.upDateY = 0.5;
            return this;
        }

        return bonus;
    }(worldObject);

    var player = function() {
        function init(name) {
            this.name = name;
            this.level = 1;
            this.points = 0;
            return this;
        }

        return {
            init: init
        };
    }();

    return {
        snake: snake,
        wall: wall,
        food: food,
        player: player,
        bonus: bonus
    };
}();