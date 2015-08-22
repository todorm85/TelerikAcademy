using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBelot.Common
{
    public class HumanPlayer : IPlayer
    {

        public string Name
        {
            get { return "Human Player"; }
        }

        public int Points
        {
            get { throw new NotImplementedException(); }
        }

        public void PlayCard()
        {
            Console.WriteLine("Human player played a card");
        }
    }
}
