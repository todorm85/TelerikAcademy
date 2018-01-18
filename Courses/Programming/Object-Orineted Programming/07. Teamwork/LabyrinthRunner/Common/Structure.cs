using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabyrinthRunner.Common
{
    public abstract class Structure : WorldObject, IRenderable
    {
        public Structure(Position position, char skin)
            : base(WorldObjectType.Structure, position, skin)
        {

        }

        public bool IsPenetrable 
        { 
            get; 
            protected set;
        }

        public void Render()
        {
            Console.SetCursorPosition(this.Position.Col, this.Position.Row);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(this.Skin);
        }
    }
}
