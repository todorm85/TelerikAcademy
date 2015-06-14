using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthRunner.UI
{
    public struct ConsoleCoords
    {
        private static ConsoleCoords centerScreen = new ConsoleCoords(Settings.ConsoleHeight / 2, Settings.ConsoleWidth / 2);
        
        private int row;
        private int col;

        public ConsoleCoords(int row, int col)
            : this()
        {
            this.Row = row;
            this.Col = col;
        }

        public static ConsoleCoords CenterScreen
        {
            get { return ConsoleCoords.centerScreen; }
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
