using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabyrinthRunner.UI;
using LabyrinthRunner.AI;
using System.Threading;


namespace LabyrinthRunner.Common
{
    public static class GameEngine
    {
        private const int maxBonuses = 5;
        private const int maxCreatures = 10;
        private const int initPlayerLifes = 3;

        private static Position playerInitPos = new Position() { Row = 10, Col = 10 };

        private static HumanPlayer hero;
        private static int spawnedBonuses;
        private static int spawnedCreatures;

        public static string[] GameLoop()
        {
            spawnedBonuses = 0;
            spawnedCreatures = 0;

            IsGameOver = false;
            GameObjects = new List<WorldObject>();
            ObjectsToRemove = new List<WorldObject>();
            CurrentLabyrinth = new Labyrinth();

            CurrentLabyrinth.LoadLevel(1);

            hero = GameFactory.CreateHumanPlayerLocal(playerInitPos, initPlayerLifes);
            GameObjects.Add(hero);

            while (true)
            {
                GamePhysics();

                GameRenderer();

                if (IsGameOver) break;
            }

            // TODO: Align the game over text
            Console.WriteLine("Score: {0}", hero.GoldAmount);
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            return new string[] { name, hero.GoldAmount.ToString() };
        }

        public static void GamePhysics()
        {
            if (spawnedBonuses < maxBonuses)
            {
                //First try to find free random position where to spawn the bonus
                Position spawnPos;
                if (Spawn.FindRandomSpawnPosition(out spawnPos) == true)
                {
                    //Free position was found
                    //Create bonus box with random bonus effects inside and add it to list of labyrinth objects
                    WorldObject bonusBox = GameFactory.CreateBonusBox(spawnPos);

                    GameObjects.Add(bonusBox);

                    spawnedBonuses++;
                }
            }

            if (spawnedCreatures < maxCreatures)
            {
                Position spawnPos;
                if (Spawn.FindRandomSpawnPosition(out spawnPos) == true)
                {
                    WorldObject creature = GameFactory.CreateCpuPlayer(spawnPos);

                    GameObjects.Add(creature);

                    spawnedCreatures++;
                }
            }

            foreach (var obj in GameObjects)
            {
                IMovable movable = obj as IMovable;

                if (movable != null)
                {
                    movable.OnMove();
                }
            }

            RemoveObjects();
        }

        public static void GameRenderer()
        {
            Console.Clear();

            CurrentLabyrinth.Render();

            foreach (var obj in GameObjects)
            {
                IRenderable renderable = obj as IRenderable;

                if (renderable != null)
                {
                    renderable.Render();
                }
            }

            GameSpeed();
        }

        public static void RemoveObjects()
        {
            foreach(var obj in ObjectsToRemove)
            {
                RemoveObject(obj);

                if(obj.Type == WorldObjectType.BonusBox)
                {
                    spawnedBonuses -= 1;
                }
            }

            ObjectsToRemove.Clear();
        }

        public static void PlayerHitByEnemy()
        {
            hero.Lifes -= 1;

            if(hero.Lifes == 0)
            {
                IsGameOver = true;
            }

            hero.Position = playerInitPos;
        }

        private static void GameSpeed()
        {
            Thread.Sleep(150);
        }

        public static void RemoveObject(WorldObject removingObj)
        {
            GameEngine.GameObjects.RemoveAll(x => x.Type == removingObj.Type &&
                                             x.Position.Row == removingObj.Position.Row &&
                                             x.Position.Col == removingObj.Position.Col);
        }

        #region Properties

        public static List<WorldObject> GameObjects
        {
            get;
            set;
        }

        public static List<WorldObject> ObjectsToRemove
        {
            get;
            set;
        }

        public static Labyrinth CurrentLabyrinth
        {
            get;
            set;
        }

        public static bool IsGameOver
        {
            get;
            set;
        }

        #endregion
    }
}
