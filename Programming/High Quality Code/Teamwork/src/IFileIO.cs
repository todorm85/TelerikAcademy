namespace BullsAndCowsGame
{
    using System.Collections.Generic;

    /// <summary>
    /// Implemented by classes that save the score.
    /// </summary>
    public interface IFileIo
    {
        /// <summary>
        /// Represents the scoreboard with the player names and scores.
        /// </summary>
        IDictionary<string, int> ScoreBoard { get; set; }

        /// <summary>
        /// Saves the scoreboard to a file.
        /// </summary>
        /// <param name="file">The file path.</param>
        void SaveToFile(string file);
    }
}