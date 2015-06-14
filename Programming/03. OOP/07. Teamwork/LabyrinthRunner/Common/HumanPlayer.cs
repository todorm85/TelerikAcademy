using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabyrinthRunner.UI;

namespace LabyrinthRunner.Common
{
    public class HumanPlayer : Player, IMovable, IRenderable
    {

        public HumanPlayer(Position position, int lifePoints)
            : base(WorldObjectType.HumanPlayer, position, (char)9787)
        {
            this.Lifes = lifePoints;
        }

        public int GoldAmount
        {
            get;
            set;
        }

        public int Lifes
        {
            get;
            set;
        }

        public override void OnMove()
        {
            while (Console.KeyAvailable)
            {
                // we assign the pressed key value to a variable pressedKey
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                // next we start checking the value of the pressed key and take action if neccessary
                if (pressedKey.Key == ConsoleKey.LeftArrow) // if left arrow is pressed then
                {
                    this.Move(Direction.Left);
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    this.Move(Direction.Right);

                }
                else if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    this.Move(Direction.Up);

                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    this.Move(Direction.Down);
                }
                else if (pressedKey.Key == ConsoleKey.Escape)   // In case user wants to go back to welcome screen
                {
                    Menus.WelcomeScreen();
                }
            }
        }

        public void Render()
        {
            Console.SetCursorPosition(this.Position.Col, this.Position.Row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(this.Skin);
        }
    }
}
