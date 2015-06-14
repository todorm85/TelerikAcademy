namespace LabyrinthRunner.UI
{
    using System;

    public static class ConsoleModifiers
    {
        public static void Resize(int height, int width)
        {
            Console.WindowWidth = width;
            Console.WindowHeight = height;
            Console.BufferWidth = Console.WindowWidth;
            Console.BufferHeight = Console.WindowHeight;
        }

        public static void PrintText(
            string txt,
            ConsoleCoords coordinates,
            int colOffset = 0,
            int rowOffset = 0,
            ConsoleColor foregroundColor = ConsoleColor.White,
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.SetCursorPosition(coordinates.Col + colOffset, coordinates.Row + rowOffset);
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(txt);
        }
    }
    

}
