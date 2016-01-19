using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04_TicTacToe
{
    public partial class Index : System.Web.UI.Page
    {
        protected void GameField_Command(object sender, CommandEventArgs e)
        {
            if (IsGameOver())
            {
                return;
            }

            var btn = sender as Button;

            if (btn.Text != " ")
            {
                container.Controls.Add(new LiteralControl("Click on empty square!"));
                return;
            }

            btn.Text = "X";

            if (!IsGameOver())
            {
                AiMove();
                IsGameOver();
            }
        }

        private bool IsGameOver()
        {
            var fields = new List<String>();
            foreach (var control in container.Controls)
            {
                if (control is Button)
                {
                    var gameField = (Button)control;
                    fields.Add(gameField.Text);
                }
            }

            for (int i = 0; i < 9; i += 3)
            {
                if (fields[i] == " ")
                {
                    continue;
                }

                if (fields[i] == fields[i + 1] && fields[i + 1] == fields[i + 2])
                {
                    var winner = fields[i];
                    container.Controls.Add(new LiteralControl($"{winner} won!"));
                    return true;
                }

            }

            for (int i = 0; i < 3; i++)
            {
                if (fields[i] == " ")
                {
                    continue;
                }

                if (fields[i] == fields[i + 3] && fields[i + 3] == fields[i + 6])
                {
                    var winner = fields[i];
                    container.Controls.Add(new LiteralControl($"{winner} won!"));
                    return true;
                }
            }

            if ((fields[0] == fields[4] && fields[4] == fields[8]) ||
                (fields[2] == fields[4] && fields[4] == fields[6]))
            {
                var winner = fields[4];
                if (winner != " ")
                {
                    container.Controls.Add(new LiteralControl($"{winner} won!"));
                    return true;
                }
            }

            return false;
        }

        private void AiMove()
        {
            foreach (var control in container.Controls)
            {
                if (control is Button)
                {
                    var gameField = (Button)control;
                    if (gameField.Text == " ")
                    {
                        gameField.Text = "O";
                        break;
                    }
                }
            }
        }

        protected void reset_ServerClick(object sender, EventArgs e)
        {
            foreach (var control in container.Controls)
            {
                if (control is Button)
                {
                    var gameField = (Button)control;
                    gameField.Text = " ";
                }
            }
        }
    }
}