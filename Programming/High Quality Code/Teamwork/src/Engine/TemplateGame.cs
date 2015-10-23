namespace BullsAndCowsGame.Engine
{
    /// <summary>
    /// Defines the steps for the game flow by implementing the template method pattern.
    /// </summary>
    public abstract class TemplateGame
    {
        /// <summary>
        /// Executes the game.
        /// </summary>
        public void Play()
        {
            this.Render();
            this.GetInput();
            this.Update();
        }

        /// <summary>
        /// Retrieves the user input.
        /// </summary>
        protected abstract void GetInput();

        /// <summary>
        /// Renders the game output data.
        /// </summary>
        protected abstract void Render();

        /// <summary>
        /// Handles the commands.
        /// </summary>
        protected abstract void Update();
    }
}
