using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthRunner.Common
{
    public struct Position
    {
        //private static GamePosition centerScreen = new GamePosition(Settings.ConsoleHeight / 2, Settings.ConsoleWidth / 2);
        
        private int row;
        private int col;

        public Position(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public int Col
        {
            get { return col; }
            set { col = value; }
        }
        
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
    }
}
