using LabyrinthRunner.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LabyrinthRunner.Common
{
    public class Gold : Bonus
    {
        private const char DefaultSkin = '$';

        public Gold(int amount)
            : base()
        {
            this.Amount = amount;
        }

        private int Amount { get; set; }

        public override void Effect(object sender, BonusEventArgs e)
        {
            var player = e.Target as HumanPlayer;
            if (player != null)
            {
                player.GoldAmount += this.Amount;
            }
        }
    }
}
