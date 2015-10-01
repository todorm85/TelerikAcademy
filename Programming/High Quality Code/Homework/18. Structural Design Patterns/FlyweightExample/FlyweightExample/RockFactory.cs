using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightExample
{
    class RockFactory
    {
        private Dictionary<RockType, Rock> flywieghts = new Dictionary<RockType, Rock>();
        public int TotalObjectsCreated { get; private set; }

        public RockFactory()
        {
            this.TotalObjectsCreated = 0;
        }
        
        private void AddFlyweight(RockType rockType)
        {
            Rock rock = null;

            switch (rockType)
            {
                case RockType.Jagged:
                    rock = new JaggedRock();
                    break;
                case RockType.Smooth:
                    rock = new SmoothRock();
                    break;
            }

            this.flywieghts.Add(rockType, rock);
            this.TotalObjectsCreated++;
        }

        public Rock GetRock(RockType rockType)
        {
            if (!flywieghts.ContainsKey(rockType))
            {
                AddFlyweight(rockType);
            }

            return flywieghts[rockType];
        }
    }
}
