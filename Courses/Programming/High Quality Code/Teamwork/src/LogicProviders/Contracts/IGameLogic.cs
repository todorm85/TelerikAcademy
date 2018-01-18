namespace BullsAndCowsGame
{
    /// <summary>
    /// Implemented by classes that define the logic of the game.
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Gets the secret number.
        /// </summary>
        ISecretNumber SecretNumber { get; }

        /// <summary>
        /// Reveals part of the secret number.
        /// </summary>
        /// <returns>String value containing the revealed part of the secret number.</returns>
        string GetCheat();

        /// <summary>
        /// Calculates the bulls and cows based on the guess and the secret number.
        /// </summary>
        /// <param name="number">The guess as string value.</param>
        /// <returns>Object of type GuessResult containing the guessed bulls and cows.</returns>
        GuessResult GetGuessResult(string number);
    }
}
