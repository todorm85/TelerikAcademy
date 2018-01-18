var RenderEngines = (function () {

    var CanvasRenderer = function () {

        function init(width, height) {
            this.stage = new Kinetic.Stage({
                container: 'canvas-container',
                width: width,
                height: height
            });

            this.layer = new Kinetic.Layer();
            this.stage.add(this.layer);

            this.canvas = document.getElementsByTagName('canvas')[0];
            this.canvas.width = width;
            this.canvas.height = height;
            this.ctx = this.canvas.getContext('2d');

            return this;
        }

        function renderState(worldObjects) {
            this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height);

            var img = new Image();
            img.src = 'media/kan1.jpg';
            if (img.complete == true) {
                var pattern = this.ctx.createPattern(img, 'repeat');
                this.ctx.fillStyle = pattern;
                this.ctx.fillRect(0, 0, this.canvas.width, this.canvas.height);

                renderSnake.call(this, worldObjects.snake);
                renderWalls.call(this, worldObjects.walls);
                //renderWalls();
                renderFood.call(this, worldObjects.food);
                renderBonus.call(this,worldObjects.bonus);
            }
        }

        function renderSnake(snake) {
            var ctx = this.ctx,
                pos = snake.tail.length - 1,
                body = new Image(),
                tailObj, bodyPat, headObj;

            body.src = 'media/snakePat.gif';
            if (body.complete == true) {
                bodyPat = this.ctx.createPattern(body, 'repeat');
            }

            for (var i = (snake.tail.length - 2); i > 0; i -= 1) {

                ctx.beginPath();
                ctx.fillStyle = bodyPat;
                ctx.arc(snake.tail[i].x, snake.tail[i].y, snake.radius, 0, 2 * Math.PI, false);
                ctx.fill();
            }

            headObj = new Image();
            headObj.src = snake.arrHeads[snake.currentDir];
            ctx.drawImage(headObj, snake.tail[pos].x - snake.radius - 5, snake.tail[pos].y - snake.radius - 5);
        }

        function renderWalls(walls) {
            var ctx = this.ctx;
            walls.forEach(function (wall) {
                var faceObj = new Image();
                faceObj.src = wall.currentImage;
                ctx.drawImage(faceObj,wall.x - wall.sizeX / 2, wall.y - wall.sizeY / 2);
                //ctx.beginPath();
                //ctx.fillStyle = 'brown';
                //ctx.rect(wall.x - wall.sizeX / 2, wall.y - wall.sizeY / 2, wall.sizeX, wall.sizeY);
                //ctx.fill();
            });
        }

        function renderFood(food) {
            var ctx = this.ctx;

            if (!food.isEaten) {
                var foodObj = new Image();
                foodObj.src = 'media/superNinja.png';
                ctx.drawImage(foodObj, food.x-foodObj.width/2, food.y-foodObj.height/2, foodObj.width, foodObj.height);
            } 

        }

        function renderBonus(bonus) {
            var ctx = this.ctx;

            if (!bonus.isTaken) {
                var bonusObj = new Image();
                bonusObj.src = 'media/jsBonus.png';
                ctx.drawImage(bonusObj, bonus.x - bonusObj.width/2, bonus.y-bonusObj.height/2, bonusObj.width, bonusObj.height);
            }
        }

        function gameOver(player) {
            var ctx = this.ctx;
            ctx.clearRect(0, 0, 900, 640);
            var img = new Image();

            img.onload = function () {

                ctx.drawImage(img, 0,0, 430, 590);
                ctx.lineWidth = 3;
                ctx.fillStyle = '#CC0000';
                ctx.shadowBlur = 1;
                ctx.shadowOffsetX = 1;
                ctx.shadowOffsetY = 1;
                ctx.shadowColor = "silver";

                ctx.font = "35px Arial";
                //ctx.strokeText(" Sorry, but you just died!  ^_^", 370, 100);
                //ctx.fillText(" Sorry, but you just died!  ^_^ ", 370, 100);
                ctx.strokeText(" Оо, да, оо, да, оо, да, оо, да, оо, да!!", 250, 100);
                ctx.fillText(" Оо, да, оо, да, оо, да, оо, да, оо, да!!", 250, 100);
                ctx.strokeText("GAME OVER!!",420, 190);
                ctx.strokeText("Било квот' било - дроп си", 350, 330);
                ctx.fillText("Било квот' било - дроп си!!", 350, 330);


                ctx.strokeText("Your points: " + player.points, 460, 390);
                ctx.fillText("Your points: " + player.points, 460, 390);

            };

            img.src = 'media/prettyKirsko.jpg';
        }

        return {
            init: init,
            renderState: renderState,
            gameOver: gameOver
        };
    }();

    return {
        CanvasRenderer: CanvasRenderer
    };

}());