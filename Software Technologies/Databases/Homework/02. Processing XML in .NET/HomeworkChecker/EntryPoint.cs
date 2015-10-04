using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlbumsCatalog;
using DirectoryTraversal;
using People;

namespace HomeworkChecker
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1 and 2");
            AlbumsCatalog.Solutions.Task1_2_extract_artists();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 3");
            AlbumsCatalog.Solutions.Task3_extract_artists_XPath();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 4");
            AlbumsCatalog.Solutions.Task4_delete_expensive_albums();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 5");
            AlbumsCatalog.Solutions.Task5_extract_song_titles();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 6");
            AlbumsCatalog.Solutions.Task6_extract_song_titles_LINQ();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 7");
            People.Solutions.Task7_txt_to_xml_people();
            Console.WriteLine(new String('-', 50));
            
            Console.WriteLine(new String('-', 50));
            Console.WriteLine("Task 8");
            AlbumsCatalog.Solutions.Task8_catalog_to_album_xml();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 9");
            DirectoryTraversal.Solutions.Task9_traverse_dir();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 10");
            DirectoryTraversal.Solutions.Task10_traverse_dir_LINQ();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task11");
            AlbumsCatalog.Solutions.Task11_extract_older_published_albums();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 12 and 13");
            AlbumsCatalog.Solutions.Task12_13_extract_older_published_albums_LINQ();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 14");
            AlbumsCatalog.Solutions.Task14_xsl_to_xhtml();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Task 16");
            AlbumsCatalog.Solutions.Task16_schema_validation_with_cSharp();
            Console.WriteLine(new String('-', 50));

            Console.WriteLine("Done! All output results can be found by browsing with your file explorer to './HomewrokChecker/output'");
        }
    }
}
