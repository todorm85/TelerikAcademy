namespace BullsAndCowsGame
{
    using System.Collections.Generic;

    /// <summary>
    /// Implemented by classes that calculate the games score.
    /// </summary>
    public interface IScoreCalculator
    {
        /// <summary>
        /// Holds the guess number.
        /// </summary>
        HashSet<string> AttemptedNumbers { get; set; }

        /// <summary>
        /// Holds the name of the player.
        /// </summary>
        string PlayerName { get; set; }

        /// <summary>
        /// Holds the count of used cheats.
        /// </summary>
        int CheatsCount { get; set; }

        /// <summary>
        /// Holds the count of guesses.
        /// </summary>
        int GuessCount { get; set; }

        /// <summary>
        /// Logic for adding the score to the scoreboard.
        /// </summary>
        /// <param name="name">String that represents the player name.</param>
        /// <param name="score">The player score.</param>
        /// <returns>If the score should be added.</returns>
        bool AddScore(string name, int score);

        /// <summary>
        /// String representation of the scores.
        /// </summary>
        /// <returns>String value representing the scores.</returns>
        string ScoreToString();
    }
}
