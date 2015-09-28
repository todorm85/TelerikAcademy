var GameEngines = function () {
    var StandartGameEngine = function () {
        var SNAKE_START_X = 100;
        var SNAKE_START_Y = 100;
        var SNAKE_START_LENGTH = 70;
        var SNAKE_START_RADIUS = 10;
        var SNAKE_START_SPEED = 2;
        var walls = [];

        function init(renderEngine, physicsEngine, scoreBoard) {
            this.renderEngine = renderEngine;
            this.physicsEngine = physicsEngine;
            this.scoreBoard = scoreBoard;
            this.gameObjects = {};
            this.gameFlags = {
                gameOver: false
            };
            var player = Object.create(WorldObjects.player).init('Player 1');
            this.gameObjects.player = player;
            this.gameObjects.snake = generateSnake();
            this.gameObjects.walls = generateWalls.call(this);
            this.gameObjects.food = generateFood.call(this);
            this.gameObjects.bonus = generateBonus.call(this);

            return this;
        }

        function generateSnake() {
            var snake = Object.create(WorldObjects.snake)
                .init(SNAKE_START_LENGTH, SNAKE_START_RADIUS, SNAKE_START_X, SNAKE_START_Y, SNAKE_START_SPEED);
            return snake;
        }

        function generateWalls() {
            var wallsCount = 10;

            while (walls.length < wallsCount) {
                var x = Math.random() * this.physicsEngine.worldSize.x,
                    y = Math.random() * this.physicsEngine.worldSize.y,
                    sizeX = 60,
                    sizeY = 99,
                    curImageInd = Math.floor(Math.random() * 4),
                    wall = Object.create(WorldObjects.wall)
                        .init(x, y, sizeX, sizeY, curImageInd);
                if (this.physicsEngine.checkWorldObjectCollisions(this.gameObjects.snake, wall)) {
                } else {
                    walls.push(wall);
                }
            }

            return walls;
        }

        function generateFood() {

            //Make sure that the initial food position is valid (not on a wall or near the world end)
            var foodX, foodY, food,
                isInvalidPosition = false;

            do
            {
                foodX = Math.floor((Math.random() * this.physicsEngine.worldSize.x - 2) + 1);
                foodY = Math.floor((Math.random() * this.physicsEngine.worldSize.y - 2) + 1);

                isInvalidPosition = walls.some(function (wall) {
                    return foodX > (wall.x - wall.sizeX / 2) && foodY > (wall.y - wall.sizeY / 2) && foodX < (wall.x + wall.sizeX / 2) && foodY < (wall.y + wall.sizeY / 2)
                });

                if (foodX < 10 || foodX > this.physicsEngine.worldSize.x - 10) {
                    isInvalidPosition = true;
                }

                if (foodY < 10 || foodY > this.physicsEngine.worldSize.y - 10) {
                    isInvalidPosition = true;
                }
            }
            while (isInvalidPosition);


            food = Object.create(WorldObjects.food).init(foodX, foodY, false);

            return food;
        }

        function generateBonus() {
            var bonusX = 0,//Math.floor((Math.random() * this.physicsEngine.worldSize.x - 2) + 1),
                bonusY = 0,// Math.floor((Math.random() * this.physicsEngine.worldSize.y - 2) + 1),
                bonus = Object.create(WorldObjects.bonus).init(bonusX, bonusY, false);
            return bonus;
        }


        function start() {
            var gameObjects = this.gameObjects,
                physicsEngine = this.physicsEngine,
                renderEngine = this.renderEngine,
                gameFlags = this.gameFlags,
                scoreBoard = this.scoreBoard;

            function gameLoop() {
                physicsEngine.updateState(gameObjects, gameFlags);
                renderEngine.renderState(gameObjects);
                scoreBoard.update(gameObjects.player);
                if (!gameFlags.gameOver) {
                    requestAnimationFrame(gameLoop);
                } else {
                    renderEngine.gameOver(gameObjects.player);
                }
            }

            gameLoop();
        }

        return {
            init: init,
            start: start
        };
    }();

    return {
        StandartGameEngine: StandartGameEngine
    };
}();