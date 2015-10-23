namespace BullsAndCowsGame
{
    /// <summary>
    /// Contains the constants used in the assembly.
    /// </summary>
    internal class Constants
    {
        internal const string ScoresFile = "../../../scores.txt";
        internal const string WelcomeMessage = "Welcome to “Bulls and Cows” game. Please try to guess my secret 4-digit number.\nUse 'top' to view the top scoreboard, 'restart' to start a new game and 'help' to cheat and 'exit' to quit the game.";
        internal const string WrongNumberMessage = "Wrong number!";
        internal const string InvalidCommandMessage = "Incorrect guess or command!";
        internal const string NumberGuessedWithoutCheats = "Congratulations! You guessed the secret number in {0} {1}.\nPlease enter your name for the top scoreboard: ";
        internal const string NumberGuessedWithCheats = "Congratulations! You guessed the secret number in {0} {1} and {2} {3}.\nYou are not allowed to enter the top scoreboard.";
        internal const string GoodBuyMessage = "Good bye!";
        internal const string ScoreBoardTitle = "SCORE BOARD:\n=====================";
    }
}
