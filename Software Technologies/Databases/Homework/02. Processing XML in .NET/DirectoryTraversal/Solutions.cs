using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DirectoryTraversal
{
    public static class Solutions
    {
        public static void Task9_traverse_dir()
        {
            string outputFileName = "../../output/dirs.xml";
            Encoding encoding = Encoding.GetEncoding("windows-1251");
            DirectoryInfo rootDir = new DirectoryInfo("../../");

            using (XmlTextWriter writer = new XmlTextWriter(outputFileName, encoding))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", rootDir.Name);

                TraverseDir(rootDir, writer);

                writer.WriteEndDocument();
            }

            Console.WriteLine("Document {0} created.", outputFileName);
        }

        public static void TraverseDir(System.IO.DirectoryInfo root, XmlWriter writer)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", fi.Name);
                    writer.WriteEndElement();
                }
            }

            // Now find all the subdirectories under this directory.
            subDirs = root.GetDirectories();
            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", dirInfo.Name);
                // Resursive call for each subdirectory.
                TraverseDir(dirInfo, writer);
                writer.WriteEndElement();
            }
        }

        public static void Task10_traverse_dir_LINQ()
        {
            var outputFileName = "../../output/dirsLINQ.xml";
            DirectoryInfo rootDir = new DirectoryInfo("../../");
            XElement writer = new XElement("dir",
                new XAttribute("name", rootDir.Name));

            TraverseDirLINQ(rootDir, writer);

            writer.Save(outputFileName);
            Console.WriteLine("Document {0} created.", outputFileName);
        }

        public static void TraverseDirLINQ(System.IO.DirectoryInfo root, XElement writer)
        {
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder
            try
            {
                files = root.GetFiles("*.*");
            }
            // This is thrown if even one of the files requires permissions greater
            // than the application provides.
            catch (UnauthorizedAccessException e)
            {
                // This code just writes out the message and continues to recurse.
                // You may decide to do something different here. For example, you
                // can try to elevate your privileges and access the file again.
                Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                foreach (System.IO.FileInfo fi in files)
                {
                    // In this example, we only access the existing FileInfo object. If we
                    // want to open, delete or modify the file, then
                    // a try-catch block is required here to handle the case
                    // where the file has been deleted since the call to TraverseTree().
                    writer.Add(new XElement("file",
                        new XAttribute("name", fi.Name)));
                }
            }

            // Now find all the subdirectories under this directory.
            subDirs = root.GetDirectories();
            foreach (System.IO.DirectoryInfo dirInfo in subDirs)
            {
                var dir = new XElement("dir",
                        new XAttribute("name", dirInfo.Name));

                // Resursive call for each subdirectory.
                TraverseDirLINQ(dirInfo, dir);

                writer.Add(dir);
            }
        }
    }
}
