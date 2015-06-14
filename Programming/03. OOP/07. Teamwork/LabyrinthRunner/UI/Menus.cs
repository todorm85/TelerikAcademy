namespace LabyrinthRunner.UI
{
    using System;

    using LabyrinthRunner.Common;
    public static class Menus
    {
        private static readonly IScoreboard scoreBoard = new Scoreboard();
        
        public static void WelcomeScreen()
        {
            Console.CursorVisible = false;

            bool exitedMenu = false;
            int currentSelectionIndex = 0;
            do
            {
                while (!Console.KeyAvailable && exitedMenu == false)
                {
                    PrintMenuSelection(currentSelectionIndex);
                    ConsoleKeyInfo currentModifier = Console.ReadKey();
                    switch (currentModifier.Key)
                    {
                        case ConsoleKey.DownArrow:
                            currentSelectionIndex += 1;
                            if (currentSelectionIndex > Settings.menuEntries.Length - 1)
                            {
                                currentSelectionIndex = 0;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            currentSelectionIndex -= 1;
                            if (currentSelectionIndex < 0)
                            {
                                currentSelectionIndex = Settings.menuEntries.Length - 1;
                            }
                            break;
                        case ConsoleKey.Enter:
                            switch (currentSelectionIndex)
                            {
                                case 0:
                                    Console.Clear();
                                    string[] gameEndParams = GameEngine.GameLoop();
                                    string name = gameEndParams[0];
                                    int points = int.Parse(gameEndParams[1]);
                                    scoreBoard.Add(name, points);
                                    break;
                                case 1:
                                    // TODO: Fix the bug of the scoreboard disappearing instantly after being shown
                                    Console.WriteLine(scoreBoard.Show());
                                    break;
                                case 2:
                                    Environment.Exit(0);
                                    break;
                            }
                            exitedMenu = true;
                            break;
                    }
                }

                Console.Clear();
                exitedMenu = false;
            } while (true);
        }

        private static void PrintMenuSelection(int currentSelectionIndex)
        {
            Console.Clear();
            int initialStart = Console.WindowHeight / 2 - (int)Math.Ceiling((double)Settings.menuEntries.Length / 2);
            int menuSpacing = 0;
            for (int i = 0; i < Settings.menuEntries.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - (int)Math.Ceiling((double)Settings.menuEntries[i].Length / 2), initialStart + menuSpacing);
                menuSpacing += 1;
                if (i == currentSelectionIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(Settings.menuEntries[i]);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }

                Console.WriteLine(Settings.menuEntries[i]);
            }
        }
    }
}
