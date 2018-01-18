namespace BullsAndCowsGame
{
    internal class Game
    {
        public Game(IInputProvider inputProvider, IOutputProvider outputProvider, IStateFactory stateFactory)
        {
            this.InputProvider = inputProvider;
            this.OutputProvider = outputProvider;
            this.StateFactory = stateFactory;

            this.State = stateFactory.GetStartMenuState(this);
        }

        public IInputProvider InputProvider { get; private set; }

        public bool IsOver { get; set; }

        public IOutputProvider OutputProvider { get; private set; }

        public IGameState State { get; set; }

        public IStateFactory StateFactory { get; private set; }

        public void GetInput()
        {
            this.State.GetInput();
        }

        public void Render()
        {
            this.State.Render();
        }

        public void Update()
        {
            this.State.Update();
        }
    }
}