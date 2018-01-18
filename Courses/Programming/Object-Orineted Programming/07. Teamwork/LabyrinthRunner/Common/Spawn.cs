
namespace LabyrinthRunner.Common
{
    using System;
    using System.Collections.Generic;

    public static class Spawn
    {
        private static Random rand = new Random();

        //Try to find free space where to spawn the object
        //only 3 tries, so there is no chance to get stuck into long loop
        public static bool FindRandomSpawnPosition(out Position spawnPos)
        {
            bool bFound = false;

            spawnPos = new Position(rand.Next(GameEngine.CurrentLabyrinth.Rows), rand.Next(GameEngine.CurrentLabyrinth.Cols));

            for (int tries = 0; tries < 3; tries++)
            {
                //TODO: Maybe can move the below snippets into CheckCollision class

                //Check if there is collision with the labyrinth walls
                if (!GameEngine.CurrentLabyrinth.LabyrinthArr[spawnPos.Row, spawnPos.Col].IsPenetrable)
                {
                    continue;
                }

                //Check if there is collision with some of the rest of objects in the labyrinth
                bool collision = false;
                foreach(var obj in GameEngine.GameObjects)
                {
                    if (obj.Position.Row == spawnPos.Row && obj.Position.Col == spawnPos.Col)
                    {
                        collision = true;
                        break;
                    }
                }

                if(collision == true)
                {
                    continue;
                }


                bFound = true;
                break;
            }

            return bFound;
        }
    }
}
