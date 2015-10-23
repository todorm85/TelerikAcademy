namespace BullsAndCowsGame
{
    using BullsAndCowsGame.Engine;
  
    /// <summary>
    /// Implemented by factories that create different game states.
    /// </summary>
    internal interface IStateFactory
    {
        /// <summary>
        /// Gets the in-game states.
        /// </summary>
        /// <param name="context">The concrete game context.</param>
        /// <returns>Object that implements the IGameState interface.</returns>
        IGameState GetInGameState(Game context);

        /// <summary>
        /// Gets the states in the start of the game.
        /// </summary>
        /// <param name="context">The concrete game context.</param>
        /// <returns>Object that implements the IGameState interface.</returns>
        IGameState GetStartMenuState(Game context);
    }
}
