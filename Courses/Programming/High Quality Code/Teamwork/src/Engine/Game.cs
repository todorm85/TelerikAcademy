namespace BullsAndCowsGame.Engine
{
    /// <summary>
    /// The game context that controls the game flow.
    /// </summary>
    internal class Game : TemplateGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="inputProvider">The input provider.</param>
        /// <param name="outputProvider">The output provider.</param>
        /// <param name="stateFactory">The factory that creates the game states.</param>
        public Game(IInputProvider inputProvider, IOutputProvider outputProvider, IStateFactory stateFactory)
        {
            this.InputProvider = inputProvider;
            this.OutputProvider = outputProvider;
            this.StateFactory = stateFactory;

            this.State = stateFactory.GetStartMenuState(this);
        }

        /// <summary>
        /// Gets the user input provider.
        /// </summary>
        public IInputProvider InputProvider { get; private set; }

        /// <summary>
        /// Gets the output provider where the results will be displayed.
        /// </summary>
        public IOutputProvider OutputProvider { get; private set; }

        /// <summary>
        /// Gets the factory that will create the game state objects.
        /// </summary>
        public IStateFactory StateFactory { get; private set; }

        /// <summary>
        /// Defines the current game state.
        /// </summary>
        public IGameState State { get; set; }

        /// <summary>
        /// Represents if the games is over.
        /// </summary>
        public bool IsOver { get; set; }

        /// <summary>
        /// Retrieves the user input.
        /// </summary>
        protected override void GetInput()
        {
            this.State.GetInput();
        }

        /// <summary>
        /// Renders the game output data.
        /// </summary>
        protected override void Render()
        {
            this.State.Render();
        }

        /// <summary>
        /// Handles the commands.
        /// </summary>
        protected override void Update()
        {
            this.State.Update();
        }
    }
}