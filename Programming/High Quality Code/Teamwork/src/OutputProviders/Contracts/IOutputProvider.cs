namespace BullsAndCowsGame
{
    /// <summary>
    /// Implemented by the rendering classes. 
    /// </summary>
    public interface IOutputProvider
    {
        /// <summary>
        /// Renders the specified string value.
        /// </summary>
        /// <param name="output">The value to write.</param>
        void Render(string output);
    }
}
