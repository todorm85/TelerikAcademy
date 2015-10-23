namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BullsAndCowsGame;
    using BullsAndCowsGame.Engine;

    /// <summary>
    /// Bull and Cows game is initialized with its components, run and terminated.
    /// </summary>
    public static class EntryPoint
    {
        /// <summary>
        /// The entry point of the game.
        /// </summary>
        public static void Main()
        {
            var inputProvider = ConsoleInputProvider.Instance;
            var outputProvider = new ConsoleOutputProvider();
            var stateFactory = new StateFactory();
            var game = new Game(inputProvider, outputProvider, stateFactory);

            while (!game.IsOver)
            {
                game.Play();
            }
        }
    }
}
