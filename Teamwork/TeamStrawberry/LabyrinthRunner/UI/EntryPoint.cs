namespace LabyrinthRunner.UI
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    using LabyrinthRunner.Common;

    public class EntryPoint
    {
        public static void Main()
        {
            // Initialize console
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            ConsoleModifiers.Resize(Settings.ConsoleHeight, Settings.ConsoleWidth);
            Console.OutputEncoding = Encoding.Unicode;

            Menus.WelcomeScreen();
        }
    }
}
