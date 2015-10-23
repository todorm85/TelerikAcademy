namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Calculates the game scores.
    /// </summary>
    public class DefaultScoreCalculator : IScoreCalculator
    {
        private const int MaxPlayersToShowInScoreboard = 5;
        private IFileIo fileIO;
        private IDictionary<string, int> scoreBoard;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultScoreCalculator"/> class.
        /// </summary>
        public DefaultScoreCalculator()
        {
            this.fileIO = new TextFileIo();
            this.scoreBoard = this.fileIO.ScoreBoard;
            this.AttemptedNumbers = new HashSet<string>();
        }

        /// <summary>
        /// Initializes a new instance of the DefaultScoreCalculator class.
        /// </summary>
        /// <param name="fileIo">Object that holds the file data where the scores will be saved.</param>
        public DefaultScoreCalculator(IFileIo fileIo)
        {
            this.fileIO = fileIo;
            this.AttemptedNumbers = new HashSet<string>();
        }

        /// <summary>
        /// Holds the guess number.
        /// </summary>
        public HashSet<string> AttemptedNumbers { get; set; }

        /// <summary>
        /// Holds the name of the player.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Holds the count of used cheats.
        /// </summary>
        public int CheatsCount { get; set; }

        /// <summary>
        /// Holds the count of guesses.
        /// </summary>
        public int GuessCount { get; set; }

        private IDictionary<string, int> ScoreBoard
        {
            get
            {
                this.scoreBoard = this.scoreBoard
                           .OrderBy(x => x.Value)
                           .Take(MaxPlayersToShowInScoreboard)
                           .ToDictionary(pair => pair.Key, pair => pair.Value);

                return this.scoreBoard;
            }

            set
            {
                this.scoreBoard = value;
            }
        }

        /// <summary>
        /// Logic for adding the score to the scoreboard.
        /// </summary>
        /// <param name="name">String that represents the player name.</param>
        /// <param name="score">The player score.</param>
        /// <returns>If the score should be added.</returns>
        public bool AddScore(string name, int score)
        {
            try
            {
                if (this.ScoreBoard.Any(x => x.Key.ToLower() == name.ToLower()))
                {
                    throw new ArgumentException();
                }

                this.ScoreBoard.Add(name, score);
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// String representation of the scores.
        /// </summary>
        /// <returns>String value representing the scores.</returns>
        public string ScoreToString()
        {
            var str = new StringBuilder();
            str.AppendLine(Constants.ScoreBoardTitle);
            foreach (var score in this.ScoreBoard)
            {
                str.AppendLine(string.Format("{0} {1}", score.Key, score.Value));
            }

            return str.ToString().Trim();
        }
    }
}
