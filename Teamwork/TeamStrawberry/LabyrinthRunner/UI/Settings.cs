using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthRunner.UI
{
    public static class Settings
    {
        public static string[] menuEntries = { "NEW GAME", "SCOREBOARD", "EXIT" };

        private static int consoleHeight;
        private static int consoleWidth;

        static Settings()
        {
            ConsoleHeight = 21;
            ConsoleWidth = 21;
        }

        public static int ConsoleWidth
        {
            get { return Settings.consoleWidth; }
            set { Settings.consoleWidth = value; }
        }

        public static int ConsoleHeight
        {
            get { return consoleHeight; }
            set { consoleHeight = value; }
        }

    }
}
