namespace TicTacToe.GameLogic
{
    public class GameResultValidator : IGameResultValidator
    {
        private string board;

        // O-X
        // O-X
        // --X
        public GameResult GetResult(string board)
        {
            this.board = board;

            var winChar = ' ';

            for (int i = 0; i < 3; i++)
            {
                var horCount = 0;
                var vertCount = 0;
                for (int j = 0; j < 2; j++)
                {
                    if (GetCell(i,j) == GetCell(i,j+1))
                    {
                        horCount++;
                    }

                    if (GetCell(j, i) == GetCell(j + 1, i))
                    {
                        vertCount++;
                    }
                }

                if (horCount == 2)
                {
                    winChar = GetCell(i, 2);
                }

                if (vertCount == 2)
                {
                    winChar = GetCell(2, i);
                }
            }

            if ((GetCell(0,0) == GetCell(1,1) && GetCell(0, 0) == GetCell(2, 2)
                || (GetCell(0, 2) == GetCell(1, 1) && GetCell(0, 2) == GetCell(2, 0))))
            {
                winChar = GetCell(1, 1);    
            }

            if (winChar == 'X')
            {
                return GameResult.WonByX;
            }

            if (winChar == 'O')
            {
                return GameResult.WonByO;
            }

            if (!board.Contains("-"))
            {
                return GameResult.Draw;
            }

            return GameResult.NotFinished;
        }

        private char GetCell(int row, int col)
        {
            return this.board[row * 3 + col];
        } 
    }
}
