namespace DirectoyTreeBuilder
{
    using System;
    using MyIO;

    internal class Startup
    {
        private const string WinDir = @"C:\Windows";

        private static void Main()
        {
            Console.WriteLine($"Building directory tree from root {WinDir} in memory. Depending on the directory`s size and structure this may take a while.");
            MyDir directoriesTree = MyDirFactory.CreateTree(WinDir);

            Console.WriteLine("Finished building.\n");

            System.Console.WriteLine($"Calculating {WinDir} size. Keep in mind that this console app does not have Permissions to access all the directories in Windows directory, so the actual calculated size will differ from the size that windows explorer will calculate. The difference should be small in percentage.");
            var totalSize = directoriesTree.CalculateTotalSize();
            Console.WriteLine($"Total size: {totalSize} bytes");
        }
    }
}