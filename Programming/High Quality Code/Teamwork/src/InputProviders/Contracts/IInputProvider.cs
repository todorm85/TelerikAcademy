namespace BullsAndCowsGame
{
    /// <summary>
    /// Implemented by classes that need to retrieve user input.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Retrieves the user input.
        /// </summary>
        /// <returns>The user input as a string.</returns>
        string GetInput();
    }
}
