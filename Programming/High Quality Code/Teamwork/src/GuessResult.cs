namespace BullsAndCowsGame
{
    /// <summary>
    /// Represents the bulls and cows in the specific guess number.
    /// </summary>
    public class GuessResult
    {
        /// <summary>
        /// The bulls in the number.
        /// </summary>
        public int Bulls { get; set; }

        /// <summary>
        /// The cows in the number.
        /// </summary>
        public int Cows { get; set; }

        /// <summary>
        /// The result represented as string.
        /// </summary>
        /// <returns>The string value with the result.</returns>
        public override string ToString()
        {
            return string.Format("Bulls: {0}, Cows: {1}", this.Bulls, this.Cows);
        }
    }
}
