using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabyrinthRunner.Common
{
    public class Labyrinth : IRenderable
    {
        private int rows;
        private int cols;
        public static char WallSkin = '\u2588';

        private Structure[,] labyrinth;

        public Labyrinth()
        {
            this.Rows = 20;
            this.Cols = 20;
            labyrinth = new Structure[this.Rows, this.Cols];
        }

        public Structure[,] LabyrinthArr
        {
            get { return labyrinth; }
            set { labyrinth = value; }
        }

        public char this[int row, int col]
        {
            get
            {
                return this.LabyrinthArr[row, col].Skin;
            }
        }

        public void Render()
        {
            StringBuilder frameBuffer = new StringBuilder();
            int counter = 0;

            foreach (var structure in LabyrinthArr)
            {
                frameBuffer.Append(structure.Skin);
                counter++;
                if (counter % 20 == 0)
                {
                    frameBuffer.Append(Environment.NewLine);
                }
            }

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(frameBuffer.ToString());
        }

        public void LoadLevel(int level)
        {
            // needs to be implemented
            string fileName = String.Format("Levels{0}.txt",level);
            string path = String.Format(@"..\..\..\{0}",fileName);
            try
            {
                using (StreamReader source = new StreamReader(path))
                {
                    string currentLine = "";
                    currentLine = source.ReadLine();
                    int currentLineNumber = 0;
                    while (currentLine != null)
                    {
                        for (int i = 0; i < this.LabyrinthArr.GetLength(1); i++)
                        {
                            switch (currentLine[i])
                            {
                                case '█':
                                    this.LabyrinthArr[currentLineNumber, i] = new BrickWall(new Position { Row = i, Col = currentLineNumber });
                                    break;
                                case ' ':
                                    this.LabyrinthArr[currentLineNumber, i] = new Air(new Position { Row = i, Col = currentLineNumber });
                                    break;
                                default:
                                    break;
                            }
                        }

                        currentLineNumber++;
                        currentLine = source.ReadLine();
                    }
                }
            }

            catch (IOException ioe)
            {
                throw new ParseFileException("Error reading from file.", fileName, null, ioe);
            }
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }

            private set
            {
                this.rows = value;
            }

        }

        public int Cols
        {
            get
            {
                return this.cols;
            }

            private set
            {
                this.cols = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.LabyrinthArr.GetLength(0); i++)
            {
                for (int j = 0; j < this.LabyrinthArr.GetLength(1); j++)
                {
                    sb.Append(this.LabyrinthArr[i, j].Skin);
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
