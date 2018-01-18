using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabyrinthRunner.AI;

namespace LabyrinthRunner.Common
{
    public class GameFactory
    {
        public static CpuPlayer CreateCpuPlayer(Position spawnPosition)
        {
            return new CpuPlayer(spawnPosition);
        }

        public static BonusBox CreateBonusBox(Position spawnPosition)
        {
            return new BonusBox(spawnPosition, BonusListGenerator.GetBonusList());
        }

        public static HumanPlayer CreateHumanPlayerLocal(Position playerInitPos, int initPlayerLifes)
        {
            return new HumanPlayer(playerInitPos, initPlayerLifes);
        }
    }
}
