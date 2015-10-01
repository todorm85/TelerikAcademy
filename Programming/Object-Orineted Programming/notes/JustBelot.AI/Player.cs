using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustBelot.Common;

namespace JustBelot.AI
{
    public class Player : IPlayer
    {
        public string Name
        {
            get { return "Bot"; }
        }

        public int Points
        {
            get { throw new NotImplementedException(); }
        }

        public void PlayCard()
        {
            Console.WriteLine("Bot played card");
        }
    }
}
