var ScoreBoard = function() {

    var StandartScoreBoard = function() {

        function init () {
            this.scoreBoard = document.getElementById('scoreboard');
            return this;
        }

        function update (player) {
            this.scoreBoard.innerHTML = 'LEVEL ' + player.level + ': ' + player.points + ' points';
        }

        return {
            init: init,
            update: update
        };
    }();

    return {
        StandartScoreBoard: StandartScoreBoard
    }
}();