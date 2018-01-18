using System;
using System.Collections.Generic;
using System.IO;
using MyIO;

namespace DirectoryTree
{
    public class DirectoryTree
    {
        private DirectoryTree()
        {
        }

        public MyDir RootFolder { get; set; }

        public static DirectoryTree CreateTree(string rootPath)
        {
            if (Uri.IsWellFormedUriString(rootPath, UriKind.Absolute))
            {
                throw new ArgumentException("Invalid root dir path");
            }

            if (Directory.Exists(rootPath))
            {
                throw new ArgumentException("Invalid path");
            }

            var tree = new DirectoryTree();
            tree.RootFolder = new MyDir(Path.GetFileName(rootPath));

            GenerateTree(tree.RootFolder, rootPath);

            return tree;
        }

        private static void GenerateTree(MyDir currentDir, string currentPath)
        {
            var filePaths = Directory.GetFiles(currentPath);
            var files = new List<MyFile>();
            foreach (var filePath in filePaths)
            {
                var currentFile = new FileInfo(filePath);
                var fileName = currentFile.Name;
                var fileSize = currentFile.Length;

                var myFile = new MyFile(fileName, fileSize);
                files.Add(myFile);
            }
            currentDir.Files = files.ToArray();

            var dirPaths = Directory.GetDirectories(currentPath);

            var subDirs = new List<MyDir>();
            foreach (var dirPath in dirPaths)
            {
                var currentSubDir = new MyDir(Path.GetDirectoryName(dirPath));
                GenerateTree(currentSubDir, dirPath);
                subDirs.Add(currentSubDir);
            }

            currentDir.Dirs = subDirs.ToArray();
        }
    }
}