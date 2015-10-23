namespace BullsAndCowsGame
{
    using System;

    /// <summary>
    /// Public class implementing Singleton pattern for selecting the System.Console as input provider.
    /// </summary>
    public class ConsoleInputProvider : IInputProvider
    {
        /// <summary>
        /// Private field containing the single instance of the input provider.
        /// </summary>
        private static IInputProvider instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="ConsoleInputProvider"/> class from being created.
        /// </summary>
        private ConsoleInputProvider()
        {
        }

        /// <summary>
        /// Gets a single new instance of the ConsoleInputProvider through checking for existence of such.
        /// </summary>
        public static IInputProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConsoleInputProvider();
                }

                return instance;
            }
        }

        /// <summary>
        /// Retrieves the user input from the System.Console.
        /// </summary>
        /// <returns>The user input from the System.Console as a string.</returns>
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
