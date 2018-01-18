
namespace LabyrinthRunner.AI
{
    using System;
    using LabyrinthRunner.Common;
    using LabyrinthRunner.UI;

    public class CpuPlayer : Player, IMovable, IRenderable
    {
        private const int possibleDirectionsSize = 400;
        private const int maxSteps = 7; 

        private static Direction[] possibleDirections;

        private Random rand = new Random();
        private Direction currentDirection;
        private int steps;

        public CpuPlayer(Position position)
            : base(WorldObjectType.CpuPlayer, position, (char)9787)
        {
            possibleDirections = new Direction[possibleDirectionsSize];

            for (int i = 0; i < possibleDirections.Length; i++ )
            {
                possibleDirections[i] = (Direction) this.rand.Next(0, 4);
            }

            this.steps = 0;
            this.currentDirection = possibleDirections[this.rand.Next(0, possibleDirections.Length)];
        }

        public override void OnMove()
        {
            if(this.steps > maxSteps)
            {
                this.steps = 0;
                this.currentDirection = possibleDirections[this.rand.Next(0, possibleDirections.Length)];
            }
            if(Move(currentDirection) == false)
            {
                this.currentDirection = possibleDirections[this.rand.Next(0, possibleDirections.Length)];
            }
            else
            {
                this.steps += 1;
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(this.Position.Col, this.Position.Row);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(this.Skin);
        }
    }
}
