namespace BullsAndCowsGame
{
    using System.Collections.Generic;

    /// <summary>
    /// Implemented by classes that represent the secret number.
    /// </summary>
    public interface ISecretNumber
    {
        /// <summary>
        /// Gets the first digit of the number.
        /// </summary>
        int FirstDigit { get; }

        /// <summary>
        /// Gets the second digit of the number.
        /// </summary>
        int SecondDigit { get; }

        /// <summary>
        /// Gets the third digit of the number.
        /// </summary>
        int ThirdDigit { get; }

        /// <summary>
        /// Gets the fourth digit of the number.
        /// </summary>
        int FourthDigit { get; }

        /// <summary>
        /// Gets the digits of the secret number.
        /// </summary>
        HashSet<int> Numbers { get; }

        /// <summary>
        /// Gets the state of the revealed secret number.
        /// </summary>
        char[] RevealedState { get; }

        /// <summary>
        /// Generates random secret number.
        /// </summary>
        /// <returns>The secret number as HashSet.</returns>
        HashSet<int> GenerateNewRandom();
    }
}