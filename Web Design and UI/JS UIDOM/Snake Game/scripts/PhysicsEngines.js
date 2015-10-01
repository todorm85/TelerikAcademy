var PhysicsEngines = (function () {

    var StandartPhysicsEngine = function () {

        function init(inputProvider) {
            this.inputProvider = inputProvider;
            this.worldSize = {
                x: 900,
                y: 600
            };
            return this;
        }

        function updateState(gameObjects, gameFlags) {
            updateSnake.call(this, gameObjects, gameFlags);
            var playerPoints = gameObjects.player.points;
            switch (playerPoints) {
                case 50:
                    gameObjects.player.level = 2;
                    gameObjects.snake.speed = 3;
                    break;
                case 200:
                    gameObjects.player.level = 3;
                    gameObjects.snake.speed = 4;
                    break;
                case 300:
                    gameObjects.player.level = 4;
                    gameObjects.snake.speed = 5;
                    break;
                case 400:
                    gameObjects.player.level = 5;
                    gameObjects.snake.speed = 6;
                    break;
                default:
                    break;
            }
        }

        function updateSnake(gameObjects, gameFlags) {
            var snake = gameObjects.snake,
                food = gameObjects.food,
                bonus = gameObjects.bonus,
                inputDirection,
                updateX = 1,
                updateY = 1;

            inputDirection = validateMove(this.inputProvider);

            if (!(inputDirection === 'other' || inputDirection === '')) {
                snake.direction = inputDirection;
            }

            switch (snake.direction) {
                case 'up':
                    snake.currentDir = 1;
                    updateX = 0;
                    updateY *= -1;
                    break;
                case 'right':
                    snake.currentDir = 0;
                    updateY = 0;
                    break;
                case 'down':
                    snake.currentDir = 3;
                    updateX = 0;
                    break;
                case 'left':
                    snake.currentDir = 2;
                    updateX *= -1;
                    updateY = 0;
                    break;
            }

            for (var i = 0; i < snake.speed; i++) {
                snake.tail.push({
                    x: snake.x += updateX,
                    y: snake.y += updateY
                });

                if (snake.tail.length > snake.length) {
                    snake.tail.shift();
                }

                checkSnakeCollisions.call(this, gameObjects, gameFlags);
                takeBonus.call(this, gameObjects);
                eatFood(gameObjects);
                animBonus.call(this, bonus);
            }

            if (gameObjects.food.isEaten) {
                snake.length += 10;
                gameObjects.player.points += 10;

                var foodX, foodY,
                    isInvalidPosition = false;

                do
                {
                    foodX = Math.floor((Math.random() * this.worldSize.x - 2) + 1);
                    foodY = Math.floor((Math.random() * this.worldSize.y - 2) + 1);

                    isInvalidPosition = gameObjects.walls.some(function (wall) {
                        return foodX > (wall.x - wall.sizeX / 2) && foodY > (wall.y - wall.sizeY / 2) && foodX < (wall.x + wall.sizeX / 2) && foodY < (wall.y + wall.sizeY / 2)
                    });

                    if (foodX < 10 || foodX > this.worldSize.x - 10) {
                        isInvalidPosition = true;
                    }

                    if (foodY < 10 || foodY > this.worldSize.y - 10) {
                        isInvalidPosition = true;
                    }
                }
                while (isInvalidPosition);

                gameObjects.food.init(foodX, foodY, false);
                //gameObjects.food.init(Math.floor((Math.random() * this.worldSize.x - 2) - 10), Math.floor((Math.random() * this.worldSize.y - 2) - 10), false);
            }

            if (gameObjects.bonus.isTaken) {
                snake.length += 10;
                gameObjects.player.points += 15;
                gameObjects.bonus.init(Math.floor((Math.random() * this.worldSize.x - 2) - 10), Math.floor((Math.random() * this.worldSize.y - 2) - 10), false);
                // gameObjects.bonus.isTaken = false;
            }

            function validateMove(inputProvider) {
                //bug fix for snake movement in opposite direction
                var inputDirection;

                if (inputProvider.getInput().p0 === 'left' && inputProvider.getInput().p1 === 'right') {
                    inputDirection = inputProvider.getInput().p0;
                    inputProvider.getInput().p1 = inputProvider.getInput().p0;
                }
                else if (inputProvider.getInput().p0 === 'right' && inputProvider.getInput().p1 === 'left') {
                    inputDirection = inputProvider.getInput().p0;
                    inputProvider.getInput().p1 = inputProvider.getInput().p0;
                }
                else if (inputProvider.getInput().p0 === 'up' && inputProvider.getInput().p1 === 'down') {
                    inputDirection = inputProvider.getInput().p0;
                    inputProvider.getInput().p1 = inputProvider.getInput().p0;
                }
                else if (inputProvider.getInput().p0 === 'down' && inputProvider.getInput().p1 === 'up') {
                    inputDirection = inputProvider.getInput().p0;
                    inputProvider.getInput().p1 = inputProvider.getInput().p0;
                }
                else {
                    inputDirection = inputProvider.getInput().p1;
                }

                return inputDirection;
            }
        }

        function animBonus(bonus) {
            if (bonus) {
                if (bonus.x + 30 >= 900 || bonus.x < 0) {
                    bonus.upDateX *= -1;
                }

                if (bonus.y + 34 >= 600 || bonus.y < 0) {
                    bonus.upDateY *= -1;
                }
                bonus.x += bonus.upDateX;
                bonus.y += bonus.upDateY;
            }

            setTimeout(animBonus, 500);

            return this;
        }

        function checkWorldObjectCollisions(object1, object2) {
            // this checks if the objects` surrounding rectangles (also called bounding box in computer graphics terminology) are colliding (overlapping)
            if (object1.x + object1.sizeX / 2 > object2.x - object2.sizeX / 2 &&
                object1.x - object1.sizeX / 2 < object2.x + object2.sizeX / 2 &&
                object1.y + object1.sizeY / 2 > object2.y - object2.sizeY / 2 &&
                object1.y - object1.sizeY / 2 < object2.y + object2.sizeY / 2) {
                return true;
            } else {
                return false;
            }
        }

        function checkSnakeCollisions(gameObjects, gameFlags) {
            var snake = gameObjects.snake;

            function isOutOfWorld() {
                if (snake.x < snake.sizeX / 2 || this.worldSize.x - snake.sizeX / 2 < snake.x) {
                    return true;
                }

                if (snake.y < snake.sizeY / 2 || this.worldSize.y - snake.sizeY / 2 < snake.y) {
                    return true;
                }

                return false;
            }

            function hasCollidedWithWall() {
                return gameObjects.walls.some(function (wall) {
                    return checkWorldObjectCollisions(snake, wall);
                });
            }

            function hasCollidedWithTail() {
                var snakeTailWithoutHead = snake.tail.slice(0, snake.tail.length - 1);
                return snakeTailWithoutHead.some(function (tailSegment) {
                    return tailSegment.x === snake.tail[snake.tail.length - 1].x && tailSegment.y === snake.tail[snake.tail.length - 1].y
                });
            }

            if (isOutOfWorld.call(this) || hasCollidedWithWall() || hasCollidedWithTail()) {
                gameFlags.gameOver = true;
            }

        }

        function eatFood(gameObjects) {
            var snake = gameObjects.snake,
                food = gameObjects.food;
            if (checkWorldObjectCollisions(food, snake)) {
                food.isEaten = true;
            }
        }

        function takeBonus(gameObjects) {
            var snake = gameObjects.snake,
                bonus = gameObjects.bonus;
            if (checkWorldObjectCollisions(bonus, snake)) {
                bonus.isTaken = true;
            }
        }

        return {
            init: init,
            updateState: updateState,
            checkWorldObjectCollisions: checkWorldObjectCollisions
        };
    }();

    return {
        StandartPhysicsEngine: StandartPhysicsEngine
    };

}());