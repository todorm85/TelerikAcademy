namespace BullsAndCowsGame.GameStates
{
    using BullsAndCowsGame.Engine;

    /// <summary>
    /// Handles the start menu game state.
    /// </summary>
    internal class StartMenuState : IGameState
    {
        private string command;
        private string message = "Type 'start' and press enter to begin game:";

        /// <summary>
        /// Defines the game context.
        /// </summary>
        public Game Context { get; set; }

        /// <summary>
        /// Renders the game data.
        /// </summary>
        public void Render()
        {
            this.Context.OutputProvider.Render(this.message);
        }

        /// <summary>
        /// Retrieves the user input.
        /// </summary>
        public void GetInput()
        {
            this.command = this.Context.InputProvider.GetInput();
        }

        /// <summary>
        /// Handles the user commands.
        /// </summary>
        public void Update()
        {
            if (this.command == "start")
            {
                var newInGameState = this.Context.StateFactory.GetInGameState(this.Context);
                this.Context.State = newInGameState;
            }
            else
            {
                this.message = "Unknown command! Please type 'start' to begin.";
            }
        }
    }
}
