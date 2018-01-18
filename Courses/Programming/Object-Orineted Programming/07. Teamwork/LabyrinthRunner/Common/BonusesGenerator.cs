
namespace LabyrinthRunner.Common
{
    using System;
    using System.Collections.Generic;

    //Generates list of wanted bonuses with randomized effects
    public static class BonusListGenerator
    {
        private const int maxGold = 1000;

        private static Random rand = new Random();

        public static List<Bonus> GetBonusList()
        {
            List<Bonus> bonusList = new List<Bonus>();
            bonusList.Add(new Gold(rand.Next(maxGold)));

            /* Add new bonuses you want to this List, as shown in the above example */

            return bonusList;
        }
    }
}
