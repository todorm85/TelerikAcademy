using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightExample
{
    class Program
    {
        /// <summary>
        /// We need to create 1000 rock objects each with different size to be used in a game. 
        /// In order to save memory only an array of sizes is created and a couple of flyweight rock object instances are used with each of the values in the array to simulate all 1000 rocks.
        /// The intrinsic (shared) object state is the actual Rock instance that is created in the rock factory. In this case we have two shared states - JaggedRock and SmoothRock.
        /// The extrinsic (context) object state is the size parameter that is passed to the Display method. In this case we have 1000 specific contextual uses of each shared state.
        /// This gives a total of 2000 different objects with actual reserved memory for only two rock objects (JaggedRock and SmoothRock) and one array of sizes.
        /// To sum up, this pattern enables the creation of multitude of objects with little memory hit, regardless of their size and complexity.
        /// </summary>
        static void Main()
        {
            var rockFactory = new RockFactory();
            var rand = new Random();
            var rockSizes = new int[1000];

            for (int i = 0; i < rockSizes.Length; i++)
            {
                rockSizes[i] = rand.Next(50);
            }

            foreach (var rockSize in rockSizes)
            {
                var jaggedRock = rockFactory.GetRock(RockType.Jagged);
                jaggedRock.Display(rockSize);
                var smoothRock = rockFactory.GetRock(RockType.Smooth);
                smoothRock.Display(rockSize);
            }

            Console.WriteLine("Total objects created: " + rockFactory.TotalObjectsCreated);
        }
    }
}
