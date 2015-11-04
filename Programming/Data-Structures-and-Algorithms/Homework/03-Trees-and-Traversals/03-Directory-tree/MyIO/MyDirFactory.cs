namespace MyIO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using MyIO;

    public static class MyDirFactory
    {
        /// <summary>
        /// Creates a MyDir object with child objects, from a filesystem directory structure.
        /// </summary>
        /// <param name="rootPath">The path to the filesystem root directory.</param>
        /// <returns>MyDir</returns>
        public static MyDir CreateTree(string rootPath)
        {
            if (!Directory.Exists(rootPath))
            {
                throw new ArgumentException("Invalid path");
            }

            var tree = new MyDir(Path.GetFileName(rootPath));

            GenerateTree(tree, rootPath);

            return tree;
        }

        private static void GenerateTree(MyDir currentDir, string currentPath)
        {
            GetFiles(currentDir, currentPath);

            GetSubDirs(currentDir, currentPath);
        }

        private static void GetSubDirs(MyDir currentDir, string currentPath)
        {
            string[] dirPaths = null;
            try
            {
                dirPaths = Directory.GetDirectories(currentPath);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            var subDirs = new List<MyDir>();
            foreach (var dirPath in dirPaths)
            {
                var currentSubDir = new MyDir(Path.GetFileName(dirPath));
                GenerateTree(currentSubDir, dirPath);
                subDirs.Add(currentSubDir);
            }

            currentDir.Dirs = subDirs.ToArray();
        }

        private static void GetFiles(MyDir dir, string path)
        {
            string[] filePaths = null;
            try
            {
                filePaths = Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            var files = new List<MyFile>();
            foreach (var filePath in filePaths)
            {
                var currentFile = new FileInfo(filePath);
                var fileName = currentFile.Name;
                var fileSize = currentFile.Length;

                var myFile = new MyFile(fileName, fileSize);
                files.Add(myFile);
            }

            dir.Files = files.ToArray();
        }
    }
}