namespace _02_Directory_traversal
{
    using System;
    using System.IO;
    using Extensions;

    public static class DirectoryTraversal
    {
        private const string WinPath = @"C:\Windows";

        public static void Main()
        {
            FindFiles(WinPath, "*.exe");
        }

        private static void FindFiles(string path, string searchMask)
        {
            string[] files = null;
            try
            {
                files = Directory.GetFiles(path, searchMask);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            if (files.Length > 0)
            {
                Console.WriteLine(path);
                var fileNames = files.ForEach(Path.GetFileName);
                fileNames.ForEach(Console.WriteLine);
            }

            var subDirPaths = Directory.GetDirectories(path);
            if (subDirPaths.Length > 0)
            {
                subDirPaths.ForEach(FindFiles, searchMask);
            }
        }
    }
}