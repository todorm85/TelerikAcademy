namespace BullsAndCowsGame
{
    using BullsAndCowsGame.Engine;
    using BullsAndCowsGame.GameStates;

    /// <summary>
    /// The factory for the game states.
    /// </summary>
    internal class StateFactory : IStateFactory
    {
        /// <summary>
        /// Gets the in-game states.
        /// </summary>
        /// <param name="context">The concrete game context.</param>
        /// <returns>Object that implements the IGameState interface.</returns>
        public IGameState GetInGameState(Game context)
        {
            var logicProvider = new StandardGameLogic(new FourDigitSecretNumber());
            var fileSaver = new TextFileIo();
            var statisticsProvider = new DefaultScoreCalculator();
            var inGameState = new InGameState(logicProvider, statisticsProvider, fileSaver);
            inGameState.Context = context;
            return inGameState;
        }

        /// <summary>
        /// Gets the states in the start of the game.
        /// </summary>
        /// <param name="context">The concrete game context.</param>
        /// <returns>Object that implements the IGameState interface.</returns>
        public IGameState GetStartMenuState(Game context)
        {
            var startMenu = new StartMenuState();
            startMenu.Context = context;
            return startMenu;
        }
    }
}
