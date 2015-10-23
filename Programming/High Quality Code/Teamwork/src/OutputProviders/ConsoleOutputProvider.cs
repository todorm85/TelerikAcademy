namespace BullsAndCowsGame
{
    using System;

    /// <summary>
    /// Public class used for defining the System.Console as rendering engine.
    /// </summary>
    public class ConsoleOutputProvider : IOutputProvider
    {
        /// <summary>
        /// Writes on the specified string value followed by the current line terminator.
        /// </summary>
        /// <param name="output">The value to write.</param>
        public void Render(string output)
        {
            Console.WriteLine("{0}\n", output);
        }
    }
}
