namespace BullsAndCowsGame
{
    /// <summary>
    /// Implemented by classes that represent the game states.
    /// </summary>
    internal interface IGameState
    {
        /// <summary>
        /// Renders the game data.
        /// </summary>
        void Render();

        /// <summary>
        /// Retrieves the user input.
        /// </summary>
        void GetInput();

        /// <summary>
        /// Handles the user commands.
        /// </summary>
        void Update();
    }
}
