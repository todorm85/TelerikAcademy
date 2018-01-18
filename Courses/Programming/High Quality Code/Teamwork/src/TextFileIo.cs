namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class for saving the scoreboard to a text file.
    /// </summary>
    public class TextFileIo : IFileIo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextFileIo"/> class.
        /// </summary>
        public TextFileIo()
        {
            this.ScoreBoard = new SortedDictionary<string, int>();
            this.LoadScoreList(Constants.ScoresFile);
        }

        /// <summary>
        /// Represents the scoreboard with the player names and scores.
        /// </summary>
        public IDictionary<string, int> ScoreBoard { get; set; }

        /// <summary>
        /// Saves the scoreboard to a file.
        /// </summary>
        /// <param name="filename">The file path.</param>
        public void SaveToFile(string filename)
        {
            try
            {
                using (StreamWriter outputStream = new StreamWriter(filename, false))
                {
                    foreach (var pair in this.ScoreBoard)
                    {
                        outputStream.WriteLine(string.Format("{0} {1}", pair.Key, pair.Value));
                    }
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Input data is not in the correct format or file is missing! Writing to high score list stopped!");
            }
        }

        private void LoadScoreList(string filename)
        {
            try
            {
                using (StreamReader inputStream = new StreamReader(filename))
                {
                    var line = inputStream.ReadLine();
                    this.ScoreBoard.Clear();
                    while (!string.IsNullOrEmpty(line))
                    {
                        var scoreArray = line.Split(' ');
                        //ValidateHighScoreData(scoreArray);
                        this.ScoreBoard.Add(scoreArray[0], int.Parse(scoreArray[1]));
                        line = inputStream.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw new ArgumentException("Something went wrong with reading data from high score list! Reading from high score list stopped!");
            }
        }

        public string ValidateHighScoreData(string[] scoreArray)
        {
            var playerName = scoreArray[0];
            var highScore = scoreArray[1];
            string pattern = @"^[a-zA-Z0-9]+$";
            
            if (playerName.Length <= 3 || !Regex.IsMatch(playerName, pattern))
            {
                return "Player name must be more than 3 symbols and can contain letters, numbers and underscore!";
            }

            else if(int.Parse(highScore) < 0)
            {
                return "Invalid high score!";
            }

            else
            {
                return "Validation completed successfully!";
            }
        }
    }
}
